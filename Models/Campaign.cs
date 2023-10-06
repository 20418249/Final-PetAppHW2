using System.ComponentModel.DataAnnotations;

namespace PetAppHW2.Models
{
    public class Campaign
    {

        [Key]

        public int campaignId { get; set; }

        public string name { get; set; }

        public double campaignAmmount { get; set; }

        public double currentAmmount { get; set; }

        public Boolean isActive { get; set; }
    }
}
