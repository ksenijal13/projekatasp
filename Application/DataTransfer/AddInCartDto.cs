using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class AddInCartDto
    {
        public int UserId { get; set; }
        public int PerfumeId { get; set; }
        public int Quantity { get; set; }
    }
}
