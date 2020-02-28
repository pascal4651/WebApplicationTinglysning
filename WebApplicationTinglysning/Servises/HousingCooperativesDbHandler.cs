using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationTinglysning.Models;
using WebApplicationTinglysning.Models.HousingCooperativesModels;

namespace WebApplicationTinglysning.Servises
{
    public class HousingCooperativesDbHandler
    {
        FirestoreDb db;
        CollectionReference collection;

        public HousingCooperativesDbHandler()
        {
            db = new FirestoreContext().Database;
            collection = db.Collection("housingCooperatives");
        }

        public async Task<ResponseObject> GetHousingCooperativesByAddressAsync(HousingCooperativeApi housingCooperativeApi)
        {
            Query housingCooperativesQuery = collection
                .WhereEqualTo("streetName", housingCooperativeApi.StreetName)
                .WhereEqualTo("streetBuildingIdentifier", housingCooperativeApi.StreetBuildingIdentifier)
                .WhereEqualTo("postCodeIdentifier", housingCooperativeApi.PostCodeIdentifier)
                .WhereEqualTo("floorIdentifier", housingCooperativeApi.FloorIdentifier)
                .WhereEqualTo("sideDoor", housingCooperativeApi.SideDoor);

            QuerySnapshot housingCooperativesSnapshot = await housingCooperativesQuery.GetSnapshotAsync();

            if (housingCooperativesSnapshot.Count > 0)
            {
                var selectedHousingCooperatives = new List<HousingCooperative>();

                foreach (var item in housingCooperativesSnapshot.Documents)
                {
                    var housingCooperative = item.ConvertTo<HousingCooperative>();
                    if (housingCooperative != null)
                    {
                        selectedHousingCooperatives.Add(housingCooperative);
                    }
                }
                if (selectedHousingCooperatives.Count > 0)
                {
                    return new ResponseObject
                    {
                        ResponseStatus = ResponseStatus.OK,
                        Content = JsonConvert.SerializeObject(selectedHousingCooperatives)
                    };
                }
            }
            return await GetFromServiceByAddressAsync(housingCooperativeApi);
        }

        public async Task<ResponseObject> GetFromServiceByAddressAsync(HousingCooperativeApi housingCooperativeApi)
        {
            string uri = string.Format("https://www.tinglysning.dk/tinglysning/ssl/andelsbolig/postnummervej?etage={0}&husnummer={1}&postnummer={2}&sidedoer={3}&vejnavn={4}", 
                housingCooperativeApi.FloorIdentifier,
                housingCooperativeApi.StreetBuildingIdentifier, 
                housingCooperativeApi.PostCodeIdentifier,
                housingCooperativeApi.SideDoor,
                housingCooperativeApi.StreetName);

            return await HandleResponseAsync(uri);
        }


        public async Task<ResponseObject> GetHousingCooperativesByMunicipalityAndStreetCodesAsync(HousingCooperativeApi housingCooperativeApi)
        {
            if (!int.TryParse(housingCooperativeApi.MunicipalityCode, out int municipalityCode))
            {
                return new ResponseObject
                {
                    ResponseStatus = ResponseStatus.BAD_REQUEST,
                    Content = "Wrong municipality code input"
                };
            }
            Query housingCooperativesQuery = collection
                .WhereEqualTo("streetCode", housingCooperativeApi.StreetCode)
                .WhereEqualTo("streetBuildingIdentifier", housingCooperativeApi.StreetBuildingIdentifier)
                .WhereEqualTo("municipalityCode", municipalityCode.ToString("D4"))
                .WhereEqualTo("floorIdentifier", housingCooperativeApi.FloorIdentifier)
                .WhereEqualTo("sideDoor", housingCooperativeApi.SideDoor);

            QuerySnapshot housingCooperativesSnapshot = await housingCooperativesQuery.GetSnapshotAsync();

            if (housingCooperativesSnapshot.Count > 0)
            {
                var selectedHousingCooperatives = new List<HousingCooperative>();

                foreach (var item in housingCooperativesSnapshot.Documents)
                {
                    var housingCooperative = item.ConvertTo<HousingCooperative>();
                    if (housingCooperative != null)
                    {
                        selectedHousingCooperatives.Add(housingCooperative);
                    }
                }
                if (selectedHousingCooperatives.Count > 0)
                {
                    return new ResponseObject
                    {
                        ResponseStatus = ResponseStatus.OK,
                        Content = JsonConvert.SerializeObject(selectedHousingCooperatives)
                    };
                }
            }
            return await GetFromServiceByMunicipalityAndStreetCodesAsync(housingCooperativeApi);
        }

        public async Task<ResponseObject> GetFromServiceByMunicipalityAndStreetCodesAsync(HousingCooperativeApi housingCooperativeApi)
        {
            string uri = string.Format("https://www.tinglysning.dk/tinglysning/ssl/andelsbolig/kommunevej?etage={0}&husnummer={1}&kommunekode={2}&sidedoer={3}&vejkode={4}",
                housingCooperativeApi.FloorIdentifier,
                housingCooperativeApi.StreetBuildingIdentifier,
                housingCooperativeApi.MunicipalityCode,
                housingCooperativeApi.SideDoor,
                housingCooperativeApi.StreetCode);

            return await HandleResponseAsync(uri);
        }

