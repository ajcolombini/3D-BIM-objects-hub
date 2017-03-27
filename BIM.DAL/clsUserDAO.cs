using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BIM.Model;
using Framework.Data;

namespace BIM.DAL
{
    public class clsUserDAO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<clsUserBO> FindAll()
        {
            SqlDataReader dr;

            List<clsUserBO> _list = new List<clsUserBO>();

            try
            {
                using (clsConexaoDAO conn = new clsConexaoDAO())
                {

                    //Chamando o DataReader passando o nome da Procedure e Lista de Parameter
                    using (dr = conn.ReturnDataReader("spGetUser", null))
                    {
                        while (dr.Read())
                        {
                            clsUserBO _user = new clsUserBO();

                            _user.Id = (Int32)dr["inUserId"];
                            _user.Login = dr["vcUserLogin"] == DBNull.Value ? string.Empty : dr["vcUserLogin"].ToString();
                            _user.Email = dr["vcUserEmail"] == DBNull.Value ? string.Empty : dr["vcUserEmail"].ToString();
                            _user.Name = dr["vcUserName"].ToString();
                            _user.Password = dr["vcUserPassword"].ToString();
                            _user.IsInternal = Convert.ToBoolean(dr["btIsInternal"]);
                            _user.IsActive = Convert.ToBoolean(dr["btIsActive"]);
                            _user.NextPwdChanging = dr["dtNextPwdChanging"] == DBNull.Value ? DateTime.Parse("1900-01-01") : DateTime.Parse(dr["dtNextPwdChanging"].ToString());

                            _user.Profile = new clsProfileBO();
                            _user.Profile = clsProfileDAO.FindOne((int)dr["inProfileId"]);
  
                          

                            _list.Add(_user);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            
            return _list;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static clsUserBO FindOne(int userId)
        {
            SqlDataReader dr;
            clsUserBO _user = new clsUserBO();
            
            try
            {
                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@inUserId", userId),
                    new SqlParameter("@vcUserLogin", null),
                    new SqlParameter("@vcUserPassword", null),
                    new SqlParameter("@vcUserName", null),
                    new SqlParameter("@vcUserEMail", null),
                    new SqlParameter("@inProfileId", null),
                    new SqlParameter("@btIsInternal", null),
                    new SqlParameter("@btIsActive", null),
                    new SqlParameter("@dtNextPwdChanging", null)
                };

                    //Chamando o DataReader passando o nome da Procedure e Lista de Parameter
                    using (dr = conn.ReturnDataReader("spGetUser", listParameter))
                    {
                        if (dr.Read())
                        {
                            _user.Id = (Int32)dr["inUserId"];
                            _user.Login = dr["vcUserLogin"] == DBNull.Value ? string.Empty : dr["vcUserLogin"].ToString();
                            _user.Email = dr["vcUserEmail"] == DBNull.Value ? string.Empty : dr["vcUserEmail"].ToString();
                            _user.Name = dr["vcUserName"].ToString();
                            _user.Password = dr["vcUserPassword"].ToString();
                            _user.IsInternal = Convert.ToBoolean(dr["btIsInternal"]);
                            _user.IsActive = Convert.ToBoolean(dr["btIsActive"]);
                            _user.NextPwdChanging = dr["dtNextPwdChanging"] == DBNull.Value ? DateTime.Parse("1900-01-01") : DateTime.Parse(dr["dtNextPwdChanging"].ToString());
                            
                            _user.Profile = new clsProfileBO();
                            _user.Profile = clsProfileDAO.FindOne((int)dr["inProfileId"]);
                            
                          

                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return _user;
        }

        public static clsUserBO FindByLogin(string login)
        {
            SqlDataReader dr;
            clsUserBO _user = new clsUserBO();
            
            try
            {
                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@inUserId", null),
                    new SqlParameter("@vcUserLogin", login),
                    new SqlParameter("@vcUserPassword", null),
                    new SqlParameter("@vcUserName", null),
                    new SqlParameter("@vcUserEMail", null),
                    new SqlParameter("@inProfileId", null),
                    new SqlParameter("@btIsInternal", null),
                    new SqlParameter("@btIsActive", null),
                    new SqlParameter("@dtNextPwdChanging", null)
                };

                    //Chamando o DataReader passando o nome da Procedure e Lista de Parameter
                    using (dr = conn.ReturnDataReader("spGetUser", listParameter))
                    {
                        if (dr.Read())
                        {
                            _user.Id = (Int32)dr["inUserId"];
                            _user.Login = dr["vcUserLogin"] == DBNull.Value ? string.Empty : dr["vcUserLogin"].ToString();
                            _user.Email = dr["vcUserEmail"] == DBNull.Value ? string.Empty : dr["vcUserEmail"].ToString();
                            _user.Name = dr["vcUserName"].ToString();
                            _user.Password = dr["vcUserPassword"].ToString();
                            _user.IsInternal = Convert.ToBoolean(dr["btIsInternal"]);
                            _user.IsActive = Convert.ToBoolean(dr["btIsActive"]);
                            _user.NextPwdChanging = dr["dtNextPwdChanging"] == DBNull.Value ? DateTime.Parse("1900-01-01") : DateTime.Parse(dr["dtNextPwdChanging"].ToString());
                            _user.Profile = new clsProfileBO();
                            _user.Profile = clsProfileDAO.FindOne((int)dr["inProfileId"]);

                          
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
          
            return _user;
        }

        /// <summary>
        /// Find User by some filters
        /// </summary>
        /// <param name="login"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="profileId"></param>
        /// <param name="bInternal"></param>
        /// <param name="bActive"></param>
        /// <returns></returns>
        public static List<clsUserBO> FindAny(String login=null, String name=null, String email=null, Int32? profileId=null, bool? bInternal=true, bool? bActive=true)
        {
            SqlDataReader dr;

            List<clsUserBO> _list = new List<clsUserBO>();

            try
            {
                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@inUserId", null),
                    new SqlParameter("@vcUserLogin", login),
                    new SqlParameter("@vcUserPassword", null),
                    new SqlParameter("@vcUserName", name),
                    new SqlParameter("@vcUserEMail", email),
                    new SqlParameter("@inProfileId", profileId),
                    new SqlParameter("@btIsInternal", bInternal),
                    new SqlParameter("@btIsActive", bActive),
                    new SqlParameter("@dtNextPwdChanging", null)
                };

                    //Chamando o DataReader passando o nome da Procedure e Lista de Parameter
                    using (dr = conn.ReturnDataReader("spGetUser", listParameter))
                    {
                        while (dr.Read())
                        {
                            clsUserBO _user = new clsUserBO();

                            _user.Id = (Int32)dr["inUserId"];
                            _user.Login = dr["vcUserLogin"] == DBNull.Value ? string.Empty : dr["vcUserLogin"].ToString();
                            _user.Email = dr["vcUserEmail"] == DBNull.Value ? string.Empty : dr["vcUserEmail"].ToString();
                            _user.Name = dr["vcUserName"].ToString();
                            _user.Password = dr["vcUserPassword"].ToString();
                            _user.IsInternal = Convert.ToBoolean(dr["btIsInternal"]);
                            _user.IsActive = Convert.ToBoolean(dr["btIsActive"]);
                            _user.NextPwdChanging = dr["dtNextPwdChanging"] == DBNull.Value ? DateTime.Parse("1900-01-01") : DateTime.Parse(dr["dtNextPwdChanging"].ToString());

                            _user.Profile = new clsProfileBO();
                            _user.Profile = clsProfileDAO.FindOne((int)dr["inProfileId"]);

                            _list.Add(_user);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return _list;
        }


        /*
         * [spSetUser] (
                            @OperationType int,
                            @inUserId	int = NULL,
                            @vcUserLogin  varchar(50),
                            @vcUserPassword	varchar(50),
                            @vcUserName	varchar(255),
                            @vcUserEMail varchar(150),
                            @inProfileId	int,
                            @inBrokerId		int,
                            @btIsInternal	bit,	
                            @btIsActive		bit	
         * 
         */

        /// <summary>
        /// Insert User
        /// </summary>
        /// <param name="User">Object clsUserBO</param>
        /// <returns></returns>
        public static bool Insert(clsUserBO User)
        {
            bool _ret = false;
            
            try
            {
                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@OperationType", EnumOperationType.Insert),
                    new SqlParameter("@inUserId", User.Id),
                    new SqlParameter("@vcUserLogin", User.Login),
                    new SqlParameter("@vcUserPassword", User.Password),
                    new SqlParameter("@vcUserName", User.Name),
                    new SqlParameter("@vcUserEMail", User.Email),
                    new SqlParameter("@inProfileId", User.Profile.Id),
                    new SqlParameter("@btIsInternal", User.IsInternal),
                    new SqlParameter("@btIsActive", User.IsActive),
                    new SqlParameter("@dtNextPwdChanging", User.NextPwdChanging)
                };
                    conn.executQuery("spSetUser", listParameter);
                    _ret = true;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
          
            return _ret;
        }

        /// <summary>
        /// Insert Identity User. Performs the insert and return the id of the record.
        /// </summary>
        /// <param name="User">Object clsUserBO</param>
        /// <returns></returns>
        public static Int32 InsertIdentity(clsUserBO User)
        {
            Int32 _ret;
            // 
            try
            {
                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() { 
                   new SqlParameter("@OperationType", EnumOperationType.Insert),
                    new SqlParameter("@inUserId", User.Id),
                    new SqlParameter("@vcUserLogin", User.Login),
                    new SqlParameter("@vcUserPassword", User.Password),
                    new SqlParameter("@vcUserName", User.Name),
                    new SqlParameter("@vcUserEMail", User.Email),
                    new SqlParameter("@inProfileId", User.Profile.Id),
                    new SqlParameter("@btIsInternal", User.IsInternal),
                    new SqlParameter("@btIsActive", User.IsActive),
                    new SqlParameter("@dtNextPwdChanging", User.NextPwdChanging)
                };
                    _ret = Convert.ToInt32( conn.executQueryIdentity("spSetUser", listParameter));
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
           
            return _ret;
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="User">Object clsUserBO</param>
        /// <returns></returns>
        public static bool Update(clsUserBO User)
        {
            bool _ret = false;
           
            try
            {
                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@OperationType", EnumOperationType.Update),
                    new SqlParameter("@inUserId", User.Id),
                    new SqlParameter("@vcUserLogin", User.Login),
                    new SqlParameter("@vcUserPassword", User.Password),
                    new SqlParameter("@vcUserName", User.Name),
                    new SqlParameter("@vcUserEMail", User.Email),
                    new SqlParameter("@inProfileId", User.Profile.Id),
                    new SqlParameter("@btIsInternal", User.IsInternal),
                    new SqlParameter("@btIsActive", User.IsActive),
                    new SqlParameter("@dtNextPwdChanging", User.NextPwdChanging)
                    };
                    conn.executQuery("spSetUser", listParameter);
                    _ret = true;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
          
            return _ret;
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            bool _ret = false;
            
            try
            {
                using (clsConexaoDAO conn = new clsConexaoDAO())
                {
                    List<SqlParameter> listParameter = new List<SqlParameter>() { 
                    new SqlParameter("@OperationType", EnumOperationType.Delete),
                    new SqlParameter("@inUserId", id)
                };
                    conn.executQuery("spSetUser", listParameter);
                    _ret = true;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
           
            return _ret;
        }

    }
}
