using DentialSystem.Application.Services.DentalService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentalSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentalHistoryController : ControllerBase
    {
        private readonly IDentalHistoryServices _dentalHistoryServices;

        public DentalHistoryController(IDentalHistoryServices dentalHistoryServices)
        {
            _dentalHistoryServices = dentalHistoryServices;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var property = await _dentalHistoryServices.GetByIdAsync(id);
            return Ok(property);
        }
    }
}
