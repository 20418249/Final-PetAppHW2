using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetAppHW2.Data;
using PetAppHW2.Models;
using System;
using System.Diagnostics;
using System.IO;
using static System.Net.WebRequestMethods;

namespace PetAppHW2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db; //declare a instance of the database


        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db; //set the database
        }


        //Use async for the data to load from the database first
        public async Task<IActionResult> Index()
        { 
            //Create a pets list
            List<Pet> pets = await _db.Pets.ToListAsync();
            List<User> user = await _db.users.ToListAsync();
            //Counter for the number of pets that got addopted.
            //------------------------------------------------
            int i = 0;
            foreach (var item in pets)
            {
                if (item.userId !=  null)
                {
                    i++;
                }    
                ViewBag.noAdopted = i;
            }
            //------------------------------------------------


            return View(pets);
        }


        public async Task<IActionResult> ViewPets(string petType = "", string petBreed = "", string Location = "", string action = "")
        {
            List<Pet> pets = await _db.Pets.ToListAsync();
            List<PetType> types = await _db.petTypes.ToListAsync();
            List<PetBreed> breeds = await _db.petBreeds.ToListAsync();
            List<Location> locations = await _db.locations.ToListAsync();
            List<Gender> genders = await _db.genders.ToListAsync();

            return View(pets);
        }

        public async Task<IActionResult> PostPetView(Pet pet, PetBreed breed, Location location, Gender gender, User user)
        {
            List<Pet> pets = await _db.Pets.ToListAsync();
            List<PetType> types = await _db.petTypes.ToListAsync();
            List<PetBreed> breeds = await _db.petBreeds.ToListAsync();
            List<Location> locations = await _db.locations.ToListAsync();
            List<Gender> genders = await _db.genders.ToListAsync();

            _db.Pets.Add(pet);
            _db.petBreeds.Add(breed);
            _db.locations.Add(location);
            _db.genders.Add(gender);
            _db.users.Add(user);

            return View(pets);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}