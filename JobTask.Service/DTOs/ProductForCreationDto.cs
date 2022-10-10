using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTask.Service.DTOs
{
    public class ProductForCreationDto
    {
        [Required, MaxLength(30)]
        public string Title { get; set; }

        [Required]
        public long Quantiy { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
