using System.ComponentModel.DataAnnotations;

namespace PetAppHW2.Models
{
    public class Pet
    {

        [Key]
        public int petId { get; set; }

        public string name { get; set; }

        public string image { get; set; }

        public int petTypeId { get; set; }
        public PetType PetType { get; set; }

        public int petBreedId { get; set; }
        public PetBreed PetBreed { get; set; }

        public int locationId { get; set; }
        public Location Location { get; set; }

        public int age { get; set; }

        public double weight { get; set; }

        public int genderId { get; set; }
        public Gender Gender { get; set; }

        public int? userId { get; set; } //The questionmark allows the userId to be null
        public User User { get; set; }
    }
}
