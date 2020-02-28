using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTinglysning.Models;
using WebApplicationTinglysning.Servises;

namespace WebApplicationTinglysning.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        CompanyDbHandler dbHandler = new CompanyDbHandler();

        // Search possible document types (Mulige dokumenttyper)
        // localhost:62191/api/company/documenttypes
        [Route("documenttypes")]
        [HttpGet]
        public async Task<IActionResult> GetDocumentTypesAsync()
        {
            var response = await dbHandler.GetDocumentTypesAsync();
            return HandleResponse(response);
        }

        // Search possible document types (Mulige dokumenttyper)
        // localhost:62191/api/company/roletypes
        [Route("roletypes")]
        [HttpGet]
        public async Task<IActionResult> GetRoleTypesAsync()
        {
            var response = await dbHandler.GetRoleTypesAsync();
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