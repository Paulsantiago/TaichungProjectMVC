using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
//using MiM_iVision;
using System.Diagnostics;
using MVC.Vision.MiM;
using MVC_ModelLibrary.MVC_Managers;
using MVC.Vision.mvcVision;
using System.Drawing.Imaging;

namespace Warp_Csharp
{
    public partial class iImgProcessForm : Form
    {
        public Mainfrm refMain;
        Stopwatch sw = new Stopwatch();
        string path;
        string stateStr = "STATE: NULL";
        string TimeStr = "Time: NULL ms";
        bool b_ColorImg = false;

        public MVC_ImageProcessingManager ImageProcessingManager;
        
        E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;

         IntPtr Input1 = MVC_Image.CreateGrayiImage();
         IntPtr Input2 = MVC_Image.CreateGrayiImage();
         IntPtr Input3 = MVC_Image.CreateGrayiImage();
         IntPtr Output1 = MVC_Image.CreateGrayiImage();
         IntPtr Output2 = MVC_Image.CreateGrayiImage();
         IntPtr Output3 = MVC_Image.CreateGrayiImage();
        public IntPtr InputGeneralImage = MVC_Image.CreateGrayiImage();
        
        public IntPtr OutputGeneralImage = MVC_Image.CreateGrayiImage();
        string[] listOfProcess = { "None", "Threshold", "Edge", "Convolution" };
        IntPtr hbitmap;
        int Threshold = 128;
        int Masksize = 1;
        int Logicvalue = 1;
        float Gain = 1;
        int Offset = 10;
        float ang = 30,scale = 1;
        int shift = 10;
        int ColorChannel = 0;

        public iImgProcessForm(Mainfrm mainFrame)
        {
            refMain = mainFrame;
            InitializeComponent();
            lbImgProcessing.SelectedIndex = 0;
            cbChoices.Items.Clear();
            cbChoices.Items.AddRange(listOfProcess);
            cbChoices.SelectedItem = "None";


            gbThreshold.Enabled = false;
            gbEdge.Enabled = false;
            gbConvolution.Enabled = false;


            
            ///ImageProcessingManager = new MVC_ImageProcessingManager(refMain.ImageManager.GetWorkingImage());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MVC_Image.iImageCopy(InputGeneralImage, refMain.ImageManager.GetWorkingImage());
            refMain.ShowCircleIPMeasure = false;
            RenderImage(InputGeneralImage);
            this.Hide();
        }

        private void iImgProcessForm_Load(object sender, EventArgs e)
        {
            //cmbBox_Edge.SelectedIndex = 0;
            //cmbBox_Mophology.SelectedIndex = 0;
            //cmbBox_Convolution.SelectedIndex = 0;
            //cmbBox_Arithmetic.SelectedIndex = 0;
            //cmbBox_Logic.SelectedIndex = 0;

            //txt_threshold.Text = Threshold.ToString();
            //txt_MaskSize.Text = Masksize.ToString();
            //txt_LogicValue.Text = Logicvalue.ToString();
            //txt_Gain.Text = Gain.ToString();
            //txt_Offset.Text = Offset.ToString();
            //txt_Rotation.Text = ang.ToString();
            //txt_Shift.Text = shift.ToString();
            //txt_Scale.Text = scale.ToString();

            toolStripStatusLabel1.Text = stateStr;
            toolStripStatusLabel2.Text = TimeStr;
        }

        public Bitmap DrawScaledImage(IntPtr a_Image, float a_scale)
        {
            Image img = Image.FromHbitmap(MVC_Image.iGetBitmapAddress(a_Image));
            Bitmap l_Bitmap = new Bitmap((int)(MVC_Image.GetWidth(a_Image) * a_scale),
                                         (int)(MVC_Image.GetHeight(a_Image) * a_scale),
                                         PixelFormat.Format32bppArgb);
            using (Graphics graph = Graphics.FromImage(l_Bitmap))
            {
                graph.ScaleTransform(a_scale, a_scale);
                graph.DrawImageUnscaled(img, 0, 0);
            }
            return l_Bitmap;
        }

