using Firebase.Auth;
using FireSharp;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

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
        protected string FirebaseSecret = ConfigurationManager.AppSettings["FireBaseToken"];

        private IFirebaseClient _client;

        
        public async void TestFixtureSetUp()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = FirebaseSecret,
                BasePath = BasePath
            };
            _client = new FirebaseClient(config); //Uses Newtonsoft.Json Json Serializer

            var task1 = _client.DeleteAsync("todos");
            var task2 = _client.DeleteAsync("fakepath");

            await Task.WhenAll(task1, task2);
        }

        protected override void FinalizeSetUp()
        { }

        
        public void Delete()
        {
            _client.Push("manufacturer/push", new ManufacturerRegister
            {
                name = "Execute PUSH4GET",
                priority = 2
            });

            var response = _client.Delete("todos/push");
            Assert.NotNull(response);
        }

    }
}