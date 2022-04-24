using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessManagementSystem.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Please enter Employee Name")]
        [StringLength(50, ErrorMessage = "Employee Name cannot be more than 50 characters")]
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [EmailAddress(ErrorMessage = "Please enter correct format of email")]
        [DisplayName("Email")]
        public string Email { get; set; }


        [DisplayName("Join Date")]
        public DateTime JoinDate { get; set; }

        [Required(ErrorMessage = "Please enter Phone Number")]
        [StringLength(10, ErrorMessage = "Phone Number cannot be more than 10 characters")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Gym ID")]
        public int GymId { get; set; }

        [DisplayName("Gym ID")]
        public virtual Gym Gym { get; set; }
    }
}
