using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingstartedwithGodot4
{
    internal class Help
    {
        public static void Debug()
        {
            if(!System.Diagnostics.Debugger.IsAttached) 
            { 
                System.Diagnostics.Debugger.Launch();
            }
        }
    }
}
