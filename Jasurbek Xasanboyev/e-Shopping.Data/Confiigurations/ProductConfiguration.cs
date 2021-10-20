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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Count = 10,
                        Name = "Olma",
                        Description = "Qizil olma",
                        Price = 12000
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Count = 10,
                        Name = "Shaftoli",
                        Description = "Tukli shaftoli",
                        Price = 10000
                    }
                );
        }
    }
}
