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
    public class UserConfiguration : IEntityTypeConfiguration<ApiUser>
    {
        public void Configure(EntityTypeBuilder<ApiUser> builder)
        {
            builder.HasData(
                new ApiUser
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = "Admin",
                    Password = "Admin",
                },
                new ApiUser
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Moderator",
                    LastName = "Moderator",
                    UserName = "Moderator",
                    Password = "Moderator",
                }
             );
        }
    }
}
