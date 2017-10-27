using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enhanced_Guild_Wars_2.Utilities
{
    public class Application
    {
        public static void OpenApplication(string EXEPath)
        {
            Process.Start(EXEPath);
        }
    }
}
