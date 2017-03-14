using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Framework.Security;
using System.Configuration;
using System.Data.SqlClient;

namespace Framework.Data
{
    [Serializable]
    public class clsCrudGenericDAO
    {
        public static T FindId<T>(string nomeProcedure, List<SqlParameter> listParamsProcedure) where T : new()
        {
            DbDataReader reader;
            T entidade = new T();
            Type tipoEntidade = entidade.GetType();
            object codigoSolicita;
            string campo;
            clsCryptionUtil _crypt = new clsCryptionUtil();
            clsConexaoDAO conexao = new clsConexaoDAO(ConfigurationManager.ConnectionStrings[0].ConnectionString);

            if (listParamsProcedure != null)
                reader = conexao.ReturnDataReader(nomeProcedure, listParamsProcedure);
            else
                throw new Exception("No parameters provided for 'listParamsProcedure'");

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    campo = reader.GetName(i);
                    if (tipoEntidade.GetProperties().Where(p => p.Name == campo).Count() > 0)
                    {
                        codigoSolicita = reader.GetValue(i);
                        if (codigoSolicita != DBNull.Value)
                        {
                            //Setando a propriedade
                            tipoEntidade.GetProperty(campo).SetValue(entidade, codigoSolicita, new object[] { });
                        }
                    }
                }
            }
            return entidade;
        }



        public static List<T> FindAny<T>(string nomeProcedure, List<SqlParameter> listaParamentrosProcedure) where T : new()
        {
            List<T> _list = new List<T>();
            DbDataReader reader;
            clsCryptionUtil _crypt = new clsCryptionUtil();
            clsConexaoDAO conexao = new clsConexaoDAO(ConfigurationManager.ConnectionStrings[0].ConnectionString);

            if (listaParamentrosProcedure != null)
                reader = conexao.ReturnDataReader(nomeProcedure, listaParamentrosProcedure);
            else
                reader = conexao.ReturnDataReader(nomeProcedure, null);

            while (reader.Read())
            {
                T entidade = new T();
                Type tipoEntidade = entidade.GetType();
                object codigoSolicita;
                string campo;

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    campo = reader.GetName(i);
                    if (tipoEntidade.GetProperties().Where(p => p.Name == campo).Count() > 0)
                    {
                        codigoSolicita = reader.GetValue(i);
                        if (codigoSolicita != DBNull.Value)
                        {
                            tipoEntidade.GetProperty(campo).SetValue(entidade, codigoSolicita, new object[] { });
                        }
                    }
                }
                _list.Add(entidade);
            }

            return _list;
        }



        public static List<T> FindAll<T>(string nomeProcedure, List<SqlParameter> listaParamentrosProcedure) where T : new()
        {
            List<T> _list = new List<T>();
            DbDataReader reader;
            clsCryptionUtil _crypt = new clsCryptionUtil();
            clsConexaoDAO conexao = new clsConexaoDAO(ConfigurationManager.ConnectionStrings[0].ConnectionString);

            if (listaParamentrosProcedure != null)
                reader = conexao.ReturnDataReader(nomeProcedure, listaParamentrosProcedure);
            else
                reader = conexao.ReturnDataReader(nomeProcedure, null);

            while (reader.Read())
            {
                T entidade = new T();
                Type tipoEntidade = entidade.GetType();
                object codigoSolicita;
                string campo;

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    campo = reader.GetName(i);
                    if (tipoEntidade.GetProperties().Where(p => p.Name == campo).Count() > 0)
                    {
                        codigoSolicita = reader.GetValue(i);
                        if (codigoSolicita != DBNull.Value)
                        {
                            tipoEntidade.GetProperty(campo).SetValue(entidade, codigoSolicita, new object[] { });
                        }
                    }
                }
                _list.Add(entidade);
            }
            return _list;
        }


        public static Guid InsertAndReturnGuid(string nomeProcedure, List<SqlParameter> listParamsProcedure) 
        {
            Guid newId;

            clsCryptionUtil _crypt = new clsCryptionUtil();
            clsConexaoDAO conexao = new clsConexaoDAO(ConfigurationManager.ConnectionStrings[0].ConnectionString);

            if (listParamsProcedure != null)
                newId = conexao.executeQueryReturnOutput(nomeProcedure, listParamsProcedure);
            else
                throw new Exception("No parameters provided for 'listParamsProcedure'");

            return newId;
        }


        public static int InsertAndReturnId(string nomeProcedure, List<SqlParameter> listParamsProcedure)
        {
            int newId;

            clsCryptionUtil _crypt = new clsCryptionUtil();
            clsConexaoDAO conexao = new clsConexaoDAO(ConfigurationManager.ConnectionStrings[0].ConnectionString);

            if (listParamsProcedure != null)
                newId = conexao.executQueryIdentity(nomeProcedure, listParamsProcedure);
            else
                throw new Exception("No parameters provided for 'listParamsProcedure'");

            return newId;
        }

        public static void Delete(string nomeProcedure, List<SqlParameter> listParamsProcedure) 
        {
            clsCryptionUtil _crypt = new clsCryptionUtil();
            clsConexaoDAO conexao = new clsConexaoDAO(ConfigurationManager.ConnectionStrings[0].ConnectionString);

            if (listParamsProcedure != null)
                 conexao.executQuery(nomeProcedure, listParamsProcedure);
            else
                throw new Exception("No parameters provided for 'listParamsProcedure'");
        }

        public static void Update(string nomeProcedure, List<SqlParameter> listParamsProcedure) 
        {
            clsCryptionUtil _crypt = new clsCryptionUtil();
            clsConexaoDAO conexao = new clsConexaoDAO(ConfigurationManager.ConnectionStrings[0].ConnectionString);

            if (listParamsProcedure != null)
                conexao.executQuery(nomeProcedure, listParamsProcedure);
            else
                throw new Exception("No parameters provided for 'listParamsProcedure'");
        }
    }
}
