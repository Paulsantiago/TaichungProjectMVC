using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MiM_iVision
{
    public class iMatch
    {
        const string dllName = "iMatch_x64.dll";

		
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "CreateNCCMatch")]
        public extern static IntPtr CreateNCCMatch();

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "DestroyNCCMatch")]
        public extern static E_iVision_ERRORS DestroyNCCMatch(IntPtr objptr);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "CreateNCCModel")]
        public extern static E_iVision_ERRORS CreateNCCModel(IntPtr Img, IntPtr model, bool mask_used = false);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "CreateNCCModelFromROI")]
        public extern static E_iVision_ERRORS CreateNCCModelFromROI(IntPtr Img, IntPtr model, mRect ROI, bool mask_used = false);
		
		[DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "MatchNCCModelEx")]
        public extern static E_iVision_ERRORS MatchNCCModelEx(IntPtr Img, IntPtr model, double minScore, 
																double maxAng , double minAng , 
																double maxScale , double minScale , 
																bool rotated = false, bool scaled = false,int Max_Pos = 1);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "MatchNCCModel")]
        public extern static E_iVision_ERRORS MatchNCCModel(IntPtr Img, IntPtr model);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "MatchNCCModelFromROI")]
        public extern static E_iVision_ERRORS MatchNCCModelFromROI(IntPtr Img, IntPtr model, mRect ROI);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "LoadiMatchModel")]
        public extern static E_iVision_ERRORS LoadiMatchModel(IntPtr model, string path);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SaveiMatchModel")]
        public extern static E_iVision_ERRORS SaveiMatchModel(IntPtr model, string path);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iDrawiMatchResults")]
        public extern static E_iVision_ERRORS iDrawiMatchResults(IntPtr model, IntPtr hDC, double Scale);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetNCCMatchResults")]
        public extern static E_iVision_ERRORS iGetNCCMatchResults(IntPtr model, int index, ref NCCFind data);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetNCCMatchNum")]
        public extern static E_iVision_ERRORS iGetNCCMatchNum(IntPtr model, ref Int32 Nums);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iSetDontCareThreshold")]
        public extern static E_iVision_ERRORS iSetDontCareThreshold(IntPtr model, int val);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetDontCareThreshold")]
        public extern static E_iVision_ERRORS iGetDontCareThreshold(IntPtr model, ref Int32 val);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iSetMinScore")]
        public extern static E_iVision_ERRORS iSetMinScore(IntPtr model, double val);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetMinScore")]
        public extern static E_iVision_ERRORS iGetMinScore(IntPtr model, ref double val);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iSetAngle")]
        public extern static E_iVision_ERRORS iSetAngle(IntPtr model, double val1, double val2);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetAngle")]
        public extern static E_iVision_ERRORS iGetAngle(IntPtr model, ref double val1, ref double val2);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iSetIsRotated")]
        public extern static E_iVision_ERRORS iSetIsRotated(IntPtr model, bool flag);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetIsRotated")]
        public extern static E_iVision_ERRORS iGetIsRotated(IntPtr model, ref bool flag);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iSetScale")]
        public extern static E_iVision_ERRORS iSetScale(IntPtr model, double val1, double val2);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetScale")]
        public extern static E_iVision_ERRORS iGetScale(IntPtr model, ref double val1, ref double val2);
		
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iSetIsScaled")]
        public extern static E_iVision_ERRORS iSetIsScaled(IntPtr model, bool flag);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetIsScaled")]
        public extern static E_iVision_ERRORS iGetIsScaled(IntPtr model, ref bool flag);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iSetIsDontArea")]
        public extern static E_iVision_ERRORS iSetIsDontArea(IntPtr model, bool flag);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetIsDontArea")]
        public extern static E_iVision_ERRORS iGetIsDontArea(IntPtr model, ref bool flag);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iSetOccurrence")]
        public extern static E_iVision_ERRORS iSetOccurrence(IntPtr model, int val);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetOccurrence")]
        public extern static E_iVision_ERRORS iGetOccurrence(IntPtr model, ref int val);
		
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetModelWidth")]
        public extern static E_iVision_ERRORS iGetModelWidth(IntPtr model, ref int val);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetModelHeight")]
        public extern static E_iVision_ERRORS iGetModelHeight(IntPtr model, ref int val);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iSetMinReduceArea")]
        public extern static E_iVision_ERRORS iSetMinReduceArea(IntPtr model, int val);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetMinReduceArea")]
        public extern static E_iVision_ERRORS iGetMinReduceArea(IntPtr model, ref int val);
		
		[DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iSetOutsideFOV")]
        public extern static E_iVision_ERRORS iSetOutsideFOV(IntPtr model, int flag);
		
		[DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetOutsideFOV")]
        public extern static E_iVision_ERRORS iGetOutsideFOV(IntPtr model, ref int flag);	

		[DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iSetRobustness")]
        public extern static E_iVision_ERRORS iSetRobustness(IntPtr model, bool flag);
		
		[DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetRobustness")]
        public extern static E_iVision_ERRORS iGetRobustness(IntPtr model, ref bool flag);	
	
		[DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iSetColorSimilarity")]
        public extern static E_iVision_ERRORS iSetColorSimilarity(IntPtr model, bool flag);
		
		[DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetColorSimilarity")]
        public extern static E_iVision_ERRORS iGetColorSimilarity(IntPtr model, ref bool flag);	

		[DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iSetColorSensitivity")]
        public extern static E_iVision_ERRORS iSetColorSensitivity(IntPtr model, int val);
		
		[DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetColorSensitivity")]
        public extern static E_iVision_ERRORS iGetColorSensitivity(IntPtr model, ref int val);
	
		[DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iSetSubPixel")]
        public extern static E_iVision_ERRORS iSetSubPixel(IntPtr model, bool flag);
		
		[DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetSubPixel")]
        public extern static E_iVision_ERRORS iGetSubPixel(IntPtr model, ref bool flag);	
		
		[DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iSetFinalReduction")]
        public extern static E_iVision_ERRORS iSetFinalReduction(IntPtr model, int val);
		
		[DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetFinalReduction")]
        public extern static E_iVision_ERRORS iGetFinalReduction(IntPtr model, ref int val);
	
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iIsPatternLearn")]
        public extern static E_iVision_ERRORS iIsPatternLearn(IntPtr model);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iIsColorModel")]
        public extern static E_iVision_ERRORS iIsColorModel(IntPtr model);
		
		[DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iPointerFromiModel")]
        public extern static E_iVision_ERRORS iPointerFromiModel(IntPtr Img, IntPtr model);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iVisitingKey")]
        public extern static E_iVision_ERRORS iVisitingKey();

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetKeyState")]
        public extern static E_iVision_ERRORS iGetKeyState();
    }
}
