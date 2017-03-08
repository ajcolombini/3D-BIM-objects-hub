using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Firebase.Auth;
using FireSharp;
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
            string _apiKey = ConfigurationManager.AppSettings["FireBaseToken"];

            try
            {

                FirebaseAuthProvider _fireAuth = new FirebaseAuthProvider(new FirebaseConfig(_apiKey));
                var _fbAuth = await _fireAuth.SignInWithEmailAndPasswordAsync(this.txtEmail.Text, this.txtPassword.Text);

                if (_fbAuth.User != null)
                {
                    Session["CurrentUser"] = _fbAuth.User;
                    Response.Redirect("Home.aspx");
                }
            }
            catch (Firebase.Auth.FirebaseAuthException)
            {
                this.pnlError.Visible = true;
                this.lblErrorMsg.Text = "E-Mail ou Senha inválidos.";
            }

        }
    }
}