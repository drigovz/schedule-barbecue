using Api.Domain.DTOs.Barbecues;
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
                var comments = await _service.GetAllAsync();
                return comments.ToList();
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
                var comment = await _service.GetAsync(id);
                if (comment == null)
                    return NotFound($"Barbecue with id {id} not found");
                else
                    return new ObjectResult(comment);
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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to delete barbecue");
            }
        }
    }
}
