using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Framework.UI.Web
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
    /// Thanks to http://www.abeautifulsite.net/blog/2008/12/jquery-alert-dialogs/
    /// </summary>
    public class clsJQuery
    {
        /// <summary>
        /// Exibe Alerta na Tela
        /// </summary>
        /// <param name="msg">Mensagem</param>
        /// <param name="title">Titulo da Mensagem</param>
        /// <param name="callback">Funcao de callback</param>
        /// <param name="page">Pagina origem</param>
        public static void jsAlert(string msg, string title, jAlertType dialogType, System.Web.UI.Page page)
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

        public static void jsConfirm(string msg, string title, jAlertType dialogType, string callBackFunction, System.Web.UI.Page page)
        {
            // Define type of the client scripts on the page.
            Type cstype = page.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            //Build the jQuery script
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("jAlertConfirm('<b><center>" + msg + "</center></b>', '" + title + "', " + callBackFunction + ");");

            //Register the script
            if (!cs.IsStartupScriptRegistered("jsConfirm"))
            {
                cs.RegisterStartupScript(cstype, "jsConfirm", sb.ToString(), true);
            }
        }


        /// <summary>
        /// Registra script na pagina com o método RegisterStartupScript
        /// </summary>
        /// <param name="script">Script a ser registrado</param>
        /// <param name="scriptName">Nome para registro</param>
        /// <param name="page">pagina onde será registrado</param>
        /// <example>clsJQuery.RegisterStartScript("alert('Hellow');", "hellowScript", this.Page);</example>
        public static void RegisterStartScript(string script, string scriptName, System.Web.UI.Page page)
        {
            // Define type of the client scripts on the page.
            Type cstype = page.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            //Register the script
            cs.RegisterStartupScript(cstype, scriptName, script, true);
        }



        /// <summary>
        /// Cria uma 'fancyBox' dinâmica na pagina
        /// </summary>
        /// <param name="msg">Texto da Mensagem</param>
        /// <param name="page">Pagina origem</param>
        public static void fancyBox(string msg, System.Web.UI.Page page)
        {
            // Define type of the client scripts on the page.
            Type cstype = page.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            //Build the jQuery script
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("$(document).ready(function(){");
            sb.AppendLine("  $.fancybox('<div style='white-space: nowrap'><h3>" + msg + "</h3></div>');");
            sb.AppendLine("});");

            //Register the script
            cs.RegisterStartupScript(cstype, "fancybox", sb.ToString(), true);
        }


        /// <summary>
        /// Cria uma 'fancyBox' dinâmica na pagina com ícone de exclamacao
        /// </summary>
        /// <param name="msg">Texto da Mensagem</param>
        /// <param name="page">Pagina origem</param>
        public static void fancyBoxIcon(string msg, System.Web.UI.Page page)
        {
            // Define type of the client scripts on the page.
            Type cstype = page.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            //Build the jQuery script
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("$(document).ready(function(){");
            sb.AppendLine("  $.fancybox(");
            sb.AppendLine("     '<table><tr><td><img src=\"../images/exclamation_lime.jpg\" style=\"height: 50px; width: 50px\"></td><td nowrap>&nbsp;" + msg + "&nbsp</td></tr></table>');");
            sb.AppendLine("});");

            //Register the script
            cs.RegisterStartupScript(cstype, "fancybox", sb.ToString(), true);
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
            sb.AppendLine("        onStart: function() {");
            sb.AppendLine("            " + onStartCode);
            sb.AppendLine("        },");
            sb.AppendLine("        onCancel: function() {");
            sb.AppendLine("          " + onCancelCode);
            sb.AppendLine("        },");
            sb.AppendLine("        onComplete: function() {");
            sb.AppendLine("          " + onCompleteCode);
            sb.AppendLine("        },");
            sb.AppendLine("        onCleanup: function() {");
            sb.AppendLine("           " + onCleanupCode);
            sb.AppendLine("        },");
            sb.AppendLine("        onClosed: function() {");
            sb.AppendLine("           " + onClosedCode);
            sb.AppendLine("        }");
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
            if (show)
            {
                sb.AppendLine("         $('" + spanName + "').show()");
            }
            else
            {
                sb.AppendLine("         $('" + spanName + "').hide()");
            }
            sb.AppendLine("     }");
            sb.AppendLine(" });"); // anonymous function + ready function

            //Register the script
            cs.RegisterStartupScript(cstype, "showSpan", sb.ToString(), true);


        }
    }
}
