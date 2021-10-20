
using e_Shopping.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Shopping.Data.Confiigurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasData(
                new Client
                {
                    Id = Guid.Parse("527458d1-e742-4498-3ef0-08d9915d00a9"),
                    Name = "Jasurbek Xasanboyev",
                    INN = "5165653131",
                    Status = "Yuridik",
                    Phone = "+998936909007",
                    Address = "Bo`ston tumani",
                    Email = "jasurbuz@gmail.com",
                    Region = "Andijon",
                    Password = "123456789"
                }
                );
        }
    }
}
