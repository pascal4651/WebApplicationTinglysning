using Google.Cloud.Firestore;
using Newtonsoft.Json;
using WebApplicationTinglysning.Models.CompaniesModels;
using System.Collections.Generic;
using WebApplicationTinglysning.Models;
using System.Threading.Tasks;

namespace WebApplicationTinglysning.Servises
{
    public class CompanyDbHandler
    {
        FirestoreDb db;

        public CompanyDbHandler()
        {
            db = new FirestoreContext().Database;
        }

        public async Task<ResponseObject> GetDocumentTypesAsync()
        {
            return await GetTypesAsync("documentTypes");
        }

        public async Task<ResponseObject> GetRoleTypesAsync()
        {
            return await GetTypesAsync("roleTypes");
        }

        public async Task<ResponseObject> GetTypesAsync(string collectionName)
        {
            QuerySnapshot typesSnapshot = await db.Collection(collectionName).GetSnapshotAsync();

            var resultsDictionary = new Dictionary<string, Dictionary<string, object>>();
            if (typesSnapshot.Count > 0)
            {
                foreach (var snapShot in typesSnapshot.Documents)
                {
                    resultsDictionary.Add(snapShot.Id, snapShot.ToDictionary());
                }
            }
            if (resultsDictionary.Count > 0)
            {
                return new ResponseObject
                {
                    ResponseStatus = ResponseStatus.OK,
                    Content = JsonConvert.SerializeObject(resultsDictionary)
                };
            }
            return await GetTypesFromService(collectionName);
        }

        public async Task<ResponseObject> GetTypesFromService(string collectionName)
        {
            string uri = collectionName == "documentTypes" ? $"https://www.tinglysning.dk/tinglysning/ssl/soegvirksomhed/dokumenttyper" :
                $"https://www.tinglysning.dk/tinglysning/ssl/soegvirksomhed/rolletyper";

            string typesDataJson = HttpWebHandler.DoSSLGet(uri);

            var typesData = JsonConvert.DeserializeObject<Dictionary<string, List<DocumentItem>>>(typesDataJson);

            if (typesData != null && typesData.Count > 0)
            {
                foreach (var type in typesData)
                {
                    var docContent = new Dictionary<string, string> ();
                    if (type.Value.Count > 0)
                    {
                        foreach (var item in type.Value)
                        {
                            docContent.Add(item.Key, item.Val);
                        }
                        await db.Collection(collectionName).Document(type.Key).SetAsync(docContent);
                    }
                }
                return new ResponseObject
                {
                    ResponseStatus = ResponseStatus.OK,
                    Content = JsonConvert.SerializeObject(typesData)
                };
            }
            else if (typesData.Count == 0)
            {
                return new ResponseObject
                {
                    ResponseStatus = ResponseStatus.NOT_FOUND,
                    Content = typesDataJson ?? ""
                };
            }
            return new ResponseObject
            {
                ResponseStatus = ResponseStatus.BAD_REQUEST,
                Content = typesDataJson ?? ""
            };
        }
    }
}
