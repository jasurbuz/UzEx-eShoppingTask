using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Shopping.Services.DTOs.Product
{
    public class ProductForCreationDto
    {
        public string Name { get; set; }
        public int Count { get; set; } = 0;
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
