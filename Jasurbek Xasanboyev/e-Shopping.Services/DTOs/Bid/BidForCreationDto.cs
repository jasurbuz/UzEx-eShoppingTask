using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Shopping.Services.DTOs.Bid
{
    public class BidForCreationDto
    {
        public Guid ProductId { get; set; }
        public Guid ClientId { get; set; }
        public int Count { get; set; }
    }
}
