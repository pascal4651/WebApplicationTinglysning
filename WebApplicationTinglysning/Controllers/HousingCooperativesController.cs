using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplicationTinglysning.Helpers;
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
            housingCooperativeApi = NormalizeHousingCooperativeApi(housingCooperativeApi);

            var response = await dbHandler.GetHousingCooperativesByAddressAsync(housingCooperativeApi);
            return HandleResponse(response);
        }

        // Search by MunicipalityCode and StreetCode (Søgning med kommunekode og vejkode)
        // localhost:62191/api/housingcooperatives/municipality?flooridentifier=1&streetbuildingidentifier=14&municipalitycode=101&sidedoor=TV&streetcode=5192
        [HttpGet]
        [Route("municipality")]
        public async Task<IActionResult> GetByMunicipalityAndStreetCodesAsync([FromQuery] HousingCooperativeApi housingCooperativeApi)
        {
            housingCooperativeApi = NormalizeHousingCooperativeApi(housingCooperativeApi);

            var response = await dbHandler.GetHousingCooperativesByMunicipalityAndStreetCodesAsync(housingCooperativeApi);
            return HandleResponse(response);
        }

        private HousingCooperativeApi NormalizeHousingCooperativeApi(HousingCooperativeApi housingCooperativeApi)
        {
            return new HousingCooperativeApi()
            {
                FloorIdentifier = housingCooperativeApi.FloorIdentifier?.ToUpper(),
                StreetBuildingIdentifier = housingCooperativeApi.StreetBuildingIdentifier?.ToUpper(),
                PostCodeIdentifier = housingCooperativeApi.PostCodeIdentifier,
                SuiteIdentifier = housingCooperativeApi.SuiteIdentifier?.ToUpper(),
                StreetName = housingCooperativeApi.StreetName?.ToTitleCase(),
                MunicipalityCode = housingCooperativeApi.MunicipalityCode,
                StreetCode = housingCooperativeApi.StreetCode
            };
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