using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BIM.Model;
using Framework.Data;


namespace BIM.DAL
{
    /// <summary>
    /// Class Module Data Access Object
    /// </summary>
    public class clsModuleDAO
    {
        /// <summary>
        /// Log de Execução
        /// </summary>
        public static string ExecutedQuery { get; set; }

        /// <summary>
        /// FindAll Module
        /// </summary>
        /// <returns>List clsModuleBO</returns>
        public static List<clsModuleBO> FindAll()
        {
            List<clsModuleBO> _list = new List<clsModuleBO>();
            SqlDataReader dr;
            
            try
            {
                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    //Chamando o DataReader passando o nome da Procedure e Lista de Parameter
                    using (dr = conn.ReturnDataReader("spGetModule", null))
                    {
                        while (dr.Read())
                        {
                            clsModuleBO _Module = new clsModuleBO();
                            _Module.Id = (Int32)dr["inModuleId"];
                            _Module.Name = dr["vcModuleName"] == DBNull.Value ? string.Empty : dr["vcModuleName"].ToString();
                            _list.Add(_Module);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ExecutedQuery + "\n\n" + ex.ToString(), ex.InnerException);
            }
            return _list;
        }

        /// <summary>
        /// FindOne Module
        /// </summary>
        /// <param name="id">id Module</param>
        /// <returns></returns>
        public static clsModuleBO FindOne(int id)
        {
            SqlDataReader dr;
            clsModuleBO _Module = new clsModuleBO();
            
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@inModuleId", id),
                    new SqlParameter("@vcModuleName", null),
                };

                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    //Chamando o DataReader passando o nome da Procedure e Lista de Parameter
                    using (dr = conn.ReturnDataReader("spGetModule", listParameter))
                    {
                        if (dr.Read())
                        {
                            _Module.Id = (Int32)dr["inModuleId"];
                            _Module.Name = dr["vcModuleName"] == DBNull.Value ? string.Empty : dr["vcModuleName"].ToString();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ExecutedQuery + "\n\n" + ex.ToString(), ex.InnerException);
            }
           
            return _Module;
        }



        /// <summary>
        /// Insert Module
        /// </summary>
        /// <param name="Module">Object clsModuleBO</param>
        /// <returns></returns>
        public static bool Insert(clsModuleBO Module)
        {
            bool _ret = false;
            
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@OperationType",1),
                    new SqlParameter("@inModuleId", Module.Id),
                    new SqlParameter("@vcModuleName", Module.Name),
                };
                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    conn.executQuery("spSetModule", listParameter);
                    _ret = true;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ExecutedQuery + "\n\n" + ex.ToString(), ex.InnerException);
            }
            return _ret;
         }

        /// <summary>
        /// Insert Identity Module. Performs the insert and return the id of the record.
        /// </summary>
        /// <param name="Module">Object clsModuleBO</param>
        /// <returns></returns>
        public static Int32 InsertIdentity(clsModuleBO Module)
        {
            
            Int32 _ret;
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@OperationType",1),
                    new SqlParameter("@inModuleId", Module.Id),
                    new SqlParameter("@vcModuleName", Module.Name),
                };
                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    _ret = Convert.ToInt32( conn.executQueryIdentity("spSetModule", listParameter));
                }
               }
            catch (SqlException ex)
            {
                throw new Exception(ExecutedQuery + "\n\n" + ex.ToString(), ex.InnerException);
            }
           
            return _ret;
        }

        /// <summary>
        /// Update Module
        /// </summary>
        /// <param name="Module">Object clsModuleBO</param>
        /// <returns></returns>
        public static bool Update(clsModuleBO Module)
        {
            bool _ret = false;
            
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@OperationType",2),
                    new SqlParameter("@inModuleId", Module.Id),
                    new SqlParameter("@vcModuleName", Module.Name),
                };
                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    conn.executQuery("spSetModule", listParameter);
                    _ret = true;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ExecutedQuery + "\n\n" + ex.ToString(), ex.InnerException);
            }
            return _ret;
        }

        /// <summary>
        /// Delete Module
        /// </summary>
        /// <param name="id">Module Id</param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            bool _ret = false;
            
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@OperationType",3),
                    new SqlParameter("@inModuleId", id)
                };
                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    conn.executQuery("spSetModule", listParameter);
                    _ret = true;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ExecutedQuery + "\n\n" + ex.ToString(), ex.InnerException);
            }
            
            return _ret;
        }


        /// <summary>
        /// ReturnDataSet
        /// </summary>
        /// <returns></returns>
        public static DataSet ReturnDataSet()
        {
            
            try
            {
                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    return conn.ReturnDataSet("spGetModule", null);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ExecutedQuery + "\n\n" + ex.ToString(), ex.InnerException);
            }
            
        }

        

    }
}

