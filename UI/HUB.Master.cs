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
                
        public UpdatePanel updPnlMaster { get { return this.updPanelMain; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                
            }
        }


        public void showMessage(string message, string title, AlertType type)
        {
            clsAlerts.bootstrapAlert(message, title, type, this.updPanelMain);
        }

        public void showConfirm(string message, string title)
        {
            clsAlerts.bootstrapConfirm(message, title, true, this.updPanelMain);
        }

        public void showConfirm(string message, string title, string callbackfunc)
        {
            clsAlerts.bootstrapConfirm(message, title, callbackfunc, this.updPanelMain);
        }


        protected void ToolkitScriptManager1_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this.updPanelMain, updPanelMain.GetType(), "HideLoader", "$('.centered_loader').hide();", true);
            showMessage(e.Exception.ToString(), "ToolkitScriptManager1_AsyncPostBackError", AlertType.Error);
        }
    }
}