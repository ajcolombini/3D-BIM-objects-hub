using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Framework.UI.Web
{
    public class clsExcelUtil
    {
        /// <summary>
        /// Gerar Excel Browser
        /// </summary>
        /// <param name="dataTableGeracao">DataTable para gear Excel</param>
        /// <param name="nomeArquivo">Nome do arquivo</param>
        /// <param name="page">page que esta se estanciando este médoto</param>
        /// <param name="form">form onde esta estanciando este médoto</param>
        /// <example>GeraExcel(GetClientesTadaTable,"excelClientes",this,this)</example>
        public void GeraExcel(DataTable dataTableGeracao, string nomeArquivo, Page page,HtmlForm form) {

            //Conteúdo do Response
            Page _pg = page;
            _pg.Response.AddHeader("content-disposition", "attachment; filename=" + nomeArquivo + ".xls");
            _pg.Response.Charset = "";
            _pg.Response.ContentType = "application/vnd.xls";

            //Objetos
            StringWriter stringWrite = new System.IO.StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            //Inclui controles 
            DataGrid dgDados = new DataGrid();
            form.Controls.Add(dgDados);

            ////Definição de cores
            //dgDados.HeaderStyle.BackColor = System.Drawing.Color.Yellow;
            dgDados.DataSource = dataTableGeracao;
            dgDados.DataBind();

            ////definição das cores das células
            //foreach (DataGridItem dgi in dgDados.Items)
            //    foreach (TableCell tcGridCells in dgi.Cells)
            //        tcGridCells.Attributes.Add("class", "sborda");

            //Renderiza o DataGrid
            dgDados.RenderControl(htmlWrite);

            //Inluir a classe de estilo
            //Response.Write(@"<style> .sborda { color : Red;border : 1px Solid Balck; } </style> ");
            //Exporta 
            _pg.Response.Write(stringWrite.ToString());
            //encerra
            _pg.Response.End();
        
        }
    }
}
