using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTinglysning.Models;

namespace WebApplicationTinglysning.Servises
{
    public class VehiclesDbHandler
    {
        FirestoreDb db;
        CollectionReference collection;

        public VehiclesDbHandler()
        {
            db = new FirestoreContext().Database;
            collection = db.Collection("vehicles");
        }

        public async Task<ResponseObject> GetVehiclesByChassisNumberAsync(string chassisNumber)
        {
            Query vehiclesQuery = collection.WhereEqualTo("chassisNumber", chassisNumber);
            QuerySnapshot vehiclesSnapshot = await vehiclesQuery.GetSnapshotAsync();

            if (vehiclesSnapshot.Count > 0)
            {
                var selectedVehicles = new List<Vehicle>();

                foreach (var item in vehiclesSnapshot.Documents)
                {
                    selectedVehicles.Add(item.ConvertTo<Vehicle>());
                }
                if (selectedVehicles.Count > 0)
                {
                    return new ResponseObject
                    {
                        ResponseStatus = ResponseStatus.OK,
                        Content = JsonConvert.SerializeObject(selectedVehicles)
                    };
                }
            }
            return await GetFromServiceByChassisNumberAsync(chassisNumber);
        }

        public async Task<ResponseObject> GetFromServiceByChassisNumberAsync(string chassisNumber)
        {
            string uri = $"https://www.tinglysning.dk/tinglysning/unsecrest/soegbil?stelnr={chassisNumber}";
            return await HandleResponseAsync(uri);
        }

        public async Task<ResponseObject> GetVehiclesByCvrAsync(string cvr)
        {
            Query vehiclesQuery = collection.WhereEqualTo("cvrNumber", cvr);
            QuerySnapshot vehiclesSnapshot = await vehiclesQuery.GetSnapshotAsync();

            if (vehiclesSnapshot.Count > 0)
            {
                var selectedVehicles = new List<Vehicle>();

                foreach (var item in vehiclesSnapshot.Documents)
                {
                    selectedVehicles.Add(item.ConvertTo<Vehicle>());
                }
                if (selectedVehicles.Count > 0)
                {
                    return new ResponseObject
                    {
                        ResponseStatus = ResponseStatus.OK,
                        Content = JsonConvert.SerializeObject(selectedVehicles)
                    }; ;
                }
            }
            return await GetVehiclesByCvrAsync(cvr);
        }

        public async Task<ResponseObject> GetServiceByCvrAsync(string cvr)
        {
            string uri = $"https://www.tinglysning.dk/tinglysning/unsecrest/soegbil?cvr={cvr}";
            return await HandleResponseAsync(uri);
        }

        private async Task<ResponseObject> HandleResponseAsync(string uri)
        {
            string newVehiclesDataJson = HttpWebHandler.DoSSLGet(uri);

            var newVehiclesData = JsonConvert.DeserializeObject<VehicleJsonResponseModel>(newVehiclesDataJson);

            if (newVehiclesData == null && newVehiclesData.Items == null)
            {
                return new ResponseObject
                {
                    ResponseStatus = ResponseStatus.BAD_REQUEST,
                    Content = string.IsNullOrEmpty(newVehiclesDataJson) ? null : newVehiclesDataJson
                };
            }
            else if (newVehiclesData.Items.Count == 0)
            {
                return new ResponseObject
                {
                    ResponseStatus = ResponseStatus.NOT_FOUND,
                    Content = string.IsNullOrEmpty(newVehiclesDataJson) ? null : newVehiclesDataJson
                };
            }
            else
            {
                return await VehiclesLookupAsync(newVehiclesData);
            }
        }

        private async Task<ResponseObject> VehiclesLookupAsync(VehicleJsonResponseModel vehiclesData)
        {
            var vehicles = new List<Vehicle>();

            foreach (var item in vehiclesData.Items.Take(10))
            {
                var newVehicleUuid = item.Uuid;
                var document = await collection.Document(newVehicleUuid).GetSnapshotAsync();
                if (document.Exists)
                {
                    vehicles.Add(document.ConvertTo<Vehicle>());
                }
                else
                {
                    string bulletinUri = $"https://www.tinglysning.dk/tinglysning/unsecrest/bil/uuid/{newVehicleUuid}";
                    string newVehicleDataXml = HttpWebHandler.DoSSLGet(bulletinUri);

                    var newVehicleData = XmlSerializerHelper<BilSummariskHentResultat>.Deserialaize(newVehicleDataXml);
                    if (newVehicleData != null)
                    {
                        var newVehicle = new Vehicle()
                        {
                            Uuid = newVehicleUuid,
                            ChassisNumber = newVehicleData.BilSummarisk?.BilStamoplysninger?.BilIdentifikator?.Stelnummer,
                            CarManufacturer = newVehicleData.BilSummarisk?.BilStamoplysninger?.BilStruktur?.BilMaerke?.BilFabrikatTekst,
                            CarModel = newVehicleData.BilSummarisk?.BilStamoplysninger?.BilStruktur?.BilMaerke?.BilModelTekst,
                            Variant = newVehicleData.BilSummarisk?.BilStamoplysninger?.BilStruktur?.BilMaerke?.BilVariantTekst,
                            RegistrationNumber = newVehicleData.BilSummarisk?.BilStamoplysninger?.BilStruktur?.RegistreringsnummerTekst,
                            FirstRegistrationYear = newVehicleData.BilSummarisk?.BilStamoplysninger?.BilStruktur?.FoersteRegistreringsAar,
                            ModelId = newVehicleData.BilSummarisk?.ModelId,
                            TranscriptDateAndTime = newVehicleData.UdskriftDatoTid,
                            ReviewReceivedIndicator = newVehicleData.AnmeldelseModtagetIndikator
                        };
                        await collection.Document(newVehicleUuid).SetAsync(newVehicle);
                        vehicles.Add(newVehicle);
                    }
                }
            }
            return new ResponseObject()
            {
                ResponseStatus = vehicles.Count > 0 ? ResponseStatus.OK : ResponseStatus.NOT_FOUND,
                Content = JsonConvert.SerializeObject(vehicles)
            };
        }
    }
}
