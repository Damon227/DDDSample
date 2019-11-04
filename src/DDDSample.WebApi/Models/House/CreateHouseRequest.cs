using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DDDSample.WebApi.Models.House
{
    public class CreateHouseRequest
    {
        [Required]
        [StringLength(32)]
        public string OwnerId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [Range(0, 99999999)]
        public double Area { get; set; }
    }
}
