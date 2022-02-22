using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonCQRS.Api.Commands;
using PersonCQRS.Api.DTOs;

namespace PersonCQRS.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator?? throw new ArgumentNullException(nameof(mediator));
        }
        
        [Route("Person")]
        [HttpPost]
        public async Task<ActionResult<Result>> CreatePersonAsync(
            [FromBody] PersonDto personDto
        )
        {
            var createPersonCommand = new CreatePersonCommand(
                personDto.FirstName,personDto.LastName,personDto.Email,personDto.DateOfBirth,personDto.PhoneNumber
            );

            var result = await _mediator.Send(createPersonCommand);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok();
        }

    }
}