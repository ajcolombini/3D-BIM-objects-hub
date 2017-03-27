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

    /// <summary>
    /// Classe ProfilePermission Business Logic Object
    /// </summary>
    public class clsProfilePermissionBLO
    {

        /// <summary>
        /// FindAll ProfilePermission
        /// </summary>
        /// <returns>List clsProfilePermissionBO</returns>
        public static List<clsProfilePermissionBO> FindAll()
        {
            try { return clsProfilePermissionDAO.FindAll(); }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// FindOne ProfilePermission
        /// </summary>
        /// <param name="id">ProfilePermissionId</param>
        /// <returns></returns>
        public static clsProfilePermissionBO FindOne(int id)
        {
            try { return clsProfilePermissionDAO.FindOne(id); }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }


        /// <summary>
        /// Find ProfilePermission by Profile
        /// </summary>
        /// <param name="profileId">Profile Id</param>
        /// <returns></returns>
        public static List<clsProfilePermissionBO> FindByProfileId(int profileId)
        {
            try { return clsProfilePermissionDAO.FindByProfileId(profileId); }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Find ProfilePermission by Profile and Module
        /// </summary>
        /// <param name="profileId">Profile Id</param>
        /// <param name="moduleId">Module Id</param>
        /// <returns></returns>
        public static List<clsProfilePermissionBO> FindByProfileAndModule(int profileId, int moduleId)
        {
            try { return clsProfilePermissionDAO.FindByProfileAndModule(profileId, moduleId); }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
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
            try { return clsProfilePermissionDAO.FindByUserAndModule(userId, moduleId); }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Insert ProfilePermission
        /// </summary>
        /// <param name="ProfilePermission">Object clsProfilePermissionBO</param>
        /// <returns></returns>
        public static bool Insert(clsProfilePermissionBO ProfilePermission)
        {
            try { return clsProfilePermissionDAO.Insert(ProfilePermission); }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Insert Identity ProfilePermission. Performs the insert and return the id of the record.
        /// </summary>
        /// <param name="ProfilePermission">Object clsProfilePermissionBO</param>
        /// <returns></returns>
        public static Int32 InsertIdentity(clsProfilePermissionBO ProfilePermission)
        {
            try { return clsProfilePermissionDAO.InsertIdentity(ProfilePermission); }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Update ProfilePermission
        /// </summary>
        /// <param name="ProfilePermission">Object clsProfilePermissionBO</param>
        /// <returns></returns>
        public static bool Update(clsProfilePermissionBO ProfilePermission)
        {
            try { return clsProfilePermissionDAO.Update(ProfilePermission); }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Delete ProfilePermission
        /// </summary>
        /// <param name="id">ProfilePermission Id</param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            try { return clsProfilePermissionDAO.Delete(id); }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

    }
}
