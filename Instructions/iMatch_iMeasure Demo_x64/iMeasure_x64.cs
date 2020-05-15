using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Management;
namespace MiM_iVision
{
    // Declaring iMCircle class
    public class iMCircle
    {
        const string dllName = "iMeasure_x64.dll";

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "CreateiMCircle")]
        public extern static IntPtr CreateiMCircle();

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "DestroyiMCircle")]
        public extern static E_iVision_ERRORS DestroyiMCircle(IntPtr a_model);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMCircleSetPara")]
        public extern static E_iVision_ERRORS iMCircleSetPara(IntPtr a_model, iAdvRingROI a_advring, int a_edge_threshold, int a_samplingstep,
                                                        int a_iterations, double a_iter_threshold, int a_transitiontype, int a_edge_choice);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMCircleSetPara2")]
        public extern static E_iVision_ERRORS iMCircleSetPara2(IntPtr a_model, iRingROI a_ring, int a_edge_threshold, int a_samplingstep,
                                                        int a_iterations, double a_iter_threshold, int a_transitiontype, int a_edge_choice);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMeasure_Circle")]
        public extern static E_iVision_ERRORS iMeasure_Circle(IntPtr a_model, IntPtr a_img);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iDrawMeasure_Circle")]
        public extern static E_iVision_ERRORS iDrawMeasure_Circle(IntPtr a_model, IntPtr a_img, IntPtr a_hDC, float a_draw_scale);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMCircle_GetResults")]
        public extern static E_iVision_ERRORS iMCircle_GetResults(IntPtr a_model, ref iCircle_Measured a_results);
       
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMCircle_GetFeatures")]
        public extern static E_iVision_ERRORS iMCircle_GetFeatures(IntPtr a_model, ref iDPoint a_features);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iVisitingKey")]
        public extern static E_iVision_ERRORS iVisitingKey();

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetKeyState")]
        public extern static E_iVision_ERRORS iGetKeyState();
    }

    // Declaring iMLine class
    public class iMLine
    {
        const string dllName = "iMeasure_x64.dll";

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "CreateiMLine")]
        public extern static IntPtr CreateiMLine();

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "DestroyiMLine")]
        public extern static E_iVision_ERRORS DestroyiMLine(IntPtr a_model);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMLineSetPara")]
        public extern static E_iVision_ERRORS iMLineSetPara(IntPtr a_model, iAdvanceROI a_adv_roi, int a_edge_threshold, int a_samplingstep,
                                                        int a_iterations, double a_iter_threshold, int a_transitiontype, int a_edge_choice);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMeasure_Line")]
        public extern static E_iVision_ERRORS iMeasure_Line(IntPtr a_model, IntPtr a_srcimg);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iDrawMeasure_Line")]
        public extern static E_iVision_ERRORS iDrawMeasure_Line(IntPtr a_model, IntPtr a_srcimg, IntPtr a_hDC, float a_draw_scale);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMLine_GetResults")]
        public extern static E_iVision_ERRORS iMLine_GetResults(IntPtr a_model, ref iLine_Measured a_results);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMLine_GetNumofFeatures")]
        public extern static E_iVision_ERRORS iMLine_GetNumofFeatures(IntPtr a_model, ref Int32 a_num);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMLine_GetFeatures")]
        public extern static E_iVision_ERRORS iMLine_GetFeatures(IntPtr a_model, ref iDPoint a_features);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iVisitingKey")]
        public extern static E_iVision_ERRORS iVisitingKey();

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetKeyState")]
        public extern static E_iVision_ERRORS iGetKeyState();
    }


    public class iMLinePair
    {
        const string dllName = "iMeasure_x64.dll";

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "CreateiMLinePair")]
        public extern static IntPtr CreateiMLinePair();
        	
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "DestroyiMLinePair")]
        public extern static E_iVision_ERRORS DestroyiMLinePair(IntPtr a_model);
	
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMLinePairSetPara")]
        public extern static E_iVision_ERRORS iMLinePairSetPara(IntPtr a_model, iAdvPairROI a_advpair_roi,int a_edge_threshold, int a_samplingstep,
                                                        int a_iterations, double a_iter_threshold, int a_transitiontype, int a_edge_choice);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMeasure_LinePair")]
        public extern static E_iVision_ERRORS iMeasure_LinePair(IntPtr a_model, IntPtr a_srcimg);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iDrawMeasure_LinePair")]
        public extern static E_iVision_ERRORS iDrawMeasure_LinePair(IntPtr a_model, IntPtr a_srcimg, IntPtr a_hDC, float a_draw_scale);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMLinePair_GetResults")]
        public extern static double iMLinePair_GetResults(IntPtr a_model, ref iLine_Measured a_results1, ref iLine_Measured a_results2);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMLinePair_GetNumofFeatures")]
        public extern static E_iVision_ERRORS iMLinePair_GetNumofFeatures(IntPtr a_model, ref Int32 a_num);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMLinePair_GetFeatures")]
        public extern static E_iVision_ERRORS iMLinePair_GetFeatures(IntPtr a_model, ref iDPoint a_features);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iVisitingKey")]
        public extern static E_iVision_ERRORS iVisitingKey();

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetKeyState")]
        public extern static E_iVision_ERRORS iGetKeyState();

    }

    public class iMRectangle
    {
        const string dllName = "iMeasure_x64.dll";

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "CreateiMRectangle")]
        public extern static IntPtr CreateiMRectangle();

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "DestroyiMRectangle")]
        public extern static E_iVision_ERRORS DestroyiMRectangle(IntPtr a_model);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMRectangleSetPara")]
        public extern static E_iVision_ERRORS iMRectangleSetPara(IntPtr a_model, iRectangleROI a_rect_roi, int a_edge_threshold, int a_samplingstep,
                                                        int a_iterations, double a_iter_threshold, int a_transitiontype, int a_edge_choice);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMeasure_Rectangle")]
        public extern static E_iVision_ERRORS iMeasure_Rectangle(IntPtr a_model, IntPtr a_srcimg);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iDrawMeasure_Rectangle")]
        public extern static E_iVision_ERRORS iDrawMeasure_Rectangle(IntPtr a_model, IntPtr a_srcimg, IntPtr a_hDC, float a_draw_scale);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMRectangle_GetResults")]
        public extern static E_iVision_ERRORS iMRectangle_GetResults(IntPtr a_model, ref iRectangle_Measured a_results);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMRectangle_GetNumofFeatures")]
        public extern static E_iVision_ERRORS iMRectangle_GetNumofFeatures(IntPtr a_model, ref Int32 a_num);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMRectangle_GetFeatures")]
        public extern static E_iVision_ERRORS iMRectangle_GetFeatures(IntPtr a_model, ref iDPoint a_features);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iVisitingKey")]
        public extern static E_iVision_ERRORS iVisitingKey();

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetKeyState")]
        public extern static E_iVision_ERRORS iGetKeyState();
    }

    public class iMTriangle
    {
        const string dllName = "iMeasure_x64.dll";

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "CreateiMTriangle")]
        public extern static IntPtr CreateiMTriangle();

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "DestroyiMTriangle")]
        public extern static E_iVision_ERRORS DestroyiMTriangle(IntPtr a_model);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMTriangleSetPara")]
        public extern static E_iVision_ERRORS iMTriangleSetPara(IntPtr a_model, iTriAdvPairROI a_tri_roi, int a_edge_threshold, int a_samplingstep,
                                                        int a_iterations, double a_iter_threshold, int a_transitiontype, int a_edge_choice);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMeasure_Triangle")]
        public extern static E_iVision_ERRORS iMeasure_Triangle(IntPtr a_model, IntPtr a_srcimg);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iDrawMeasure_Triangle")]
        public extern static E_iVision_ERRORS iDrawMeasure_Triangle(IntPtr a_model, IntPtr a_srcimg, IntPtr a_hDC, float a_draw_scale);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMTriangle_GetResults")]
        public extern static E_iVision_ERRORS iMTriangle_GetResults(IntPtr a_model, ref iTriangle_Measured a_results);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMTriangle_GetNumofFeatures")]
        public extern static E_iVision_ERRORS iMTriangle_GetNumofFeatures(IntPtr a_model, ref int a_num);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMTriangle_GetFeatures")]
        public extern static E_iVision_ERRORS iMTriangle_GetFeatures(IntPtr a_model, ref iDPoint a_features);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iVisitingKey")]
        public extern static E_iVision_ERRORS iVisitingKey();

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetKeyState")]
        public extern static E_iVision_ERRORS iGetKeyState();
    }

    public class iMApplication
    {
        const string dllName = "iMeasure_x64.dll";

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMCircleToCircle")]
        public extern static E_iVision_ERRORS iMCircleToCircle(iCircle_Measured a_circle_results, iCircle_Measured a_circle_results2, ref iMCLLC_Measured a_results);
      
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iMCircleToLine")]
        public extern static E_iVision_ERRORS iMCircleToLine(iCircle_Measured a_circle_results, iLine_Measured a_line_results, ref iMCLLC_Measured a_results);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iVisitingKey")]
        public extern static E_iVision_ERRORS iVisitingKey();

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetKeyState")]
        public extern static E_iVision_ERRORS iGetKeyState();
    }
}	