using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                using (FireBaseHelper _fb = new FireBaseHelper())
                {
                    Task resultTask = _fb.searchManufacturerByName(txtBusca.Text);
                    
                }
            }
            catch (AggregateException aEx)
            {
                //pnlError.Visible = true;
                //lblErrorMsg.Text = aEx.Message + "\n" + aEx.InnerException ?? aEx.InnerException.ToString();
            }
            catch (Exception ex)
            {
                //lblErrorMsg.Text = ex.Message;
            }
        }
    }
}