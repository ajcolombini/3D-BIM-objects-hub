using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIM.Model;
using BIM.BLL;
using Framework.Util;
using System.IO;

namespace UI
{
    public partial class Register : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hdnProdutoId.Value = Guid.NewGuid().ToString();
                //clsAlerts.bootstrapAlert(hdnProdutoId.Value, "", AlertType.Info, this.Master.updPnlMaster);

                CarregaFabricantes();
                CarregaFamilias();
                CarregaSubtipos();
            }
        }

        private void CarregaFabricantes()
        {
            ddlFamilia.AppendDataBoundItems = true;
            ddlFamilia.Items.Clear();
            ddlFamilia.Items.Add(new ListItem("[Selecione]", "0"));

            List<Fabricante> _lstFabricante = BIM.BLL.FabricanteBLO.FindAll();
            this.ddlFabricante.DataTextField = "Nome";
            this.ddlFabricante.DataValueField = "Id";
            this.ddlFabricante.DataSource = _lstFabricante.OrderBy(x => x.Nome);
            this.ddlFabricante.DataBind();
        }

        private void CarregaFamilias()
        {
            ddlFamilia.AppendDataBoundItems = true;
            ddlFamilia.Items.Clear();
            ddlFamilia.Items.Add(new ListItem("[Selecione]", "0"));

            List<Familia> _lstFamilias = BIM.BLL.FamiliaBLO.FindAll();
            this.ddlFamilia.DataTextField = "Descricao";
            this.ddlFamilia.DataValueField = "Id";
            this.ddlFamilia.DataSource = _lstFamilias.OrderBy(x => x.Descricao);
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
            try
            {
                
                if (ValidaForm())
                {

                    BIM.Model.Produto _prod = new Produto();
                    _prod.Id = Guid.Parse(hdnProdutoId.Value);
                    _prod.ClasseConsumo = ddlClasseConsumo.SelectedValue;
                    _prod.Codigo = txtCodigo.Text;
                    _prod.Descricao = txtDescricao.Text;
                    _prod.Dimensoes = string.Concat(txtLargura.Text + " X " + txtAltura.Text + " X " + txtProfundidade.Text);
                    _prod.IdFabricante = Guid.Parse(ddlFabricante.SelectedValue);
                    _prod.IdFamilia = int.Parse(ddlFamilia.SelectedValue);
                    _prod.IdSubtipo = int.Parse(ddlSubgrupo.SelectedValue);
                    _prod.Nome = txtName.Text;
                    _prod.Preco = decimal.Parse(txtPreco.Text);
                    _prod.Status = ddlStatus.SelectedValue;
                    _prod.Voltagem = ddlVoltagem.SelectedValue;
                    _prod.Imagem = RecuperaImagem();

                    _prod.docs = RecuperaDocumentos();

                    Guid _retProdId = BIM.BLL.ProdutoBLO.Insert(_prod);

                    if (_retProdId == _prod.Id)
                    {
                        //Salva documentos
                        foreach (BIM.Model.Documento _doc in _prod.docs)
                        {
                            DocumentBLO.Insert(_doc);
                        }
                    }
                    else
                    {
                        lblErrorMsg.Text = "Erro ao salvar Produto.";
                        pnlError.Visible = true;
                    }

                    clsAlerts.bootstrapAlert("Produto incluído com sucesso!", "Sucesso", AlertType.Success, this.Master.updPnlMaster);
                }
                else
                {
                    pnlError.Visible = true;
                    //clsAlerts.bootstrapAlert(lblErrorMsg.Text, "Atenção", AlertType.Warning, this.Master.updPnlMaster);
                    clsAlerts.bootstrapConfirm("As imagens e arquivos selecionados ainda não foram enviados. Enviar agora?", "Aviso", "uploadFiles()", this.Master.updPnlMaster);
                }

            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
                pnlError.Visible = true;
                clsAlerts.bootstrapAlert(lblErrorMsg.Text, "Atenção", AlertType.Error, this.Master.updPnlMaster);
            }
        }

        private List<Documento> RecuperaDocumentos()
        {
            List<Documento> _lstDocs = new List<Documento>();

            string _docPath = Server.MapPath("tempFiles/doc/") + hdnProdutoId.Value;
            if (System.IO.Directory.Exists(_docPath))
            {
                FileInfo[] _files = Framework.Util.clsFileUtil.ReadsFilesDirectory(_docPath, "*");
                foreach (FileInfo _file in _files)
                {

                    Documento _doc = new Documento();

                    _doc.Id = Guid.NewGuid();
                    _doc.IdProduto = Guid.Parse(hdnProdutoId.Value);
                    _doc.Formato = _file.Extension;
                    _doc.TamanhoKb = _file.Length / 1024;
                    _doc.Titulo = _file.Name;

                    byte[] bytes = System.IO.File.ReadAllBytes(_file.FullName);
                    _doc.Objeto = bytes;

                    _lstDocs.Add(_doc);
                }
            }

            return _lstDocs;
        }

        private byte[] RecuperaImagem()
        {
            byte[] _imgArr = null;

            string _imgPath = Server.MapPath("tempFiles/img/") + hdnProdutoId.Value;
            if (System.IO.Directory.Exists(_imgPath))
            {
                FileInfo[] _files = Framework.Util.clsFileUtil.ReadsFilesDirectory(_imgPath, "*");
                if (_files != null)
                {
                    _imgArr = System.IO.File.ReadAllBytes(_files[0].FullName);
                }
            }

            return _imgArr;
        }


        //Validar campos do formulário
        public bool ValidaForm()
        {
            
            //Existe Documento?
            string _docPath = Server.MapPath("tempFiles/doc/") + hdnProdutoId.Value;
            if (System.IO.Directory.Exists(_docPath))
            {
                FileInfo[] _files = Framework.Util.clsFileUtil.ReadsFilesDirectory(_docPath, "*");
                if (_files.Count() == 0)
                {
                    //lblErrorMsg.Text += "Faça upload do(s) arquivo(s) do produto.";
                    return false;
                }
            }
            else
            {
                //lblErrorMsg.Text += "Faça upload do(s) arquivo(s) do produto.";
                return false;
            }
            return true;
        }

        //protected void hdnProdutoId_ValueChanged(object sender, EventArgs e)
        //{
        //    ViewState["IdProduto"] = hdnProdutoId.Value;
        //}
    }
}