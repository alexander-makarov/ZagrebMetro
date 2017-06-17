using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RestRequestHelpers
{
    public static class RestRequestHelper
    {
        /// <summary>
        /// POST a JSON string
        /// </summary>
        /// <param name="url"></param>
        /// <param name="jsonContent"></param>
        /// <param name="clientCertificate"></param>
        /// <param name="allowUncertifiedServer"> True to trust all server (even with self signed certificates)
        /// <remarks>
        /// https://stackoverflow.com/questions/703272/could-not-establish-trust-relationship-for-ssl-tls-secure-channel-soap
        /// https://stackoverflow.com/questions/9983265/the-remote-certificate-is-invalid-according-to-the-validation-procedure
        /// </remarks>
        /// </param>
        /// <returns></returns>

        public static string POST(string url, string jsonContent, X509Certificate clientCertificate = null, bool allowUncertifiedServer = true)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            if (allowUncertifiedServer) request.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            if (clientCertificate != null) request.ClientCertificates.Add(clientCertificate);

            var encoding = new System.Text.UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(jsonContent);

            request.ContentLength = byteArray.Length;
            request.ContentType = @"application/json";

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                if (errorResponse != null)
                {
                    using (Stream responseStream = errorResponse.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                        String errorText = reader.ReadToEnd(); // xml-html fault message
                        var exc = new WebException(errorText, ex);
                        throw exc;
                    }
                }
                throw;
            }
        }

        /// <summary>
        ///  Returns JSON string
        /// </summary>
        /// <param name="url"></param>
        /// <param name="clientCertificate"></param>
        /// <param name="allowUncertifiedServer"> True to trust all server (even with self signed certificates)
        /// <remarks>
        /// https://stackoverflow.com/questions/703272/could-not-establish-trust-relationship-for-ssl-tls-secure-channel-soap
        /// https://stackoverflow.com/questions/9983265/the-remote-certificate-is-invalid-according-to-the-validation-procedure
        /// </remarks>
        /// </param>
        /// <returns></returns>
        public static string GET(string url, X509Certificate clientCertificate = null, bool allowUncertifiedServer = true)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            if (allowUncertifiedServer) request.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            if (clientCertificate != null) request.ClientCertificates.Add(clientCertificate);

            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                if (errorResponse != null)
                {
                    using (Stream responseStream = errorResponse.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                        String errorText = reader.ReadToEnd(); // xml-html fault message
                        var exc = new WebException(errorText, ex);
                        throw exc;
                    }
                }
                throw;
            }
        }
    }
}
