using System.ComponentModel.DataAnnotations;

namespace PetAppHW2.Models
{
    public class Donation
    {

        [Key]
        public int donationId { get; set; }

        public double ammount { get; set; }

        public int userId { get; set; }

        public User User { get; set; }

        public int campaignId { get; set; }

        public Campaign Campaign { get; set; }

    }
}
