using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class HUB : System.Web.UI.MasterPage
    {
        private string _apiKey = ConfigurationManager.AppSettings["FireBaseToken"];
        
        public string ApiKey {
            get { return _apiKey; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FireBaseHelper _fb = new FireBaseHelper();


                
            }
        }
    }
}