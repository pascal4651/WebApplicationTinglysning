using Google.Cloud.Firestore;
using System.Collections.Generic;

namespace WebApplicationTinglysning.Models
{
    [FirestoreData]
    public class RealEstate
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

        // Distriktsnavn
        [FirestoreProperty("districtSubdivisionIdentifier")]
        public string DistrictSubdivisionIdentifier { get; set; }


        // UmatrikuleretType
        [FirestoreProperty("unmatriculatedType")]
        public string UnmatriculatedType { get; set; }

        // Umatrikuleret Identifikator
        [FirestoreProperty("unmatriculatedIdentifier")]
        public string UnmatriculatedIdentifier { get; set; }

        // Umatrikuleretareal Beskrivelse
        [FirestoreProperty("unmatriculatedArealDescription")]
        public string UnmatriculatedArealDescription { get; set; }

        // hovednoteringsnummer (BestemtFastEjendomNummer)
        [FirestoreProperty("certainRealEstateNumber")]
        public string CertainRealEstateNumber { get; set; }

        // ejendomsnummer
        [FirestoreProperty("municipalRealEstateIdentifier")]
        public string MunicipalRealEstateIdentifier { get; set; }

        // ejendomVaerdi
        [FirestoreProperty("realEstateValue")]
        public string RealEstateValue { get; set; }

        // matrikel
        [FirestoreProperty("cadastrals")]
        public List<Cadastral> Cadastrals { get; set; }


        // landsejerlavid
        [FirestoreProperty("landOwnerId")]
        public string LandOwnerId { get; set; }


        // etage
        [FirestoreProperty("floorIdentifier")]
        public string FloorIdentifier { get; set; }

        // SideDoer
        [FirestoreProperty("sideDoor")]
        public string SideDoor { get; set; }
    }


    [FirestoreData]
    public class Cadastral
    {
        [FirestoreProperty("cadastralDistrictName")]
        public string CadastralDistrictName { get; set; }

        [FirestoreProperty("cadastralDistrictIdentifier")]
        public string CadastralDistrictIdentifier { get; set; }

        // matrikelnummer
        [FirestoreProperty("cadastralNumber")]
        public string CadastralNumber { get; set; }
    }
}
