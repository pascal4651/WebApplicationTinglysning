using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Grpc.Auth;
using Grpc.Core;
using System;
using System.IO;

namespace WebApplicationTinglysning.Servises
{
    public class FirestoreContext : IFireStoreContext
    {
        public FirestoreDb Database { get; }

        public FirestoreContext()
        {
            var path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"Resources/Keys\gcloud_service_account.json"));
            /*
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(path),
            });*/

            var credential = GoogleCredential.FromFile(path);

            var projectID = "tinglysning-b87b2";
            var channelCredentials = credential.ToChannelCredentials();
            var channel = new Channel(FirestoreClient.DefaultEndpoint.ToString(), channelCredentials);
            var firestoreClient = FirestoreClient.Create(channel);

            Database = FirestoreDb.Create(projectID, client: firestoreClient);
        }
    }
}
