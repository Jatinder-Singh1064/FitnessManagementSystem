using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessManagementSystem.Models
{
    public class Enrollment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DisplayName("Enrollment ID")]
        public int EnrollmentId { get; set; }

        [DisplayName("Plan ID")]
        public int PlanId { get; set; }

        [DisplayName("Number of Months")]
        public int NumberOfMonths { get; set; }

        [DisplayName("Gym ID")]
        public int GymId { get; set; }

        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }

        public virtual Gym Gym { get; set; }

        public virtual MembershipPlans MembershipPlans { get; set; }
    }
}
