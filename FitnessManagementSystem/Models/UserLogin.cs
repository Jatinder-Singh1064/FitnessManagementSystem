using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FitnessManagementSystem.Models
{
    public class UserLogin
    {
        [Key]
        [DisplayName("User ID")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please enter the User Name")]
        [StringLength(50, ErrorMessage = "User Name cannot be more than 50 characters")]
        [DisplayName("User Email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter the Password")]
        [StringLength(50, ErrorMessage = "Password cannot be more than 50 characters")]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}
