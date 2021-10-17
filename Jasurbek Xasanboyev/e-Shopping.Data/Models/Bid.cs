using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Shopping.Data.Models
{
    public class Bid
    {
        public Guid Id { get; set; }
        public DateTime BidTime { get; set; } = DateTime.Now;
        public int Count { get; set; }
        public double Total { get; set; }

        #region Relation

        #region Product
        
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        #endregion

        #region Client

        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        #endregion
        
        #endregion
    }
}
