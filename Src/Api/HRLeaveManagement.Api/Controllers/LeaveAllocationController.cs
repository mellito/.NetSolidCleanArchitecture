using HRLeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HRLeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using HRLeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using HRLeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HRLeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRLeaveManagement.Api.Controllers
{
    [ApiController]
    [Route("api/leaveallocation")]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetLeaveAllocationDto>>> Get()
        {
            var allocations = await _mediator.Send(new GetLeaveAllocationsRequest());
            return allocations;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetLeaveAllocationDetailDto>> Get([FromRoute] int id)
        {
            var allocation = await _mediator.Send(new GetLeaveAllocationDetailRequest(id));
            return Ok(allocation);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateLeaveAllocationDto leaveAllocation)
        {
            var response = await _mediator.Send(new CreateLeaveAllocationRequest(leaveAllocation));
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAllocationDto leaveAllocation)
        {
            await _mediator.Send(new UpdateAllocationRequest(id, leaveAllocation));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _mediator.Send(new DeleteLeaveAllocationRequest(id));
            return NoContent();
        }
    }
}