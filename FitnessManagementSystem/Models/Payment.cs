using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitnessManagementSystem.Models
{
    public class Payment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DisplayName("Transaction ID")]
        public int TransactionId { get; set; }

        [DisplayName("Amount")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Please enter the Card Number.")]
        [StringLength(16, ErrorMessage = "Please enter the valid card number.")]
        [DisplayName("Card Number")]
        public String CardNumber { get; set; }

        [Required(ErrorMessage = "Please enter the card expiry date.")]
        [DisplayName("Expiry Date")]
        public DateTime ExpiryDate { get; set; }

        [Required(ErrorMessage = "Please enter CVV detail.")]
        [StringLength(3, ErrorMessage = "Please enter valid CVV detail.")]
        [DisplayName("CVV")]
        public String CVV { get; set; }

        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }
            
        [DisplayName("Enrollment ID")]
        public int EnrollmentId { get; set; }
    }
}