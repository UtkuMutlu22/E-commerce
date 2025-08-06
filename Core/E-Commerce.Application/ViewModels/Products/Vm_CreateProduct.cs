using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.ViewModels.Products
{
    public class Vm_CreateProduct
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
    }
    public class Vm_UpdateProduct
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
    }
}
