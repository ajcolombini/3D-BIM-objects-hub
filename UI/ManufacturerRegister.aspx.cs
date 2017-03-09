using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Firebase.Auth;
using FireSharp;


namespace UI
{
    public partial class ManufacturerRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = btnRegistrar.UniqueID;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
           
           //string _body = FireBaseHelper.JsonModel;

            //FireSharp.Response.PushResponse _push = new FireSharp.Response.PushResponse(_body, System.Net.HttpStatusCode.OK, new System.Net.Http.HttpResponseMessage());
        }
    }
}