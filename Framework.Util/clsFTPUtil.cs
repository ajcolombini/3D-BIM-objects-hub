using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace Framework.Util
{
    public class clsFTPUtil
    {
        /// <summary>
        /// ListFiles
        /// </summary>
        public List<string> ListFiles(string rootURL, string folder, string usr, string pwd)
        {
            List<string> lstArquivos = new List<string>();
            //Cria comunicação com o servidor
            //Definir o diretório a ser listado
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(rootURL + folder);
            //Define que a ação vai ser de listar diretório
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            //Credenciais para o login (usuario, senha)
            request.Credentials = new NetworkCredential(usr.Normalize(), pwd.Normalize());
            //modo passivo
            request.UsePassive = true;
            //dados binarios
            request.UseBinary = true;
            //setar o KeepAlive para true
            request.KeepAlive = true;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                //Criando a Stream para pegar o retorno
                Stream responseStream = response.GetResponseStream();
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    //Adicionar os arquivos na lista
                    lstArquivos = reader.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                }
            }

            return lstArquivos;
        }


        /// <summary>
        /// Download de Arquivo
        /// </summary>
        /// <param name="sourceUlr">ulr/path completo do arquivo</param>
        /// <param name="fullDownloadPath">caminho completo para o download</param>
        /// <param name="fileNameToDownload">nome do arquivo</param>
        /// <param name="usr">usuario ftp ou rede</param>
        /// <param name="pwd">senha ftp ou rede</param>
        /// <param name="ftpTimeout">tempo em Minutos para Timeout</param>
        /// <returns></returns>
        public bool DownloadFile(string sourceUlr, string fullDownloadPath, string fileNameToDownload, string usr, string pwd, int ftpTimeout)
        {
            bool _ret = false;


            //Cria comunicação com o servidor
            //definindo o arquivo para download
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(sourceUlr + fileNameToDownload);

            //Define que a ação vai ser de download
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            //Credenciais para o login (usuario, senha)
            request.Credentials = new NetworkCredential(usr.Normalize(), pwd.Normalize());

            //modo passivo
            request.UsePassive = true;
            //dados binarios
            request.UseBinary = true;
            //setar o KeepAlive para true
            request.KeepAlive = true;
            //request timeout em milissegundos, no app.config em minutos
            request.Timeout = ftpTimeout * 60000;

            //criando o objeto FtpWebResponse
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            //Criando a Stream para ler o arquivo
            Stream responseStream = response.GetResponseStream();

            byte[] buffer = new byte[2048];

            //Definir o local onde o arquivo será criado.
            FileStream newFile = new FileStream(Path.Combine(fullDownloadPath, fileNameToDownload), FileMode.Create);
            //Ler o arquivo de origem
            int readCount = responseStream.Read(buffer, 0, buffer.Length);
            while (readCount > 0)
            {
                //Escrever o arquivo
                newFile.Write(buffer, 0, readCount);
                readCount = responseStream.Read(buffer, 0, buffer.Length);
            }
            newFile.Close();
            responseStream.Close();
            response.Close();

            _ret = true;

            return _ret;
        }


        /// <summary>
        /// Upload de Arquivo
        /// </summary>
        /// <param name="sourcePath">caminho origem do arquivo (sem nome do arquivo)</param>
        /// <param name="fullDestinationPath">caminho destino completo (sem nome do arquivo)</param>
        /// <param name="fileNameToUpload">nome do arquivo</param>
        /// <param name="usr">usuario ftp ou rede</param>
        /// <param name="pwd">senha ftp ou rede</param>
        /// <param name="ftpTimeout">tempo em Minutos para Timeout</param>
        /// <returns></returns>
        public bool UploadFile(string sourcePath, string fullDestinationPath, string fileNameToUpload, string usr, string pwd, int ftpTimeout)
        {
            bool _ret = false;

            //Caminho do arquivo para upload
            FileInfo fileInf = new FileInfo(Path.Combine(sourcePath, fileNameToUpload));

            FtpWebRequest requestWeb;

            //Cria comunicação com o servidor
            requestWeb = (FtpWebRequest)FtpWebRequest.Create(Path.Combine(fullDestinationPath, fileNameToUpload));

            //Define que a ação vai ser de upload
            requestWeb.Method = WebRequestMethods.Ftp.UploadFile;

            //Credenciais para o login (usuario, senha)
            requestWeb.Credentials = new NetworkCredential(usr.Normalize(), pwd.Normalize());

            //modo passivo
            requestWeb.UsePassive = true;

            //dados binarios
            requestWeb.UseBinary = true;

            //setar o KeepAlive para false
            requestWeb.KeepAlive = false;

            //request timeout em milissegundos, no app.config em minutos
            requestWeb.Timeout = ftpTimeout * 60000;

            requestWeb.ContentLength = fileInf.Length;

            //cria a stream que será usada para mandar o arquivo via FTP
            Stream responseStream = requestWeb.GetRequestStream();
            byte[] buffer = new byte[2048];

            //Lê o arquivo de origem
            FileStream fs = fileInf.OpenRead();
            try
            {
                //Enquanto vai lendo o arquivo de origem, vai escrevendo no FTP
                int readCount = fs.Read(buffer, 0, buffer.Length);
                while (readCount > 0)
                {
                    //Esceve o arquivo
                    responseStream.Write(buffer, 0, readCount);
                    readCount = fs.Read(buffer, 0, buffer.Length);
                }

                _ret = true;
            }
            catch (Exception) { }
            finally
            {
                fs.Close();
                responseStream.Close();
            }


            return _ret;
        }


        /// <summary>
        /// Rename Files
        /// </summary>
        /// <param name="ftpPath"></param>
        /// <param name="currentFilename"></param>
        /// <param name="newFilename"></param>
        /// <param name="usr">usuario ftp ou rede</param>
        /// <param name="pwd">senha ftp ou rede</param>
        /// <returns></returns>
        public bool RenameFile(string ftpPath, string currentFilename, string newFilename, string usr, string pwd)
        {
            bool _ret = false;
            FtpWebRequest reqFTP = null;
            Stream ftpStream = null;

            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(Path.Combine(ftpPath, currentFilename)));
            reqFTP.Method = WebRequestMethods.Ftp.Rename;
            reqFTP.RenameTo = newFilename;
            reqFTP.UseBinary = true;
            reqFTP.Credentials = new NetworkCredential(usr.Normalize(), pwd.Normalize());
            
            FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            ftpStream = response.GetResponseStream();
            ftpStream.Close();
            response.Close();
            _ret = false;


            if (ftpStream != null)
            {
                ftpStream.Close();
                ftpStream.Dispose();
            }

            return _ret;
        }


        /// <summary>
        /// Auxiliar para MoveFile
        /// </summary>
        /// <param name="ftpBasePath"></param>
        /// <param name="ftpToPath"></param>
        /// <returns></returns>
        public static string GetRelativePath(string ftpBasePath, string ftpToPath)
        {


            if (ftpBasePath.EndsWith("/"))
            {
                ftpBasePath = ftpBasePath.Substring(0, ftpBasePath.Length - 1);
            }

            if (ftpToPath.EndsWith("/"))
            {
                ftpToPath = ftpToPath.Substring(0, ftpToPath.Length - 1);
            }
            string[] arrBasePath = ftpBasePath.Split("/".ToCharArray());
            string[] arrToPath = ftpToPath.Split("/".ToCharArray());

            int basePathCount = arrBasePath.Count();
            int levelChanged = basePathCount;
            for (int iIndex = 0; iIndex < basePathCount; iIndex++)
            {
                if (arrToPath.Count() > iIndex)
                {
                    if (arrBasePath[iIndex] != arrToPath[iIndex])
                    {
                        levelChanged = iIndex;
                        break;
                    }
                }
            }
            int HowManyBack = basePathCount - levelChanged;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < HowManyBack; i++)
            {
                sb.Append("../");
            }
            for (int i = levelChanged; i < arrToPath.Count(); i++)
            {
                sb.Append(arrToPath[i]);
                sb.Append("/");
            }
            for (int i = arrToPath.Count(); i < levelChanged; i++)
            {
                sb.Append("../");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Move a FTP File
        /// http://stackoverflow.com/questions/4864925/how-can-i-use-ftp-to-move-files-between-directories
        /// </summary>
        /// <param name="ftpFullFromPath"></param>
        /// <param name="ftpFullToPath"></param>
        /// <param name="fileName"></param>
        /// <param name="usr"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool MoveFile(string ftpFullFromPath, string ftpFullToPath, string fileName, string usr, string pwd)
        {
            bool _ret = false;


            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpFullFromPath + fileName);
            ftp.Method = WebRequestMethods.Ftp.Rename;
            ftp.Credentials = new NetworkCredential(usr.Normalize(), pwd.Normalize());
            ftp.UsePassive = true;
            ftp.RenameTo = GetRelativePath(ftpFullFromPath, ftpFullToPath) + fileName;

            FtpWebResponse ftpresponse = (FtpWebResponse)ftp.GetResponse();
            _ret = true;


            return _ret;
        }

    }

}
