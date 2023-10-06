using System.ComponentModel.DataAnnotations;

namespace PetAppHW2.Models
{
    public class PetBreed
    {

        [Key]

        public int petBreedId { get; set; }

        public string description { get; set; }
    }
}
