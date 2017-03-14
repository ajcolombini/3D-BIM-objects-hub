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

    public class clsAlerts
    {

        /// <summary>
        /// Exibe Alerta na Tela
        /// </summary>
        /// <param name="msg">Mensagem</param>
        /// <param name="title">Titulo da Mensagem</param>
        /// <param name="dialogType">Enumerador para Tipo de Mensagem</param>
        /// <param name="page">Pagina origem</param>
        public static void jsAlert(string msg, string title, AlertType dialogType, Page page)
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
        public static void jsAlert(string msg, string title, AlertType dialogType, Control updPanel)
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



        public static void jsAlert(string msg, string title, AlertType dialogType, Control updPanel, String callBackFunction)
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
        public static void jsConfirm(string msg, string title, bool useCallBackFunction, Page page)
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



            //Funcao necessaria para utilização com clsAlerts.Confirm()
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
        public static void jsConfirm(string msg, string title, bool useCallBackFunction, Control updPanel)
        {

            //Build the jQuery script
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("jAlertConfirm('" + msg + "', '" + title + "', " + useCallBackFunction.ToString().ToLower() + ");");

            //Registra Script de dentro de um UpdatePanel
            System.Web.UI.ScriptManager.RegisterStartupScript(updPanel, updPanel.GetType(), "jsConfirm", sb.ToString(), true);
        }


        //Registra Script na Pagina
        public static void jsRegisterScript(string title, string script, System.Web.UI.Page page)
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

