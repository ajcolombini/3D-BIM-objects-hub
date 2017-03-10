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

       

    }
}