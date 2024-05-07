using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRLeaveManagement.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
             new IdentityUserRole<string>
             {
                 RoleId = "d2b1023d-1be6-4b1e-8dc5-f3c123a79c55",
                 UserId = "fa74745d-1455-4974-a6a8-365b20ec5f00"
             },
               new IdentityUserRole<string>
               {
                   RoleId = "86ece1b6-ee1c-4ad6-9714-3a7d3ae79445",
                   UserId = "78ca50e8-1a86-4b90-a4a8-e5565cff23f5"
               });

        }
    }
}