        private void btn_Threshold_Click(object sender, EventArgs e)
        {
            err = refMain.ImageManager.iImageIsNULL();
            if (err == E_iVision_ERRORS.E_TRUE)
            {
                MessageBox.Show(String.Format("iImageIsNULL: " + err.ToString(), "ERROR"));
                return;
            }

            sw.Reset();
            sw.Start();
            err = MVC_ImageProcessing.Threshold(InputGeneralImage, OutputGeneralImage, Convert.ToInt32(txt_threshold.Text));
            //MVC_ImageProcessing.thre
            sw.Stop();
            if (err == E_iVision_ERRORS.E_OK)
            {
                if (refMain.pictureBox1.Image != null)
                    refMain.pictureBox1.Image.Dispose();
               
               refMain.pictureBox1.Image = DrawScaledImage(OutputGeneralImage, refMain.scale);
            }
            //iROI.iROIAttached(refMain.MatchingROIToolManager, refMain.ProcessImg, refMain.hDC_ImgProcess);
            toolStripStatusLabel1.Text = String.Format("State: " + err.ToString());
            toolStripStatusLabel2.Text = String.Format("Time: {0} ms", sw.ElapsedMilliseconds);
        }

        private void btn_Otsu_Click(object sender, EventArgs e)
        {
            err = refMain.ImageManager.iImageIsNULL();
            if (err == E_iVision_ERRORS.E_TRUE)
            {
                MessageBox.Show(String.Format("iImageIsNULL: " + err.ToString(), "ERROR"));
                return;
            }

            sw.Reset();
            sw.Start();
            MVC_ImageProcessing.OtsuThreshold(InputGeneralImage, OutputGeneralImage);
            sw.Stop();
            
            if (refMain.pictureBox1.Image != null)
                refMain.pictureBox1.Image.Dispose();
            refMain.pictureBox1.Image = DrawScaledImage(OutputGeneralImage, refMain.scale);
            //refMain.pictureBox1.Image = System.Drawing.Image.FromHbitmap(hbitmap);

            toolStripStatusLabel1.Text = String.Format("State: " + err.ToString());
            toolStripStatusLabel2.Text = String.Format("Time: {0} ms", sw.ElapsedMilliseconds);
        }

        private void btn_Edge_Click(object sender, EventArgs e)
        {
            MVC_Image.iImageCopy(InputGeneralImage, OutputGeneralImage);

            err = MVC_Image.iImageIsNULL(InputGeneralImage);
            if (err == E_iVision_ERRORS.E_TRUE)
            {
                MessageBox.Show(String.Format("iImageIsNULL: " + err.ToString(), "ERROR"));
                return;
            }

            switch (cmbBox_Edge.SelectedIndex)
            {
                case 0:
                    sw.Reset();
                    sw.Start();
                    err = MVC_ImageProcessing.Sobel(InputGeneralImage, OutputGeneralImage);
                    sw.Stop();
                    break;
                case 1:
                    sw.Reset();
                    sw.Start();
                    err = MVC_ImageProcessing.Laplacian(InputGeneralImage, OutputGeneralImage);
                    sw.Stop();
                    break;
                case 2:
                    sw.Reset();
                    sw.Start();
                    err = MVC_ImageProcessing.Robert(InputGeneralImage, OutputGeneralImage);
                    sw.Stop();
                    break;
                case 3:
                    sw.Reset();
                    sw.Start();
                    err = MVC_ImageProcessing.Prewitt(InputGeneralImage, OutputGeneralImage);
                    sw.Stop();
                    break;
                case 4:
                    sw.Reset();
                    sw.Start();
                    err = MVC_ImageProcessing.LaplacianSharping(InputGeneralImage, OutputGeneralImage);
                    sw.Stop();
                    break;
            }

            if (err == E_iVision_ERRORS.E_OK)
            {
                hbitmap = MVC_Image.iGetBitmapAddress(OutputGeneralImage);
                if (refMain.pictureBox1.Image != null)
                    refMain.pictureBox1.Image.Dispose();
                refMain.pictureBox1.Image = DrawScaledImage(OutputGeneralImage, refMain.scale);
                //refMain.pictureBox1.Image = System.Drawing.Image.FromHbitmap(hbitmap);
            }
            toolStripStatusLabel1.Text = String.Format("State: " + err.ToString());
            toolStripStatusLabel2.Text = String.Format("Time: {0} ms", sw.ElapsedMilliseconds);

        }

