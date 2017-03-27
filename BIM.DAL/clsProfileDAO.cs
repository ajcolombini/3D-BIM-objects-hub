using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BIM.Model;
using Framework.Data;
//using BIM.Model.Enum;

namespace BIM.DAL
{
    public class clsProfileDAO 
    {
        /// <summary>
        /// Log de Execução
        /// </summary>
        public static string ExecutedQuery { get; set; }

        public static List<clsProfileBO> FindAll()
        {
            SqlDataReader dr;
            List<clsProfileBO> _list = new List<clsProfileBO>();
            
            try
            {
                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    //Chamando o DataReader passando o nome da Procedure e Lista de Parameter
                    using (dr = conn.ReturnDataReader("spGetProfile", null))
                    {
                        while (dr.Read())
                        {
                            clsProfileBO _profile = new clsProfileBO();
                            _profile.Id = (Int32)dr["inProfileId"];
                            _profile.ProfileName = dr["vcProfileName"].ToString();
                            _profile.Description = dr["vcDescription"] == DBNull.Value ? string.Empty : dr["vcDescription"].ToString();
                            _profile.IsActive = Convert.ToBoolean(dr["btIsActive"]);
                            _list.Add(_profile);
                        }
                    }

                    foreach (var _obj in _list)
                    {
                        List<SqlParameter> listParameter = new List<SqlParameter>() { 
                        new SqlParameter("@inProfilePermissionId", null),
                        new SqlParameter("@inModuleId", null),
                        new SqlParameter("@inProfileId", _obj.Id),
                        new SqlParameter("@btPermissionMaintenance", null),
                        new SqlParameter("@btPermissionConsult", null)};

                        //Carrega a Lista de Permissoes do Perfil
                        _obj.ListProfilePermission = new List<clsProfilePermissionBO>();

                        using (dr = conn.ReturnDataReader("spGetProfilePermission", listParameter))
                        {
                            while (dr.Read())
                            {
                                clsProfilePermissionBO _profilePermission = new clsProfilePermissionBO();
                                _profilePermission.Id = (Int32)dr["inProfilePermissionId"];
                                _profilePermission.Module = new clsModuleBO();
                                _profilePermission.Module.Id = (int)dr["inModuleId"];
                                _profilePermission.Module.Name = dr["ModuleName"].ToString();
                                _profilePermission.PermissionConsult = Convert.ToBoolean(dr["btPermissionConsult"]);
                                _profilePermission.PermissionMaintenance = Convert.ToBoolean(dr["btPermissionMaintenance"]);
                                _obj.ListProfilePermission.Add(_profilePermission);
                            }
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

        public static clsProfileBO FindByName(string profileName)
        {
            SqlDataReader dr;
            clsProfileBO _profile = new clsProfileBO();
            
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@inProfileId", null),
                    new SqlParameter("@vcProfileName", profileName),
                    new SqlParameter("@vcDescription", null),
                    new SqlParameter("@btIsActive", null),
                };

                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    //Chamando o DataReader passando o nome da Procedure e Lista de Parameter
                    using (dr = conn.ReturnDataReader("spGetProfile", listParameter))
                    {
                        if (dr.Read())
                        {
                            _profile.Id = (Int32)dr["inProfileId"];
                            _profile.ProfileName = dr["vcProfileName"].ToString();
                            _profile.Description = dr["vcDescription"] == DBNull.Value ? string.Empty : dr["vcDescription"].ToString();
                            _profile.IsActive = Convert.ToBoolean(dr["btIsActive"]);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ExecutedQuery + "\n\n" + ex.ToString(), ex.InnerException);
            }
           
            return _profile;
        }
        

        /// <summary>
        /// FindOne Profile
        /// </summary>
        /// <param name="id">id profile</param>
        /// <returns></returns>
        public static clsProfileBO FindOne(int id)
        {
            SqlDataReader dr;
            clsProfileBO _profile = new clsProfileBO();
            
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@inProfileId", id),
                    new SqlParameter("@vcProfileName", null),
                    new SqlParameter("@vcDescription", null),
                    new SqlParameter("@btIsActive", null),
               };

                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    //Chamando o DataReader passando o nome da Procedure e Lista de Parameter
                    using (dr = conn.ReturnDataReader("spGetProfile", listParameter))
                    {
                        if (dr.Read())
                        {
                            _profile.Id = (Int32)dr["inProfileId"];
                            _profile.ProfileName = dr["vcProfileName"].ToString();
                            _profile.Description = dr["vcDescription"] == DBNull.Value ? string.Empty : dr["vcDescription"].ToString();
                            _profile.IsActive = Convert.ToBoolean(dr["btIsActive"]);

                            _profile.ListProfilePermission = new List<clsProfilePermissionBO>();
                            _profile.ListProfilePermission = clsProfilePermissionDAO.FindByProfileId(_profile.Id);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ExecutedQuery + "\n\n" + ex.ToString(), ex.InnerException);
            }
            
            return _profile;
        }


        #region " CRUD Methods "

        /// <summary>
        /// Insert Profile
        /// </summary>
        /// <param name="profile">Object clsProfileBO</param>
        /// <returns></returns>
        public static bool Insert(clsProfileBO profile)
        {
            bool _ret = false;
            
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@OperationType", EnumOperationType.Insert),
                    new SqlParameter("@inProfileId", profile.Id),
                    new SqlParameter("@vcProfileName", profile.ProfileName),
                    new SqlParameter("@vcDescription", profile.Description),
                    new SqlParameter("@btIsActive", profile.IsActive),
                };
                using (clsConexaoDAO conn =  new clsConexaoDAO())
                {
                    conn.executQuery("spSetProfile", listParameter);
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
        /// Insert Identity Profile. Performs the insert and return the id of the record.
        /// </summary>
        /// <param name="profile">Object clsProfileBO</param>
        /// <returns></returns>
        public static Int32 InsertIdentity(clsProfileBO profile)
        {
            
            Int32 _ret;
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@OperationType", EnumOperationType.Insert),
                    new SqlParameter("@inProfileId", null),
                    new SqlParameter("@vcProfileName", profile.ProfileName),
                    new SqlParameter("@vcDescription", profile.Description),
                    new SqlParameter("@btIsActive", profile.IsActive),
                };
                using (clsConexaoDAO conn =  new clsConexaoDAO())
                {
                    _ret = Convert.ToInt32( conn.executQueryIdentity("spSetProfile", listParameter) );
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ExecutedQuery + "\n\n" + ex.ToString(), ex.InnerException);
            }
           
            return _ret;
        }

        /// <summary>
        /// Update Profile
        /// </summary>
        /// <param name="profile">Object clsProfileBO</param>
        /// <returns></returns>
        public static bool Update(clsProfileBO profile)
        {
            bool _ret = false;
            
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@OperationType", EnumOperationType.Update),
                    new SqlParameter("@inProfileId", profile.Id),
                    new SqlParameter("@vcProfileName", profile.ProfileName),
                    new SqlParameter("@vcDescription", profile.Description),
                    new SqlParameter("@btIsActive", profile.IsActive),
                };
                using (clsConexaoDAO conn =  new clsConexaoDAO())
                {
                    conn.executQuery("spSetProfile", listParameter);
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
        /// Delete Profile
        /// </summary>
        /// <param name="id">Profile Id</param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            bool _ret = false;
            
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@OperationType", EnumOperationType.Delete),
                    new SqlParameter("@inProfileId", id)
                };
                using (clsConexaoDAO conn =  new clsConexaoDAO())
                {
                    conn.executQuery("spSetProfile", listParameter);
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
