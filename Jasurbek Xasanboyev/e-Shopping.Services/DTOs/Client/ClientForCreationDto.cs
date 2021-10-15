using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Shopping.Services.DTOs.Client
{
    public class ClientForCreationDto
    {
        public string Name { get; set; }
        public string INN { get; set; }
        public string Status { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Region { get; set; }

        [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1}", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
