using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIM.Model
{
    public class clsProfileBO
    {
        public int Id { get; set; }
        public string ProfileName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public List<clsProfilePermissionBO> ListProfilePermission { get; set; }

    }
}
