using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Firebase.Auth;
using FireSharp;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FireSharp.Response;
using System.Configuration;
using BIM.BLL;
using BIM.Model;
using AjaxControlToolkit;

namespace UI
{
    public partial class ManufacturerRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = btnRegistrar.UniqueID;


            ((ToolkitScriptManager)this.Master.FindControl("ToolkitScriptManager1")).RegisterAsyncPostBackControl(this.AsyncFileUpload1);

            if (!IsPostBack)
            {
                
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Fabricante _manuf = new Fabricante();

            _manuf.Id = Guid.NewGuid();
            _manuf.Nome = txtName.Text;
            _manuf.RazaoSocial = txtFormalName.Text;
            _manuf.Telefone = txtPhone.Text;
            _manuf.Email = txtEmail.Text;
            _manuf.Site = txtSite.Text;
            #region ImageLogo
            if ( !string.IsNullOrEmpty(lblFileName.Text) && System.IO.File.Exists(Server.MapPath("~/tempfiles/") + lblFileName.Text))
            {
                String filepath = Server.MapPath("~/tempfiles/") + lblFileName.Text;
                // convert to byte array
                byte[] _imgArr = ImageToByteArray(filepath);
                _manuf.Logo = _imgArr; //save as base64 array
            }
            #endregion

            LimpaMensagens();

            try
            {

                Guid _newId = FabricanteBLO.Insert(_manuf);
                if (_newId != Guid.Empty)
                {
                    lblSuccessMsg.Text = "Fabricante incluído com Sucesso";
                    pnlSuccess.Visible = true;
                }

            }
            catch (AggregateException aEx)
            {
                lblErrorMsg.Text = aEx.Message + aEx.InnerException ?? "<br />" + aEx.InnerException.ToString();
                pnlError.Visible = true;
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message + ex.InnerException ?? "<br />" + ex.InnerException.ToString();
                pnlError.Visible = true;
            }


        }

        private void LimpaMensagens()
        {
            pnlError.Visible = false; lblErrorMsg.Text = string.Empty;
            pnlSuccess.Visible = false; lblSuccessMsg.Text = string.Empty;
            pnlInfo.Visible = false; lblInfoMsg.Text = string.Empty;
        }

        public static byte[] ImageToByteArray(string imageLocation)
        {
            byte[] imageData = null;
            FileInfo fileInfo = new FileInfo(imageLocation);
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imageData = br.ReadBytes((int)imageFileLength);
            return imageData;
        }




        #region AsyncFileUpload Buttons
            
        protected void AsyncFileUpload1_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
        {
            lblErrorMsg.Text = string.Empty;

            if (AsyncFileUpload1.HasFile)
            {
                try
                {
                    if ((new string[] { "image/png", "image/jpg", "image/jpeg" }).Contains(AsyncFileUpload1.PostedFile.ContentType))
                    {
                        if (AsyncFileUpload1.PostedFile.ContentLength < 102400)
                        {
                            lblFileName.Text = AsyncFileUpload1.FileName;
                            AsyncFileUpload1.PostedFile.SaveAs(Server.MapPath("~/tempfiles/") + lblFileName.Text);
                        }
                        else
                            lblErrorMsg.Text = "Aviso: Tamanho do arquivo deve ser até 100 kb.<br/>";
                    }
                    else
                        lblErrorMsg.Text = "Aviso: Extensão do arquivo inválida. Utilize apenas .png, .jpg ou .jpeg<br/>";
                }
                catch (Exception ex)
                {
                    lblErrorMsg.Text += "Falha ao enviar arquivo:  " + ex.Message;
                }

                if (!string.IsNullOrEmpty(lblErrorMsg.Text))
                {
                    this.Master.showMessage(lblErrorMsg.Text, "Atenção", AlertType.Warning);
                }
                pnlError.Visible = !string.IsNullOrEmpty(lblErrorMsg.Text);

            }
            else
            {
                lblFileName.Text = null;
            }

        }

        protected void AsyncFileUpload1_UploadedFileError(object sender, AsyncFileUploadEventArgs e)
        {
            if (e.StatusMessage != "The file attached has an invalid filename.")
            {
                lblErrorMsg.Text = "FileUpload: " + e.StatusMessage;
            }
            else
            {
                lblErrorMsg.Text = "Arquivo inválido.";
                pnlError.Visible = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (lblFileName.Text!= null && System.IO.File.Exists(Server.MapPath("~/tempfiles/") + lblFileName.Text.ToString()))
            {
                File.Delete(Server.MapPath("~/tempfiles/") + lblFileName.Text.ToString());
            }
            lblFileName.Text = string.Empty;

        }
        #endregion

    }
}