        private void btn_Convolution_Click(object sender, EventArgs e)
        {

            err = MVC_Image.iImageIsNULL(InputGeneralImage);
            if (err == E_iVision_ERRORS.E_TRUE)
            {
                MessageBox.Show(String.Format("iImageIsNULL: " + err.ToString(), "ERROR"));
                return;
            }

            switch (cmbBox_Convolution.SelectedIndex)
            {
                case 0:
                    sw.Reset();
                    sw.Start();
                    err = MVC_ImageProcessing.GaussianSmoothing3x3(InputGeneralImage, OutputGeneralImage);
                    sw.Stop();
                    break;
                case 1:
                    sw.Reset();
                    sw.Start();
                    err = MVC_ImageProcessing.GaussianSmoothing5x5(InputGeneralImage, OutputGeneralImage);
                    sw.Stop();
                    break;
                case 2:
                    sw.Reset();
                    sw.Start();
                    err = MVC_ImageProcessing.GaussianSmoothing7x7(InputGeneralImage, OutputGeneralImage);
                    sw.Stop();
                    break;
                case 3:
                    sw.Reset();
                    sw.Start();
                    err = MVC_ImageProcessing.MeanSmoothing3x3(InputGeneralImage, OutputGeneralImage);
                    sw.Stop();
                    break;
                case 4:
                    sw.Reset();
                    sw.Start();
                    err = MVC_ImageProcessing.MeanSmoothing5x5(InputGeneralImage, OutputGeneralImage);
                    sw.Stop();
                    break;
                case 5:
                    sw.Reset();
                    sw.Start();
                    err = MVC_ImageProcessing.MeanSmoothing7x7(InputGeneralImage, OutputGeneralImage);
                    sw.Stop();
                    break;
                case 6:
                    sw.Reset();
                    sw.Start();
                    err = MVC_ImageProcessing.MedianFilter3x3(InputGeneralImage, OutputGeneralImage);
                    sw.Stop();
                    break;
                case 7:
                    sw.Reset();
                    sw.Start();
                    err = MVC_ImageProcessing.MedianFilter5x5(InputGeneralImage, OutputGeneralImage);
                    sw.Stop();
                    break;
            }

            if (err == E_iVision_ERRORS.E_OK)
            {
                hbitmap = MVC_Image.iGetBitmapAddress(OutputGeneralImage);
                if (refMain.pictureBox1.Image != null)
                    refMain.pictureBox1.Image.Dispose();
                refMain.pictureBox1.Image = DrawScaledImage(OutputGeneralImage, refMain.scale);
                //refMain.pictureBox1.Image = System.Drawing.Image.FromHbitmap(hbitmap);
            }
            toolStripStatusLabel1.Text = String.Format("State: " + err.ToString());
            toolStripStatusLabel2.Text = String.Format("Time: {0} ms", sw.ElapsedMilliseconds);
        }

        #region commented for not use more functions 
        //private void btn_Mophology_Click(object sender, EventArgs e)
        //{
        //    Masksize = Convert.ToInt32(txt_MaskSize.Text);

        //   // err = iImage.iImageIsNULL(refMain.GrayImg);
        //    if (err == E_iVision_ERRORS.E_TRUE)
        //    {
        //        MessageBox.Show(String.Format("iImageIsNULL: " + err.ToString(), "ERROR"));
        //        return;
        //    }

