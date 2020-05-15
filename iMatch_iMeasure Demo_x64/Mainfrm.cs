using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
//using MiM_iVision;
using MVC.Vision.MiM;
using MVC_ModelLibrary.MVC_Managers;
using MVC.Vision.mvcVision;
//using MVC_ModelLibrary;
//using MVC_ModelLibrary.MVC_Managers;



namespace Warp_Csharp
{
    public partial class Mainfrm : Form
    {
        DemoDialog Dlg ;
        iLineForm LineDlg = new iLineForm();
        iImgProcessForm ImgDlg;

        public MVC_ImageManager ImageManager;
        MVC_VisionManager VisionManager = new MVC_VisionManager();
        public IntPtr GrayImg;
        //public IntPtr GrayROIImg = iImage.CreateGrayiImage();
        public IntPtr ProcessImg = MVC_Image.CreateGrayiImage();

        public IntPtr hbitmap;
        //public IntPtr NCCmodel = iMatch.CreateNCCMatch();
        //public IntPtr imeasure = iMCircle.CreateiMCircle();
        //public IntPtr iMeasureLine = iMLine.CreateiMLine();
        public iIPoint ROIVectorCircle = new iIPoint();
        public iIPoint ROIVectorLine = new iIPoint();
        
        public float scale = 1;


        public iIPoint CpofMatch;

        //For show ROI
        public bool ShowCircleNoIPMeasure;
        public bool ShowMatchingROI;
        public Graphics g;
        public IntPtr hDC;
        public Graphics g_ImgProcess;
        public IntPtr hDC_ImgProcess;

        public bool ShowCircleIPMeasure = false;
        private bool isColor;
        public bool ShowLineIPMeasure = false;
        internal bool ShowLineNoIPMeasure = false;

        public Mainfrm()
        {
            InitializeComponent();
            isColor = false;
            Dlg = new DemoDialog(this);
            ShowMatchingROI = false;
            ShowCircleNoIPMeasure = false;
            ImgDlg = new iImgProcessForm(this);
            cbScale.SelectedItem = cbScale.Items[0].ToString();
        }

        private void openNCCDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Dlg.refMain = this;
            Dlg.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void keyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int serial = 0;
            E_iVision_ERRORS err = VisionManager.GetKeySerial(ref serial);
            //E_iVision_ERRORS err = iVision.iGetKeySerial(ref serial);

            MessageBox.Show("Key State:" + err.ToString() + " Serial:" + serial.ToString(), "Information");
        }

