using System;
using System.Text;
using System.DirectoryServices;
using System.Security.Principal;
using System.Configuration;
using System.DirectoryServices.AccountManagement;

namespace Framework.Security
{
    /// <summary>
    /// É necessário adicionar webconfig as info. referente ao domínio.
    /// </summary>
    public class clsActiveDirectory
    {

        public enum ADProperties
        {
            distinguishedName,
            displayName,
            telephoneNumber,
            samAccountName,
            manager,
            title,
            department,
            givenName,
            sn
        }

        private string nome;


        /// <summary>
        /// Retorna o nome completo de um usuário do Active Directory.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public string RetonarNomeUsuario(string userName, string Password)
        {

            SearchResult result = DirectorySearch(userName, Password, "cn");

            if (result != null)
                return result.GetDirectoryEntry().Properties["cn"].Value.ToString();
            else

                return "User não encontrado no Active Directory";
        }

        /// <summary>
        /// Validar Usuário e Senha no AD
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool LoginValid(string userName, string Password)
        {
            bool bolResult = false;
            try
            {
                SearchResult result = DirectorySearch(userName, Password, "cn");

                if (result != null)
                    bolResult = true;
                else
                    bolResult = false;
            }
            catch
            {
                bolResult = false;
            }

            return bolResult;
        }

        /// <summary>
        /// Verifica se UserName informado está no AD e retorna Nome completo.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string GetFullName(string userName)
        {
            try
            {
                SearchResult result = DirectorySearch(userName, "cn");


                if (result != null)
                    return result.GetDirectoryEntry().Properties["cn"].Value.ToString();
                else return "False";
            }

            catch (Exception ex)
            {
                return "An error was thrown by the LDAP Web Service.  The Error was \r\n" + ex.Message.ToString();
            }
        }


        /// <summary>
        /// Verifica se UserName informado está no AD.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool LoginExists(string userName)
        {
            try
            {
                SearchResult result = DirectorySearch(userName, "cn");


                if (result != null)
                    return true;
                else
                    return false;
            }

            catch (Exception)
            {
                return false;
            }
        }



        /// <summary>
        /// Directory Search Overload.  Allows authentication to AD with a specified username and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        private SearchResult DirectorySearch(string userName, string password, string property)
        {
            DirectoryEntry dEntry = new DirectoryEntry(ConfigurationManager.AppSettings["LDAPServer"].ToString(), FilterOutDomain(userName.Trim()), password);
            DirectorySearcher search = new DirectorySearcher(dEntry);

            search.PropertiesToLoad.Add(property);
            search.Filter = "sAMAccountName=" + FilterOutDomain(userName);

            SearchResult result = search.FindOne();

            return result;
        }


        /// <summary>
        /// Directory Search Overload.  Allows authentication to AD with a specified username and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        private SearchResult DirectorySearch(string userName, string property)
        {
            DirectoryEntry dEntry = new DirectoryEntry(ConfigurationManager.AppSettings["LDAPServer"].ToString());
            DirectorySearcher search = new DirectorySearcher(dEntry);

            search.PropertiesToLoad.Add(property);
            search.Filter = "sAMAccountName=" + FilterOutDomain(userName);

            SearchResult result = search.FindOne();




            return result;
        }

        private string FilterOutDomain(string userName)
        {
            string result = string.Empty;

            if (userName.IndexOf("\\") > 0)
            {
                string UserName = string.Empty;
                int SlashSpot = 0;
                int NameLen = 0;

                SlashSpot = userName.IndexOf(@"\") + 1;

                NameLen = userName.Length - SlashSpot;

                UserName = userName.Substring(SlashSpot, NameLen);

                result = UserName;
            }
            else
            {
                result = userName;
            }

            return result;
        }


        /// <summary>
        /// Consulta Usuário
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string ConsultaUsuario(string userName)
        {

            try
            {
                DirectoryEntry Acesso = new DirectoryEntry(ConfigurationManager.AppSettings["LDAPServer"].ToString());
                DirectorySearcher search = new DirectorySearcher(Acesso);

                search.SearchRoot = Acesso;
                search.SearchScope = SearchScope.Subtree;
                search.Filter = "(ObjectClass=user)";
                search.Filter = "(&(objectClass=user)(samaccountname=" + userName + "))";

                foreach (SearchResult filtro in search.FindAll())
                {
                    nome = filtro.Properties["cn"][0].ToString();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
           

            return nome;
        }





    }




}
