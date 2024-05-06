using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRLeaveManagement.Domain;
using HRLeaveManagement.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace HRLeaveManagament.Persistence.Integration
{
    public class HRDatabaseContextTest
    {
        private HRDatabaseContext _hrDatabaseContext;

        public HRDatabaseContextTest()
        {
            var dbOptions = new DbContextOptionsBuilder<HRDatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _hrDatabaseContext = new HRDatabaseContext(dbOptions);
        }
        [Fact]
        public async void Save_SetDateCreated()
        {
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test vacation"
            };

            await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrDatabaseContext.SaveChangesAsync();

            leaveType.DateCreated.ShouldNotBeNull();

        }

        [Fact]
        public async void Save_SetDateModifiedValue()
        {
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test vacation"
            };

            await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrDatabaseContext.SaveChangesAsync();

            leaveType.DateModified.ShouldNotBeNull();
        }
    }
}