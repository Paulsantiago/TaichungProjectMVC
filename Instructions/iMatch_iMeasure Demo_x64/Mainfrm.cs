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
using MiM_iVision;

namespace Warp_Csharp
{
    public partial class Mainfrm : Form
    {
        DemoDialog Dlg = new DemoDialog();
        iLineForm LineDlg = new iLineForm();
        iImgProcessForm ImgDlg = new iImgProcessForm();
        public IntPtr GrayImg = iImage.CreateGrayiImage();
        public IntPtr GrayROIImg = iImage.CreateGrayiImage();
        public IntPtr ProcessImg = iImage.CreateGrayiImage();

        public IntPtr hbitmap;
        public IntPtr NCCmodel = iMatch.CreateNCCMatch();
        public IntPtr imeasure = iMCircle.CreateiMCircle();
        public IntPtr iMeasureLine = iMLine.CreateiMLine();
        public iIPoint ROIVectorCircle = new iIPoint();
        public iIPoint ROIVectorLine = new iIPoint();
        public IntPtr MeasureROIToolManager = iROI.CreateiROIManager();
        public IntPtr MatchingROIToolManager = iROI.CreateiROIManager();
        public IntPtr ImageProcessinglManager = iROI.CreateiROIManager();
        public float scale = 1;


        public iIPoint CpofMatch;

        //For show ROI
        public bool ShowMeasureROI;
        public bool ShowMatchingROI;
        public Graphics g_ROIs;
        public IntPtr hDC;
        public Graphics g_ImgProcess;
        public IntPtr hDC_ImgProcess;

        public bool IsUsedImageProcessing = false;

        public Mainfrm()
        {
            
            InitializeComponent();
            ShowMatchingROI = false;
            ShowMeasureROI = false;
        }

        private void openNCCDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dlg.refMain = this;
            Dlg.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void keyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int serial = 0;
            E_iVision_ERRORS err = iVision.iGetKeySerial(ref serial);

            MessageBox.Show("Key State:" + err.ToString() + " Serial:" + serial.ToString(), "Information");
        }

        private void getVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IntPtr ptr = iVision.iGetiMatchVersion();
            string str = Marshal.PtrToStringAnsi(ptr);
            ptr = iVision.iGetiMatchVersionDate();
            string strdate = Marshal.PtrToStringAnsi(ptr);
            MessageBox.Show(str.ToString()+ "   "+ strdate.ToString(), "Information");
        }

        private void Mainfrm_FormClosed(object sender, FormClosedEventArgs e)
        {

            iMCircle.DestroyiMCircle(imeasure);
            iMatch.DestroyNCCMatch(NCCmodel);
            iImage.DestroyiImage(GrayImg);

            if (Dlg != null)
                Dlg.Dispose();
        }

        private void Picbox_MouseDown(object sender, MouseEventArgs e)
        {
            if (iImage.iImageIsNULL(GrayImg) == E_iVision_ERRORS.E_FALSE)
            {
                if (ShowMeasureROI)
                {
                    if (iROI.iROISize(MeasureROIToolManager) != 0)
                        iROI.iROIMouseDown(MeasureROIToolManager, hDC, e.X, e.Y);
                }
                if (ShowMatchingROI)
                {
                    if (iROI.iROISize(MatchingROIToolManager) != 0)
                        iROI.iROIMouseDown(MatchingROIToolManager, hDC, e.X, e.Y);
                }
                if (IsUsedImageProcessing)
                {
                    if (iROI.iROISize(ImageProcessinglManager) != 0)
                        iROI.iROIMouseDown(ImageProcessinglManager, hDC_ImgProcess, e.X, e.Y);
                }
            }
        }

        private void Picbox_MouseMove(object sender, MouseEventArgs e)
        {
            if (iImage.iImageIsNULL(GrayImg) == E_iVision_ERRORS.E_FALSE)
            {
                if (ShowMeasureROI)
                {
                    if (iROI.iROISize(MeasureROIToolManager) != 0)
                        iROI.iROIMouseMove(MeasureROIToolManager, hDC, e.X, e.Y);
                }
                if (ShowMatchingROI)
                {
                        if (iROI.iROISize(MatchingROIToolManager) != 0)
                            iROI.iROIMouseMove(MatchingROIToolManager, hDC, e.X, e.Y);
                }
                if (IsUsedImageProcessing)
                {
                    if (iROI.iROISize(ImageProcessinglManager) != 0)
                        iROI.iROIMouseMove(ImageProcessinglManager, hDC_ImgProcess, e.X, e.Y);
                }
            }
        }

        private void cbScale_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string selectedItem = cbScale.Items[cbScale.SelectedIndex].ToString();
            if (selectedItem == "1 : 0.5") scale = 0.5f;
            else if (selectedItem == "1 : 0.75") scale = 0.75f;
            else if (selectedItem == "1 : 1") scale = 1f;
            else if (selectedItem == "1 : 1.25") scale = 1.25f;
            else if (selectedItem == "1 : 1.5") scale = 1.5f;
            else if (selectedItem == "1 : 2") scale = 2f;

            if (iImage.iImageIsNULL(GrayImg) != E_iVision_ERRORS.E_TRUE)
            {
                pictureBox1.Image = DrawScaledImage(GrayImg, scale);
                //pbImagen.Image = Image.FromHbitmap(iImage.iGetBitmapAddress(GrayImg));
                pictureBox1.Size = pictureBox1.Image.Size;
                iROI.iROIManagerSetDrawScale(MatchingROIToolManager, hDC, scale);
                iROI.iROIManagerSetDrawScale(MeasureROIToolManager, hDC, scale);
                
              

                // iROI.iROIManagerSetDrawScale(NCCmodel, hDC, scale);

                //  iROI.iROIManagerSetDrawScale(imeasure, hDC, scale);

                //iMatch.iSetScale()
                //iAutoMeasure.iDrawAutoMeasureROIScale(AutoTool, hDC, scale);
                //m_g_ = pbImagen.CreateGraphics();
                //hDC = m_g_.GetHdc();
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
            Image img = Image.FromHbitmap(iImage.iGetBitmapAddress(a_Image));

            Bitmap l_Bitmap = new Bitmap((int)(iImage.GetWidth(a_Image) * a_scale),
                                         (int)(iImage.GetHeight(a_Image) * a_scale),
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
    }
}

