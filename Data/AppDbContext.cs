using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PetAppHW2.Models;



namespace PetAppHW2.Data
{
    public class AppDbContext : DbContext
    {

        //Install Entity Framework package

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Entities for migration
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Gender> genders { get; set; }
        public DbSet<PetType> petTypes { get; set; }
        public DbSet<PetBreed> petBreeds { get; set; }
        public DbSet<Donation> donations { get; set; }
        public DbSet<Campaign> campaigns { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Location> locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //seed data
            //seed Genders
            var genders = new Gender[]
            {
                new Gender { genderId = 1, description = "Male" },
                new Gender { genderId = 2, description = "Female" }
            };

            modelBuilder.Entity<Gender>().HasData(genders);

            //seed User
            var users = new User[]
            {
                new User { userId = 1, name = "Christiaan", surname = "Holm", address = "1282 Boundary Ln, Hatfield, Pretoria", phone = "081 481 0285", email = "christiaanholm20@gmail.com" },
                new User { userId = 2, name = "Sophia", surname = "van der Merwe", address = "45 Acacia Street, Johannesburg, Gauteng", phone = "082 555 9876", email = "sophia.vandermerwe@example.com" },
                new User { userId = 3, name = "Alex", surname = "Smith", address = "22 Jacaranda Avenue, Durban, KwaZulu-Natal", phone = "071 234 5678", email = "alex.smith@example.com" },
                new User { userId = 4, name = "James", surname = "Johnson", address = "78 Protea Road, Cape Town, Western Cape", phone = "084 876 5432", email = "james.johnson@example.com" },
                new User { userId = 5, name = "Emily", surname = "Brown", address = "12 Marula Lane, Port Elizabeth, Eastern Cape", phone = "083 765 4321", email = "emily.brown@example.com" },
                new User { userId = 6, name = "Liam", surname = "Khumalo", address = "9 Baobab Street, Bloemfontein, Free State", phone = "079 555 8888", email = "liam.khumalo@example.com" },
                new User { userId = 7, name = "Noah", surname = "Ndlovu", address = "33 Maroela Road, Polokwane, Limpopo", phone = "072 444 9999", email = "noah.ndlovu@example.com" },
                new User { userId = 8, name = "Ava", surname = "Williams", address = "67 Eucalyptus Crescent, Nelspruit, Mpumalanga", phone = "076 222 3333", email = "ava.williams@example.com" },
                new User { userId = 9, name = "William", surname = "Molefe", address = "5 Protea Avenue, Kimberley, Northern Cape", phone = "073 111 2222", email = "william.molefe@example.com" },
                new User { userId = 10, name = "Olivia", surname = "Clark", address = "18 Baobab Street, Rustenburg, North West", phone = "081 333 4444", email = "olivia.clark@example.com" }
            };
            modelBuilder.Entity<User>().HasData(users);


            //seed Campaign
            var campaigns = new Campaign[]
            {
                new Campaign { campaignId = 1, name = "Woof Food Drive", campaignAmmount = 10000.00, currentAmmount = 50.00, isActive = true},
                new Campaign { campaignId = 2, name = "Paws for a Cause", campaignAmmount = 12000.00, currentAmmount = 3000.00, isActive = true },
                new Campaign { campaignId = 3, name = "Meow Mission: Helping Homeless Cats", campaignAmmount = 8000.00, currentAmmount = 1500.00, isActive = true },
                new Campaign { campaignId = 4, name = "Bark Aid: Shelter Support for Dogs", campaignAmmount = 18000.00, currentAmmount = 6000.00, isActive = true }

            };
            modelBuilder.Entity<Campaign>().HasData(campaigns);

            //seed Donations
            var donations = new Donation[]
            {
                new Donation { donationId = 1, ammount = 50.00, campaignId = 1, userId = 1 },
            };
            modelBuilder.Entity<Donation>().HasData(donations);


            //seed pet breed
            var petBreeds = new PetBreed[]
            {
                new PetBreed { petBreedId = 1, description = "Labrador"},
                new PetBreed { petBreedId = 2, description = "German Shepherd"},
                new PetBreed { petBreedId = 3,  description = "Persian"},
                new PetBreed { petBreedId = 4, description = "Burmese" },
                new PetBreed { petBreedId = 5, description = "Maine Coon"},
                new PetBreed { petBreedId = 6, description = "Siamese"},
                new PetBreed { petBreedId = 7, description = "Australian Shepherd"},
                new PetBreed { petBreedId = 8, description = "Dalmatian"},
                new PetBreed { petBreedId = 9, description = "Yorkshire Terrier"},
                new PetBreed { petBreedId = 10, description = "Belgian Malanois"}
            };
            modelBuilder.Entity<PetBreed>().HasData(petBreeds);

            //seed pet type
            var petTypes = new PetType[]
            {
                new PetType { petTypeId = 1, description = "Dog"},
                new PetType { petTypeId = 2, description = "Cat"}
            };
            modelBuilder.Entity<PetType>().HasData(petTypes);

            //seed Location
            var locations = new Location[]
            {
                new Location {locationId = 1 , name = "Gauteng" },
                new Location {locationId = 2 , name = "North West"},
                new Location {locationId = 3 , name = "Limpopo"},
                new Location {locationId = 4 , name = "Western Cape"},
                new Location {locationId = 5 , name = "Eastern Cape"},
                new Location {locationId = 6 , name = "Northern Cape"},
                new Location {locationId = 7 , name = "Freestate"},
                new Location {locationId = 8 , name = "Kwazulu Natal"}
            };
            modelBuilder.Entity<Location>().HasData(locations);

            var Pets = new Pet[]
            {
                new Pet { petId = 1, petTypeId = 1, name = "Benji", petBreedId = 2, age = 6, weight = 27.00, genderId = 1, locationId = 2, userId = 1, image = "iamge placeholder"},
                new Pet { petId = 2, petTypeId = 2, name = "Buddy", petBreedId = 7, age = 4, weight = 15.5, genderId = 2, locationId = 5, userId = 3, image = "" },
                new Pet { petId = 3, petTypeId = 1, name = "Luna", petBreedId = 3, age = 2, weight = 12.8, genderId = 1, locationId = 4, userId = 8, image = "image placeholder" },
                new Pet { petId = 4, petTypeId = 2, name = "Milo", petBreedId = 9, age = 7, weight = 19.3, genderId = 2, locationId = 7, userId = null, image = "" },
                new Pet { petId = 5, petTypeId = 1, name = "Max", petBreedId = 5, age = 9, weight = 21.0, genderId = 1, locationId = 1, userId = 5, image = "image placeholder" },
                new Pet { petId = 6, petTypeId = 2, name = "Daisy", petBreedId = 8, age = 12, weight = 8.7, genderId = 2, locationId = 3, userId = 7, image = "" }

        };
            modelBuilder.Entity<Pet>().HasData(Pets);
        }
    }
}
