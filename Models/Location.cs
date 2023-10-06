using System.ComponentModel.DataAnnotations;

namespace PetAppHW2.Models
{
    public class Location
    {

        [Key]

        public int locationId { get; set; }

        public string name { get; set; }

        
    }
}
