using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Principal;
using Framework.Security;
using System.Collections.Generic;
using System.Reflection;

namespace Framework.Data
{
    /// <summary>
    /// Classe que encapsula a funcionalidade de conexão com o banco de dados SQL Server.
    /// <remarks>Este objeto não é recomendado para projetos Web onde há a abertura de várias conexões.</remarks>
    /// </summary>
    public class clsConexaoSQLServer : IDbConnection
    {
        #region Propriedades privadas

        /// <summary>
        /// Conexão encapsulada.
        /// </summary>
        private SqlConnection _conexao = null;
        /// <summary>
        /// Arquivo de configuração do componente.
        /// </summary>
        private Configuration config = null;

        #endregion

        #region Propriedades públicas

        /// <summary>
        /// Código identificador do sistema que deseja conectar.
        /// </summary>
        public int IdentificadorSistema { get; set; }
        /// <summary>
        /// Descrição resumida (chave) que identifica o sistema na base de dados.
        /// </summary>
        public string DescricaoSistema { get; set; }

        #endregion

        #region Construtor

        /// <summary>
        /// Construtor.
        /// </summary>
        public clsConexaoSQLServer()
        {
            this._conexao = new SqlConnection();

            string pathDLL = Assembly.GetExecutingAssembly().Location;
            pathDLL += ".config";

            ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
            configFile.ExeConfigFilename = pathDLL;

            config = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);

            if (!config.HasFile)
            {
                throw new Exception("Arquivo de configuração não encontrado: " + config.FilePath);
            }

        }

        #endregion

        #region IDbConnection Members

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return this._conexao.BeginTransaction(il);
        }

        public IDbTransaction BeginTransaction()
        {
            return this._conexao.BeginTransaction();
        }

        public void ChangeDatabase(string databaseName)
        {
            this._conexao.ChangeDatabase(databaseName);
        }

        public void Close()
        {
            if (this._conexao.State == ConnectionState.Open)
                this._conexao.Close();
        }

        public string ConnectionString
        {
            get
            {
                // A intenção é não deixar que alguém visualize mesmo.
                return "";
            }
            set
            {
                this._conexao.ConnectionString = value;
            }
        }

        public int ConnectionTimeout
        {
            get { return this._conexao.ConnectionTimeout; }
        }

        public IDbCommand CreateCommand()
        {
            return this._conexao.CreateCommand();
        }

        public string Database
        {
            get { return this._conexao.Database; }
        }

        public void Open()
        {
            if ((this.IdentificadorSistema > 0) && (this.DescricaoSistema != ""))
            {
                this._conexao.ConnectionString = this.ObterConnectionString(this.IdentificadorSistema, this.DescricaoSistema);
                this._conexao.Open();
            }
        }

        public ConnectionState State
        {
            get { return this._conexao.State; }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (this._conexao != null)
            {
                this.Close();
                this._conexao.Dispose();
            }
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Retorna um DataReader com os dados da consulta.
        /// </summary>
        /// <param name="nameProcedure">Nome da Procedure</param>
        /// <param name="listParameter">Lista de Parametros</param>
        /// <returns>DataReader com o resultado da consulta.</returns>
        public SqlDataReader GetDataReader(string procedure, List<SqlParameter> parametros)
        {
            try
            {
                //Instância o sqlcommand com a query sql que será executada e a conexão.
                SqlCommand comando = this._conexao.CreateCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = procedure;

                if (parametros != null)
                    foreach (SqlParameter parametro in parametros)
                    {
                        comando.Parameters.AddWithValue(parametro.ParameterName + "", parametro.SqlDbType).Value = parametro.Value;
                    }

                // Executa a query sql.
                SqlDataReader retornaQuery = comando.ExecuteReader();
                comando.Dispose();

                // Retorna o dataReader com o resultado
                return retornaQuery;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Executa instrução SQL.
        /// </summary>
        /// <param name="nameProcedure">Nome da Procedure</param>
        /// <param name="listParameter">Lista de Parametros</param>
        public void executQuery(string procedure, List<SqlParameter> parametros)
        {
            // Instância o sqlcommand com a query sql que será executada e a conexão.
            try
            {
                SqlCommand comando = this._conexao.CreateCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = procedure;

                if (parametros.Count > 0)
                {
                    foreach (SqlParameter parametro in parametros)
                    {
                        comando.Parameters.AddWithValue(parametro.ParameterName + "", parametro.SqlDbType).Value = parametro.Value;
                    }
                }

                // Executa a query sql.
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Métodos privados

        /// <summary>
        /// Pesquisa a connection string.
        /// </summary>
        /// <param name="idSistema">Id do Sistema desejado.</param>
        /// <param name="nomeResumido">Nome resumido do sistema desejado.</param>
        /// <returns>Connection string.</returns>
        private string ObterConnectionString(int idSistema, string nomeResumido)
        {
            // Senha.
            //string senhaConfig = ConfigurationManager.AppSettings["certificado_01"];
            string senhaConfig = config.AppSettings.Settings["certificado_01"].Value;
            // Salt.
            //string saltConfig = ConfigurationManager.AppSettings["certificado_02"];
            string saltConfig = config.AppSettings.Settings["certificado_02"].Value;
            // ConnectionString.
            //string conexaoConfigEnc = ConfigurationManager.AppSettings["certificado_03"];
            string conexaoConfigEnc = config.AppSettings.Settings["certificado_03"].Value;

            // Dados do usuário e da estação que está em uso.
            string usuario = WindowsIdentity.GetCurrent().Name;
            string estacao = Environment.MachineName;

            // Dados para conexão com o sistema desejado.
            string[] credenciaisSistema = new string[3];

            // Armazena a connection string do sistema desejado.;
            string retorno = null;

            // String para conexão com a base Config.
            string conexaoConfigDec = clsCriptografia.Decriptar(conexaoConfigEnc, senhaConfig, saltConfig);

            // Conexão com a base Config.
            using (SqlConnection conn = new SqlConnection(conexaoConfigDec))
            {
                try
                {
                    // Abre a conexão com a base Config.
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        // Conectou com sucesso.
                        using (SqlCommand command = new SqlCommand())
                        {
                            // Preparação do command para obter os dados de conexão
                            // com o sistema desejado.
                            command.Connection = conn;
                            command.CommandText = "dbo.uspSYSGetDados";
                            command.CommandType = System.Data.CommandType.StoredProcedure;

                            // Parâmetros da consulta.
                            command.Parameters.AddWithValue("@OperationType", 1);
                            command.Parameters.AddWithValue("@inSistemaId", idSistema);
                            command.Parameters.AddWithValue("@vcNomeResumido", nomeResumido);
                            command.Parameters.AddWithValue("@vcUsuario", usuario);
                            command.Parameters.AddWithValue("@vcMaquina", estacao);

                            SqlDataReader reader = command.ExecuteReader();

                            // Obtém os dados da conexão.
                            while (reader.Read())
                            {
                                credenciaisSistema[2] = reader[0].ToString();
                                credenciaisSistema[0] = reader[1].ToString();
                                credenciaisSistema[1] = reader[2].ToString();
                            }

                            // Decripta os dados para retorno.
                            retorno = clsCriptografia.Decriptar(credenciaisSistema[2], credenciaisSistema[0], credenciaisSistema[1]);
                        }
                    }
                    else
                    {
                        retorno = "Erro ao estabelecer conexão.";
                    }
                }
                catch (Exception ex)
                {
                    retorno = "";
                    throw new Exception("(Framework.Data.Conexao.ObterConnectionString)-Erro ao estabelecer conexão.", ex);
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }
            }
            return retorno;
        }

        #endregion
    }
}
