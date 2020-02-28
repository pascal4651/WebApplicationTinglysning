using System;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace WebApplicationTinglysning.Servises
{
    public class HttpWebHandler
    {
        private const string FOCES_PATH = @"C:\Users\os\Downloads\FOCES_gyldig_2022_2.p12";

        public static string DoSSLGet(string uri)
        {
            string response = string.Empty;
            try
            {
                X509Certificate2 clientCertificate = new X509Certificate2(FOCES_PATH, "FunktionerSignatur4242");
                CertificateWebClient myWebClient = new CertificateWebClient(clientCertificate);

                response = myWebClient.DownloadString(uri);
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    HttpWebResponse resp = wex.Response as HttpWebResponse;
                    StreamReader streamReader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
                    string body = streamReader.ReadToEnd();
                    response = body;
                }
                else
                {
                    response = wex.Message;
                }
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }

        public static string DoSSLPost(string uri)
        {
            string response = string.Empty;
            try
            {
                X509Certificate2 clientCertificate = new X509Certificate2(FOCES_PATH, "FunktionerSignatur4242");
                CertificateWebClient myWebClient = new CertificateWebClient(clientCertificate);

                response = myWebClient.UploadString(uri, "POST", "textBoxPost.Text"); //*******
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    HttpWebResponse resp = wex.Response as HttpWebResponse;
                    StreamReader streamReader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
                    string body = streamReader.ReadToEnd();
                    response = body;
                }
                else
                {
                    response = wex.Message;
                }
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
    }
}
