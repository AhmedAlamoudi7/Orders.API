using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Data.Models
{
    public class Resturant : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        [Required]
        public string Phone { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Address { get; set; }
        public List<Meal> Meals { get; set; }
        public List<Order> Orders { get; set; }
    }
}