        //    switch (cmbBox_Mophology.SelectedIndex)
        //    {
        //        case 0:
        //            if (rb_MaskType_Rect.Checked == true)
        //            {
        //                sw.Reset();
        //                sw.Start();
        //               // err = iImgProcess.iImg_Dilation(refMain.GrayImg,refMain.ProcessImg,Masksize,Masksize);
        //                sw.Stop();
        //            }
        //            else if (rb_MaskType_Diamond.Checked == true)
        //            {
        //                sw.Reset();
        //                sw.Start();
        //              //  err = iImgProcess.iImg_DilationDiamond(refMain.GrayImg,refMain.ProcessImg,Masksize);
        //                sw.Stop();
        //            }
        //            else
        //            {
        //                sw.Reset();
        //                sw.Start();
        //              //  err = iImgProcess.iImg_DilationCircle(refMain.GrayImg,refMain.ProcessImg,Masksize);
        //                sw.Stop();
        //            }
        //            break;
        //        case 1:
        //            if (rb_MaskType_Rect.Checked == true)
        //            {
        //                sw.Reset();
        //                sw.Start();
        //             //   err = iImgProcess.iImg_Erosion(refMain.GrayImg,refMain.ProcessImg,Masksize,Masksize);
        //                sw.Stop();
        //            }
        //            else if (rb_MaskType_Diamond.Checked == true)
        //            {
        //                sw.Reset();
        //                sw.Start();
        //                //err = iImgProcess.iImg_ErosionDiamond(refMain.GrayImg,refMain.ProcessImg,Masksize);
        //                sw.Stop();
        //            }
        //            else
        //            {
        //                sw.Reset();
        //                sw.Start();
        //                //err = iImgProcess.iImg_ErosionCircle(refMain.GrayImg,refMain.ProcessImg,Masksize);
        //                sw.Stop();
        //            }
        //            break;
        //        case 2:
        //            if (rb_MaskType_Rect.Checked == true)
        //            {
        //                sw.Reset();
        //                sw.Start();
        //               // err = iImgProcess.iImg_Opening(refMain.GrayImg,refMain.ProcessImg,Masksize,Masksize);
        //                sw.Stop();
        //            }
        //            else if (rb_MaskType_Diamond.Checked == true)
        //            {
        //                sw.Reset();
        //                sw.Start();
        //                //err = iImgProcess.iImg_OpeningDiamond(refMain.GrayImg,refMain.ProcessImg,Masksize);
        //                sw.Stop();
        //            }
        //            else
        //            {
        //                sw.Reset();
        //                sw.Start();
        //                //err = iImgProcess.iImg_OpeningCircle(refMain.GrayImg,refMain.ProcessImg,Masksize);
        //                sw.Stop();
        //            }
        //            break;
        //        case 3:
        //            if (rb_MaskType_Rect.Checked == true)
        //            {
        //                sw.Reset();
        //                sw.Start();
        //                //err = iImgProcess.iImg_Closing(refMain.GrayImg,refMain.ProcessImg,Masksize,Masksize);
        //                sw.Stop();
        //            }
        //            else if (rb_MaskType_Diamond.Checked == true)
        //            {
        //                sw.Reset();
        //                sw.Start();
        //               //err = iImgProcess.iImg_ClosingDiamond(refMain.GrayImg,refMain.ProcessImg,Masksize);
        //                sw.Stop();
        //            }
        //            else
        //            {
        //                sw.Reset();
        //                sw.Start();
        //                //err = iImgProcess.iImg_ClosingCircle(refMain.GrayImg,refMain.ProcessImg,Masksize);
        //                sw.Stop();
        //            }
        //            break;
        //        case 4:
        //            if (rb_MaskType_Rect.Checked == true)
        //            {
        //                sw.Reset();
        //                sw.Start();
        //                //err = iImgProcess.iImg_MorphGradient(refMain.GrayImg,refMain.ProcessImg,Masksize,Masksize);
        //                sw.Stop();
        //            }
        //            else if (rb_MaskType_Diamond.Checked == true)
        //            {
        //                sw.Reset();
        //                sw.Start();
        //                //err = iImgProcess.iImg_MorphGradientDiamond(refMain.GrayImg, refMain.ProcessImg, Masksize);
        //                sw.Stop();
        //            }
        //            else
        //            {
        //                sw.Reset();
        //                sw.Start();
        //                //err = iImgProcess.iImg_MorphGradientCircle(refMain.GrayImg, refMain.ProcessImg, Masksize);
        //                sw.Stop();
        //            }
        //            break;
        //    }

        //    if (err == E_iVision_ERRORS.E_OK)
        //    {
        //        //hbitmap = iImage.iGetBitmapAddress(refMain.ProcessImg);
        //        if (refMain.pictureBox1.Image != null)
        //            refMain.pictureBox1.Image.Dispose();
        //        refMain.pictureBox1.Image = System.Drawing.Image.FromHbitmap(hbitmap);
        //    }
        //    toolStripStatusLabel1.Text = String.Format("State: " + err.ToString());
        //    toolStripStatusLabel2.Text = String.Format("Time: {0} ms", sw.ElapsedMilliseconds);
        //}

