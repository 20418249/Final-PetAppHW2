using System.ComponentModel.DataAnnotations;

namespace PetAppHW2.Models
{
    public class Gender
    {

        [Key]
        public int genderId { get; set; }
        public string description { get; set; }
    }
}
