using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FitnessManagementSystem.Models
{
    public class MembershipPlans
    {
        [Key]
        [DisplayName("ID")]
        public int PlanId { get; set; }

        [Required(ErrorMessage = "Please enter the Plan Name")]
        [StringLength(50, ErrorMessage = "Plan Name cannot be more than 50 characters")]
        [DisplayName("Plan Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the Description")]
        [StringLength(1000, ErrorMessage = "Description cannot be more than 50 characters")]
        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Price")]
        public int Price { get; set; }
    }
}
