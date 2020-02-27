using System.Collections.Generic;

namespace WebApplicationTinglysning.Models.HousingCooperativesModels
{
    public class HousingCooperativesJsonResponseModel
    {
        public List<HousingCooperativeResponse> Items { get; set; }
    }
    public class HousingCooperativeResponse
    {
        public string Uuid { get; set; }
        public string Kommunenummer { get; set; }
        public string Kommunenavn { get; set; }
        public string Postnummer { get; set; }
        public string Postdistrikt { get; set; }
        public string Vejkode { get; set; }
        public string Vejnavn { get; set; }
        public string Husnummer { get; set; }
        public string Etage { get; set; }
        public string Side { get; set; }
    }
}
