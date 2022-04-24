using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FitnessManagementSystem.Models
{
    public class Slots
    {
        [Key]
        [DisplayName("Slot ID")]
        public int SlotId { get; set; }

        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }

        [DisplayName("Gym ID")]
        public int GymId { get; set; }

        [DisplayName("Date")]
        public DateTime Date { get; set; }

        [DisplayName("Slot Detail")]
        public String SlotTimeID { get; set; }
    }
}
