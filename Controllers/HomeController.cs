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
            List<Pet> pets = new List<Pet>();
            if (action == "2" || action == "")
            {
                pets = await _db.Pets.ToListAsync();
            }
            else
            {
                pets = await _db.Pets.Where(x => x.PetType.description == petType && x.PetBreed.description == petBreed && x.Location.name == Location).ToListAsync();
            }
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