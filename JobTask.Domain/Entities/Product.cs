using JobTask.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTask.Domain.Entities
{
    public class Product : Auditable
    {
        public string Title { get; set; }
        public long Quantiy { get; set; }
        public decimal Price { get; set; }
    }
}
