using System.ComponentModel.DataAnnotations;

namespace WebApplicationTinglysning.Models
{
    public class RealEstateApi
    {
        public string FloorIdentifier { get; set; }

        public string StreetBuildingIdentifier { get; set; }

        public string PostCodeIdentifier { get; set; }

        public string SideDoor { get; set; }

        public string StreetName { get; set; }
    }
}
