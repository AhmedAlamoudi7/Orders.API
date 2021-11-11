using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.Dtos
{
    public class CreateResturantDto
    {
        [Required]
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        [Required]
        public string Phone { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string Address { get; set; }
    }
}
