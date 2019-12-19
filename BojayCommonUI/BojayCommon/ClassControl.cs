using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace BojayCommon
{
    
    class ClassControl
    {
        public ClassControl()
        {
           
        }

    }
    public static class BojayEntryClass
    {
        [DllImport("BojayEntryFunction.dll")]
        public static extern void BojayEntryFunction();

    }
}
