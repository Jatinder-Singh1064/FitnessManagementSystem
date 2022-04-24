using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FitnessManagementSystem.Models
{
    public class Customer
    {
        [Key]
        [DisplayName("Customer Id")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter Customer Name")]
        [StringLength(50, ErrorMessage = "Customer Name cannot be more than 50 characters")]
        [DisplayName("Customer Name")]
        public String CustomerName { get; set; }

        [Required(ErrorMessage = "Please enter Password.")]
        [StringLength(50, ErrorMessage = "Password cannot be more than 50 characters")]
        [DisplayName("Password")]
        public String Password { get; set; }

        [Required(ErrorMessage = "Please enter Customer Email.")]
        [EmailAddress(ErrorMessage = "Please enter correct format of email")]
        [DisplayName("Customer Email")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Please enter Phone Number.")]
        [StringLength(10, ErrorMessage = "Phone Number cannot be more than 10 characters")]
        [DisplayName("Customer Phone")]
        public String CustomerPhone { get; set; }

        [Required(ErrorMessage = "Please enter Customer Address.")]
        [StringLength(50, ErrorMessage = "Customer Address cannot be more than 50 characters")]
        [DisplayName("Customer Address")]
        public String CustomerAddress { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
    }
}
