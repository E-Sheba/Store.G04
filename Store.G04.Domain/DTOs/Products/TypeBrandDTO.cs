using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Domain.DTOs.Products
{
    public class TypeBrandDTO
    {
        public string Name { get; set; }
        public DateTime CreatAt { get; set; } = DateTime.Now;
    }
}
