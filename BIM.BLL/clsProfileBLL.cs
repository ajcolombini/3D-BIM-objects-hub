using System;
using BIM.Model;
using BIM.DAL;

namespace BIM.BLL
{
    public class clsProfileBLL
    {
        public clsProfileBO FindByName(string profileName)
        {
            try
            {
                return clsProfileDAO.FindByName(profileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static System.Collections.Generic.List<clsProfileBO> FindAll()
        {
            try
            {
                return clsProfileDAO.FindAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
