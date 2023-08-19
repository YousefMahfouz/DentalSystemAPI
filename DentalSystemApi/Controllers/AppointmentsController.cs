using DentialSystem.Application.Services.AppointmentService;
using DentialSystem.Domain;
using DentialSystem.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace DentalSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentServices _appointmentServices;

        public AppointmentsController(IAppointmentServices appointmentServices)
        {
            _appointmentServices = appointmentServices;
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentDTO>> CreateAppointment(AppointmentDTO appointmentDto)
        {
            try
            {
                var createdAppointment = await _appointmentServices.CreateAppointment(appointmentDto);
                return Ok(createdAppointment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateAppointment/{id}")]
        
        public async Task<IActionResult> UpdateAppointment(int id,  AppointmentDTO appointmentDto)
        {
            //if (id != appointmentDto.Id)
            //{
            //    return BadRequest("ID mismatch between route parameter and appointment data.");
            //}

            try
            {
                var updatedAppointmentDto = await _appointmentServices.UpdateAppointment(id, appointmentDto);
                return Ok(updatedAppointmentDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the appointment.");
            }
        }

        [HttpDelete("DeleteAppointment/{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            try
            {
                var isDeleted = await _appointmentServices.DeleteAppointment(id);

                if (isDeleted)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the appointment.");
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var property = await _appointmentServices.GetByIdAsync(id);
            return Ok(property);
        }
        [HttpGet]
        [Route("GetAllAppointmentByPaitantId/{id}")]

        public async Task<IActionResult> GetAllAppointmentByPaitantId(string id)
        {
            var AllApointment = await _appointmentServices.GetAll(id);
            return Ok(AllApointment);
        }



    }
}
