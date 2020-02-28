using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTinglysning.Models;

namespace WebApplicationTinglysning.Servises
{
    public class RealEstatesDbHandler
    {
        FirestoreDb db;
        CollectionReference collection, collectionCadastrals;

        public RealEstatesDbHandler()
        {
            db = new FirestoreContext().Database;
            collection = db.Collection("realEstates");
            collectionCadastrals = db.Collection("cadastrals");
        }

        public async Task<ResponseObject> GetRealEsatesByAddressAsync(RealEstateApi realEstateApi)
        {
            Query realEstateQuery = collection
                .WhereEqualTo("streetName", realEstateApi.StreetName)
                .WhereEqualTo("postCodeIdentifier", realEstateApi.PostCodeIdentifier);
 
            QuerySnapshot realEstatesSnapshot = await realEstateQuery.GetSnapshotAsync();

            if (realEstatesSnapshot.Count > 0)
            {
                var selectedRealEstates = new List<RealEstate>();

                foreach (var item in realEstatesSnapshot.Documents)
                {
                    RealEstate realEstate = item.ConvertTo<RealEstate>();
                    if (realEstate != null && realEstateApi.StreetBuildingIdentifier != null && realEstate.StreetBuildingIdentifier.ToLower().Contains(realEstateApi.StreetBuildingIdentifier.ToLower()))
                    {
                        selectedRealEstates.Add(realEstate);
                    }
                }
                if (selectedRealEstates.Count > 0)
                {
                    return new ResponseObject
                    {
                        ResponseStatus = ResponseStatus.OK,
                        Content = JsonConvert.SerializeObject(selectedRealEstates)
                    };
                }
            }
            return await GetFromServiceByAddressAsync(realEstateApi);
        }

        public async Task<ResponseObject> GetFromServiceByAddressAsync(RealEstateApi realEstateApi)
        {
            string uri = string.Format("https://www.tinglysning.dk/tinglysning/ssl/ejendom/adresse?husnummer={0}&postnummer={1}&vejnavn={2}",
                    realEstateApi.StreetBuildingIdentifier, realEstateApi.PostCodeIdentifier, realEstateApi.StreetName);
            return await HandleResponseAsync(uri);
        }

        public async Task<ResponseObject> GetRealEstatesByCertainNumberAsync(string certainNumber)
        {
            Query realEstateQuery = collection.WhereEqualTo("certainRealEstateNumber", certainNumber);

            QuerySnapshot realEstatesSnapshot = await realEstateQuery.GetSnapshotAsync();

            if (realEstatesSnapshot.Count > 0)
            {
                var selectedRealEstates = new List<RealEstate>();

                foreach (var item in realEstatesSnapshot.Documents)
                {
                    RealEstate realEstate = item.ConvertTo<RealEstate>();
                    if (realEstate != null)
                    {
                        selectedRealEstates.Add(realEstate);
                    }
                }
                if (selectedRealEstates.Count > 0)
                {
                    return new ResponseObject
                    {
                        ResponseStatus = ResponseStatus.OK,
                        Content = JsonConvert.SerializeObject(selectedRealEstates)
                    };
                }
            }
            return await GetFromServiceByCertianNumberAsync(certainNumber);
        }

        public async Task<ResponseObject> GetFromServiceByCertianNumberAsync(string certainNumber)
        {
            string uri = $"https://www.tinglysning.dk/tinglysning/ssl/ejendom/hovednoteringsnummer?hovednoteringsnummer={certainNumber}";
            return await HandleResponseAsync(uri);
        }

        public async Task<ResponseObject> GetRealEstatesByUmaAsync(string uma)
        {
            Query realEstateQuery = collection.WhereEqualTo("unmatriculatedArealDescription", uma);

            QuerySnapshot realEstatesSnapshot = await realEstateQuery.GetSnapshotAsync();

            if (realEstatesSnapshot.Count > 0)
            {
                var selectedRealEstates = new List<RealEstate>();

                foreach (var item in realEstatesSnapshot.Documents)
                {
                    RealEstate realEstate = item.ConvertTo<RealEstate>();
                    if (realEstate != null)
                    {
                        selectedRealEstates.Add(realEstate);
                    }
                }
                if (selectedRealEstates.Count > 0)
                {
                    return new ResponseObject
                    {
                        ResponseStatus = ResponseStatus.OK,
                        Content = JsonConvert.SerializeObject(selectedRealEstates)
                    };
                }
            }
            return await GetFromServiceByUmaAsync(uma);
        }

        public async Task<ResponseObject> GetFromServiceByUmaAsync(string uma)
        {
            string uri = $"https://www.tinglysning.dk/tinglysning/ssl/ejendom/uma/{uma}";
            return await HandleResponseAsync(uri);
        }

