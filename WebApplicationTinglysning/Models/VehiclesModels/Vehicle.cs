using Google.Cloud.Firestore;

namespace WebApplicationTinglysning.Models
{
    [FirestoreData]
    public class Vehicle
    {
        [FirestoreProperty("uuid")]
        public string Uuid { get; set; }

        // Stelnummer
        [FirestoreProperty("chassisNumber")]
        public string ChassisNumber { get; set; }

        // BilFabrikat
        [FirestoreProperty("carManufacturer")]
        public string CarManufacturer { get; set; }

        // BilModel
        [FirestoreProperty("carModel")]
        public string CarModel { get; set; }

        // Variant
        [FirestoreProperty("variant")]
        public string Variant { get; set; }

        // Registreringsnummer
        [FirestoreProperty("registrationNumber")]
        public string RegistrationNumber { get; set; }

        // FoersteRegistreringsAar
        [FirestoreProperty("firstRegistrationYear")]
        public string FirstRegistrationYear { get; set; }

        // ModelId
        [FirestoreProperty("modelId")]
        public string ModelId { get; set; }

        // Udskrift Dato og Tid
        [FirestoreProperty("transcriptDateAndTime")]
        public string TranscriptDateAndTime { get; set; }

        // Anmeldelse Modtaget Indikator
        [FirestoreProperty("reviewReceivedIndicator")]
        public string ReviewReceivedIndicator { get; set; }

        // EjerUuid
        [FirestoreProperty("ownerUuid")]
        public string OwnerUuid { get; set; }

        // Cvr
        [FirestoreProperty("cvrNumber")]
        public string CvrNumber { get; set; }
    }
}
