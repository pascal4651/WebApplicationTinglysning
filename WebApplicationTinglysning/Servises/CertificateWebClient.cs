using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace WebApplicationTinglysning.Servises
{
    class CertificateWebClient : WebClient
    {
        private readonly X509Certificate2 certificate;

        public CertificateWebClient(X509Certificate2 cert)
        {
            certificate = cert;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
            ServicePointManager.ServerCertificateValidationCallback = delegate (object obj, X509Certificate X509certificate, X509Chain chain, System.Net.Security.SslPolicyErrors errors)
            {
                return true;
            };

            if (!request.ClientCertificates.Contains(certificate))
            {
                request.ClientCertificates.Add(certificate);
            }
            return request;
        }
    }
}