        public async Task<ResponseObject> GetRealEstatesByCadastralIdAsync(string cadastralId, string cadastralNumber)
        { 
            Query cadastralQuery = collectionCadastrals
                .WhereEqualTo("cadastralDistrictIdentifier", cadastralId)
                .WhereEqualTo("cadastralNumber", cadastralNumber);

            QuerySnapshot cadastralSnapshot = await cadastralQuery.GetSnapshotAsync();

            if (cadastralSnapshot.Count > 0)
            {
                var selectedRealEstates = new List<RealEstate>();

                foreach (var item in cadastralSnapshot.Documents)
                {
                    Dictionary<string, object> cadastral = item.ToDictionary();
                    DocumentSnapshot snapshot = await collection.Document(cadastral["uuid"].ToString()).GetSnapshotAsync();

                    if (snapshot.Exists)
                    {
                        var realEstate = snapshot.ConvertTo<RealEstate>();
                        if (realEstate != null)
                        {
                            selectedRealEstates.Add(realEstate);
                        }
                    }
                }
                if (selectedRealEstates.Count > 0)
                {
                    return new ResponseObject
                    {
                        ResponseStatus = ResponseStatus.OK,
                        Content = JsonConvert.SerializeObject(selectedRealEstates)
                    };
                }
            }
            return await GetFromServiceByCadastralIdAsync(cadastralId, cadastralNumber);
        }

        public async Task<ResponseObject> GetFromServiceByCadastralIdAsync(string cadastralId, string cadastralNumber)
        {
            string uri = $"https://www.tinglysning.dk/tinglysning/ssl/ejendom/landsejerlavmatrikel?landsejerlavid={cadastralId}&matrikelnr={cadastralNumber}";
            return await HandleResponseAsync(uri);
        }

        public async Task<ResponseObject> GetRealEstatesByMunicipalCodeAndIdAsync(string municipalRealEstateId, string municipalityCode)
        {
            if (!int.TryParse(municipalityCode, out int mCode))
            {
                return new ResponseObject
                {
                    ResponseStatus = ResponseStatus.BAD_REQUEST,
                    Content = "Wrong municipality code input"
                };
            }
            Query realEstateQuery = collection
               .WhereEqualTo("certainRealEstateNumber", municipalRealEstateId)
                .WhereEqualTo("municipalityCode", mCode.ToString("D4"));

            QuerySnapshot realEstatesSnapshot = await realEstateQuery.GetSnapshotAsync();

            if (realEstatesSnapshot.Count > 0)
            {
                var selectedRealEstates = new List<RealEstate>();

                foreach (var item in realEstatesSnapshot.Documents)
                {
                    RealEstate realEstate = item.ConvertTo<RealEstate>();
                    if (realEstate != null)
                    {
                        selectedRealEstates.Add(realEstate);
                    }
                }
                if (selectedRealEstates.Count > 0)
                {
                    return new ResponseObject
                    {
                        ResponseStatus = ResponseStatus.OK,
                        Content = JsonConvert.SerializeObject(selectedRealEstates)
                    };
                }
            }
            return await GetFromServiceByMunicipalCodeAndIdAsync(municipalRealEstateId, municipalityCode);
        }

        public async Task<ResponseObject> GetFromServiceByMunicipalCodeAndIdAsync(string municipalRealEstateId, string municipalityCode)
        {
            string uri = $"https://www.tinglysning.dk/tinglysning/ssl/ejendom/kommune?ejendomsnummer={municipalRealEstateId}&kommunekode={municipalityCode}";
            return await HandleResponseAsync(uri);
        }

