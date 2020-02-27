using Google.Cloud.Firestore;

namespace WebApplicationTinglysning.Servises
{
    public interface IFireStoreContext
    {
        FirestoreDb Database { get; }
    }
}
