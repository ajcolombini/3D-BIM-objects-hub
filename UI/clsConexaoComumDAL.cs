using System.Configuration;
using System;
using Framework.Security;

namespace DAL
{
    public class clsConexaoComumDAL : IDisposable
    {
        protected string ConnString = null;
        protected string ConnStringLog = null;

        public clsConexaoComumDAL()
        {
            string connectionStringEncriptada = ConfigurationManager.ConnectionStrings["Conexao"].ToString();
            clsCryptionUtil dec = new clsCryptionUtil();
            this.ConnString = dec.Decrypt(connectionStringEncriptada);

            this.ConnStringLog = dec.Decrypt(ConfigurationManager.ConnectionStrings["ConexaoLogIntegrado"].ToString());
        }

        ~clsConexaoComumDAL()
        { 
            this.Dispose(); 
        }

        public void Dispose(){}
        
    }
}
