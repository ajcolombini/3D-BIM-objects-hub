using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    /// <summary>
    /// Tipos de Alerta
    /// </summary>
    public enum AlertType
    {
        Error,
        Warning,
        Confirm,
        Info,
        Success
    }

    /// <summary>
    /// Utilizar Bootbox.js e fontawesome para gerar alertas
    /// </summary>
    public class clsAlerts
    {

        /// <summary>
        /// Exibe Alerta na Tela
        /// </summary>
        /// <param name="msg">Mensagem</param>
        /// <param name="title">Titulo da Mensagem</param>
        /// <param name="dialogType">Enumerador para Tipo de Mensagem</param>
        /// <param name="page">Pagina origem</param>
        public static void bootstrapAlert(string msg, string title, AlertType dialogType, Page page)
        {
            // Define type of the client scripts on the page.
            Type cstype = page.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            //Build the jQuery script
            StringBuilder sb = new StringBuilder();

            switch (dialogType)
            {
                case AlertType.Error:
                    sb.AppendLine("jAlertError('" + msg + "', '" + title + "', '');");
                    break;
                case AlertType.Warning:
                    sb.AppendLine("jAlertWarning('" + msg + "', '" + title + "', '');");
                    break;
                case AlertType.Info:
                    sb.AppendLine("jAlertInfo('" + msg + "', '" + title + "', '');");
                    break;
                case AlertType.Success:
                    sb.AppendLine("jAlertSuccess('" + msg + "', '" + title + "', '');");
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
        public static void bootstrapAlert(string msg, string title, AlertType dialogType, Control updPanel)
        {


            //Build the jQuery script
            StringBuilder sb = new StringBuilder();

            switch (dialogType)
            {
                case AlertType.Error:
                    sb.AppendLine("jAlertError('" + msg + "', '" + title + "', '');");
                    break;
                case AlertType.Warning:
                    sb.AppendLine("jAlertWarning('" + msg + "', '" + title + "', '');");
                    break;
                case AlertType.Info:
                    sb.AppendLine("jAlertInfo('" + msg + "', '" + title + "', '');");
                    break;
                case AlertType.Success:
                    sb.AppendLine("jAlertSuccess('" + msg + "', '" + title + "', '');");
                    break;
                default:
                    break;
            }


            //Registra Script de dentro de um UpdatePanel
            System.Web.UI.ScriptManager.RegisterStartupScript(updPanel, updPanel.GetType(), "jsAlert", sb.ToString(), true);

        }



        public static void bootstrapAlert(string msg, string title, AlertType dialogType, Control updPanel, String callBackFunction)
        {


            //Build the jQuery script
            StringBuilder sb = new StringBuilder();

            switch (dialogType)
            {
                case AlertType.Error:
                    sb.AppendLine("jAlertError('" + msg + "', '" + title + "', " + callBackFunction + ");");
                    break;
                case AlertType.Warning:
                    sb.AppendLine("jAlertWarning('" + msg + "', '" + title + "', " + callBackFunction + ");");
                    break;
                case AlertType.Info:
                    sb.AppendLine("jAlertInfo('" + msg + "', '" + title + "', " + callBackFunction + ");");
                    break;
                case AlertType.Success:
                    sb.AppendLine("jAlertSuccess('" + msg + "', '" + title + "', " + callBackFunction + ");");
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
        public static void bootstrapConfirm(string msg, string title, bool useCallBackFunction, Page page)
        {
            // Define type of the client scripts on the page.
            Type cstype = page.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            //Build the jQuery script
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("jAlertConfirm('" + msg + "', '" + title + "', " + useCallBackFunction.ToString().ToLower() + ");");

            //Register the script
            cs.RegisterStartupScript(cstype, "jsConfirm", sb.ToString(), true);

            /* Funcao necessaria para utilização com clsAlerts.Confirm() */
            //function setDialogResult(r) {
            //    if (r) {
            //         document.getElementById('<%= lnkConfirmOK.ClientID %>').click();
            //    }
            //    else {
            //        //TODO: Implement Cancel event, if need.
            //    }
            //}
        }




        /// <summary>
        /// Versao para paginas que contem updatePanels
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        /// <param name="useCallBackFunction"></param>
        /// <param name="updPanel"></param>
        public static void bootstrapConfirm(string msg, string title, bool useCallBackFunction, Control updPanel)
        {

            //Build the jQuery script
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("jAlertConfirm('" + msg + "', '" + title + "', " + useCallBackFunction.ToString().ToLower() + ");");

            //Registra Script de dentro de um UpdatePanel
            System.Web.UI.ScriptManager.RegisterStartupScript(updPanel, updPanel.GetType(), "jsConfirm", sb.ToString(), true);
        }

        /// <summary>
        /// Caixa de Confirmação
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        /// <param name="callBackFunction">function personalisada para callback ex: 'callMeOnConfirm', onde callMeOnConfir(){....};</param>
        /// <param name="oRenderer">Ex: this.Page ou this.UpdatePanel1 (se estiver dentro de um updatePanel com id='UpdatePanel1')</param>
        public static void bootstrapConfirm(string msg, string title, string callBackFunction, object oRenderer)
        {
            //Build the jQuery script
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("jAlertConfirm('" + msg + "', '" + title + "', '" + callBackFunction.ToLower() + "');");

            if (oRenderer.GetType().Equals(typeof(Page)))
            {
                // Define type of the client scripts on the page.
                Type cstype = ((Page)oRenderer).GetType();

                // Get a ClientScriptManager reference from the Page class.
                ClientScriptManager cs = ((Page)oRenderer).ClientScript;

                //Register the script na pagina
                cs.RegisterStartupScript(cstype, "jsConfirm", sb.ToString(), true);

            }

            if (oRenderer.GetType().Equals(typeof(UpdatePanel)))
            {
                //Registra Script de dentro de um UpdatePanel
                System.Web.UI.ScriptManager.RegisterStartupScript(((UpdatePanel)oRenderer), ((UpdatePanel)oRenderer).GetType(), "jsConfirm", sb.ToString(), true);
            }
        }

        #region fancybox

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
            if (!string.IsNullOrEmpty(onClosedCode))
            {
                sb.AppendLine("        onClosed: function() {");
                sb.AppendLine("           " + onClosedCode);
                sb.AppendLine("        }");
            }
            sb.AppendLine("    });"); // fancybox function
            sb.AppendLine(" });"); // anonymous function + ready function

            //Register the script
            cs.RegisterStartupScript(cstype, "fancybox", sb.ToString(), true);
        }

        #endregion


        #region script Registration
        //Registra Script na Pagina
        public static void registerScript(string title, string script, System.Web.UI.Page page)
        {
            // Define type of the client scripts on the page.
            Type cstype = page.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;


            //Register the script
            cs.RegisterStartupScript(cstype, title, script, true);
        }


        //Registra Script na Pagina
        public static void registerScript(string title, string script, System.Web.UI.UpdatePanel updPanel)
        {
            //Registra Script de dentro de um UpdatePanel
            System.Web.UI.ScriptManager.RegisterStartupScript(updPanel, updPanel.GetType(), title, script, true);
        }
        #endregion

    }
}