        //private void btn_Arithmetic_Click(object sender, EventArgs e)
        //{
        //   // err = iImage.iImageIsNULL(refMain.GrayImg);
        //    if (err == E_iVision_ERRORS.E_TRUE)
        //    {
        //        MessageBox.Show(String.Format("iImageIsNULL: " + err.ToString(), "ERROR"));
        //        return;
        //    }

        //    switch (cmbBox_Arithmetic.SelectedIndex)
        //    {
        //        case 0:
        //            //iImgProcess.iImg_Sobel(refMain.GrayImg,refMain.ProcessImg);
        //            sw.Reset();
        //            sw.Start();
        //           // err = iImgProcess.iImg_ImageAdd(refMain.GrayImg, refMain.ProcessImg, refMain.ProcessImg);
        //            sw.Stop();
        //            break;
        //        case 1:
        //           // iImgProcess.iImg_Sobel(refMain.GrayImg,refMain.ProcessImg);
        //            sw.Reset();
        //            sw.Start();
        //           // err = iImgProcess.iImg_ImageSub(refMain.GrayImg, refMain.ProcessImg, refMain.ProcessImg);
        //            sw.Stop();
        //            break;
        //        case 2:
        //            sw.Reset();
        //            sw.Start();
        //            //err = iImgProcess.iImg_ImageMul(refMain.GrayImg, refMain.ProcessImg, 2);
        //            sw.Stop();
        //            break;
        //        case 3:
        //            sw.Reset();
        //            sw.Start();
        //           // err = iImgProcess.iImg_ImageDiv(refMain.GrayImg, refMain.ProcessImg, 2);
        //            sw.Stop();
        //            break;
        //    }
        //    if (err == E_iVision_ERRORS.E_OK)
        //    {
        //        //hbitmap = iImage.iGetBitmapAddress(refMain.GrayImg);
        //        if (refMain.pictureBox1.Image != null)
        //            refMain.pictureBox1.Image.Dispose();
        //        refMain.pictureBox1.Image = System.Drawing.Image.FromHbitmap(hbitmap);
        //    }
        //    toolStripStatusLabel1.Text = String.Format("State: " + err.ToString());
        //    toolStripStatusLabel2.Text = String.Format("Time: {0} ms", sw.ElapsedMilliseconds);

        //}

        //private void btn_Logic_Click(object sender, EventArgs e)
        //{
        //    Logicvalue = Convert.ToInt32(txt_LogicValue.Text);
        //    Gain = Convert.ToSingle(txt_Gain.Text);
        //    Offset = Convert.ToInt32(txt_Offset.Text);

        //    //err = iImage.iImageIsNULL(refMain.GrayImg);
        //    //if (err == E_iVision_ERRORS.E_TRUE)
        //    //{
        //    //    MessageBox.Show(String.Format("iImageIsNULL: " + err.ToString(), "ERROR"));
        //    //    return;
        //    //}

