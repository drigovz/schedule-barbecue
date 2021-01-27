using Api.Domain.DTOs.Barbecues;
using Api.Domain.DTOs.Participants;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.BarbecueService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class BarbecuesController : ControllerBase
    {
        private readonly IBarbecueService _service;

        public BarbecuesController(IBarbecueService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BarbecueDTO>>> GetAll()
        {
            try
            {
                var barbecues = await _service.GetAllAsync();
                return barbecues.ToList();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to connect on server");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([BindRequired] int id)
        {
            try
            {
                var barbecue = await _service.GetAsync(id);
                if (barbecue == null)
                    return NotFound($"Barbecue with id {id} not found");
                else
                    return new ObjectResult(barbecue);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to connect on server");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BarbecueDTO barbecue)
        {
            try
            {
                var result = await _service.PostAsync(barbecue);
                return new ObjectResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when try to add a new barbecue: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([BindRequired] int id, [FromBody] BarbecueDTO barbecue)
        {
            try
            {
                if (barbecue == null || id != barbecue.Id)
                    return BadRequest($"Barbecue with id {id} not found");
                else
                {
                    var result = await _service.PutAsync(barbecue);
                    return StatusCode(StatusCodes.Status200OK, $"Barbecue id {id} update succesfull");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when try to update barbecue {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([BindRequired] int id)
        {
            try
            {
                var result = await _service.GetAsync(id);
                if (result == null)
                    return NotFound($"Barbecue with id {id} not found");

                await _service.DeleteAsync(id);

                return StatusCode(StatusCodes.Status200OK, "Barbecue deleted succesfull");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to delete barbecue");
            }
        }

        [HttpGet("participants/{barbecueId:int}")]
        public async Task<IEnumerable<Participant>> GetParticipants([BindRequired] int barbecueId)
        {
            return await _service.BarbecueParticipants(barbecueId);
        }

        [HttpPost("participants")]
        public async Task<ActionResult> AddParticipantsOnBarbecue([FromBody] ParticipantDTO participant)
        {
            try
            {
                if (participant == null || participant.BarbecueId <= 0)
                    return BadRequest("Please, make sure to fill in the fields correctly!");

                var result = await _service.AddParticipantsOnBarbecue(participant);
                return new ObjectResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when try to add barbecue participants: {ex.Message}");
            }
        }

        [HttpDelete("participants/{participantId:int}")]
        public async Task<ActionResult> RemoveParticipantsFromBarbecue([BindRequired] int participantId)
        {
            try
            {
                if (participantId <= 0)
                    return BadRequest("Please, make sure you are correctly parameters!");

                await _service.RemoveParticipantsFromBarbecue(participantId);

                return StatusCode(StatusCodes.Status200OK, "Participant deleted succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when try to remove participant from barbecue: {ex.Message}");
            }
        }
    }
}
