using AutoMapper;
using HRLeaveManagement.Application.Contracts.Logging;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveType;
using HRLeaveManagement.Application.MappingProfile;
using HRLeaveManagement.Application.UnitTests.Mock;
using Moq;
using Shouldly;
using Xunit;

namespace HRLeaveManagement.Application.UnitTests.Feature.LeaveType.Queries
{
    public class GetLeaveTypeListRequestHandlerTest
    {
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetLeaveTypeQueryRequestHandler>> _mockAppLogger;

        public GetLeaveTypeListRequestHandlerTest()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypes();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<LeaveTypeProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetLeaveTypeQueryRequestHandler>>();
        }
        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypeQueryRequestHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);
            var result = await handler.Handle(new GetLeaveTypeQueryRequest(), CancellationToken.None);
            result.ShouldBeOfType<List<LeaveTypeDto>>();
            result.Count.ShouldBe(3);
        }
    }
}