using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;

namespace ACE.Util
{
    public class clsControlsUtil
    {
    
     /// <summary>
        ///  You can use t in this way: 
        ///  List<Control> repeaters = GetControlsByType(containerControl, typeof(Repeater));
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<Control> GetControlsByType(Control ctl, Type type)
        {
            List<Control> controls = new List<Control>();

            foreach (Control childCtl in ctl.Controls)
            {
                if (childCtl.GetType() == type)
                {
                    controls.Add(childCtl);
                }

                List<Control> childControls = GetControlsByType(childCtl, type);
                foreach (Control childControl in childControls)
                {
                    controls.Add(childControl);
                }
            }

            return controls;
        }
    }

}
