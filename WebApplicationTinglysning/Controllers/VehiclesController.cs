using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTinglysning.Models;
using WebApplicationTinglysning.Servises;

namespace WebApplicationTinglysning.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        VehiclesDbHandler dbHandler = new VehiclesDbHandler();

        // Search by chassis number (stelnummer)
        // localhost:62191/api/vehicles/chassisnumber?chassisnumber=5Y4AJ14W0B0518535
        [Route("chassisnumber")]
        [HttpGet]
        public async Task<IActionResult> GetByChassisNumber(string chassisNumber)
        {
            var response = await dbHandler.GetVehiclesByChassisNumberAsync(chassisNumber.ToUpper());

            return HandleResponse(response);
        }

        // search by cvr number
        // localhost:62191/api/vehicles/cvr?cvr=123456
        [Route("cvr")]
        [HttpGet]
        public async Task<IActionResult> GetByCvr(string cvr)
        {
            var response = await dbHandler.GetVehiclesByCvrAsync(cvr);

            return HandleResponse(response);
        }

        private IActionResult HandleResponse(ResponseObject response)
        {
            if (response.ResponseStatus == ResponseStatus.OK)
            {
                return Ok(response.Content);
            }
            else if (response.ResponseStatus == ResponseStatus.NOT_FOUND)
            {
                return NotFound(response.Content);
            }
            else
            {
                return BadRequest(response.Content);
            }
        }
    }
}
