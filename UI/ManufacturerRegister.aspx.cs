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
            Model _model = new Model();

            _model.manufacturer.id = Guid.NewGuid().ToString();
            _model.manufacturer.name = txtName.Text;
            _model.manufacturer.formalName = txtFormalName.Text;
            _model.manufacturer.phone = txtPhone.Text;
            _model.manufacturer.eMail = txtEmail.Text;
            _model.manufacturer.webSite = txtSite.Text;
            if (!string.IsNullOrEmpty(hdnFileSelected.Value)) {
                _model.manufacturer.logo = 
            }

           //string _body = FireBaseHelper.JsonModel;

            //FireSharp.Response.PushResponse _push = new FireSharp.Response.PushResponse(_body, System.Net.HttpStatusCode.OK, new System.Net.Http.HttpResponseMessage());
        }
    }
}