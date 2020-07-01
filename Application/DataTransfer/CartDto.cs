using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class CartDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PerfumeId { get; set; }
        public int Quantity { get; set; }
    }
}
