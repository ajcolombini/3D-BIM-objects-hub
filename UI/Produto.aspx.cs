using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIM.Model;
using BIM.BLL;

namespace UI
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaFamilias();
                CarregaSubtipos();
            }
        }

        private void CarregaFamilias()
        {
            ddlFamilia.AppendDataBoundItems = true;
            ddlFamilia.Items.Clear();
            ddlFamilia.Items.Add(new ListItem("[Selecione]", "0"));

            List<Familia> _lstFamilias = BIM.BLL.FamiliaBLO.FindAll();
            this.ddlFamilia.DataTextField = "Descricao";
            this.ddlFamilia.DataValueField = "Id";
            this.ddlFamilia.DataSource = _lstFamilias;
            this.ddlFamilia.DataBind();
        }


        private void CarregaSubtipos()
        {
            ddlSubgrupo.AppendDataBoundItems = true;
            ddlSubgrupo.Items.Clear();
            ddlSubgrupo.Items.Add(new ListItem("[Selecione]", "0"));

            List<Subtipo> _lstSubtipos = BIM.BLL.SubtipoBLO.FindAll();
            this.ddlSubgrupo.DataTextField = "Descricao";
            this.ddlSubgrupo.DataValueField = "Id";
            this.ddlSubgrupo.DataSource = _lstSubtipos;
            this.ddlSubgrupo.DataBind();
        }
    }
}