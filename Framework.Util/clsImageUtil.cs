using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.UI;


namespace Framework.Util
{
    public class clsImageUtil:IDisposable
    {

   
        /// <summary>
        /// Converte File em Byte[]
        /// </summary>
        /// <param name="sPath">Caminho do arquivo para ser convertido e salvo no Bando de dados</param>
        /// <returns>Byte[] do Arquivo convertido</returns>
        public byte[] ConvertFileToByteArray(string sPath)
        {
            byte[] data = null;
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            try
            {
                using (FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fStream))
                    {
                        data = br.ReadBytes((int)numBytes);
                        br.Close();
                        fStream.Close();
                    }
                }
            }
            catch (IOException ex)
            {
                throw new IOException(ex.Message);
            }
            return data;
        }


        /// <summary>
        /// Converte Array de Bytes em arquivo
        /// </summary>
        /// <param name="fileBytes">Array de Byte</param>
        /// <param name="caminhoSalvarArquivo">Caminho para salvar o arquivo</param>
        /// <param name="extensaoArquivo">extensão do arquivo</param>
        /// <param name="NomeArquivo">Nome para salvar o arquivo</param>
        public void ConvertByteToFile(Byte[] fileBytes, string caminhoSalvarArquivo, string extensaoArquivo, string NomeArquivo)
        {
            BinaryWriter Writer = null;
            try
            {
                 //Caso não exista o diretório passado, será criado em tempo de execução.
                if (Directory.Exists(caminhoSalvarArquivo) == false){
                    //Criando o diretório
                    Directory.CreateDirectory(caminhoSalvarArquivo);
                }
                else
                {
                    // Create a new stream to write to the file
                    using (Writer = new BinaryWriter(File.OpenWrite(caminhoSalvarArquivo + NomeArquivo + extensaoArquivo)))
                    {
                        // Writer raw data                
                        Writer.Write(fileBytes);
                        Writer.Flush();
                        Writer.Close();
                    }
                }
            }
            catch (Exception ex){
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Converte Array de Bytes em arquivo em browser's
        /// </summary>
        /// <param name="arquivoByte"></param>
        /// <param name="page"></param>
        public void ConvertByteToFileForWeb(byte[] arquivoByte,Page page, string extensaoArquivo)
        {
            #region Abrindo arquivo que esta em byte no browser
            Page _page = page;
            _page.Response.ContentType = "application/" + extensaoArquivo;
            if (arquivoByte != null)
            {
                _page.Response.BinaryWrite(arquivoByte);
                _page.Response.End();
            }
            #endregion
        }

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
        // ~clsImageUtil() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
