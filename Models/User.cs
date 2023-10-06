using System.ComponentModel.DataAnnotations;

namespace PetAppHW2.Models
{
    public class User
    {

        [Key]
        public int userId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
    }
}
