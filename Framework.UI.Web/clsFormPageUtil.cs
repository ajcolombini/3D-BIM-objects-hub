using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Collections.Specialized;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml.Serialization;


namespace Framework.UI.Web
{
    /// <summary>
    /// 2016-08-12:  Acrescentado método PagePostJson
    /// </summary>
    public class clsFormPageUtil
    {
        /// <summary>
        /// Método: PagePost. 
        /// Usado para enviar via post parametros. Exemplo: PagePost("http://www.pagina-destino.com.br", "parametro1=valor1&parametro2=valor2");
        /// </summary>
        /// <param name="uri">Pagina Destino</param>
        /// <param name="parameters">Parametros do Post</param>
        /// <example>PagePost("http://www.pagina-destino.com.br", "parametro1=valor1&parametro2=valor2");</example>
        /// <returns>retorno string do POST</returns>
        public string PagePost(string url, string parameters)
        {
            string _ret = string.Empty;
            //parameters: name1=value1&name2=value2	
            WebRequest webRequest = WebRequest.Create(url);
            //string ProxyString = 
            //System.Configuration.ConfigurationManager.AppSettings
            //[GetConfigKey("proxy")];
            //webRequest.Proxy = new WebProxy (ProxyString, true);
            //Commenting out above required change to App.Config
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(parameters);
            Stream os = null;
            try
            { //Enviando o Post
                webRequest.ContentLength = bytes.Length;   //Count bytes to send
                os = webRequest.GetRequestStream();
                os.Write(bytes, 0, bytes.Length);         //Send it
            }
            catch (WebException ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (os != null)
                {
                    os.Close();
                }
            }

            try
            { // get the response
                WebResponse webResponse = webRequest.GetResponse();
                if (webResponse == null)
                { return null; }
                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                _ret = sr.ReadToEnd().Trim();
            }
            catch (WebException ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return _ret;
        } // end HttpPost 

        /// <summary>
        /// Método: PagePostXML. 
        /// Usado para enviar via post parametros.
        /// </summary>
        /// <param name="uri">Pagina Destino</param>
        /// <param name="parameters">Parametros do Post</param>
        /// <example>PagePost("http://www.pagina-destino.com.br", "parametro1=valor1&parametro2=valor2");</example>
        /// <returns>retorno XML do POST</returns>
        public XmlDocument PagePostXML(string url, string parameters)
        {
            XmlDocument _ret = new XmlDocument();
            //parameters: name1=value1&name2=value2	
            WebRequest webRequest = WebRequest.Create(url);
            //string ProxyString = 
            //System.Configuration.ConfigurationManager.AppSettings
            //[GetConfigKey("proxy")];
            //webRequest.Proxy = new WebProxy (ProxyString, true);
            //Commenting out above required change to App.Config
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(parameters);
            Stream os = null;
            try
            { //Enviando o Post
                webRequest.ContentLength = bytes.Length;   //Count bytes to send
                os = webRequest.GetRequestStream();
                os.Write(bytes, 0, bytes.Length);         //Send it
            }
            catch (WebException ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (os != null) { os.Close(); }
            }

            try
            { // get the response
                WebResponse webResponse = webRequest.GetResponse();
                if (webResponse == null)
                { return null; }
                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                _ret.Load(sr);
            }
            catch (WebException ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return _ret;
        } // end HttpPost 

        public void SetError500()
        {
            HttpContext.Current.Response.StatusCode = 500;
        }


        /// <summary>
        /// Envia POST para uma URL e navega para ela.
        /// </summary>
        /// <param name="contexto">Objeto HttpContext da solicitação.</param>
        /// <param name="parametros">Lista dos parâmetros do POST.</param>
        /// <param name="URL">Página que irá processar a solicitação.</param>
        /// <param name="nomeForm">Nome do formulário.</param>
        public void NavegarPOST(HttpContext contexto, NameValueCollection parametros, string URL, string nomeForm)
        {
            // Limpa o Response.
            contexto.Response.Clear();

            // Prepara a página.
            contexto.Response.Write("<html><head>");
            contexto.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", nomeForm));
            contexto.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", nomeForm, "POST", URL));

            // Inclui os parâmetros informados na página.
            for (int i = 0; i < parametros.Keys.Count; i++)
            {
                contexto.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", parametros.Keys[i], parametros[parametros.Keys[i]]));
            }

            contexto.Response.Write("</form>");
            contexto.Response.Write("</body></html>");
        }

        /// <summary>
        /// Post utizando Json
        /// </summary>
        /// <param name="url"></param>
        /// <param name="jsonBody"></param>
        /// <param name="requestMethod">POST ou GET</param>
        /// <returns></returns>
        public string PagePostJson(string url, string jsonBody, string requestMethod)
        {
            string _result = string.Empty;

            try
            {

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
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


    }
}
