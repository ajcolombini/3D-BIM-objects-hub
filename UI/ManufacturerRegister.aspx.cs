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
                //this.Master.showMessage("TESTE", "Atenção", AlertType.Warning); 
                //clsAlerts.bootstrapAlert("TESTE", "Aviso", AlertType.Error, this.Master.updPnlMaster);
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Manufacturer _manuf = new Manufacturer();

            _manuf.id = Guid.NewGuid().ToString();
            _manuf.name = txtName.Text;
            _manuf.formalName = txtFormalName.Text;
            _manuf.phone = txtPhone.Text;
            _manuf.eMail = txtEmail.Text;
            _manuf.webSite = txtSite.Text;
            #region ImageLogo
            if (ViewState["FileName"] != null && !string.IsNullOrEmpty(ViewState["FileName"].ToString()) && System.IO.File.Exists(Server.MapPath("~/tempfiles/") + ViewState["FileName"].ToString()))
            {
                String filepath = Server.MapPath("~/tempfiles/") + ViewState["FileName"].ToString();
                // convert to byte array
                byte[] _imgArr = ImageToByteArray(filepath);
                _manuf.logo = _imgArr; //save as base64 array
            }
            #endregion

            LimpaMensagens();

            try
            {

                Guid _newId = ManufacturerBLO.Insert(_manuf);
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



        #region fileUpload Buttons
        //protected void btnSaveFile_Click(object sender, EventArgs e)
        //{
        //    if (fileUploadLogo.HasFile)
        //    {
        //        try
        //        {
        //            if ((new string[] { "image/png", "image/jpg", "image/jpeg" }).Contains(fileUploadLogo.PostedFile.ContentType))
        //            {
        //                if (fileUploadLogo.PostedFile.ContentLength < 102400)
        //                {
        //                    string filename = Path.GetFileName(fileUploadLogo.FileName);
        //                    fileUploadLogo.SaveAs(Server.MapPath("~/tempfiles/") + filename);
        //                }
        //                else
        //                    lblErrorMsg.Text += "Aviso: Tamanho do arquivo deve ser até 100 kb.<br/>";
        //            }
        //            else
        //                lblErrorMsg.Text += "Aviso: Extensão do arquivo inválida. Utilize apenas .png, .jpg ou .jpeg<br/>";

        //        }
        //        catch (Exception ex)
        //        {
        //            lblErrorMsg.Text += "Falha ao enviar arquivo:  " + ex.Message;
        //        }

        //        if (!string.IsNullOrEmpty(lblErrorMsg.Text))
        //        {
        //            clsAlerts.jsAlert(lblErrorMsg.Text, "Aviso", AlertType.Error, this.Page);
        //            clsJQuery.jsAlert(lblErrorMsg.Text, "Aviso", jAlertType.Error, this.Page);
        //        }


        //        pnlError.Visible = !string.IsNullOrEmpty(lblErrorMsg.Text);
        //    }
        //}

        //protected void btnDelFile_Click(object sender, EventArgs e)
        //{
        //    if (File.Exists(Server.MapPath("~/tempfiles/") + txtFileName.Text))
        //        File.Delete(Server.MapPath("~/tempfiles/") + txtFileName.Text);

        //    txtFileName.Text = string.Empty;
        //}
        #endregion

        #region AsyncFileUpload Buttons
            
        protected void AsyncFileUpload1_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
        {
            if (AsyncFileUpload1.HasFile)
            {
                try
                {
                    if ((new string[] { "image/png", "image/jpg", "image/jpeg" }).Contains(AsyncFileUpload1.PostedFile.ContentType))
                    {
                        if (AsyncFileUpload1.PostedFile.ContentLength < 102400)
                        {
                            ViewState["FileName"] = AsyncFileUpload1.FileName;
                            lblFileName.Text = ViewState["FileName"].ToString();
                            AsyncFileUpload1.PostedFile.SaveAs(Server.MapPath("~/tempfiles/") + ViewState["FileName"].ToString());

                        }
                        else
                            lblErrorMsg.Text += "Aviso: Tamanho do arquivo deve ser até 100 kb.<br/>";
                    }
                    else
                        lblErrorMsg.Text += "Aviso: Extensão do arquivo inválida. Utilize apenas .png, .jpg ou .jpeg<br/>";


                }
                catch (Exception ex)
                {
                    lblErrorMsg.Text += "Falha ao enviar arquivo:  " + ex.Message;
                }

                if (!string.IsNullOrEmpty(lblErrorMsg.Text))
                {
                   // clsAlerts.bootstrapAlert(lblErrorMsg.Text, "Aviso", AlertType.Error, this.Master.updPnlMaster);
                    this.Master.showMessage(lblErrorMsg.Text, "Atenção", AlertType.Warning);
                    ViewState["FileName"] = null;
                    ViewState["FileName"] = string.Empty;
                }
                pnlError.Visible = !string.IsNullOrEmpty(lblErrorMsg.Text);

            }
            else
            {
                ViewState["FileName"] = null;
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

        //protected void btnSaveFile_Click(object sender, EventArgs e)
        //{
        //    if (ViewState["FileName"]!=null)
        //    {
        //        txtFileName.Text = ViewState["FileName"].ToString();
        //    }
        //}

        protected void btnDelFile_Click(object sender, EventArgs e)
        {
            if (ViewState["FileName"] != null && System.IO.File.Exists(Server.MapPath("~/tempfiles/") + ViewState["FileName"].ToString()))
            {
                File.Delete(Server.MapPath("~/tempfiles/") + ViewState["FileName"].ToString());
            }
            ViewState["FileName"] = null;

        }
        #endregion

    }
}