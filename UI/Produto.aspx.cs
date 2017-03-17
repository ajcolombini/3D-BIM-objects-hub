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


        protected void lnkRegistrar_Click(object sender, EventArgs e)
        {
            if(ValidaForm())
            {
                BIM.Model.Produto _prod = new Produto();

                _prod.ClasseConsumo = ddlClasseConsumo.SelectedValue;
                _prod.Codigo = txtCodigo.Text;
                _prod.Descricao = txtDescricao.Text;
                _prod.Dimensoes = string.Concat(txtLargura.Text + " X " + txtAltura.Text + " X " + txtProfundidade.Text);
                _prod.IdFabricante = int.Parse(hdnFabricanteId.Value);
                _prod.IdFamilia = int.Parse(ddlFamilia.SelectedValue);
                _prod.IdSubtipo = int.Parse(ddlSubgrupo.SelectedValue);
                _prod.Imagem = RecuperaImagem();
                _prod.Nome = txtName.Text;
                _prod.Preco = decimal.Parse(txtPreco.Text);
                _prod.Status = ddlStatus.SelectedValue;
                _prod.Voltagem = ddlVoltagem.SelectedValue;
                _prod.docs = RecuperaDocumentos();
                
                Guid _newProdId = BIM.BLL.ProdutoBLO.Insert(_prod);

                if (_newProdId != Guid.Empty)
                {
                    //Salva documentos
                    foreach (BIM.Model.Documento _doc in _prod.docs)
                    {
                        DocumentBLO.Insert(_doc);
                    }
                }
            }
        }

        private List<Documento> RecuperaDocumentos()
        {
            List<Documento> _lstDocs = new List<Documento>();

            return _lstDocs;
        }

        private byte[] RecuperaImagem()
        {
            byte[] _imgArr = null;

            return _imgArr;
        }

        public bool ValidaForm()
        {

            return true;
        }
    }
}