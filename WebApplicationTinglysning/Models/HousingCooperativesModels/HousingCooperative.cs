using Google.Cloud.Firestore;

namespace WebApplicationTinglysning.Models.HousingCooperativesModels
{
    [FirestoreData]
    public class HousingCooperative
    {
        // uuid
        [FirestoreProperty("uuid")]
        public string Uuid { get; set; }

        // kommunekode
        [FirestoreProperty("municipalityCode")]
        public string MunicipalityCode { get; set; }

        // vejnavn
        [FirestoreProperty("streetName")]
        public string StreetName { get; set; }

        [FirestoreProperty("streetCode")]
        public string StreetCode { get; set; }

        // husnummer
        [FirestoreProperty("streetBuildingIdentifier")]
        public string StreetBuildingIdentifier { get; set; }

        // postnummer
        [FirestoreProperty("postCodeIdentifier")]
        public string PostCodeIdentifier { get; set; }

        // Distriktsnavn
        [FirestoreProperty("districtName")]
        public string DistrictName { get; set; }

        [FirestoreProperty("districtSubdivisionIdentifier")]
        public string DistrictSubdivisionIdentifier { get; set; }

        // etage
        [FirestoreProperty("floorIdentifier")]
        public string FloorIdentifier { get; set; }

        // SideDoer
        [FirestoreProperty("suiteIdentifier")]
        public string SuiteIdentifier { get; set; }
    }
}
