using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRLeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagement.Identity.DbContext
{
    public class HRLeaveManageMentIdentityContext : IdentityDbContext<ApplicationUser>
    {
        public HRLeaveManageMentIdentityContext(DbContextOptions<HRLeaveManageMentIdentityContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(HRLeaveManageMentIdentityContext).Assembly);
        }
    }
}