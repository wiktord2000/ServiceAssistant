using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.ServiceDtos
{
    public class ServiceUpdateDto
    {   
        [Required]
        public string Name { get; set; }
        public float CostNet { get; set; }
        public float CostGross { get; set; }
        [Required]
        public string Unit { get; set; }
        [Required]
        public float? EstimatedTime { get; set; }
        public float TotalNet { get; set; }
        public float TotalGross { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}