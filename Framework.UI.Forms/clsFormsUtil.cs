using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace ACE.UI.Forms
{
    public class clsFormsUtil
    {

        public static void LimparForm(Form frm, bool limpaComboBox)
        {
            foreach (Control item in frm.Controls)
            {
                if (item is TextBox)
                    ((TextBox)item).Text = string.Empty;
                else if (item is RichTextBox)
                    ((RichTextBox)item).Text = string.Empty;
                else if (item is DateTimePicker)
                    item.Text = string.Empty;
                else if (item is MaskedTextBox)
                    item.Text = string.Empty;
                else if (item is GroupBox)
                {
                    for (int i = 0; i < item.Controls.Count; i++)
                    {
                        if (item.Controls[i] is TextBox)
                        {
                            (item.Controls[i] as TextBox).Text = string.Empty;
                        }

                        if (limpaComboBox)
                        {
                            if (item.Controls[i] is ComboBox)
                            {
                                (item.Controls[i] as ComboBox).SelectedIndex = 0;
                            }
                            if (item.Controls[i] is ComboBox)
                            {
                                (item.Controls[i] as ComboBox).SelectedValue = 0;
                            }
                        }
                        if (item.Controls[i] is RichTextBox)
                        {
                            (item.Controls[i] as RichTextBox).Text = string.Empty;
                        }
                        if (item.Controls[i] is RadioButton)
                        {
                            (item.Controls[i] as RadioButton).Checked = true;
                        }
                        if (item.Controls[i] is DateTimePicker)
                        {
                            (item.Controls[i] as DateTimePicker).Text = string.Empty;
                        }

                        if (item.Controls[i] is MaskedTextBox)
                        {
                            (item.Controls[i] as MaskedTextBox).Text = string.Empty;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Formata o CPF no Textbox
        /// </summary>
        /// <example>
        /// Usar no evento Keypress do TextBox
        /// private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        //{
            //if (Information.IsNumeric(e.KeyChar) && txtCPF.TextLength < txtCPF.MaxLength)
            //{
            //    txtCPF.Text += e.KeyChar;
            //    txtCPF.SelectionStart = txtCPF.TextLength;
            //    txtCPF.Text = clsFormsUtil.FormataCPF(txtCPF);               
            //}
            //e.Handled = true;
        //}
        /// </example>
        /// <param name="txtTexto">Objeto tipo TextBox</param>
        /// <returns>String Formatada com mascara do CPF</returns>
        public static string FormataCPF(TextBox txtTexto)
        {
            string _ret = string.Empty;
            if (txtTexto.Text.ToString().Length == 3)
            {
                txtTexto.Text = txtTexto.Text + ".";
                txtTexto.SelectionStart = txtTexto.Text.ToString().Length + 1;
            }
            else if (txtTexto.Text.ToString().Length == 7)
            {
                txtTexto.Text = txtTexto.Text + ".";
                txtTexto.SelectionStart = txtTexto.Text.ToString().Length + 1;
            }
            else if (txtTexto.Text.ToString().Length == 11)
            {
                txtTexto.Text = txtTexto.Text + "-";
                txtTexto.SelectionStart = txtTexto.Text.ToString().Length + 1;
            }
            return _ret = txtTexto.Text;
        }
        
        public static string FormatarCNPJCPF(string strCpfCnpj)
        {
            if (strCpfCnpj.Length <= 11)
            {
                MaskedTextProvider mtpCpf = new MaskedTextProvider(@"000\.000\.000-00");
                mtpCpf.Set(ZerosEsquerda(strCpfCnpj, 11));
                return mtpCpf.ToString();
            }
            else
            {
                MaskedTextProvider mtpCnpj = new MaskedTextProvider(@"00\.000\.000/0000-00");
                mtpCnpj.Set(ZerosEsquerda(strCpfCnpj, 11));
                return mtpCnpj.ToString();
            }
        }

        public static string ZerosEsquerda(string strString, int intTamanho)
        {
            string strResult = "";
            for (int intCont = 1; intCont <= (intTamanho - strString.Length); intCont++)
            {
                strResult += "0";
            }
            return strResult + strString;
        }
        
        public static void AbrirArquivo(string strPathFile)
        {
            try
            {
                //Verifico se o arquivo que desejo abrir existe e passo como parâmetro a respectiva variável
                if (File.Exists(strPathFile))
                {
                    //Se existir "starto" um processo do sistema para abrir o arquivo e, sem precisar
                    //passar ao processo o aplicativo a ser aberto, ele abre automaticamente o Notepad
                    System.Diagnostics.Process.Start(strPathFile);
                }

                else
                {
                    //Se não existir exibo a mensagem
                    MessageBox.Show("Arquivo não encontrado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Apagar arquivos de um diretorio e o diretorio
        /// </summary>
        /// <param name="strPathFile">Caminho do diretório</param>
        /// <param name="apagaDiretorio">True = apagar arquivo(s) e o diretório, False = apaga somente o(s) arquivo(s)</param>
        public static void ApagarArquivosPath(string strPathFile, bool apagaDiretorio)
        {
            try
            {
                string[] files = System.IO.Directory.GetFiles(strPathFile);
                string fileName = string.Empty;
                string destFile = string.Empty;

                foreach (string s in files){
                    System.IO.File.Delete(s);
                }

                if (apagaDiretorio == true)
                    Directory.Delete(strPathFile);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
