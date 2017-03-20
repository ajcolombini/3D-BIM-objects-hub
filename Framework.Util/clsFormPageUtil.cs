using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Web;
using System.Xml;

namespace Framework.Util
{
    public class clsFormPageUtil
    {
        /// <summary>
        /// Método: PagePost. 
        /// Usado para enviar via post parametros. Exemplo: PagePost("http://www.pagina-destino.com.br", "parametro1=valor1&parametro2=valor2");
        /// </summary>
        /// <param name="uri">Pagina Destino</param>
        /// <param name="parameters">Parametros do Post</param>
        /// <example></example>
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
             
            //byte[] bytes = Encoding.ASCII.GetBytes(parameters);
            byte[] bytes = Encoding.UTF8.GetBytes(parameters);
            // byte[] bytes = Encoding.Unicode.GetBytes(parameters);
            // byte[] bytes = Encoding.Default.GetBytes(parameters);

             Stream os = null; //Object Stream
             try
             { 
                 //Enviando o Post
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
                 if (os != null){os.Close();}
             }

             try
             { // get the response
                 WebResponse webResponse = webRequest.GetResponse();
                 if (webResponse == null)
                 { 
                     return null; 
                 }
                 StreamReader sr = new StreamReader(webResponse.GetResponseStream());

                 var Encode = sr.CurrentEncoding;
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
            catch (WebException ex){
                throw new Exception(ex.Message.ToString());
            }
            finally{
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
            catch (WebException ex){
                throw new Exception(ex.Message.ToString());
            }
            return _ret;
        } // end HttpPost 
        
        #region SetError500
        public static void SetError500() {
            HttpContext.Current.Response.StatusCode = 500;
        }


       #endregion

        /// <summary>
        /// Baixa arquivo de um link com o nome do arquivo ex: http://www1.caixa.gov.br/loterias/_arquivos/loterias/D_mgsasc.zip. Baixa o arquivo D_mgsasc.zip.
        /// </summary>
        /// <param name="urlWithFileName">Url para arquivo ou serviço com o arquivo a baixar</param>
        /// <param name="pathToSave">Caminho para Baixar o arquivo</param>
        /// <returns>booleano</returns>
        private bool DownLoadFile(string urlWithFileName, string pathToSave)
        {
            //thanks to http://www.vbdotnetheaven.com/UploadFile/bfarley/FileDownload04182005043858AM/FileDownload.aspx
   
            try
            {
                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(urlWithFileName);
                wr.Method = "GET";
                wr.KeepAlive = true;
                wr.AllowAutoRedirect = true;
                wr.PreAuthenticate = true;
                CookieContainer cookieContainer = new CookieContainer();
                wr.CookieContainer = cookieContainer;
                HttpWebResponse ws = (HttpWebResponse)wr.GetResponse();

                Stream str = ws.GetResponseStream();
                byte[] inBuf = new byte[100001];
                int bytesToRead = Convert.ToInt32(inBuf.Length);
                int bytesRead = 0;
                string sSaveDir = null;
                FileStream fstr = null;

                sSaveDir = pathToSave;

                string fileName = string.Empty;

                if (string.IsNullOrEmpty(fileName))
                {
                    fileName = urlWithFileName.Substring( urlWithFileName.LastIndexOf("/") + 2, urlWithFileName.Length - urlWithFileName.LastIndexOf("/"));
                }
     

                while (bytesToRead > 0)
                {
                    int n = str.Read(inBuf, bytesRead, bytesToRead);
                    if (n == 0)
                    {
                        break; 
                    }
                    bytesRead += n;
                    bytesToRead -= n;
                }
                fstr = new FileStream(sSaveDir + "\\" + fileName, FileMode.OpenOrCreate, FileAccess.Write);


                fstr.Write(inBuf, 0, bytesRead);

                str.Close();
                fstr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.ToString());
            }
            finally
            {
               
            }

            return true;

        }


    }
}
