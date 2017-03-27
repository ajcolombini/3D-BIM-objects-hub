using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Framework.Data;
using Framework.Security;

using BIM.Model;

namespace BIM.DAL
{
    public class clsProfilePermissionDAO 
    {
        /// <summary>
        /// Log de Execução
        /// </summary>
        public static string ExecutedQuery { get; set; }

        public static List<clsProfilePermissionBO> FindAll()
        {
            SqlDataReader dr;
            List<clsProfilePermissionBO> _list = new List<clsProfilePermissionBO>();

            try
            {
                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    //Chamando o DataReader passando o nome da Procedure e Lista de Parameter
                    using (dr = conn.ReturnDataReader("spGetProfilePermission", null))
                    {
                        while (dr.Read())
                        {
                            clsProfilePermissionBO _profilePermission = new clsProfilePermissionBO();
                            _profilePermission.Id = (Int32)dr["inProfilePermissionId"];
                            _profilePermission.Module = new clsModuleBO();
                            _profilePermission.Module.Id = (int)dr["inModuleId"];
                            _profilePermission.Module.Name = dr["ModuleName"].ToString();
                            _profilePermission.Profile = new clsProfileBO { Id = (int)dr["inProfileId"] };
                            _profilePermission.PermissionConsult = Convert.ToBoolean(dr["btPermissionConsult"]);
                            _profilePermission.PermissionMaintenance = Convert.ToBoolean(dr["btPermissionMaintenance"]);
                            _list.Add(_profilePermission);
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


        public static clsProfilePermissionBO FindOne(int profilePermissionId)
        {
            SqlDataReader dr;
            clsProfilePermissionBO _profilePermission = new clsProfilePermissionBO();


            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@inProfilePermissionId", profilePermissionId),
                    new SqlParameter("@inModuleId", null),
                    new SqlParameter("@inProfileId", null),
                    new SqlParameter("@btPermissionMaintenance", null),
                    new SqlParameter("@btPermissionConsult", null)
                };

                #region Proc Params
                /* .[spGetProfilePermission] (
                    @inProfilePermissionId	int = NULL,
                    @inModuleId				int = NULL,
                    @inProfileId			int = NULL,
                    @btPermissionMaintenance	bit	= NULL,
                    @btPermissionConsult		bit = NULL
                    )
                 */
                #endregion
                using (clsConexaoDAO conn = new clsConexaoDAO())
                {

                    //Chamando o DataReader passando o nome da Procedure e Lista de Parameter
                    using (dr = conn.ReturnDataReader("spGetProfilePermission", listParameter))
                    {
                        if (dr.Read())
                        {
                            _profilePermission.Id = (Int32)dr["inProfilePermissionId"];
                            _profilePermission.Module = new clsModuleBO { Id = (int)dr["inModuleId"] };
                            _profilePermission.Profile = new clsProfileBO { Id = (int)dr["inProfileId"] };
                            _profilePermission.PermissionConsult = Convert.ToBoolean(dr["btPermissionConsult"]);
                            _profilePermission.PermissionMaintenance = Convert.ToBoolean(dr["btPermissionMaintenance"]);
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ExecutedQuery + "\n\n" + ex.ToString(), ex.InnerException);
            }

            return _profilePermission;
        }


        public static List<clsProfilePermissionBO> FindByProfileId(int profileId)
        {
            SqlDataReader dr;
            List<clsProfilePermissionBO> _list = new List<clsProfilePermissionBO>();


            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@inProfilePermissionId", null),
                    new SqlParameter("@inModuleId", null),
                    new SqlParameter("@inProfileId", profileId),
                    new SqlParameter("@btPermissionMaintenance", null),
                    new SqlParameter("@btPermissionConsult", null)
                };

                #region Proc Params
                /* .[spGetProfilePermission] (
					                    @inProfilePermissionId	int = NULL,
					                    @inModuleId				int = NULL,
					                    @inProfileId			int = NULL,
					                    @btPermissionMaintenance	bit	= NULL,
					                    @btPermissionConsult		bit = NULL
					                    )
                                     */
                #endregion

                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    //Chamando o DataReader passando o nome da Procedure e Lista de Parameter
                    using (dr = conn.ReturnDataReader("spGetProfilePermission", listParameter))
                    {
                        while (dr.Read())
                        {
                            clsProfilePermissionBO _profilePermission = new clsProfilePermissionBO();

                            //clsModuleBO _mod = new clsModuleBO();
                            //_mod = clsModuleDAO.FindOne((int)dr["inModuleId"]);

                            //clsProfileBO _prof = new clsProfileBO();
                            //_prof = clsProfileDAO.FindOne((int)dr["inProfileId"]);

                            _profilePermission.Id = (Int32)dr["inProfilePermissionId"];
                            _profilePermission.Module = new clsModuleBO { Id = (int)dr["inModuleId"] };
                            _profilePermission.Profile = new clsProfileBO { Id = (int)dr["inProfileId"] };
                            _profilePermission.PermissionConsult = Convert.ToBoolean(dr["btPermissionConsult"]);
                            _profilePermission.PermissionMaintenance = Convert.ToBoolean(dr["btPermissionMaintenance"]);

                            _list.Add(_profilePermission);
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


        public static List<clsProfilePermissionBO> FindByProfileAndModule(int profileId, int moduleId)
        {
            SqlDataReader dr;
            List<clsProfilePermissionBO> _list = new List<clsProfilePermissionBO>();


            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@inProfilePermissionId", null),
                    new SqlParameter("@inModuleId", moduleId),
                    new SqlParameter("@inProfileId", profileId),
                    new SqlParameter("@btPermissionMaintenance", null),
                    new SqlParameter("@btPermissionConsult", null)
                };

                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    //Chamando o DataReader passando o nome da Procedure e Lista de Parameter
                    using (dr = conn.ReturnDataReader("spGetProfilePermission", listParameter))
                    {

                        while (dr.Read())
                        {
                            clsProfilePermissionBO _profilePermission = new clsProfilePermissionBO();

                            clsModuleBO _mod = new clsModuleBO();
                            _mod = clsModuleDAO.FindOne((int)dr["inModuleId"]);

                            clsProfileBO _prof = new clsProfileBO();
                            _prof = clsProfileDAO.FindOne((int)dr["inProfileId"]);

                            _profilePermission.Id = (Int32)dr["inProfilePermissionId"];
                            _profilePermission.Module = _mod;
                            _profilePermission.Profile = _prof;
                            _profilePermission.PermissionConsult = Convert.ToBoolean(dr["btPermissionConsult"]);
                            _profilePermission.PermissionMaintenance = Convert.ToBoolean(dr["btPermissionMaintenance"]);

                            _list.Add(_profilePermission);
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
        /// Permissoes do Usario
        /// Utiliza proc spGetUserProfilePermission
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public static clsProfilePermissionBO FindByUserAndModule(int userId, int moduleId)
        {
            SqlDataReader dr;
            clsProfilePermissionBO _profilePermission = new clsProfilePermissionBO();

            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@inUserId", userId),
                    new SqlParameter("@inModuleId", moduleId)
                };

                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    //Chamando o DataReader passando o nome da Procedure e Lista de Parameter
                    using (dr = conn.ReturnDataReader("spGetUserProfilePermission", listParameter))
                    {

                        if (dr.Read())
                        {

                            clsModuleBO _mod = new clsModuleBO();
                            _mod =clsModuleDAO.FindOne((int)dr["inModuleId"]);

                            clsProfileBO _prof = new clsProfileBO();
                            _prof = clsProfileDAO.FindOne((int)dr["inProfileId"]);

                            _profilePermission.Id = (Int32)dr["inProfilePermissionId"];
                            _profilePermission.Module = _mod;
                            _profilePermission.Profile = _prof;
                            _profilePermission.PermissionConsult = Convert.ToBoolean(dr["btPermissionConsult"]);
                            _profilePermission.PermissionMaintenance = Convert.ToBoolean(dr["btPermissionMaintenance"]);

                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ExecutedQuery + "\n\n" + ex.ToString(), ex.InnerException);
            }

            return _profilePermission;
        }


        #region CRUD methods

        /*
         [spSetProfilePermission] (
					@OperationType int,
					@inProfilePermissionId	int = NULL,
					@inModuleId int,
					@inProfileId int,
					@btPermissionMaintenance bit,
					@btPermissionConsult bit
		    )
         */

        /// <summary>
        /// Insert ProfilePermission
        /// </summary>
        /// <param name="profilePermission">clsProfilePermissionBO Object </param>
        /// <returns></returns>
        public static bool Insert(clsProfilePermissionBO profilePermission)
        {
            bool _ret = false;

            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@OperationType", EnumOperationType.Insert),
                    new SqlParameter("@inProfilePermissionId", profilePermission.Id),
                    new SqlParameter("@inModuleId", profilePermission.Module.Id),
                    new SqlParameter("@inProfileId", profilePermission.Profile.Id),
                    new SqlParameter("@btPermissionMaintenance", profilePermission.PermissionMaintenance),
                    new SqlParameter("@btPermissionConsult", profilePermission.PermissionConsult),
                    
                };
                using (clsConexaoDAO conn =  new clsConexaoDAO())
                {
                    conn.executQuery("spSetProfilePermission", listParameter);
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
        /// Insert Identity ProfilePermission. Performs the insert and return the id of the record.
        /// </summary>
        /// <param name="profilePermission">Object clsProfilePermissionBO</param>
        /// <returns></returns>
        public static Int32 InsertIdentity(clsProfilePermissionBO profilePermission)
        {

            Int32 _ret;
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@OperationType", EnumOperationType.Insert),
                    new SqlParameter("@inProfilePermissionId", profilePermission.Id),
                    new SqlParameter("@inModuleId", profilePermission.Module.Id),
                    new SqlParameter("@inProfileId", profilePermission.Profile.Id),
                    new SqlParameter("@btPermissionMaintenance", profilePermission.PermissionMaintenance),
                    new SqlParameter("@btPermissionConsult", profilePermission.PermissionConsult),
                };
                using (clsConexaoDAO conn =  new clsConexaoDAO())
                {
                    _ret = Convert.ToInt32(conn.executQueryIdentity("spSetProfilePermission", listParameter));
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ExecutedQuery + "\n\n" + ex.ToString(), ex.InnerException);
            }

            return _ret;
        }

        /// <summary>
        /// Update ProfilePermission
        /// </summary>
        /// <param name="profilePermission">Object clsProfilePermissionBO</param>
        /// <returns></returns>
        public static bool Update(clsProfilePermissionBO profilePermission)
        {
            bool _ret = false;

            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@OperationType", EnumOperationType.Update),
                    new SqlParameter("@inProfilePermissionId", profilePermission.Id),
                    new SqlParameter("@inModuleId", profilePermission.Module.Id),
                    new SqlParameter("@inProfileId", profilePermission.Profile.Id),
                    new SqlParameter("@btPermissionMaintenance", profilePermission.PermissionMaintenance),
                    new SqlParameter("@btPermissionConsult", profilePermission.PermissionConsult),
                };
                using (clsConexaoDAO conn =  new clsConexaoDAO())
                {
                    conn.executQuery("spSetProfilePermission", listParameter);
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
        /// Delete ProfilePermission
        /// </summary>
        /// <param name="id">ProfilePermission Id</param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            bool _ret = false;

            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@OperationType", EnumOperationType.Delete),
                    new SqlParameter("@inProfilePermissionId", id)
                };
                using (clsConexaoDAO conn =  new clsConexaoDAO())
                {
                    conn.executQuery("spSetProfilePermission", listParameter);
                    _ret = true;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ExecutedQuery + "\n\n" + ex.ToString(), ex.InnerException);
            }

            return _ret;
        }

        #endregion
    }
}
