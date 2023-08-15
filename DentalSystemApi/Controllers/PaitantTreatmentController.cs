using DentialSystem.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentalSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaitantTreatmentController : ControllerBase
    {
        private readonly ITreatmentServices treatmentServices;
        private readonly IPaitantTreatmentServices paitantTreatmentServices;

        public PaitantTreatmentController(ITreatmentServices treatmentServices,
            IPaitantTreatmentServices paitantTreatmentServices)
        {
            this.treatmentServices = treatmentServices;
            this.paitantTreatmentServices = paitantTreatmentServices;
        }
        [HttpGet]
        [Route("GetpaitantTreatmentById")]
        public async Task<IActionResult> GetpaitantTreatmentById(string paitantid)
        {
            var treatments = await paitantTreatmentServices.GetPaitantTreatments(paitantid);
                return Ok(treatments);
           
        }
        [HttpGet]
        [Route("GetAllTreatments")]
        public async Task<IActionResult> GetAllTreatments()
        {
            var treatments = await treatmentServices.GetAllTreatment();
            return Ok(treatments);

        }
    }
}
