using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FitnessManagementSystem.Models
{
    public class Gym
    {
        [Key]
        [DisplayName("Gym Id")]
        public int GymId { get; set; }

        [DisplayName("Gym Address")]
        [Required(ErrorMessage = "Please enter Street Address")]
        [StringLength(100, ErrorMessage = "Address cannot be more than 50 characters")]
        public string GymStAddress { get; set; }

        [Required(ErrorMessage = "Please enter City name")]
        [StringLength(50, ErrorMessage = "City Name cannot be more than 50 characters")]
        [DisplayName("City")]
        public string GymCity { get; set; }

        [DisplayName("Province")]
        [Required(ErrorMessage = "Please enter Province name")]
        [StringLength(50, ErrorMessage = "Province Name cannot be more than 50 characters")]
        public string GymProvince { get; set; }

        [Required(ErrorMessage = "Please enter Postal Code")]
        [StringLength(50, ErrorMessage = "Postal code cannot be more than 50 characters")]
        [DisplayName("Postal Code")]
        public string GymPostal { get; set; }
    }
}
