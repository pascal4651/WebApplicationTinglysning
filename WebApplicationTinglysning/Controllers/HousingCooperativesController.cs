using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTinglysning.Models;
using WebApplicationTinglysning.Models.HousingCooperativesModels;
using WebApplicationTinglysning.Servises;

namespace WebApplicationTinglysning.Controllers
{
    [Route("api/housingcooperatives")]
    [ApiController]
    public class HousingCooperativesController : ControllerBase
    {
        HousingCooperativesDbHandler dbHandler = new HousingCooperativesDbHandler();

        // Search by address: floor, house number, post number, side door, street name (Søgning med adresse: etage, husnummer, postnummer, sidedoer, vejnavn)
        // localhost:62191/api/housingcooperatives/address?flooridentifier=1&streetbuildingidentifier=14&postcodeidentifier=2200&sidedoor=TV&streetname=Nørrebrogade
        // localhost:62191/api/housingcooperatives/address?streetbuildingidentifier=14&postcodeidentifier=2200&streetname=Nørrebrogade
        [HttpGet]
        [Route("address")] 
        public async Task<IActionResult> GetByAddressAsync([FromQuery] HousingCooperativeApi housingCooperativeApi)
        {
            var response = await dbHandler.GetHousingCooperativesByAddressAsync(housingCooperativeApi);
            return HandleResponse(response);
        }

        // Search by MunicipalityCode and StreetCode (Søgning med kommunekode og vejkode)
        // localhost:62191/api/housingcooperatives/municipality?flooridentifier=1&streetbuildingidentifier=14&municipalitycode=101&sidedoor=TV&streetcode=5192
        [HttpGet]
        [Route("municipality")]
        public async Task<IActionResult> GetByMunicipalityAndStreetCodesAsync([FromQuery] HousingCooperativeApi housingCooperativeApi)
        {
            var response = await dbHandler.GetHousingCooperativesByMunicipalityAndStreetCodesAsync(housingCooperativeApi);
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