using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MiM_iVision
{
    class iColor
    {
        const string dllName = "iColor_x64.dll";
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iColor_ColorToGray")]
        public extern static E_iVision_ERRORS iColor_ColorToGray(IntPtr iSrcImg,IntPtr iOutImg);
    }
}
