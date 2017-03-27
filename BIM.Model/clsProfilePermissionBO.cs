using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIM.Model
{
    [Serializable]
    public class clsProfilePermissionBO
    {
        #region Destrutor
        ~clsProfilePermissionBO() { }
        #endregion

        #region Propriedades
        public int Id { get; set; }
        public bool PermissionMaintenance { get; set; }
        public bool PermissionConsult { get; set; }
        public clsProfileBO Profile { get; set; }
        public clsModuleBO Module { get; set; }
        #endregion
    }
}
