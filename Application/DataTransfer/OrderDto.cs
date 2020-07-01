using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class OrderDto
    {
        public int UserId { get; set; }
        public string Address { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
    }
    public class OrderItemDto
    {
        public int OrderId { get; set; }
        public int PerfumeId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