        private async Task<ResponseObject> RealEstatesLookupAsync(RealEstateJsonResponseModel realEstatesData)
        {
            var realEstates = new List<RealEstate>();

            foreach (var item in realEstatesData.Items.Take(10))
            {
                var newRealEstateUuid = item.Uuid;
                var document = await collection.Document(newRealEstateUuid).GetSnapshotAsync();
                if (document.Exists)
                {
                    realEstates.Add(document.ConvertTo<RealEstate>());
                }
                else
                {
                    string bulletinUri = $"https://www.tinglysning.dk/tinglysning/ssl/ejdsummarisk/{newRealEstateUuid}";
                    string newRealEstateDataXml = HttpWebHandler.DoSSLGet(bulletinUri);

                    var newRealEstateData = XmlSerializerHelper<EjendomSummariskHentResultat>.Deserialaize(newRealEstateDataXml);
                    if (newRealEstateData != null)
                    {
                        var newRealEstate = new RealEstate()
                        {
                            Uuid = newRealEstateUuid,
                            MunicipalityCode = newRealEstateData.EjendomSummarisk?.EjendomStamoplysninger?.AdresseStruktur?.AddressSpecific?.AddressAccess?.MunicipalityCode,
                            StreetName = newRealEstateData.EjendomSummarisk?.EjendomStamoplysninger?.AdresseStruktur?.StreetName,
                            StreetCode = newRealEstateData.EjendomSummarisk?.EjendomStamoplysninger?.AdresseStruktur?.AddressSpecific?.AddressAccess?.StreetCode,
                            StreetBuildingIdentifier = newRealEstateData.EjendomSummarisk?.EjendomStamoplysninger?.AdresseStruktur?.AddressSpecific?.AddressAccess?.StreetBuildingIdentifier,
                            PostCodeIdentifier = newRealEstateData.EjendomSummarisk?.EjendomStamoplysninger?.AdresseStruktur?.PostCodeIdentifier,
                            DistrictName = newRealEstateData.EjendomSummarisk?.EjendomStamoplysninger?.AdresseStruktur?.DistrictName,
                            DistrictSubdivisionIdentifier = newRealEstateData.EjendomSummarisk?.EjendomStamoplysninger?.AdresseStruktur?.DistrictSubdivisionIdentifier,
                            UnmatriculatedType = newRealEstateData.EjendomSummarisk?.EjendomStamoplysninger?.EjendomIdentifikator?.Umatrikuleretareal?.UmatrikuleretType,
                            UnmatriculatedIdentifier = newRealEstateData.EjendomSummarisk?.EjendomStamoplysninger?.EjendomIdentifikator?.Umatrikuleretareal?.UmatrikuleretIdentifikator,
                            UnmatriculatedArealDescription = newRealEstateData.EjendomSummarisk?.EjendomStamoplysninger?.EjendomIdentifikator?.Umatrikuleretareal?.UmatrikuleretarealBeskrivelse,
                            CertainRealEstateNumber = newRealEstateData.EjendomSummarisk?.EjendomStamoplysninger?.EjendomIdentifikator?.BestemtFastEjendomNummer,
                            MunicipalRealEstateIdentifier = newRealEstateData.EjendomSummarisk?.EjendomStamoplysninger?.EjendomVurderingSamling?.EjendomVurderingStruktur?.RealPropertyStructure?.MunicipalRealPropertyIdentifier,
                            RealEstateValue = newRealEstateData.EjendomSummarisk?.EjendomStamoplysninger?.EjendomVurderingSamling?.EjendomVurderingStruktur?.EjendomVaerdi,
                            Cadastrals = await ConvertCadastralsListAsync(newRealEstateData.EjendomSummarisk?.EjendomStamoplysninger?.EjendomIdentifikator?.Matrikel, newRealEstateUuid),
                        };
                        await collection.Document(newRealEstateUuid).SetAsync(newRealEstate);
                        realEstates.Add(newRealEstate);
                    }
                }
            }
            return new ResponseObject()
            {
                ResponseStatus = realEstates.Count > 0 ? ResponseStatus.OK : ResponseStatus.NOT_FOUND,
                Content = JsonConvert.SerializeObject(realEstates)
            };
        }

        private async Task<List<Cadastral>> ConvertCadastralsListAsync(List<Matrikel> inputList, string realEstateUuid)
        {
            if (inputList != null && inputList.Count > 0)
            {
                var outputList = new List<Cadastral>();

                foreach (var item in inputList)
                {
                    outputList.Add(new Cadastral()
                    {
                        CadastralDistrictName = item.CadastralDistrictName,
                        CadastralDistrictIdentifier = item.CadastralDistrictIdentifier,
                        CadastralNumber = item.Matrikelnummer
                    });

                    // Save cadastral to Firestore
                    await collectionCadastrals.Document().SetAsync(new
                    {
                        uuid = realEstateUuid,
                        cadastralDistrictName = item.CadastralDistrictName,
                        cadastralDistrictIdentifier = item.CadastralDistrictIdentifier,
                        cadastralNumber = item.Matrikelnummer
                    });
                }
                return outputList;
            }
            return null;
        }

        private async Task<ResponseObject> HandleResponseAsync(string uri)
        {
            string newRealEstateDataJson = HttpWebHandler.DoSSLGet(uri);

            var newRealEstatesData = JsonConvert.DeserializeObject<RealEstateJsonResponseModel>(newRealEstateDataJson);

            if (newRealEstatesData == null || newRealEstatesData.Items == null)
            {
                return new ResponseObject
                {
                    ResponseStatus = ResponseStatus.BAD_REQUEST,
                    Content = newRealEstateDataJson ?? ""
                };
            }
            else if (newRealEstatesData.Items.Count == 0)
            {
                return new ResponseObject
                {
                    ResponseStatus = ResponseStatus.NOT_FOUND,
                    Content = newRealEstateDataJson ?? ""
                };
            }
            else
            {
                return await RealEstatesLookupAsync(newRealEstatesData);
            }
        }
    }
}
