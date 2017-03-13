using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Office.Interop.Excel;

namespace ACE.UI.Forms
{
    public class clsExcelUtil
    {
        /// <summary>
        /// Gera arquivo excel, baseado em um DataGrudView
        /// </summary>
        /// <param name="_listNomeColunaRemover">Lista de string com nomes de colunas para remover do excel</param>
        /// <param name="dataGridViewGerarExcel">Objeto DataGridView</param>
        /// <param name="nomeArquivo">Nome do arquivo</param>
        /// <param name="pathSaveFile">Caminho físico para salvar o arquivo</param>
        /// <example>
        /// List<string> _listColunm = new List<string>();
        /// _listColunm.Add("chkBaixa");
        /// _listColunm.Add("Id");
        /// GeraFileExcel(_listColunm, gvGridGenerico, "testemetodo", "C:\\Temp\\");
        /// </example>
        public void GeraFileExcel(List<string> _listNomeColunaRemover,
            DataGridView dataGridViewGerarExcel, string nomeArquivo, string pathSaveFile)
        {

            DataGridView _gvRelatorio = new DataGridView();
            _gvRelatorio = dataGridViewGerarExcel;

            if (_listNomeColunaRemover != null)
            {
                if (_listNomeColunaRemover.Count > 0)
                {
                    foreach (string _objList in _listNomeColunaRemover)
                    {
                        _gvRelatorio.Columns.Remove(_objList.ToString());
                    }
                }
            }
            
            // instanciando as variáveis
            Microsoft.Office.Interop.Excel.Application excelapp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excelapp.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            excelapp.Visible = true;

            try
            {
                // pegando a primeira planilha do excel;
                // deixando-a como ativa e ao final, 
                // será atribuido um nome a ela.
                worksheet = (Worksheet)workbook.Sheets["Plan1"];
                worksheet = (Worksheet)workbook.ActiveSheet;
                worksheet.Name = nomeArquivo;

                // pegando os nomes das colunas do DataGridView
                for (int i = 1; i < _gvRelatorio.Columns.Count + 1; i++){
                    worksheet.Cells[1, i] = _gvRelatorio.Columns[i - 1].HeaderText;
                }

                // fazendo um loop no DataGridView, que recupera as rows
                // do DataGridView, correspondente a cada column.
                for (int i = 0; i < _gvRelatorio.Rows.Count; i++){
                    for (int j = 0; j < _gvRelatorio.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = _gvRelatorio.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // ao final, salva no formato do Excel.
                workbook.SaveAs(pathSaveFile + nomeArquivo + ".xlsx",
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing,
                    Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
                MessageBox.Show("Arquivo criado com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                excelapp = null;
                workbook = null;
                worksheet = null;
            }
        }
    }
}
