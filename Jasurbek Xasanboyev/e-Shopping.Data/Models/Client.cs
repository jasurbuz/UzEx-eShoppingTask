using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Shopping.Data.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string INN { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        #region Relation
        public Bid Bid { get; set; }
        #endregion

    }
}