        private async Task<ResponseObject> HousingCooperativesLookupAsync(HousingCooperativesJsonResponseModel housingCooperativesData)
        {
            var housingCooperatives = new List<HousingCooperative>();

            foreach (var item in housingCooperativesData.Items)
            {
                if (string.IsNullOrEmpty(item.Uuid))
                {
                    Query housingCooperativesQuery = collection
                        .WhereEqualTo("streetName", item.Vejnavn)
                        .WhereEqualTo("streetBuildingIdentifier", item.Husnummer)
                        .WhereEqualTo("postCodeIdentifier", item.Postnummer)
                        .WhereEqualTo("floorIdentifier", item.Etage)
                        .WhereEqualTo("sideDoor", item.Side);
                    QuerySnapshot housingCooperativesSnapshot = await housingCooperativesQuery.GetSnapshotAsync();
                    if (housingCooperativesSnapshot.Count > 0)
                    {
                        foreach (var i in housingCooperativesSnapshot.Documents)
                        {
                            housingCooperatives.Add(i.ConvertTo<HousingCooperative>());
                        }
                    }
                    else
                    {
                        var newHousingCooperative = new HousingCooperative()
                        {
                            MunicipalityCode = item.Kommunenummer,
                            StreetName = item.Vejnavn,
                            StreetCode = item.Vejkode,
                            StreetBuildingIdentifier = item.Husnummer,
                            PostCodeIdentifier = item.Postnummer,
                            DistrictName = item.Kommunenavn,
                            FloorIdentifier = item.Etage,
                            SideDoor = item.Side
                        };
                        housingCooperatives.Add(newHousingCooperative);
                        await collection.Document().SetAsync(newHousingCooperative);
                    }
                }
                else
                {
                    var newHousingCooperativeUuid = item.Uuid;
                    var document = await collection.Document(newHousingCooperativeUuid).GetSnapshotAsync();
                    if (document.Exists)
                    {
                        housingCooperatives.Add(document.ConvertTo<HousingCooperative>());
                    }
                    else
                    {
                        string bulletinUri = $"https://www.tinglysning.dk/tinglysning/ssl/andelsbolig/andelsbolig/{newHousingCooperativeUuid}";
                        string newHousingCooperativeDataXml = HttpWebHandler.DoSSLGet(bulletinUri);

                        var newHousingCooperativeData = XmlSerializerHelper<AndelSummariskHentResultat>.Deserialaize(newHousingCooperativeDataXml);
                        if (newHousingCooperativeData != null)
                        {
                            var newHousingCooperative = new HousingCooperative()
                            {
                                Uuid = newHousingCooperativeUuid,
                                MunicipalityCode = newHousingCooperativeData.AndelSummarisk.AndelStamoplysninger.AndelIdentifikator.MunicipalityCode,
                                StreetName = newHousingCooperativeData.AndelSummarisk.AndelStamoplysninger.AdresseStruktur.StreetName,
                                StreetCode = newHousingCooperativeData.AndelSummarisk.AndelStamoplysninger.AndelIdentifikator.StreetCode,
                                StreetBuildingIdentifier = newHousingCooperativeData.AndelSummarisk.AndelStamoplysninger.AndelIdentifikator.StreetBuildingIdentifier,
                                PostCodeIdentifier = newHousingCooperativeData.AndelSummarisk.AndelStamoplysninger.AdresseStruktur.PostCodeIdentifier,
                                DistrictName = newHousingCooperativeData.AndelSummarisk.AndelStamoplysninger.AdresseStruktur.DistrictName,
                                FloorIdentifier = newHousingCooperativeData.AndelSummarisk.AndelStamoplysninger.AndelIdentifikator.FloorIdentifier,
                                SideDoor = newHousingCooperativeData.AndelSummarisk.AndelStamoplysninger.AndelIdentifikator.SideDoerTekst
                            };

                            await collection.Document(newHousingCooperativeUuid).SetAsync(newHousingCooperative);
                            housingCooperatives.Add(newHousingCooperative);
                        }
                    }
                }
            }
            return new ResponseObject()
            {
                ResponseStatus = housingCooperatives.Count > 0 ? ResponseStatus.OK : ResponseStatus.NOT_FOUND,
                Content = JsonConvert.SerializeObject(housingCooperatives)
            };
        }

        private async Task<ResponseObject> HandleResponseAsync(string uri)
        {
            string newHousingCooperativesDataJson = HttpWebHandler.DoSSLGet(uri);

            var newHousingCooperativesData = JsonConvert.DeserializeObject<HousingCooperativesJsonResponseModel>(newHousingCooperativesDataJson);


            if (newHousingCooperativesData == null || newHousingCooperativesData.Items == null)
            {
                return new ResponseObject
                {
                    ResponseStatus = ResponseStatus.BAD_REQUEST,
                    Content = newHousingCooperativesDataJson ?? ""
                };
            }
            else if (newHousingCooperativesData.Items.Count == 0)
            {
                return new ResponseObject
                {
                    ResponseStatus = ResponseStatus.NOT_FOUND,
                    Content = newHousingCooperativesDataJson ?? ""
                };
            }
            else
            {
                return await HousingCooperativesLookupAsync(newHousingCooperativesData);
            }
        }
    }
}
