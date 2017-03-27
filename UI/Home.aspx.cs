using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIM.Model;
using BIM.BLL;
using System.IO;
using System.Data;

namespace UI
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                //Fabricante _fab = new Fabricante();
                //_fab.Nome = txtBusca.Text;
                //_fab.RazaoSocial = txtBusca.Text;

                //List<Fabricante> _lstFabricantes = FabricanteBLO.FindAny(_fab);

                ////Product _prod = new Product();
                ////_prod.code = txtBusca.Text;
                ////_prod.name = txtBusca.Text;
                ////_prod.description = txtBusca.Text;

                ////List<Product> _lstProdutos = ProductBLO.FindAny(_prod);


                //gvwResults.DataSource = _lstFabricantes;
                //gvwResults.DataBind();
                //pnlResults.Visible = _lstFabricantes.Count > 0;

                //if (_lstFabricantes.Count == 0)
                //{
                //    lblInfoMsg.Text = "Sem Resultados para a Busca.";
                //    pnlInfo.Visible = true;
                //}
                //else
                //{
                //    lblInfoMsg.Text = string.Empty;
                //    pnlInfo.Visible = false;
                //}

                DataSet _return = new DataSet();
                _return = FabricanteBLO.FindAnything(txtBusca.Text);

                this.gvwResults.DataSource = _return;
                this.gvwResults.DataBind();

                pnlResults.Visible = (gvwResults.Rows.Count > 0);

            }
            catch (AggregateException aEx)
            {
                lblErrorMsg.Text = aEx.Message + "\n" + aEx.InnerException ?? aEx.InnerException.ToString();
                pnlError.Visible = true;
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
                pnlError.Visible = true;
            }
        }

        protected void gvwResults_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Image _imgCtrl = (Image)(e.Row).FindControl("imgProduto");
            //    object _oImgData = e.Row.DataItem;
                
            //    // Retrieve the underlying data item. In this example
            //    // the underlying data item is a DataRowView object. 
            //    DataRowView rowView = (DataRowView)e.Row.DataItem;

            //    // Retrieve the state value for the current row. 
            //    byte[] bytes = (byte[])rowView["Imagem"];

            //    if (bytes != null && _imgCtrl != null)
            //        _imgCtrl.ImageUrl = Getbase64Image(bytes);
            //}
        }

        private System.Drawing.Image GetSystemDrawingImage(object imgByteArray)
        {
            byte[] imgArray = (byte[])imgByteArray;

            MemoryStream ms = new MemoryStream(imgArray);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

            return img;
        }

        public string Getbase64Image(object input)
        {

            byte[] bytes = (byte[])input;
            return "data:image/jpeg;base64," +  Convert.ToBase64String(bytes, Base64FormattingOptions.None);

            //string encoded = HttpUtility.UrlEncode(Convert.ToBase64String(bytes));
            //return "HttpImageHandler?imgByteArray=" + encoded;
        }

    }
}