        //    //switch (cmbBox_Logic.SelectedIndex)
        //    //{
        //    //    case 0:
        //    //        sw.Reset();
        //    //        sw.Start();
        //    //        err = iImgProcess.iImg_ImageShiftLeft(refMain.GrayImg, refMain.ProcessImg, Logicvalue);
        //    //        sw.Stop();
        //    //        break;
        //    //    case 1:
        //    //        sw.Reset();
        //    //        sw.Start();
        //    //        err = iImgProcess.iImg_ImageShiftRight(refMain.GrayImg, refMain.ProcessImg, Logicvalue);
        //    //        sw.Stop();
        //    //        break;
        //    //    case 2:
        //    //        iImgProcess.iImg_OtsuThreshold(refMain.GrayImg,refMain.ProcessImg);
        //    //        sw.Reset();
        //    //        sw.Start();
        //    //        err = iImgProcess.iImg_ImageBitwiseAND(refMain.GrayImg, refMain.ProcessImg, refMain.ProcessImg);
        //    //        sw.Stop();
        //    //        break;
        //    //    case 3:
        //    //        iImgProcess.iImg_OtsuThreshold(refMain.GrayImg, refMain.ProcessImg);
        //    //        sw.Reset();
        //    //        sw.Start();
        //    //        err = iImgProcess.iImg_ImageBitwiseOR(refMain.GrayImg, refMain.ProcessImg, refMain.ProcessImg);
        //    //        sw.Stop();
        //    //        break;
        //    //    case 4:
        //    //        iImgProcess.iImg_OtsuThreshold(refMain.GrayImg, refMain.ProcessImg);
        //    //        sw.Reset();
        //    //        sw.Start();
        //    //        err = iImgProcess.iImg_ImageBitwiseXOR(refMain.GrayImg, refMain.ProcessImg, refMain.ProcessImg);
        //    //        sw.Stop();
        //    //        break;
        //    //    case 5:
        //    //        iImgProcess.iImg_Sobel(refMain.GrayImg,refMain.ProcessImg);
        //    //        sw.Reset();
        //    //        sw.Start();
        //    //        err = iImgProcess.iImg_ImageEqual(refMain.GrayImg, refMain.ProcessImg, refMain.ProcessImg);
        //    //        sw.Stop();
        //    //        break;
        //    //    case 6:
        //    //        iImgProcess.iImg_Sobel(refMain.GrayImg,refMain.ProcessImg);
        //    //        sw.Reset();
        //    //        sw.Start();
        //    //        err = iImgProcess.iImg_ImageNOTEqual(refMain.GrayImg, refMain.ProcessImg, refMain.ProcessImg);
        //    //        sw.Stop();
        //    //        break;
        //    //    case 7:
        //    //        sw.Reset();
        //    //        sw.Start();
        //    //        err = iImgProcess.iImg_ImageInvert(refMain.GrayImg, refMain.ProcessImg);
        //    //        sw.Stop();
        //    //        break;
        //    //    case 8:
        //    //        sw.Reset();
        //    //        sw.Start();
        //    //        err = iImgProcess.iImg_ImageGainOffset(refMain.GrayImg,refMain.ProcessImg, Gain,Offset);
        //    //        sw.Stop();
        //    //        break;
        //    //}
        //    if (err == E_iVision_ERRORS.E_OK)
        //    {
        //       // hbitmap = iImage.iGetBitmapAddress(refMain.GrayImg);
        //        if (refMain.pictureBox1.Image != null)
        //            refMain.pictureBox1.Image.Dispose();
        //        refMain.pictureBox1.Image = System.Drawing.Image.FromHbitmap(hbitmap);
        //    }
        //    toolStripStatusLabel1.Text = String.Format("State: " + err.ToString());
        //    toolStripStatusLabel2.Text = String.Format("Time: {0} ms", sw.ElapsedMilliseconds);

        //}

        //private void btn_Transform_Click(object sender, EventArgs e)
        //{
        //    //int wid,hei;
        //    //ang = Convert.ToSingle(txt_Rotation.Text);
        //    //scale = Convert.ToSingle(txt_Scale.Text);
        //    //shift = Convert.ToInt32(txt_Shift.Text);

        //    //err = iImage.iImageIsNULL(refMain.GrayImg);
        //    //if (err == E_iVision_ERRORS.E_TRUE)
        //    //{
        //    //    MessageBox.Show(String.Format("iImageIsNULL: " + err.ToString(), "ERROR"));
        //    //    return;
        //    //}
            
        //    //wid = iImage.GetWidth(refMain.GrayImg);
        //    //hei = iImage.GetHeight(refMain.GrayImg);
        //    //iImage.iImageResize(refMain.ProcessImg, wid, hei);

        //    //if (rb_Rotation.Checked == true)
        //    //{
        //    //    sw.Reset();
        //    //    sw.Start();
        //    //    err = iImgProcess.iImg_ImageRotation(refMain.GrayImg, refMain.ProcessImg, wid / 2, hei / 2, wid / 2, hei / 2, ang);
        //    //    sw.Stop();                
        //    //}
        //    //else if (rb_Shift.Checked == true)
        //    //{
        //    //    sw.Reset();
        //    //    sw.Start();
        //    //    err = iImgProcess.iImg_ImageTranslation(refMain.GrayImg, refMain.ProcessImg, wid / 2, hei / 2, wid / 2 + shift, hei / 2 + shift);
        //    //    sw.Stop();  
        //    //}
        //    //else
        //    //{
        //    //    sw.Reset();
        //    //    sw.Start();
        //    //    err = iImgProcess.iImg_ImageScaling(refMain.GrayImg, refMain.ProcessImg, wid / 2, hei / 2, scale);
        //    //    sw.Stop();  
        //    //}

