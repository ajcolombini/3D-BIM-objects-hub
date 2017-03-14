using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*
 * Referenciar:
 *  System.Web.Extensions
 *  System.Web.Extensions.Design
 */

namespace ACE.Util
{
/// <summary>
/// 
/// </summary>
    public enum jAlertType
    {
        Error,
        Warning,
        Confirm,
        Info,
        Success
    }

    /// <summary>
    /// Utiliza jQuery para criar scripts dinamicos
    /// </summary>
    public class clsJQuery
    {
        /// <summary>
        /// Exibe Alerta na Tela
        /// </summary>
        /// <param name="msg">Mensagem</param>
        /// <param name="title">Titulo da Mensagem</param>
        /// <param name="dialogType">Enumerador para Tipo de Mensagem</param>
        /// <param name="page">Pagina origem</param>
        public static void jsAlert(string msg, string title, jAlertType dialogType, Page page)
        {
            // Define type of the client scripts on the page.
            Type cstype = page.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            //Build the jQuery script
            StringBuilder sb = new StringBuilder();

            switch (dialogType)
            {
                case jAlertType.Error:
                    sb.AppendLine("jAlertError('<b><center>" + msg + "</center></b>', '" + title + "', '');");
                    break;
                case jAlertType.Warning:
                    sb.AppendLine("jAlertWarning('<b><center>" + msg + "</center></b>', '" + title + "', '');");
                    break;
                case jAlertType.Info:
                    sb.AppendLine("jAlertInfo('<b><center>" + msg + "</center></b>', '" + title + "', '');");
                    break;
                case jAlertType.Success:
                    sb.AppendLine("jAlertSuccess('<b><center>" + msg + "</center></b>', '" + title + "', '');");
                    break;
                default:
                    break;
            }

            //Register the script
            cs.RegisterStartupScript(cstype, "jsAlerty", sb.ToString(), true);
        }

