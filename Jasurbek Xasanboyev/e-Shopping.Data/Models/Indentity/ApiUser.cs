using e_Shopping.Data.Models.Events;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Shopping.Data.Models
{
    public class ApiUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string Region { get; set; }

        public string District { get; set; }

        public string Street { get; set; }
    }
}
