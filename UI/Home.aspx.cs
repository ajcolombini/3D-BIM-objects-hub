using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIM.Model;
using BIM.BLL;

namespace UI
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected  void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                
                Fabricante _fab = new Fabricante();
                _fab.Nome = txtBusca.Text;
                _fab.RazaoSocial = txtBusca.Text;

                List<Fabricante> _lstFabricantes = FabricanteBLO.FindAny(_fab);

                //Product _prod = new Product();
                //_prod.code = txtBusca.Text;
                //_prod.name = txtBusca.Text;
                //_prod.description = txtBusca.Text;

                //List<Product> _lstProdutos = ProductBLO.FindAny(_prod);


                gvwResults.DataSource = _lstFabricantes;
                gvwResults.DataBind();
                pnlResults.Visible = _lstFabricantes.Count > 0;

                if(_lstFabricantes.Count == 0)
                {
                    lblInfoMsg.Text = "Sem Resultados para a Busca.";
                    pnlInfo.Visible = true;
                }else
                {
                    lblInfoMsg.Text = string.Empty;
                    pnlInfo.Visible = false;
                }
                
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
    }
}