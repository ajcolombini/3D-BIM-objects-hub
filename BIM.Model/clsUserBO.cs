using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIM.Model
{
   [Serializable]
   public class clsUserBO
   {

       #region Destrutor
            ~clsUserBO() { }
        #endregion

       #region Propriedades
           public int Id { get; set; }
           public string Login { get; set; }
           public string Name { get; set; }
           public string Email { get; set; }
           public string Password { get; set; } 
           public clsProfileBO Profile { get; set; }
           public bool IsInternal { get; set; }
           public bool IsActive { get; set; }
           public DateTime? NextPwdChanging { get; set; }
       #endregion
   }
}
