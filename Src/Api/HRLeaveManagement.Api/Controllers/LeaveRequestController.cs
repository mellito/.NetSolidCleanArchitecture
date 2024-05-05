using HRLeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using HRLeaveManagement.Application.Features.LeaveRequest.Command.CancelLeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequest.Command.ChangeLeaveRequestApproval;
using HRLeaveManagement.Application.Features.LeaveRequest.Command.CreateLeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequest.Command.UpdateLeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers;

[Route("api/leaverequest")]
[ApiController]
public class LeaveRequestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveRequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<LeaveRequestsController>
    [HttpGet]
    public async Task<ActionResult<List<LeaveRequestListDto>>> Get(bool isLoggedInUser = false)
    {
        var leaveRequests = await _mediator.Send(new GetLeaveRequestListRequest());
        return Ok(leaveRequests);
    }

    // GET api/<LeaveRequestsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveRequestDetailDto>> Get([FromRoute] int id)
    {
        var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailRequest(id));
        return Ok(leaveRequest);
    }

    // POST api/<LeaveRequestsController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto leaveRequest)
    {
        var response = await _mediator.Send(new CreateLeaveRequestRequest(leaveRequest));
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    // PUT api/<LeaveRequestsController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put([FromRoute] int id, [FromBody] UpdateLeaveRequestDto leaveRequest)
    {
        await _mediator.Send(new UpdateLeaveRequestRequest(id, leaveRequest));
        return NoContent();
    }

    // PUT api/<LeaveRequestsController>/CancelRequest/
    [HttpPut("cancelrequest/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> CancelRequest([FromRoute] int id)
    {
        await _mediator.Send(new CancelLeaveRequestRequest(id));
        return NoContent();
    }

    // PUT api/<LeaveRequestsController>/UpdateApproval/
    [HttpPut("updateapproval/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateApproval([FromRoute] int id, [FromRoute] ChangeLeaveRequestApprovalDto leaveRequest)
    {
        await _mediator.Send(new ChangeLeaveRequestApprovalRequest(leaveRequest, id));
        return NoContent();
    }

    // DELETE api/<LeaveRequestsController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new DeleteLeaveAllocationRequest(id));
        return NoContent();
    }
}