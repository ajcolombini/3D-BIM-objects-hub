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

            FireBaseHelper _help = new FireBaseHelper();

            ModelObject _model = new ModelObject();
            _model.manufacturer.name = txtNome.Text;
            _model.manufacturer.eMail = txtEmail.Text;
            _model.manufacturer.formalName = txtRazao.Text;
            _model.manufacturer.id = new Guid();
            _model.manufacturer.webSite = txtSite.Text;

            _help.SetDataToFirebase(this.textBox.Text);

        }

        //FireSharp.Response.PushResponse _push = new FireSharp.Response.PushResponse(_body, System.Net.HttpStatusCode.OK, new System.Net.Http.HttpResponseMessage());
    }
    }
}