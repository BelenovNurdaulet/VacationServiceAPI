using Microsoft.AspNetCore.Mvc;
using MediatR;
using VacationService.Application.Vacancies.Commands;
using VacationService.Application.Vacancies.Queries;
using VacationService.Domain.Entities;
using VacationServiceAPI.Contracts.Requests;

namespace VacationServiceAPI.Controllers
{
    [Route("api/vacations")]
    [ApiController]
    public class VacationsController : ControllerBase
    {
        private readonly ILogger<VacationsController> _logger;
        private readonly IMediator _mediator;

        public VacationsController(ILogger<VacationsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(VacationsApplication), StatusCodes.Status201Created)]
        public async Task<ActionResult> PostVacation([FromBody] CreateVacationApplicationRequest vacRequest)
        {

            var vacationApplicationResult = await _mediator.Send(
                new CreateVacationApplicationCommand(vacRequest.CreateBy,
                    vacRequest.StartDate,
                    vacRequest.EndDate,
                    vacRequest.ApplicationTypeId));
                if (vacationApplicationResult.IsSuccess)
                {
                    return CreatedAtAction(nameof(GetVacationById), new { id = vacationApplicationResult.Value.CreateBy }, vacationApplicationResult.Value);
                }
                {
                    _logger.LogError("Failed to create vacation application: {Error}", vacationApplicationResult.Error);
                    return BadRequest(vacationApplicationResult.Error);
                }
           
        }

        [HttpGet("CreateBy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVacationById(int CreateBy)
        {
                var vacations = await _mediator.Send(new GetVacationApplicationsQuery(CreateBy));

                return Ok(vacations);
        }
    }
}
