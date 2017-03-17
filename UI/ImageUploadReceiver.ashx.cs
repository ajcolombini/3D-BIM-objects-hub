using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace UI
{
    /// <summary>
    /// Summary description for ImageUploadReceiver
    /// </summary>
    public class ImageUploadReceiver : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                context.Response.Expires = -1;
                HttpFileCollection files = context.Request.Files;
                
                //string pathrefer = context.Request.UrlReferrer.ToString();
                for (int i = 0; i < files.Count; i++)
                {
                    string file = string.Empty;
                    var postedFile = context.Request.Files[i];
                    var extraData = context.Request.Params["id"];

                    string newId = extraData;
                    string fileDirectory = HttpContext.Current.Server.MapPath("tempFiles/img/") + newId;


                    //In case of IE
                    if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")
                    {
                        string[] arrFiles = postedFile.FileName.Split(new char[] { '\\' });
                        file = arrFiles[arrFiles.Length - 1];
                    }
                    else // In case of other browsers
                    {
                        file = postedFile.FileName;
                    }


                    if (!Directory.Exists(fileDirectory))
                        Directory.CreateDirectory(fileDirectory);
                                       
                    if (context.Request.QueryString["fileName"] != null)
                    {
                        file = context.Request.QueryString["fileName"];
                        if (File.Exists(fileDirectory + "\\" + file))
                        {
                            File.Delete(fileDirectory + "\\" + file);
                        }
                    }

                    string ext = Path.GetExtension(fileDirectory + "\\" + file);
                    //file = Guid.NewGuid() + ext; // Creating a unique name for the file 

                    var fileNamePath = fileDirectory + "\\" + file;

                    postedFile.SaveAs(fileNamePath);
                }//for

                context.Response.AddHeader("Vary", "Accept");
                try
                {
                    if (context.Request["HTTP_ACCEPT"].Contains("application/json"))
                        context.Response.ContentType = "application/json";
                    else
                        context.Response.ContentType = "text/plain";
                }
                catch
                {
                    context.Response.ContentType = "text/plain";
                }

                // store a successful response (default at least an empty array). You
                // could return any additional response info you need to the plugin for
                // advanced implementations.             
                context.Response.Write("{}"); 

            }
            catch (HttpException ex)
            {
                var serializer = new JavaScriptSerializer();
                string jsonError = serializer.Serialize(new { error = string.Format("Erro ao enviar arquivos: {0}", ex.Message) });
                context.Response.Write(jsonError);
            }
            catch (Exception exp)
            {
                var serializer = new JavaScriptSerializer();
                string jsonError = serializer.Serialize(new { error = string.Format("Erro ao enviar arquivos: {0}", exp.Message) });
                context.Response.Write(jsonError);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}