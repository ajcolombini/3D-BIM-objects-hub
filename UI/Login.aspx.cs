using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = btnSignIn.ClientID;


        }

        protected async void btnSignIn_Click(object sender, EventArgs e)
        {
           

            try
            {
              
                Response.Redirect("Home.aspx");
            }
            catch (Exception ex)
            {
                this.pnlError.Visible = true;
                this.lblErrorMsg.Text = "E-Mail ou Senha inválidos.";
            }

        }
    }
}