        //    //if (err == E_iVision_ERRORS.E_OK)
        //    //{
        //    //    hbitmap = iImage.iGetBitmapAddress(refMain.ProcessImg);
        //    //    if (refMain.pictureBox1.Image != null)
        //    //        refMain.pictureBox1.Image.Dispose();
        //    //    refMain.pictureBox1.Image = System.Drawing.Image.FromHbitmap(hbitmap);
        //    //}
        //    //toolStripStatusLabel1.Text = String.Format("State: " + err.ToString());
        //    //toolStripStatusLabel2.Text = String.Format("Time: {0} ms", sw.ElapsedMilliseconds);
        //}

        //private void btn_Color_Click(object sender, EventArgs e)
        //{
        ////    err = iImage.iImageIsNULL(ColorImg);
        ////    if (err == E_iVision_ERRORS.E_TRUE)
        ////    {
        ////        MessageBox.Show(String.Format("iImageIsNULL: " + err.ToString(), "ERROR"));
        ////        return;
        ////    }

        ////    int wid, hei;
        ////    wid = iImage.GetWidth(ColorImg);
        ////    hei = iImage.GetHeight(ColorImg);

        ////    iImage.iImageResize(refMain.GrayImg, wid, hei);

        ////    if (rb_Color2Gray.Checked == true)
        ////    {
        ////        sw.Reset();
        ////        sw.Start();
        ////        err = iColor.iColor_ColorToGray(ColorImg, refMain.GrayImg);
        ////        sw.Stop();
        ////    }

        ////    if (err == E_iVision_ERRORS.E_OK)
        ////    {
        ////        hbitmap = iImage.iGetBitmapAddress(refMain.GrayImg);
        ////        if (refMain.pictureBox1.Image != null)
        ////            refMain.pictureBox1.Image.Dispose();
        ////        refMain.pictureBox1.Image = System.Drawing.Image.FromHbitmap(hbitmap);
        ////    }
        ////    toolStripStatusLabel1.Text = String.Format("State: " + err.ToString());
        ////    toolStripStatusLabel2.Text = String.Format("Time: {0} ms", sw.ElapsedMilliseconds);
        //}






        #endregion


        private void sldThreshold_ValueChanged(object sender, EventArgs e)
        {
            if (err == E_iVision_ERRORS.E_TRUE)
            {
                MessageBox.Show(String.Format("iImageIsNULL: " + err.ToString(), "ERROR"));
                return;
            }

            sw.Reset();
            sw.Start();
            //err = ImageProcessingManager.Threshold(refMain.ProcessImg, Convert.ToInt32(sldThreshold.Value));
            err = MVC_ImageProcessing.Threshold(InputGeneralImage, OutputGeneralImage, Convert.ToInt32(sldThreshold.Value));
            sw.Stop();
            lbValue.Text = sldThreshold.Value.ToString();
            if (err == E_iVision_ERRORS.E_OK)
            {


                hbitmap = MVC_Image.iGetBitmapAddress(OutputGeneralImage);
                if (refMain.pictureBox1.Image != null)
                    refMain.pictureBox1.Image.Dispose();

                refMain.pictureBox1.Image = DrawScaledImage(OutputGeneralImage, refMain.scale);
                //refMain.pictureBox1.Size = refMain.pictureBox1.Image.Size;

                //refMain.pictureBox1.Image = System.Drawing.Image.FromHbitmap(hbitmap);

                //  check this here we add the new graphics for the image process image
                //
                //refMain.g = refMain.pictureBox1.CreateGraphics();
                //refMain.hDC = refMain.g.GetHdc();

                // refMain.pictureBox1.Refresh();

                //iROI.iROIManagerSetDrawScale(refMain.ImageProcessinglManager, refMain.hDC_ImgProcess, refMain.scale);
                //iROI.iROIManagerSetDrawScale(refMain.ImageProcessinglManager, refMain.hDC_ImgProcess, refMain.scale);


            }


            toolStripStatusLabel1.Text = String.Format("State: " + err.ToString());
            toolStripStatusLabel2.Text = String.Format("Time: {0} ms", sw.ElapsedMilliseconds);
        }

      
        void RenderImage(IntPtr img)
        {
            if (refMain != null && img!=null)
            {
                DrawScaledImage(img, refMain.scale);
               
            }
            else { return; }
        }

