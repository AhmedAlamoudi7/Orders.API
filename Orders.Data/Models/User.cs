using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDelete { get; set; }

        public User()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
