using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class YourCartDto
    {
       public int Id { get; set; }
        public string BrandName { get; set; }
        public string FragranceName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
