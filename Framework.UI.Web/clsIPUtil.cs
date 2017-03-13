using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Framework.UI.Web
{
    public class clsIPUtil
    {

        protected string getEnderecoIP()
        {
            string strEnderecoIP;
            strEnderecoIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (strEnderecoIP == null)
                strEnderecoIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            return strEnderecoIP;
        }
    }
}
