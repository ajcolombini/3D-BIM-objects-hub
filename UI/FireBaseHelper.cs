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

namespace UI
{
    public class FireBaseHelper
    {
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

        protected const string BasePath = "https://firesharp.firebaseio.com/";
        protected const string BasePathWithoutSlash = "https://firesharp.firebaseio.com";
        protected static string _apiKey = ConfigurationManager.AppSettings["FireBaseToken"];
     
        public FirebaseConfig fbConfig = new FirebaseConfig(_apiKey);
        

        public async void SetDataToFirebase(string text)
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret =  "AIzaSyA3LGLgBNc9mxQEPDqSg9GzqKhsIUtW0lI",
                BasePath = "https://dhub-4bd37.firebaseio.com/"
            };
            IFirebaseClient client;

            //Initializing FirebaseClient with reference link
            client = new FirebaseClient(config);
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("Name", text);
            var response = await client.PushAsync("FireSharp/Name/", values);
            
        }

        
    }
}