        private void getVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //IntPtr ptr = iVision.iGetiMatchVersion();
            IntPtr ptr = VisionManager.GetiMatchVersion() ;
            string str = Marshal.PtrToStringAnsi(ptr);
            //ptr = iVision.iGetiMatchVersionDate();
            ptr = VisionManager.GetiMatchVersionDate();
            string strdate = Marshal.PtrToStringAnsi(ptr);
            MessageBox.Show(str.ToString()+ "   "+ strdate.ToString(), "Information");
        }

        private void Mainfrm_FormClosed(object sender, FormClosedEventArgs e)
        {

            //iMCircle.DestroyiMCircle(imeasure);
            //iMatch.DestroyNCCMatch(NCCmodel);
            //iImage.DestroyiImage(GrayImg);

            if (Dlg != null)
                Dlg.Dispose();
        }

        private void Picbox_MouseDown(object sender, MouseEventArgs e)
        {
            if (ImageManager!=null)
            {
                if (ImageManager.iImageIsNULL() == E_iVision_ERRORS.E_FALSE)
                {
                    if (ShowCircleNoIPMeasure)
                    {
                        //if (iROI.iROISize(MeasureROIToolManager) != 0)
                        //   iROI.iROIMouseDown(MeasureROIToolManager, hDC, e.X, e.Y);
                        if (Dlg.ROINoIPCircleMeasureManager.ROISize() != 0)
                            Dlg.ROINoIPCircleMeasureManager.MouseDownEvents(e.X, e.Y);
                    }
                    if (ShowMatchingROI)
                    {
                        //if (iROI.iROISize(MatchingROIToolManager) != 0)
                        //    iROI.iROIMouseDown(MatchingROIToolManager, hDC, e.X, e.Y);
                        if (Dlg.ROIMatchingManager.ROISize() != 0)
                            Dlg.ROIMatchingManager.MouseDownEvents(e.X, e.Y);
                    }
                    if (ShowCircleIPMeasure)
                    {
                        if (Dlg.ROIIPCircleManager.ROISize() != 0)
                            Dlg.ROIIPCircleManager.MouseDownEvents(e.X, e.Y);
                    }
                    if (ShowLineIPMeasure)
                    {
                        if (Dlg.ROIIPLineManager.ROISize() != 0)
                            Dlg.ROIIPLineManager.MouseDownEvents(e.X, e.Y);
                    }
                    if (    ShowLineNoIPMeasure)
                    {
                        if (Dlg.ROINoIPLineMeasureManager.ROISize() != 0)
                            Dlg.ROINoIPLineMeasureManager.MouseDownEvents(e.X, e.Y);
                    }
                }
            }
            
        }

        private void Picbox_MouseMove(object sender, MouseEventArgs e)
        {
            if (ImageManager != null)
            {
                if (ImageManager.iImageIsNULL() == E_iVision_ERRORS.E_FALSE)
                {
                    if (ShowCircleNoIPMeasure)
                    {
                        //if (iROI.iROISize(MeasureROIToolManager) != 0)
                        //   iROI.iROIMouseDown(MeasureROIToolManager, hDC, e.X, e.Y);
                        if (Dlg.ROINoIPCircleMeasureManager.ROISize() != 0)
                            Dlg.ROINoIPCircleMeasureManager.MouseMoveEvent(e.X, e.Y);
                    }
                    if (ShowMatchingROI)
                    {
                        //if (iROI.iROISize(MatchingROIToolManager) != 0)
                        //    iROI.iROIMouseDown(MatchingROIToolManager, hDC, e.X, e.Y);
                        if (Dlg.ROIMatchingManager.ROISize() != 0)
                            Dlg.ROIMatchingManager.MouseMoveEvent(e.X, e.Y);
                    }
                    if (ShowCircleIPMeasure)
                    {
                       
                        if (Dlg.ROIIPCircleManager.ROISize() != 0)
                            Dlg.ROIIPCircleManager.MouseMoveEvent(e.X, e.Y);
                    }
                    if (ShowLineIPMeasure)
                    {
                        if (Dlg.ROIIPLineManager.ROISize() != 0)
                            Dlg.ROIIPLineManager.MouseMoveEvent(e.X, e.Y);
                    }
                    if (ShowLineNoIPMeasure)
                    {
                        if (Dlg.ROINoIPLineMeasureManager.ROISize() != 0)
                            Dlg.ROINoIPLineMeasureManager.MouseMoveEvent(e.X, e.Y);
                    }
                }
            }
                

        }

        private void cbScale_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string selectedItem = cbScale.Items[cbScale.SelectedIndex].ToString();
            if (selectedItem == "1 : 0.25") scale = 0.25f;
            if (selectedItem == "1 : 0.5") scale = 0.5f;
            else if (selectedItem == "1 : 0.75") scale = 0.75f;
            else if (selectedItem == "1 : 1") scale = 1f;
            else if (selectedItem == "1 : 1.25") scale = 1.25f;
            else if (selectedItem == "1 : 1.5") scale = 1.5f;
            else if (selectedItem == "1 : 2") scale = 2f;
            if (ImageManager!=null)
            {
                if (ImageManager.iImageIsNULL() != E_iVision_ERRORS.E_TRUE)
                //if (iImage.iImageIsNULL(GrayImg) != E_iVision_ERRORS.E_TRUE)
                {
                    pictureBox1.Image = DrawScaledImage(ImageManager.GetWorkingImage(), scale);
                    //pbImagen.Image = Image.FromHbitmap(iImage.iGetBitmapAddress(GrayImg));
                    //pictureBox1.Size = pictureBox1.Image.Size;

                    Dlg.ROIMatchingManager.SetDrawScale(scale);
                    Dlg.ROINoIPCircleMeasureManager.SetDrawScale(scale);
                    Dlg.ROINoIPLineMeasureManager.SetDrawScale(scale);
                    //iROI.iROIManagerSetDrawScale(MatchingROIToolManager, hDC, scale);
                    //iROI.iROIManagerSetDrawScale(MeasureROIToolManager, hDC, scale);



                    // iROI.iROIManagerSetDrawScale(NCCmodel, hDC, scale);

                    //  iROI.iROIManagerSetDrawScale(imeasure, hDC, scale);

                    //iMatch.iSetScale()
                    //iAutoMeasure.iDrawAutoMeasureROIScale(AutoTool, hDC, scale);
                    //m_g_ = pbImagen.CreateGraphics();
                    //hDC = m_g_.GetHdc();
                }
            }
          
        }
        /// <summary>
        ///  resize the image using the Pointer
        /// </summary>
        /// <param name="a_Image"></param>
        /// <param name="a_scale"></param>
        /// <returns></returns>
        public Bitmap DrawScaledImage(IntPtr a_Image, float a_scale)
        {
            Image img = Image.FromHbitmap(ImageManager.iGetBitmapAddress());

            //Bitmap l_Bitmap = new Bitmap((int)(iImage.GetWidth(a_Image) * a_scale),
            //                             (int)(iImage.GetHeight(a_Image) * a_scale),
            //                             PixelFormat.Format32bppArgb);

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

        internal void showLineDlg()
        {
            LineDlg.RefMain = this;
            LineDlg.Show();
        }

        internal void showImgProcessDlg()
        {
             ImgDlg.refMain = this;
            ImgDlg.Show();
        }
        internal void HideImgProcessDlg()
        {
            ImgDlg.Hide();
        }


        private void btn_LoadGrayImg_Click(object sender, EventArgs e)
        {
            ImageManager = new MVC_ImageManager(isColor); // check this
            //ImgDlg.ImgChangedManager = new MVC_ImageManager(isColor);
            GrayImg = ImageManager.GetWorkingImage();
           
            using (OpenFileDialog openDlg = new OpenFileDialog())
            {
                openDlg.Filter = LoadImage.filter;
                if (openDlg.ShowDialog() == DialogResult.OK)
                {
                    string path = openDlg.FileName;
                    E_iVision_ERRORS ERR = ImageManager.iReadImage(path);
                    if (ERR == E_iVision_ERRORS.E_OK)
                    {
                        hbitmap = ImageManager.iGetBitmapAddress();
                        if (pictureBox1.Image != null)
                            pictureBox1.Image.Dispose();
                        pictureBox1.Image = Image.FromHbitmap(hbitmap);
                        //pictureBox1.Refresh();
                        g = pictureBox1.CreateGraphics();
                        hDC = g.GetHdc();
                        Dlg.ROIMatchingManager = new MVC_ROIManager(ImageManager.GetWorkingImage(), hDC);
                        Dlg.ROINoIPCircleMeasureManager = new MVC_ROIManager(ImageManager.GetWorkingImage(), hDC);
                        Dlg.ROINoIPLineMeasureManager = new MVC_ROIManager(ImageManager.GetWorkingImage(), hDC);
                        cbScale_SelectedIndexChanged(sender, e);
                    }
                    else
                    {
                        MessageBox.Show(ERR.ToString(), "Error");
                        label2.Text = "Error";
                    }
                }
            }
        }

        private void openImgProcessingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImgDlg.refMain = this;
            ImgDlg.Show();
        }
        public IntPtr GetImageProcessedImg()
        {
            return ImgDlg.GetImageProcessedImage();


        }
    }
}

