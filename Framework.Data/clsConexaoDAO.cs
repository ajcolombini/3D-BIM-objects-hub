using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Framework.Data
{
    /// <summary>
    /// Class Conexao Data Access Object.
    /// </summary>
    public class clsConexaoDAO : IDisposable, IDbConnection
    {

        #region Propriedades públicas

        /// <summary>
        /// Propriedade que atribui ou retorna a string de conexão
        /// </summary>
        public string ConnectionString { get; set; }

        #endregion

        #region Propriedades privadas

        //Instância o sqlconnection.
        private SqlConnection sqlconnection = null;

        #endregion

        #region Construtores

        public clsConexaoDAO()
        {
            sqlconnection = new SqlConnection();
        }

        public clsConexaoDAO(string connString)
        {
            sqlconnection = new SqlConnection(connString);
            connection();
        }

        #endregion

        #region Destrutor
        /// <summary>
        /// Destructor of the Class
        /// </summary>
        ~clsConexaoDAO() { }

        #endregion

        #region Métodos públicos

        /// <summary>
        /// Método que retorna um datareader com o resultado da query.
        /// </summary>
        /// <param name="nameProcedure">Nome da Procedure</param>
        /// <param name="listParameter">Lista de Parametros</param>
        /// <returns></returns>
        public SqlDataReader ReturnDataReader(string nameProcedure, List<SqlParameter> listParameter)
        {
            try
            {
                //Instância o sqlcommand com a query sql que será executada e a conexão.
                //SqlCommand comando = new SqlCommand(nameProcedure, connection());
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = nameProcedure;
                comando.Connection = this.sqlconnection;

                if (listParameter != null)
                {
                    foreach (var objList in listParameter)
                    {
                        comando.Parameters.AddWithValue(objList.ParameterName + "", objList.SqlDbType).Value = objList.Value;
                    }
                }
                //Executa a query sql.
                var retornaQuery = comando.ExecuteReader();
                comando.Dispose();

                //Retorna o dataReader com o resultado
                return retornaQuery;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método que retorna o resultado da consulta sql em um dataset.
        /// </summary>
        /// <param name="nameProcedure">Nome da Procedure</param>
        /// <param name="listParameter">Lista de Parametros</param>
        /// <returns></returns>
        public DataSet ReturnDataSet(string nameProcedure, List<SqlParameter> listParameter)
        {
            try
            {
                //Instância o sqlcommand com a query sql que será executada a conexão.
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = nameProcedure;
                comando.Connection = this.sqlconnection;

                if (listParameter != null)
                {
                    foreach (var objList in listParameter)
                    {
                        comando.Parameters.AddWithValue(objList.ParameterName + "", objList.SqlDbType).Value = objList.Value;
                    }
                }

                //Instância o sqldataAdapter.
                SqlDataAdapter adapter = new SqlDataAdapter(comando);

                //Instância o dataSet de retorno.
                DataSet dataSet = new DataSet();

                //Atualiza o dataSet
                adapter.Fill(dataSet);

                comando.Dispose();

                //Retorna o dataSet com o resultado da query sql.
                return dataSet;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método que executa a query sql.
        /// </summary>
        /// <param name="nameProcedure">Nome da Procedure</param>
        /// <param name="listParameter">Lista de Parametros</param>
        public void executQuery(string nameProcedure, List<SqlParameter> listParameter)
        {
            executQuery(nameProcedure, listParameter, null);
        }


        /// <summary>
        /// Método que executa a query sql.
        /// </summary>
        /// <param name="nameProcedure">Nome da Procedure</param>
        /// <param name="listParameter">Lista de Parametros</param>
        /// <param name="SqlTransaction">SqlTransaction</param>
        public void executQuery(string nameProcedure, List<SqlParameter> listParameter, SqlTransaction transaction)
        {
            //Instância o sqlcommand com a query sql que será executada e a conexão.
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = nameProcedure;
                comando.Connection = sqlconnection;//connection(true);

                if (transaction != null)
                    comando.Transaction = transaction;

                if (listParameter.Count > 0)
                {
                    foreach (var objList in listParameter)
                    {
                        comando.Parameters.AddWithValue(objList.ParameterName + "", objList.SqlDbType).Value = objList.Value;
                    }
                }
                //Executa a query sql.
                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método que executa a query sql e retorna o identity.
        /// </summary>
        /// <param name="nameProcedure">Nome da Procedure</param>
        /// <param name="listParameter">Lista de Parametros</param>
        public int executQueryIdentity(string nameProcedure, List<SqlParameter> listParameter)
        {
            try
            {
                //Instância o sqlcommand com a query sql que será executada e a conexão.
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = nameProcedure;
                comando.Connection = this.sqlconnection;

                if (listParameter.Count > 0)
                {
                    foreach (var objList in listParameter)
                    {
                        comando.Parameters.AddWithValue(objList.ParameterName + "", objList.SqlDbType).Value = objList.Value;
                    }
                }

                //Executa a query sql.
                return Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Método que executa a query sql e retorna o identity.
        /// </summary>
        /// <param name="nameProcedure">Nome da Procedure</param>
        /// <param name="listParameter">Lista de Parametros</param>
        /// <param name="SqlTransaction">SqlTransaction</param>
        public int executQueryIdentity(string nameProcedure, List<SqlParameter> listParameter, SqlTransaction transaction)
        {
            return int.Parse(this.executarQueryIdentity(nameProcedure, listParameter, transaction).ToString());
        }

        /// <summary>
        /// Método que executa a query sql e retorna o identity.
        /// </summary>
        /// <param name="nameProcedure">Nome da Procedure</param>
        /// <param name="listParameter">Lista de Parametros</param>
        /// <param name="SqlTransaction">SqlTransaction</param>
        public long executQueryIdentityLong(string nameProcedure, List<SqlParameter> listParameter, SqlTransaction transaction)
        {
            return long.Parse(this.executarQueryIdentity(nameProcedure, listParameter, transaction).ToString());
        }

        /// <summary>
        /// Método que executa a query sql e retorna um Guid (PK).
        /// </summary>
        /// <param name="nameProcedure">Nome da Procedure</param>
        /// <param name="listParameter">Lista de Parametros</param>
        public Guid executeQueryReturnOutput(string nameProcedure, List<SqlParameter> listParameter)
        {
        

            Guid _ret = new Guid();
            SqlCommand comando = new SqlCommand();
            clsConexaoDAO _conn = new clsConexaoDAO();
            try
            {
                //Instância o sqlcommand com a query sql que será executada e a conexão.

                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = nameProcedure;
                comando.Connection = this.sqlconnection;
                comando.UpdatedRowSource = UpdateRowSource.OutputParameters;

                if (listParameter.Count > 0)
                {
                    Debug.Print(nameProcedure + Environment.NewLine);
                    foreach (var objParam in listParameter)
                    {
                        comando.Parameters.AddWithValue(objParam.ParameterName + "", objParam.SqlDbType).Value = objParam.Value;
                        Debug.Print( objParam.ParameterName + " = " + (objParam.Value == DBNull.Value ? "NULL": "," + objParam.Value.ToString()));
                    }
                }

                //Executa a query sql.
                object _retObj = comando.ExecuteScalar();
                _ret = new Guid(_retObj.ToString());
                comando.Dispose();
                return _ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Métodos privados

        /// <summary>
        /// Método que retorna a conexão com a base de dados. O nome da ConnectionString no Web.config deve ser ConnectionAce
        /// </summary>
        /// <returns></returns>
        private void connection()
        {
            try
            {
                if (this.sqlconnection.State != ConnectionState.Open)
                {
                    this.sqlconnection.Open();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao abrir conexão.", ex);
            }
        }

        /// <summary>
        /// Método que executa a query sql e retorna o identity.
        /// </summary>
        /// <param name="nameProcedure">Nome da Procedure</param>
        /// <param name="listParameter">Lista de Parametros</param>
        /// <param name="SqlTransaction">SqlTransaction</param>
        private object executarQueryIdentity(string nameProcedure, List<SqlParameter> listParameter, SqlTransaction transaction)
        {
            clsConexaoDAO _conn = new clsConexaoDAO();
            try
            {
                //Instância o sqlcommand com a query sql que será executada e a conexão.
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = nameProcedure;
                comando.Connection = this.sqlconnection;
                comando.Transaction = transaction;

                if (listParameter.Count > 0)
                {
                    foreach (var objList in listParameter)
                    {
                        comando.Parameters.AddWithValue(objList.ParameterName + "", objList.SqlDbType).Value = objList.Value;
                    }
                }
                //Executa a query sql.
                return comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Dispose Method
        /// </summary>
        public void Dispose()
        {
            if (this.sqlconnection.State == ConnectionState.Open)
                this.sqlconnection.Close();
            this.sqlconnection = null;
        }

        #endregion

        #region IDbConnection Members

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return this.sqlconnection.BeginTransaction(il);
        }

        public IDbTransaction BeginTransaction()
        {
            return this.sqlconnection.BeginTransaction();
        }

        public void ChangeDatabase(string databaseName)
        {
            this.sqlconnection.ChangeDatabase(databaseName);
        }

        public void Close()
        {
            if (this.sqlconnection.State == ConnectionState.Open)
                this.sqlconnection.Close();
        }

        public int ConnectionTimeout
        {
            get { return this.sqlconnection.ConnectionTimeout; }
        }

        public IDbCommand CreateCommand()
        {
            return this.sqlconnection.CreateCommand();
        }

        public string Database
        {
            get { return this.sqlconnection.Database; }
        }

        public void Open()
        {
            this.sqlconnection.Open();
        }

        public ConnectionState State
        {
            get { return this.sqlconnection.State; }
        }

        #endregion
    }
}
