using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using BIM.Model;
using BIM.DAL;

namespace Framework.BLO
{
    public class clsUserBLO
    {
         
        /// <summary>
        /// FindAll Users
        /// </summary>
        /// <returns>List clsUserBO</returns>
        public static List<clsUserBO> FindAll()
        {
            try { return clsUserDAO.FindAll();}
            catch (SqlException ex) {
                throw new Exception(ex.Message, ex.InnerException); 
            }
        }

       
        /// <summary>
        /// FindOne User
        /// </summary>
        /// <param name="id">id user</param>
        /// <returns></returns>
        public static clsUserBO FindOne(int id)
        {
            try { return clsUserDAO.FindOne(id); }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Retorna Objeto clsUserBO pelo Login
        /// </summary>
        /// <param name="login">Login do Usuario</param>
        /// <returns></returns>
        public static clsUserBO FindByLogin(string login)
        {
            try
            {
                return clsUserDAO.FindByLogin(login);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
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
            try
            {
                return clsUserDAO.FindAny(login, name, email, profileId, bInternal, bActive);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Insert User
        /// </summary>
        /// <param name="User">Object clsUserBO</param>
        /// <returns></returns>
        public static bool Insert(clsUserBO User)
        {
            try { return clsUserDAO.Insert(User); }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Insert Identity User. Performs the insert and return the id of the record.
        /// </summary>
        /// <param name="User">Object clsUserBO</param>
        /// <returns></returns>
        public static Int32 InsertIdentity(clsUserBO User)
        {
            try { return clsUserDAO.InsertIdentity(User); }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="User">Object clsUserBO</param>
        /// <returns></returns>
        public static bool Update(clsUserBO User)
        {
            try { return clsUserDAO.Update(User); }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            try { return clsUserDAO.Delete(id); }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
