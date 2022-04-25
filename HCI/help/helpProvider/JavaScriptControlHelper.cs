using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace HCI.help.helpProvider
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public class JavaScriptControlHelper
    {
        System.Windows.Window prozor;
        public JavaScriptControlHelper(System.Windows.Window w)
        {
            prozor = w;
        }

    }
}
