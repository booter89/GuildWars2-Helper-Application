﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Enhanced_Guild_Wars_2.Utilities
{
    public class GuildWars
    {
        // import the function in your class
        [DllImport("User32.dll")]
        public static extern int SetForegroundWindow(IntPtr point);

        //...
    }
}
