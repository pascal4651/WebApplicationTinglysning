using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplicationTinglysning.Helpers;
using WebApplicationTinglysning.Models;
using WebApplicationTinglysning.Servises;

namespace WebApplicationTinglysning.Controllers
{
    [Route("api/realestates")]
    [ApiController]
    public class RealEstatesController : ControllerBase
    {

        RealEstatesDbHandler dbHandler = new RealEstatesDbHandler();

        // Search by address: postCodeIdentifier, districtName, streetBuildingIdentifier (Søgning med adresse)
        // localhost:62191/api/realestates/address?postcodeidentifier=2500&streetname=Retortvej
        // localhost:62191/api/realestates/address?streetbuildingidentifier=8&postcodeidentifier=2500&streetname=Retortvej
        // localhost:62191/api/realestates/address?floorIdentifier=2&streetbuildingidentifier=28A&postcodeidentifier=2500&suiteIdentifier=TV&streetname=Retortvej
        [HttpGet]
        [Route("address")]
        public async Task<IActionResult> GetByAddressAsync([FromQuery] RealEstateApi realEstateApi)
        {
            realEstateApi = NormalizeRealEstateApi(realEstateApi);
            var response = await dbHandler.GetRealEsatesByAddressAsync(realEstateApi);
            return HandleResponse(response);
        }

        // Search by CertainRealEstateNumber (Søgning med Bestemt Fast Ejendomsnummer (BFE-nr.) / hovednoteringsnummer)
        // localhost:62191/api/realestates/certainnumber?certainnumber=6030169
        [HttpGet]
        [Route("certainnumber")]
        public async Task<IActionResult> GetByCertainNumberAsync([FromQuery] string certainNumber)
        {
            
            var response = await dbHandler.GetRealEstatesByCertainNumberAsync(certainNumber);
            return HandleResponse(response);
        }

        // Search by UnmetricatedAreal (Søgning efter umatrikuleret areal)
        // localhost:62191/api/realestates/uma?uma=1UMA0001ama
        [HttpGet]
        [Route("uma")]
        public async Task<IActionResult> GetByUmaAsync([FromQuery] string uma)
        {
            var response = await dbHandler.GetRealEstatesByUmaAsync(uma);
            return HandleResponse(response);
        }

        // Search by CadastralDistrictId and CadastralNumber (Søgning med landsejerlav og matrikelnummer)
        // localhost:62191/api/realestates/cadastralId?cadastralid=2000180&cadastralnumber=3188a
        [HttpGet]
        [Route("cadastralId")]
        public async Task<IActionResult> GetByCadastralDistrictIdAndNumberAsync([FromQuery] string cadastralId, string cadastralNumber)
        {
            var response = await dbHandler.GetRealEstatesByCadastralIdAsync(cadastralId, cadastralNumber.ToLower());
            return HandleResponse(response);
        }

        // Search by MunicipalityCode and MunicipalRealEstateIdentifier (søgning med kommunekode ejendomsnummer (BBR-nummer))
        // localhost:62191/api/realestates/municipalid?municipalRealEstateId=014138&municipalitycode=101
        [HttpGet]
        [Route("municipalId")]
        public async Task<IActionResult> GetByMunicipalCodeAndIdAsync([FromQuery] string municipalRealEstateId, string municipalityCode)
        {
            var response = await dbHandler.GetRealEstatesByMunicipalCodeAndIdAsync(municipalRealEstateId, municipalityCode);
            return HandleResponse(response);
        }

        private RealEstateApi NormalizeRealEstateApi(RealEstateApi realEstateApi)
        {
            return new RealEstateApi()
            {
                FloorIdentifier = realEstateApi.FloorIdentifier?.ToUpper(),
                StreetBuildingIdentifier = realEstateApi.StreetBuildingIdentifier?.ToUpper(),
                PostCodeIdentifier = realEstateApi.PostCodeIdentifier,
                SuiteIdentifier = realEstateApi.SuiteIdentifier?.ToUpper(),
                StreetName = realEstateApi.StreetName?.ToTitleCase()
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
