using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Shopping.Data.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; } = 0;
        public string Description { get; set; }
        public double Price { get; set; }

        #region Relation
        public Bid Bid { get; set; }
        #endregion
    }
}
