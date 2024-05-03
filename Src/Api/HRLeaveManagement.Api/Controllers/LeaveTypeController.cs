using HRLeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HRLeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;
using HRLeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveType;
using HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRLeaveManagement.Api.Controllers
{
    [ApiController]
    [Route("api/leavetype")]
    public class LeaveTypeController : ControllerBase
    {
        public readonly IMediator _mediator;
        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<LeaveTypeDto>> GetAll()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeQueryRequest());
            return leaveTypes;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LeaveTypeDetailsDto>> Get([FromRoute] int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailsQueryRequest(id));
            return Ok(leaveType);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] CreateLeaveTypeCommandRequest leaveType)
        {
            var response = await _mediator.Send(leaveType);
            return Ok(response);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] UpdateLeaveTypeCommandRequest leaveType)
        {
            await _mediator.Send(leaveType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _mediator.Send(new DeleteLeaveTypeCommandRequest(id));
            return NoContent();
        }
    }
}