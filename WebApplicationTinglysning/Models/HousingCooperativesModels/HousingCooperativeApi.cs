using System.ComponentModel.DataAnnotations;

namespace WebApplicationTinglysning.Models.HousingCooperativesModels
{
    public class HousingCooperativeApi
    {
        public string StreetName { get; set; }

        public string StreetBuildingIdentifier { get; set; }

        public string PostCodeIdentifier { get; set; }

        public string FloorIdentifier { get; set; }

        public string SideDoor { get; set; }

        public string MunicipalityCode { get; set; }

        public string StreetCode { get; set; }
    }
}