        private void ApplySelectedMethod(string method, object sender, EventArgs e)
        {
            
            if (method == "Threshold")
            {
                btn_Threshold_Click(sender, e);
            }
            if (method == "Edge")
            {
                btn_Edge_Click(sender, e);
            }
            if (method == "Convolution")
            {
                btn_Convolution_Click(sender, e);
            }
        }
        public void EnableGroupBox(object selectedItems)
        {
            if (selectedItems == "None")
            {
                gbThreshold.Enabled = false;
                gbEdge.Enabled = false;
                gbConvolution.Enabled = false;
            }
            else if (selectedItems == "Threshold")
            {
                gbThreshold.Enabled = true;
                gbEdge.Enabled = false;
                gbConvolution.Enabled = false;
            }
            else if (selectedItems == "Edge")
            {
                gbEdge.Enabled = true;
                gbThreshold.Enabled = false;
                gbConvolution.Enabled = false;
            }
            else if (selectedItems == "Convolution")
            {
                gbConvolution.Enabled = true;
                gbEdge.Enabled = false;
                gbThreshold.Enabled = false;
            }

        }

        private void cbChoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Line " + cbChoices.SelectedItem);
            lbImgProcessing.Items[lbImgProcessing.SelectedIndex] = lbImgProcessing.SelectedIndex.ToString() + ". " + cbChoices.SelectedItem;
            EnableGroupBox(cbChoices.SelectedItem);
            if (lbImgProcessing.SelectedIndex == 0 && lbImgProcessing.SelectedItem.ToString() == "0. None")
            {
                if (refMain.ImageManager != null)
                {
                    MVC_Image.iImageCopy(Output1, refMain.ImageManager.GetWorkingImage());
                    RenderImage(InputGeneralImage);
                }

                return;
            }
            if (lbImgProcessing.SelectedIndex == 0 && lbImgProcessing.SelectedItem.ToString() != "0. None")
            {
                if (refMain.ImageManager != null)
                {
                    MVC_Image.iImageCopy(InputGeneralImage, refMain.ImageManager.GetWorkingImage());
                }
                ApplySelectedMethod(lbImgProcessing.SelectedItem.ToString().Remove(0, 3), sender, e);
                return;
            }

            if (lbImgProcessing.SelectedIndex == 1 && lbImgProcessing.SelectedItem.ToString() != "1. None ")
            {
                MVC_Image.iImageCopy(InputGeneralImage, Output1);
                ApplySelectedMethod(lbImgProcessing.SelectedItem.ToString().Remove(0, 3), sender, e);
                return;
            }
            else if (lbImgProcessing.SelectedIndex == 1 && lbImgProcessing.SelectedItem.ToString() == "1. None ")
            {
                MVC_Image.iImageCopy(InputGeneralImage, Output1);
                RenderImage(InputGeneralImage);
                return;
            }
            else if (lbImgProcessing.SelectedIndex == 1 && lbImgProcessing.Items[0].ToString() == "0. None")
            {
                MVC_Image.iImageCopy(InputGeneralImage, Output1);
                ApplySelectedMethod(lbImgProcessing.SelectedItem.ToString().Remove(0, 3), sender, e);
                return;
            }
            if (lbImgProcessing.SelectedIndex == 2 && lbImgProcessing.SelectedItem.ToString() != "2. None ")
            {
                MVC_Image.iImageCopy(InputGeneralImage, Output2);
                ApplySelectedMethod(lbImgProcessing.SelectedItem.ToString().Remove(0, 3), sender, e);
                return;
            }
            else if (lbImgProcessing.SelectedIndex == 2 && lbImgProcessing.SelectedItem.ToString() == "2. None ")
            {
                MVC_Image.iImageCopy(InputGeneralImage, Output2);
                RenderImage(InputGeneralImage);
            }
        }

        public IntPtr GetImageProcessedImage()
        {
            return OutputGeneralImage;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //err = iImgProcess.iVisitingKey();
            //toolStripStatusLabel1.Text = String.Format("State: " + err.ToString());
        }

 
    }

}
