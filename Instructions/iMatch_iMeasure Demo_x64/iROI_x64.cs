using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MiM_iVision
{
    // Declaring iROI class
    public class iROI
    {
        const string dllName = "iROI_x64.dll";

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "CreateiROIManager")]
        public extern static IntPtr CreateiROIManager();
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "DestroyiROIManager")]
        public extern static void DestroyiROIManager(IntPtr iROI);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIAddBaseROI")]
        public extern static E_iVision_ERRORS iROIAddBaseROI(IntPtr iROI, iBaseROI a_base_roi);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIAddAdvanceROI")]
        public extern static E_iVision_ERRORS iROIAddAdvanceROI(IntPtr iROI, iAdvanceROI a_base_roi);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIAddAdvPairROI")]
        public extern static E_iVision_ERRORS iROIAddAdvPairROI(IntPtr iROI, iAdvPairROI a_AdvPair_roi);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIAddTriAdvPairROI")]
        public extern static E_iVision_ERRORS iROIAddTriAdvPairROI(IntPtr iROI, iTriAdvPairROI a_TriAdvPair_roi);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIAddAdvRingROI")]
        public extern static E_iVision_ERRORS iROIAddAdvRingROI(IntPtr iROI, iAdvRingROI a_advring_roi);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIAddRectangleROI")]
        public extern static E_iVision_ERRORS iROIAddRectangleROI(IntPtr iROI, iRectangleROI a_rectangle_roi);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIAddCircleROI")]
        public extern static E_iVision_ERRORS iROIAddCircleROI(IntPtr iROI, iCircleROI a_circle_roi);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIAddRingROI")]
        public extern static E_iVision_ERRORS iROIAddRingROI(IntPtr iROI, iRingROI a_ring_roi);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIMouseMove")]
        public extern static E_iVision_ERRORS iROIMouseMove(IntPtr iROI, IntPtr hDC, int a_mouse_x, int a_mouse_y);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIMouseDown")]
        public extern static E_iVision_ERRORS iROIMouseDown(IntPtr iROI, IntPtr a_hDC, int a_mouse_x, int a_mouse_y);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIAttached")]
        public extern static E_iVision_ERRORS iROIAttached(IntPtr iROI, IntPtr iImage, IntPtr hDC);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIAttachedDC")]
        public extern static E_iVision_ERRORS iROIAttachedDC(IntPtr iROI, IntPtr hDC, int a_wid, int a_hei);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIManagerSetDrawScale")]
        public extern static E_iVision_ERRORS iROIManagerSetDrawScale(IntPtr iROI, IntPtr hDC, double a_scale);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIUnAttached")]
        public extern static E_iVision_ERRORS iROIUnAttached(IntPtr iROI, IntPtr hDC);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIPlot")]
        public extern static E_iVision_ERRORS iROIPlot(IntPtr iROI, IntPtr a_hDC);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIGetType")]
        public extern static iROI_Type iROIGetType(IntPtr iROI, int a_index);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIGetInfo")]
        public extern static iROI_Type iROIGetInfo(IntPtr iROI, ref double a_ptr);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIGetWorkingIndex")]
        public extern static int iROIGetWorkingIndex(IntPtr iROI);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIGetInfoIndex")]
        public extern static iROI_Type iROIGetInfoIndex(IntPtr iROI, int a_index, ref double a_ptr);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROISetActive")]
        public extern static E_iVision_ERRORS iROISetActive(IntPtr iROI, int a_index);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROISize")]
        public extern static int iROISize(IntPtr iROI);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIDeleteROI")]
        public extern static E_iVision_ERRORS iROIDeleteROI(IntPtr iROI);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIDeleteROIIndex")]
        public extern static E_iVision_ERRORS iROIDeleteROIIndex(IntPtr iROI, int a_index);
        
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iROIDeleteAll")]
        public extern static E_iVision_ERRORS iROIDeleteAll(IntPtr iROI);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "iROILoad")]
        public extern static E_iVision_ERRORS iROILoad(IntPtr iROI, string a_file_path);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "iROISave")]
        public extern static E_iVision_ERRORS iROISave(IntPtr iROI, string a_file_path);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iVisitingKey")]
        public extern static E_iVision_ERRORS iVisitingKey();
    }
}