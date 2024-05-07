using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRLeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRLeaveManagement.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(new ApplicationUser
            {
                Id = "78ca50e8-1a86-4b90-a4a8-e5565cff23f5",
                Email = "admin@localhost.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM",
                FirstName = "system",
                LastName = "Admin",
                UserName = "admin@localhost.com",
                NormalizedUserName = "ADMIN@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, "P@assword1"),
                EmailConfirmed = true
            },
            new ApplicationUser
            {
                Id = "fa74745d-1455-4974-a6a8-365b20ec5f00",
                Email = "user@localhost.com",
                NormalizedEmail = "USER@LOCALHOST.COM",
                FirstName = "system",
                LastName = "User",
                UserName = "user@localhost.com",
                NormalizedUserName = "user@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, "P@assword1"),
                EmailConfirmed = true
            }
            );
        }
    }
}