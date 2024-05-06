using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using Moq;

namespace HRLeaveManagement.Application.UnitTests.Mock
{
    public class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypes()
        {
            var leaveTypes = new List<LeaveType>
            {
                new() {
                    Id = 1,
                    DefaultDays= 10,
                    Name = "Test vacation"
                },
                   new() {
                    Id = 2,
                    DefaultDays= 15,
                    Name = "Test sick"
                },
                   new() {
                    Id = 1,
                    DefaultDays= 15,
                    Name = "Test maternity"
                }
            };

            var mockRepo = new Mock<ILeaveTypeRepository>();
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(leaveTypes);
            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return new()
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Test vacation"
                };
            });
            mockRepo.Setup(r => r.CreateAsync(It.IsAny<LeaveType>())).Returns((LeaveType leaveType) =>
            {
                leaveTypes.Add(leaveType);
                return Task.CompletedTask;
            });

            return mockRepo;
        }

    }
}