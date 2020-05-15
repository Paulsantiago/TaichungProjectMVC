using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MiM_iVision
{
    class iImgProcess
    {
        const string dllName = "iImgProcess_x64.dll";

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_Threshold")]
        public extern static E_iVision_ERRORS iImg_Threshold(IntPtr iImgIn,IntPtr iImgOut,int Value);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_OtsuThreshold")]
        public extern static int iImg_OtsuThreshold(IntPtr iImgIn,IntPtr iImgOut);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_DoubleThreshold")]
        public extern static E_iVision_ERRORS iImg_DoubleThreshold(IntPtr iImgIn,IntPtr iImgOut,int Value1,int Value2);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_Sobel")]
        public extern static E_iVision_ERRORS iImg_Sobel(IntPtr iImgIn,IntPtr iImgOut);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_Laplacian")]
        public extern static E_iVision_ERRORS iImg_Laplacian(IntPtr iImgIn,IntPtr iImgOut);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_Robert")]
        public extern static E_iVision_ERRORS iImg_Robert(IntPtr iImgIn,IntPtr iImgOut);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_Prewitt")]
        public extern static E_iVision_ERRORS iImg_Prewitt(IntPtr iImgIn,IntPtr iImgOut);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_LaplacianSharping")]
        public extern static E_iVision_ERRORS iImg_LaplacianSharping(IntPtr iImgIn,IntPtr iImgOut);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_GaussianSmoothing3x3")]
        public extern static E_iVision_ERRORS iImg_GaussianSmoothing3x3(IntPtr iImgIn,IntPtr iImgOut);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_GaussianSmoothing5x5")]
        public extern static E_iVision_ERRORS iImg_GaussianSmoothing5x5(IntPtr iImgIn,IntPtr iImgOut);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_GaussianSmoothing7x7")]
        public extern static E_iVision_ERRORS iImg_GaussianSmoothing7x7(IntPtr iImgIn,IntPtr iImgOut);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_MeanSmoothing")]
        public extern static E_iVision_ERRORS iImg_MeanSmoothing(IntPtr iImgIn,IntPtr iImgOut, int FilterSize);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_MeanSmoothing3x3")]
        public extern static E_iVision_ERRORS iImg_MeanSmoothing3x3(IntPtr iImgIn,IntPtr iImgOut);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_MeanSmoothing5x5")]
        public extern static E_iVision_ERRORS iImg_MeanSmoothing5x5(IntPtr iImgIn,IntPtr iImgOut);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_MeanSmoothing7x7")]
        public extern static E_iVision_ERRORS iImg_MeanSmoothing7x7(IntPtr iImgIn,IntPtr iImgOut);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ArbitraryConvolution3x3")]
        public extern static E_iVision_ERRORS iImg_ArbitraryConvolution3x3(IntPtr iImgIn,IntPtr iImgOut,ref int Mask);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ArbitraryConvolution5x5")]
        public extern static E_iVision_ERRORS iImg_ArbitraryConvolution5x5(IntPtr iImgIn,IntPtr iImgOut,ref int Mask);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ArbitraryConvolution7x7")]
        public extern static E_iVision_ERRORS iImg_ArbitraryConvolution7x7(IntPtr iImgIn,IntPtr iImgOut,ref int Mask);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_MedianFilter3x3")]
        public extern static E_iVision_ERRORS iImg_MedianFilter3x3(IntPtr iImgIn,IntPtr iImgOut);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_MedianFilter5x5")]
        public extern static E_iVision_ERRORS iImg_MedianFilter5x5(IntPtr iImgIn,IntPtr iImgOut);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_Dilation")]
        public extern static E_iVision_ERRORS iImg_Dilation(IntPtr iImgIn,IntPtr iImgOut, int WidthSize, int HeightSize);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_Erosion")]
        public extern static E_iVision_ERRORS iImg_Erosion(IntPtr iImgIn,IntPtr iImgOut, int WidthSize, int HeightSize);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_Opening")]
        public extern static E_iVision_ERRORS iImg_Opening(IntPtr iImgIn,IntPtr iImgOut, int WidthSize, int HeightSize);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_Closing")]
        public extern static E_iVision_ERRORS iImg_Closing(IntPtr iImgIn,IntPtr iImgOut, int WidthSize, int HeightSize);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_MorphGradient")]
        public extern static E_iVision_ERRORS iImg_MorphGradient(IntPtr iImgIn,IntPtr iImgOut, int WidthSize, int HeightSize);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_MorphWhiteTopHat")]
        public extern static E_iVision_ERRORS iImg_MorphWhiteTopHat(IntPtr iImgIn,IntPtr iImgOut, int WidthSize, int HeightSize);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_MorphBlackTopHat")]
        public extern static E_iVision_ERRORS iImg_MorphBlackTopHat(IntPtr iImgIn,IntPtr iImgOut, int WidthSize, int HeightSize);


        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_DilationDiamond")]
        public extern static E_iVision_ERRORS iImg_DilationDiamond(IntPtr iImgIn,IntPtr iImgOut, int RadiusSize);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ErosionDiamond")]
        public extern static E_iVision_ERRORS iImg_ErosionDiamond(IntPtr iImgIn,IntPtr iImgOut, int RadiusSize);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_OpeningDiamond")]
        public extern static E_iVision_ERRORS iImg_OpeningDiamond(IntPtr iImgIn,IntPtr iImgOut, int RadiusSize);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ClosingDiamond")]
        public extern static E_iVision_ERRORS iImg_ClosingDiamond(IntPtr iImgIn,IntPtr iImgOut, int RadiusSize);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_MorphGradientDiamond")]
        public extern static E_iVision_ERRORS iImg_MorphGradientDiamond(IntPtr iImgIn,IntPtr iImgOut, int RadiusSize);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_MorphWhiteTopHatDiamond")]
        public extern static E_iVision_ERRORS iImg_MorphWhiteTopHatDiamond(IntPtr iImgIn,IntPtr iImgOut, int RadiusSize);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_MorphBlackTopHatDiamond")]
        public extern static E_iVision_ERRORS iImg_MorphBlackTopHatDiamond(IntPtr iImgIn,IntPtr iImgOut, int RadiusSize);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_DilationCircle")]
        public extern static E_iVision_ERRORS iImg_DilationCircle(IntPtr iImgIn,IntPtr iImgOut, int RadiusSize);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ErosionCircle")]
        public extern static E_iVision_ERRORS iImg_ErosionCircle(IntPtr iImgIn,IntPtr iImgOut, int RadiusSize);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_OpeningCircle")]
        public extern static E_iVision_ERRORS iImg_OpeningCircle(IntPtr iImgIn,IntPtr iImgOut, int RadiusSize);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ClosingCircle")]
        public extern static E_iVision_ERRORS iImg_ClosingCircle(IntPtr iImgIn,IntPtr iImgOut, int RadiusSize);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_MorphGradientCircle")]
        public extern static E_iVision_ERRORS iImg_MorphGradientCircle(IntPtr iImgIn,IntPtr iImgOut, int RadiusSize);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_MorphWhiteTopHatCircle")]
        public extern static E_iVision_ERRORS iImg_MorphWhiteTopHatCircle(IntPtr iImgIn,IntPtr iImgOut, int RadiusSize);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_MorphBlackTopHatCircle")]
        public extern static E_iVision_ERRORS iImg_MorphBlackTopHatCircle(IntPtr iImgIn,IntPtr iImgOut, int RadiusSize);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ImageAdd")]
        public extern static E_iVision_ERRORS iImg_ImageAdd(IntPtr iImgIn,IntPtr iImgAdd, IntPtr iImgOut);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ImageSub")]
        public extern static E_iVision_ERRORS iImg_ImageSub(IntPtr iImgIn,IntPtr iImgSub, IntPtr iImgOut);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ImageMul")]
        public extern static E_iVision_ERRORS iImg_ImageMul(IntPtr iImgIn,IntPtr iImgOut,int Constant);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ImageDiv")]
        public extern static E_iVision_ERRORS iImg_ImageDiv(IntPtr iImgIn,IntPtr iImgOut,int Constant);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ImageShiftLeft")]
        public extern static E_iVision_ERRORS iImg_ImageShiftLeft(IntPtr iImgIn,IntPtr iImgOut,int Constant);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ImageShiftRight")]
        public extern static E_iVision_ERRORS iImg_ImageShiftRight(IntPtr iImgIn,IntPtr iImgOut,int Constant);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ImageBitwiseAND")]
        public extern static E_iVision_ERRORS iImg_ImageBitwiseAND(IntPtr iImgIn, IntPtr iImgIn2,IntPtr iImgOut);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ImageBitwiseOR")]
        public extern static E_iVision_ERRORS iImg_ImageBitwiseOR(IntPtr iImgIn, IntPtr iImgIn2,IntPtr iImgOut);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ImageBitwiseXOR")]
        public extern static E_iVision_ERRORS iImg_ImageBitwiseXOR(IntPtr iImgIn, IntPtr iImgIn2,IntPtr iImgOut);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ImageEqual")]
        public extern static E_iVision_ERRORS iImg_ImageEqual(IntPtr iImgIn, IntPtr iImgIn2,IntPtr iImgOut);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ImageNOTEqual")]
        public extern static E_iVision_ERRORS iImg_ImageNOTEqual(IntPtr iImgIn, IntPtr iImgIn2,IntPtr iImgOut);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ImageInvert")]
        public extern static E_iVision_ERRORS iImg_ImageInvert(IntPtr iImgIn,IntPtr iImgOut);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ImageGainOffset")]
        public extern static E_iVision_ERRORS iImg_ImageGainOffset(IntPtr iImgIn, IntPtr iImgOut, float GainValue, int OffsetValue);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ImageScaling")]
        public extern static E_iVision_ERRORS iImg_ImageScaling(IntPtr iImgIn,IntPtr iImgOut, int XCenter, int YCenter, float Scale);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ImageRotation")]
        public extern static E_iVision_ERRORS iImg_ImageRotation(IntPtr iImgIn,IntPtr iImgOut, int OrgXCenter, int OrgYCenter, int DestXCenter, 
																int DestYCenter, double Alpha);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ImageTranslation")]
        public extern static E_iVision_ERRORS iImg_ImageTranslation(IntPtr iImgIn,IntPtr iImgOut, int SrcXCenter, int SrcYCenter, int DestXCenter, 
																	int DestYCenter);
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_BiRotation")]
        public extern static E_iVision_ERRORS iImg_BiRotation(IntPtr iImgIn, IntPtr iImgOut, int OrgXCenter, int OrgYCenter, int DestXCenter, 
																int DestYCenter, double Alpha);
		
		[DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iImg_ImageMaximum")]
        public extern static E_iVision_ERRORS iImg_ImageMaximum(IntPtr iImgIn1, IntPtr iImgIn2, IntPtr iImgOut);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iGetKeyState")]
        public extern static E_iVision_ERRORS iGetKeyState();

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "iVisitingKey")]
        public extern static E_iVision_ERRORS iVisitingKey();		

    }
}
