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

        public UpdatePanel updPnlMaster { get { return this.updPanelMain; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //FireBaseHelper _fb = new FireBaseHelper();


                
            }
        }

        protected void ToolkitScriptManager1_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this.updPanelMain, updPanelMain.GetType(), "HideLoader", "$('.centered_loader').hide();", true);
            clsJQuery.jsAlert(e.Exception.ToString(), "ToolkitScriptManager1_AsyncPostBackError", jAlertType.Error, this.updPanelMain);
        }
    }
}