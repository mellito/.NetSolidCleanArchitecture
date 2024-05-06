using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HRLeaveManagement.Application.Contracts.Logging;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using HRLeaveManagement.Application.MappingProfile;
using HRLeaveManagement.Application.UnitTests.Mock;
using Moq;
using Shouldly;

namespace HRLeaveManagement.Application.UnitTests.Feature.LeaveType.Queries
{
    public class GetLeaveTypeDetailsQueryRequestHandlerTest
    {
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetLeaveTypeDetailsQueryRequestHandler>> _mockAppLogger;

        public GetLeaveTypeDetailsQueryRequestHandlerTest()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypes();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<LeaveTypeProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetLeaveTypeDetailsQueryRequestHandler>>();
        }
        [Fact]
        public async Task GetLeaveTypeTest()
        {
            var handler = new GetLeaveTypeDetailsQueryRequestHandler(_mapper, _mockRepo.Object);
            var result = await handler.Handle(new GetLeaveTypeDetailsQueryRequest(1), CancellationToken.None);
            result.ShouldBeOfType<LeaveTypeDetailsDto>();
            result.ShouldNotBeNull();
            result.Name.ShouldBe("Test vacation");

        }
    }
}