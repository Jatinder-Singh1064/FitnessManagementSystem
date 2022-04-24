using System.ComponentModel.DataAnnotations;

namespace FitnessManagementSystem.Models
{
    public class City
    {
        [Key]
        public string Title { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }
    }
}
