using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CreativeModePlus
{
    class Asm
    {
        public static Assembly exe = null;
        public static Version ver = null;

        public static void init()
        {
            exe = Assembly.GetExecutingAssembly();
            ver = Assembly.GetEntryAssembly().GetName().Version;
        }
    }
}
