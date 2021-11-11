using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Data.Models
{
    public class Meal : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public float? DiscountValue { get; set; }
        public int ResturantId { get; set; }
        public Resturant Resturant { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<OrderItem> Orders { get; set; }
    }
}