        /// <summary>
        /// Versao para paginas que contem updatePanels
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        /// <param name="dialogType"></param>
        /// <param name="updPanel"></param>
        public static void jsAlert(string msg, string title, jAlertType dialogType, Control updPanel)
        {
      

            //Build the jQuery script
            StringBuilder sb = new StringBuilder();

            switch (dialogType)
            {
                case jAlertType.Error:
                    sb.AppendLine("jAlertError('<b><center>" + msg + "</center></b>', '" + title + "', '');");
                    break;
                case jAlertType.Warning:
                    sb.AppendLine("jAlertWarning('<b><center>" + msg + "</center></b>', '" + title + "', '');");
                    break;
                case jAlertType.Info:
                    sb.AppendLine("jAlertInfo('<b><center>" + msg + "</center></b>', '" + title + "', '');");
                    break;
                case jAlertType.Success:
                    sb.AppendLine("jAlertSuccess('<b><center>" + msg + "</center></b>', '" + title + "', '');");
                    break;
                default:
                    break;
            }


            //Registra Script de dentro de um UpdatePanel
            System.Web.UI.ScriptManager.RegisterStartupScript(updPanel, updPanel.GetType(), "jsConfirm", sb.ToString(), true);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        /// <param name="dialogType"></param>
        /// <param name="updPanel"></param>
        /// <param name="callBackFunction"></param>
        public static void jsAlert(string msg, string title, jAlertType dialogType, Control updPanel, String callBackFunction)
        {


            //Build the jQuery script
            StringBuilder sb = new StringBuilder();

            switch (dialogType)
            {
                case jAlertType.Error:
                    sb.AppendLine("jAlertError('<b><center>" + msg + "</center></b>', '" + title + "', " + callBackFunction + ");");
                    break;
                case jAlertType.Warning:
                    sb.AppendLine("jAlertWarning('<b><center>" + msg + "</center></b>', '" + title + "', " + callBackFunction + ");");
                    break;
                case jAlertType.Info:
                    sb.AppendLine("jAlertInfo('<b><center>" + msg + "</center></b>', '" + title + "', " + callBackFunction + ");");
                    break;
                case jAlertType.Success:
                    sb.AppendLine("jAlertSuccess('<b><center>" + msg + "</center></b>', '" + title + "', " + callBackFunction + ");");
                    break;
                default:
                    break;
            }


            //Registra Script de dentro de um UpdatePanel
            System.Web.UI.ScriptManager.RegisterStartupScript(updPanel, updPanel.GetType(), "jsConfirm", sb.ToString(), true);

        }




       
        /// <summary>
        /// Caixa de Confirmação
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        /// <param name="useCallBackFunction">Se true, deve haver funcao 'setDialogResult' declarada</param>
        /// <param name="page"></param>
        public static void jsConfirm(string msg, string title,  bool useCallBackFunction, Page page)
        {
            // Define type of the client scripts on the page.
            Type cstype = page.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            //Build the jQuery script
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("jAlertConfirm('<b><center>" + msg + "</center></b>', '" + title + "', '" + useCallBackFunction + "');");
                  
            //Register the script
            cs.RegisterStartupScript(cstype, "jsConfirm", sb.ToString(), true);


            ////Declaracao da Funcao 'setDialogResult' Necessaria para uso com jConfirm:
            //function setDialogResult(r) {
            //    if (r) {
            //        //Se retornou True
            //        $("[ID$=btnHiddenConfirmOK]").click();
            //    } else {
            //        //Se retornou False
            //        $("[ID$=btnHiddenConfirmNO]").click();
            //    }
        }


       

        /// <summary>
        /// Versao para paginas que contem updatePanels
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        /// <param name="useCallBackFunction"></param>
        /// <param name="updPanel"></param>
        public static void jsConfirm(string msg, string title, bool useCallBackFunction, Control updPanel)
        {

            //Build the jQuery script
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("jAlertConfirm('<b><center>" + msg + "</center></b>', '" + title + "', '" + useCallBackFunction + "');");

            //Registra Script de dentro de um UpdatePanel
            ScriptManager.RegisterStartupScript(updPanel, updPanel.GetType(), "jsConfirm", sb.ToString(), true);
        }


        /// <summary>
        /// Confirm chamando funcao callback personalizada
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        /// <param name="callBackFunction">nome da funcão javascript ou jquery para chamar no callback</param>
        /// <param name="updPanel"></param>
        public static void jsConfirm(string msg, string title, string callBackFunction, Control updPanel)
        {

            //Build the jQuery script
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("jAlertConfirm('<b><center>" + msg + "</center></b>', '" + title + "', " + callBackFunction + ");");

            //Registra Script de dentro de um UpdatePanel
            ScriptManager.RegisterStartupScript(updPanel, updPanel.GetType(), "jsConfirm", sb.ToString(), true);
        }

        /// <summary>
        /// Chamada para paginas sem updatePanel
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        /// <param name="callBackFunction"></param>
        /// <param name="page"></param>
        public static void jsConfirm(string msg, string title, string callBackFunction, Page page)
        {
            // Define type of the client scripts on the page.
            Type cstype = page.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            //Build the jQuery script
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("jAlertConfirm('<b><center>" + msg + "</center></b>', '" + title + "', " + callBackFunction + ");");

            //Registra Script de dentro de um UpdatePanel
            cs.RegisterStartupScript(cstype, "jsConfirm", sb.ToString(), true);
        }


        /// <summary>
        /// Cria uma 'fancyBox' dinâmica na pagina
        /// </summary>
        /// <param name="msg">Texto da Mensagem</param>
        /// <param name="page">Pagina origem</param>
        public static void fancyBox(string msg, Page page)
        {
            // Define type of the client scripts on the page.
            Type cstype = page.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            //Build the jQuery script
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"$(document).ready(function(){");
            sb.AppendLine(@"  $.fancybox('<div style=""""white-space: nowrap""""><h3>" + msg + "</h3></div>');");
            sb.AppendLine(@"});");

            //Register the script
            cs.RegisterStartupScript(cstype, "fancybox", sb.ToString(), true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientControlID"></param>
        /// <param name="msg"></param>
        /// <param name="page"></param>
        //public static void fancyBoxCtrl(string clientControlID, string msg, Page page)
        //{
        //    // Define type of the client scripts on the page.
        //    Type cstype = page.GetType();

        //    // Get a ClientScriptManager reference from the Page class.
        //    ClientScriptManager cs = page.ClientScript;
            
        //    //Build the jQuery script
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine(@"$(document).ready(function(){");
        //    sb.AppendLine(@"  $('#" + clientControlID + "').fancybox();");
        //    sb.AppendLine(@"});");

        //    //Register the script
        //    cs.RegisterStartupScript(cstype, "fancyboxCtrl", sb.ToString(), true);
        //}

     
        /// <summary>
        /// Cria uma 'fancyBox' dinâmica na pagina com ícone de exclamacao
        /// </summary>
        /// <param name="msg">Texto da Mensagem</param>
        /// <param name="page">Pagina origem</param>
        /// <param name="fontAwesomeIcon">ex: 'fa fa-exclamation-triangle'</param>
        /// <param name="iconStyle">Ex: 'font-size:48px;color:red'</param>
        public static void fancyBoxIcon(string msg, string fontAwesomeIcon, string iconStyle, Page page)
        {
            // Define type of the client scripts on the page.
            Type cstype = page.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            //Build the jQuery script
            StringBuilder sb = new StringBuilder();
             
            sb.AppendLine("$(document).ready(function(){");
            sb.AppendLine("  $.fancybox(");
            sb.AppendLine("     \"<div><i class='" + fontAwesomeIcon + "' style='" + iconStyle + "'></i><span>&nbsp;" + msg + "&nbsp</span></div>\"");
            sb.AppendLine("  );");
            sb.AppendLine("});");

            //Register the script
            cs.RegisterStartupScript(cstype, "fancyboxWarning", sb.ToString(), true);
        }

        public static void fancyBoxIconWarning(string msg, Page page)
        {
            // Define type of the client scripts on the page.
            Type cstype = page.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            //Build the jQuery script
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("$(document).ready(function(){");
            sb.AppendLine("  $.fancybox(");
            sb.AppendLine("     \"<div><i class='fa fa-exclamation-triangle' style='font-size:48px;color:orange'></i><span>&nbsp;" + msg + "&nbsp</span></div>\"");
            sb.AppendLine("  );");
            sb.AppendLine("});");

            //Register the script
            cs.RegisterStartupScript(cstype, "fancyboxWarning", sb.ToString(), true);
        }

        /// <summary>
        /// Cria uma 'fancyBox' dinâmica na pagina e executa um código passado como callback
        /// </summary>
        /// <param name="msg">Texto da Mensagem</param>
        /// <param name="page">Pagina origem</param>
        /// <param name="onStartCode">Codigo executado no evento onStart</param>
        /// <param name="onCancelCode">Codigo executado no evento onCancel</param>
        /// <param name="onCompleteCode">Codigo executado no evento onComplete</param>
        /// <param name="onCleanupCode">Codigo executado no evento onCleanup</param>
        /// <param name="onClosedCode">Codigo executado no evento onClosed</param>
        public static void fancyBoxCallBack(string msg, System.Web.UI.Page page, string onStartCode, string onCancelCode, string onCompleteCode, string onCleanupCode, string onClosedCode)
        {
            // Define type of the client scripts on the page.
            Type cstype = page.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            //Build the jQuery script
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(" $(document).ready(");
            sb.AppendLine(" function() {");
            sb.AppendLine("    $.fancybox('" + msg + "', {");
            if (!string.IsNullOrEmpty(onStartCode))
            {
                sb.AppendLine("        onStart: function() {");
                sb.AppendLine("            " + onStartCode);
                sb.AppendLine("        },");
            }
            if (!string.IsNullOrEmpty(onCancelCode))
            {
                sb.AppendLine("        onCancel: function() {");
                sb.AppendLine("          " + onCancelCode);
                sb.AppendLine("        },");
            }
            if (!string.IsNullOrEmpty(onCompleteCode))
            {
                sb.AppendLine("        onComplete: function() {");
                sb.AppendLine("          " + onCompleteCode);
                sb.AppendLine("        },");
            }
            if (!string.IsNullOrEmpty(onCleanupCode))
            {
                sb.AppendLine("        onCleanup: function() {");
                sb.AppendLine("           " + onCleanupCode);
                sb.AppendLine("        },");
            }
            if(!string.IsNullOrEmpty(onClosedCode))
            {
                sb.AppendLine("        onClosed: function() {");
                sb.AppendLine("           " + onClosedCode );
                sb.AppendLine("        }");
            }
            sb.AppendLine("    });"); // fancybox function
            sb.AppendLine(" });"); // anonymous function + ready function
            
            //Register the script
            cs.RegisterStartupScript(cstype, "fancybox", sb.ToString(), true);
        }

        /// <summary>
        /// Mostra / Esconde Span
        /// </summary>
        /// <param name="page"></param>
        /// <param name="spanName"></param>
        /// <param name="show"></param>
        public static void showSpan(System.Web.UI.Page page, string spanName, bool show)
        {
            // Define type of the client scripts on the page.
            Type cstype = page.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            //Build the jQuery script
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" $(document).ready(");
            sb.AppendLine("     function() {");
            if (show) {
                sb.AppendLine("         $('" + spanName + "').show()");
            }
            else {
                sb.AppendLine("         $('" + spanName + "').hide()");
            }
            sb.AppendLine("     }");
            sb.AppendLine(" });"); // anonymous function + ready function

            //Register the script
            cs.RegisterStartupScript(cstype, "showSpan", sb.ToString(), true);

            
        }

        //Registra Script na Pagina
        public static void jsRegisterScript( string title, string script, System.Web.UI.Page page)
        {
            // Define type of the client scripts on the page.
            Type cstype = page.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            
            //Register the script
            cs.RegisterStartupScript(cstype, title, script, true);
        }


        //Registra Script na Pagina
        public static void jsRegisterScript(string title, string script, System.Web.UI.UpdatePanel updPanel)
        {
            //Registra Script de dentro de um UpdatePanel
            System.Web.UI.ScriptManager.RegisterStartupScript(updPanel, updPanel.GetType(), title, script, true);
        }
    }
}
