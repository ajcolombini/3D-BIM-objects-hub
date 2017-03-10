using Firebase.Auth;
using FireSharp;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using System.Web.Script.Serialization;
using System.IO;
using System.Net;
using FireSharp.Response;

namespace UI
{
    public class FireBaseHelper : IDisposable
    {
        public static IFirebaseClient client;
        public static IFirebaseConfig config;

        string BasePath;
        string FirebaseToken;


        Firebase()
        {
            BasePath = ConfigurationManager.AppSettings["FireBaseUrl"];
            FirebaseToken = ConfigurationManager.AppSettings["FireBaseToken"];

            config.AuthSecret = FirebaseToken;
            config.BasePath = BasePath;

            client = new FirebaseClient(config);

           // _client = new FirebaseClient(config);
        }

        public string JsonModel { get { return _jsonModel; } }

        #region Model
        private string _jsonModel = @"{
                                              ""manufacturer"": {
                                                ""id"": """",
                                                ""name"": """",
                                                ""logo"": """",
                                                ""eMail"": """",
                                                ""webSite"": """",
                                                ""products"": [
                                                  {
                                                    ""id"": """",
                                                    ""category"": """",
                                                    ""type"": """",
                                                    ""subType"": """",
                                                    ""title"": """",
                                                    ""dimensions"": """",
                                                    ""voltage"": """",
                                                    ""energyConsumpsionClass"": """",
                                                    ""price"": """",
                                                    ""status"": """",
                                                    ""image"": """",
                                                    ""docs"": [
                                                      {
                                                        ""id"": """",
                                                        ""name"": """",
                                                        ""format"": """",
                                                        ""sizeKb"": """",
                                                        ""docObject"": """"
                                                      }
                                                    ]
                                                  },
                                                  {
                                                    ""id"": """",
                                                    ""category"": """",
                                                    ""type"": """",
                                                    ""subType"": """",
                                                    ""title"": """",
                                                    ""dimensions"": """",
                                                    ""voltage"": """",
                                                    ""energyConsumpsionClass"": """",
                                                    ""price"": """",
                                                    ""status"": """",
                                                    ""image"": """",
                                                    ""docs"": [
                                                      {
                                                        ""id"": """",
                                                        ""name"": """",
                                                        ""format"": """",
                                                        ""sizeKb"": """",
                                                        ""docObject"": """"
                                                      }
                                                    ]
                                                  }
                                                ]
                                              }
                                            }";
        #endregion

        #region jsonHelper
        /// <summary>
        /// Post utizando Json
        /// </summary>
        /// <param name="url"></param>
        /// <param name="jsonBody"></param>
        /// <param name="requestMethod">POST ou GET</param>
        /// <returns></returns>
        public string PostJson(string url, string jsonBody, string requestMethod)
        {
            string _result = string.Empty;

            try
            {

                System.Net.HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;

                httpWebRequest.Method = requestMethod.ToUpper(); // "POST" ou "GET";
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.KeepAlive = false;


                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(jsonBody);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    _result = streamReader.ReadToEnd();
                }

            }
            catch (WebException wEx)
            {
                _result = wEx.Message;

                if (wEx.Response != null)
                {
                    using (var stream = wEx.Response.GetResponseStream())
                    {
                        var reader = new StreamReader(stream);
                        var responseString = reader.ReadToEnd();
                        _result = responseString;
                    }
                }
            }
            catch (Exception ex)
            {
                _result = ex.Message;
            }
            return _result;
        }



        /// <summary>
        /// Utiliza JavaScriptSerializer para Serializar Objetos tipo T para Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize"></param>
        /// <returns></returns>
        public string SerializeObjectJson<T>(T objectToSerialize)
        {
            JavaScriptSerializer _serializer = new JavaScriptSerializer();
            string _retJson = string.Empty;
            try
            {
                _retJson = _serializer.Serialize(objectToSerialize);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _serializer = null;
            }

            return _retJson;
        }

        /// <summary>
        /// Deserializa Json string para Objetos tipo T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public T DeserializeObjectJson<T>(string json)
        {
            JavaScriptSerializer _serializer = new JavaScriptSerializer();
            T _ret;

            try
            {
                _ret = _serializer.Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _serializer = null;
            }
            return _ret;
        }
        #endregion


        #region fireBase Helper

        public async Task<PushResponse> SaveManufacturer(Model oModel)
        {
            var response = await client.PushAsync("manufacturer/", oModel.manufacturer);
            return response;
        }

        public async Task<PushResponse> SaveProduct(Model oModel)
        {
            var response = await client.PushAsync("manufacturer/products", oModel.manufacturer.products);
            return response;
        }

        public async Task<PushResponse> SaveDocument(Model oModel, string productId)
        {
            var response = await client.PushAsync("manufacturer/products/documents", oModel.manufacturer.products);
            return response;
        }



        #endregion


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~FireBaseHelper()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            //GC.SuppressFinalize(this);
        }
        #endregion
    }
}