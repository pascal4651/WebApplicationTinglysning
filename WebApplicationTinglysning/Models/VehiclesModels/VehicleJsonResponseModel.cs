using System.Collections.Generic;

namespace WebApplicationTinglysning.Models
{
    public class VehicleJsonResponseModel
    {
        public List<VehicleResponse> Items { get; set; }
    }

    public class VehicleResponse
    {
        public string Uuid { get; set; }
        public string Stelnummer { get; set; }
        public string Registreringsnummer { get; set; }
        public string Fabrikat { get; set; }
        public string Model { get; set; }
        public string Aargang { get; set; }
        public string Variant { get; set; }
    }
}
