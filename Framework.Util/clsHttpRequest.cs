using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Security;
using System.Configuration;
using System.IO;
using System.Net;


namespace Framework.Util
{

    /// <summary>
    /// A simple basic class for HTTP Requests.
    /// https://gist.github.com/865296
    /// </summary>
    public class clsHttpRequest
    {

        /// <summary>
        /// UserAgent to be used on the requests
        /// </summary>
        public const string UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:8.0) Gecko/20100101 Firefox/8.0";
        // @"Mozilla/5.0 (Windows; Windows NT 6.1) AppleWebKit/534.23 (KHTML, like Gecko) Chrome/11.0.686.3 Safari/534.23";
                                        


        /// <summary>
        /// Cookie Container that will handle all the cookies.
        /// </summary>
        private CookieContainer cJar;

        /// <summary>
        /// Performs a basic HTTP GET request.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="follow_redirect">Follow redirection responses</param>
        /// <returns>HTML Content of the response.</returns>
        public string HttpGet(string url, bool follow_redirect)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cJar;
            request.UserAgent = UserAgent;
            request.KeepAlive = false;

            if (follow_redirect)
                request.AllowAutoRedirect = false;

            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (follow_redirect && (response.StatusCode == HttpStatusCode.Moved || response.StatusCode == HttpStatusCode.Found))
            {
                while (response.StatusCode == HttpStatusCode.Found || response.StatusCode == HttpStatusCode.Moved)
                {
                    response.Close();
                    request = (HttpWebRequest)HttpWebRequest.Create(response.Headers["Location"]);
                    request.AllowAutoRedirect = false;
                    request.CookieContainer = cJar;
                    response = (HttpWebResponse)request.GetResponse();
                }
            }
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd();
        }


        /// <summary>
        /// Performs a basic HTTP GET request.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="user">usuário para autenticacao</param>
        /// <param name="pwd">senha para autenticacao</param>
        /// <param name="follow_redirect">Follow redirection responses</param>
        /// <returns>HTML Content of the response.</returns>
        public string HttpGet(string url, string user, string pwd, bool follow_redirect)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cJar;
            request.UserAgent = UserAgent;
            request.KeepAlive = false;
            NetworkCredential nc = new NetworkCredential(user, pwd);
            request.Credentials = nc;

            if (follow_redirect)
                request.AllowAutoRedirect = false;

            request.Method = "GET";

            string auth = "Basic " + Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(user + ":" + pwd));
            request.Headers.Add("Authorization", auth);
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (follow_redirect && (response.StatusCode == HttpStatusCode.Moved || response.StatusCode == HttpStatusCode.Found))
            {
                while (response.StatusCode == HttpStatusCode.Found || response.StatusCode == HttpStatusCode.Moved)
                {
                    response.Close();
                    request = (HttpWebRequest)HttpWebRequest.Create(response.Headers["Location"]);
                    request.AllowAutoRedirect = false;
                    request.CookieContainer = cJar;
                    response = (HttpWebResponse)request.GetResponse();
                }
            }
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd();
        }


        /// <summary>
        /// Performs a basic HTTP GET request.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="user">usuário para autenticacao</param>
        /// <param name="pwd">senha para autenticacao</param>
        /// <param name="host"></param>
        /// <returns>The HttpWebResponse object</returns>
        public static HttpWebResponse HttpGet(string url, string user, string pwd)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            CookieContainer _cookies = new CookieContainer();

            request.CookieContainer = _cookies;
            //request.UserAgent = UserAgent;
            request.KeepAlive = true;
            request.AllowAutoRedirect = true;
            request.Method = "GET";
            request.Accept = "*/*";

            ////HACK: add proxy
            //IWebProxy proxy = WebRequest.GetSystemWebProxy();
            //proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            //request.Proxy = proxy;
            //request.PreAuthenticate = true;
            ////HACK: end add proxy

            //string auth = "Basic " + Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(user + ":" + pwd));
            //request.Headers.Add("Authorization", auth);

            // authentication 
            var credential = new CredentialCache();
            credential.Add(new Uri(url), "Basic", new NetworkCredential(user, pwd));
            request.Credentials = credential;
 
            //NetworkCredential nc = new NetworkCredential(user, pwd);
            //request.Credentials = nc;

            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.Moved || response.StatusCode == HttpStatusCode.Found)
            {
                while (response.StatusCode == HttpStatusCode.Found || response.StatusCode == HttpStatusCode.Moved)
                {
                    response.Close();
                    request = (HttpWebRequest)HttpWebRequest.Create(response.Headers["Location"]);
                    request.AllowAutoRedirect = false;
                    request.CookieContainer = _cookies;
                    response = (HttpWebResponse)request.GetResponse();
                }
            }

            return response;
        }



        /// <summary>
        /// Performs a basic HTTP POST request
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="post">POST Data to be passed.</param>
        /// <param name="refer">Referrer of the request</param>
        /// <param name="follow_redirect"></param>
        /// <returns>HTML Content of the response.</returns>
        public string HttpPost(string url, string post, bool follow_redirect, string refer)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cJar;
            request.UserAgent = UserAgent;
            request.KeepAlive = false;
            request.Method = "POST";

            request.Referer = refer;

            if (follow_redirect)
                request.AllowAutoRedirect = false;

            byte[] postBytes = Encoding.ASCII.GetBytes(post);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postBytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (follow_redirect && (response.StatusCode == HttpStatusCode.Moved || response.StatusCode == HttpStatusCode.Found))
            {
                while (response.StatusCode == HttpStatusCode.Found || response.StatusCode == HttpStatusCode.Moved)
                {
                    response.Close();
                    request = (HttpWebRequest)HttpWebRequest.Create(response.Headers["Location"]);
                    request.AllowAutoRedirect = false;
                    request.CookieContainer = cJar;
                    response = (HttpWebResponse)request.GetResponse();
                }
            }
            StreamReader sr = new StreamReader(response.GetResponseStream());

            return sr.ReadToEnd();
        }

        /// <summary>
        /// Creates an HTML file from the string.
        /// </summary>
        /// <param name="html">HTML String.</param>
        public void DebugHtml(string html)
        {
            StreamWriter sw = new StreamWriter("debug.html");
            sw.Write(html);
            sw.Close();
        }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="BReq"/> class.
        ///// </summary>
        //public clsHttpRequest()
        //{
        //    cJar = new CookieContainer();
        //}


        /// <summary>
        /// To ignore SSL certificate errors on HTTPS 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certification"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <returns>True</returns>
        public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }


        /// <summary>
        /// Copy Stream to File
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref=""/> is reclaimed by garbage collection.
        /// </summary>
        ~clsHttpRequest()
        {
            // Nothing here
        }


    }
}
