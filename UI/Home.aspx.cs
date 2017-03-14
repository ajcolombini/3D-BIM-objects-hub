﻿using System;
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
                
                Manufacturer _fab = new Manufacturer();
                _fab.name = txtBusca.Text;
                _fab.formalName = txtBusca.Text;

                List<Manufacturer> _lstFabricantes = ManufacturerBLO.FindAny(_fab);

                //Product _prod = new Product();
                //_prod.code = txtBusca.Text;
                //_prod.name = txtBusca.Text;
                //_prod.description = txtBusca.Text;

                //List<Product> _lstProdutos = ProductBLO.FindAny(_prod);


                gvwResults.DataSource = _lstFabricantes;
                gvwResults.DataBind();
                
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