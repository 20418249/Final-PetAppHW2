using System.ComponentModel.DataAnnotations;

namespace PetAppHW2.Models
{
    public class PetType
    {

        [Key]

        public int petTypeId { get; set; }

        public string description { get; set; }
    }
}
