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

namespace UI
{
    public partial class ManufacturerRegister : System.Web.UI.Page
    {
        protected  void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = btnRegistrar.UniqueID;

            if (!IsPostBack)
            {

               
            }
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
            #region ImageLogo
            if (!string.IsNullOrEmpty(txtFileName.Text) && System.IO.File.Exists(Server.MapPath("~/tempfiles/") + txtFileName.Text))
            {
                String filepath = Server.MapPath("~/tempfiles/") + txtFileName.Text;
                // convert to byte array
                byte[] _imgArr = ImageToByteArray(filepath);

                // get the base 64 string
                String _imgString = Convert.ToBase64String(_imgArr);

                _model.manufacturer.logo = _imgString; //save as base64 array
            }
            #endregion


            try
            {
                using (FireBaseHelper _fb = new FireBaseHelper())
                {
                    Task resultTask = _fb.SaveManufacturer(_model);
                    resultTask.Wait();
                }
            }
            catch (AggregateException aEx)
            {
                pnlError.Visible = true;
                lblErrorMsg.Text = aEx.Message + "\n" + aEx.InnerException ?? aEx.InnerException.ToString();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }


            //string _body = FireBaseHelper.JsonModel;
            //FireSharp.Response.PushResponse _push = new FireSharp.Response.PushResponse(_body, System.Net.HttpStatusCode.OK, new System.Net.Http.HttpResponseMessage());
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





        protected void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (fileUploadLogo.HasFile)
            {
                try
                {
                    if ((new string[] { "image/png", "image/jpg", "image/jpeg" }).Contains(fileUploadLogo.PostedFile.ContentType))
                    {
                        if (fileUploadLogo.PostedFile.ContentLength < 102400)
                        {
                            string filename = Path.GetFileName(fileUploadLogo.FileName);
                            fileUploadLogo.SaveAs(Server.MapPath("~/tempfiles/") + filename);
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


                pnlError.Visible = !string.IsNullOrEmpty(lblErrorMsg.Text);
            }
        }

        protected void btnDelFile_Click(object sender, EventArgs e)
        {
            if (File.Exists(Server.MapPath("~/tempfiles/") + txtFileName.Text))
                File.Delete(Server.MapPath("~/tempfiles/") + txtFileName.Text);

            txtFileName.Text = string.Empty;
        }


    }
}