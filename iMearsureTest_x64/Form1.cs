using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MiM_iVision;
using System.Drawing.Drawing2D;

namespace iMearsureTest
{
    public partial class MainForm : Form
    {
        public IntPtr GrayImg;
        public IntPtr hbitmap;

        iLineForm iLineDlg = new iLineForm();
        iCircleForm iCircleDlg = new iCircleForm();

        public Graphics g;
        public IntPtr hDC;
        public IntPtr ROIManager;
        internal double scale=1;

        public MainForm()
        {
            InitializeComponent();
            pictureBox1.Location = new System.Drawing.Point(10, 30);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            GrayImg = iImage.CreateGrayiImage();
            ROIManager = iROI.CreateiROIManager();
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iLineDlg.RefMain = this;
            iLineDlg.Show();
        }

        private void MainForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (iLineDlg != null)
                iLineDlg.Dispose();

            if (iCircleDlg != null)
                iCircleDlg.Dispose();

            if (GrayImg != null)
                iImage.DestroyiImage(GrayImg);

            if (ROIManager != null)
                iROI.DestroyiROIManager(ROIManager);
        }

        private void MainForm_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //E_iVision_ERRORS err = iImage.iImageIsNULL(GrayImg);
            //if (err == E_iVision_ERRORS.E_FALSE)
            
            
            iROI.iROIMouseMove(ROIManager, hDC, e.X, e.Y);
        }

        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //E_iVision_ERRORS err = iImage.iImageIsNULL(GrayImg);
            //if (err == E_iVision_ERRORS.E_FALSE)
            
                
            iROI.iROIMouseDown(ROIManager, hDC, e.X, e.Y);
        }

        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //E_iVision_ERRORS err = iImage.iImageIsNULL(GrayImg);
            //if (err == E_iVision_ERRORS.E_FALSE)
            
                
            iROI.iROIPlot(ROIManager, hDC);
        }

        private void iCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iCircleDlg.RefMain = this;
            iCircleDlg.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

       
    }
}
