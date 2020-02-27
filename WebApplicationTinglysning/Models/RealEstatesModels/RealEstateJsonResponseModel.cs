using System.Collections.Generic;

namespace WebApplicationTinglysning.Models
{
    public class RealEstateJsonResponseModel
    {
        public IList<RealEstateResponse> Items { get; set; }
    }

    public class RealEstateResponse
    {
        public string Uuid { get; set; }
        public string Adresse { get; set; }
        public string Vedroerende { get; set; }
        public string Identifikator { get; set; }
        public string Beskrivelse { get; set; }
    }
}