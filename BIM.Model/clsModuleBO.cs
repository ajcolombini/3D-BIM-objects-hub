using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIM.Model
{
    [Serializable]
    public class clsModuleBO
    {
        #region Destrutor
        ~clsModuleBO() { }
        #endregion

        #region Propriedades

        public int Id { get; set; }
        public string Name { get; set; }
        #endregion
    }
}
