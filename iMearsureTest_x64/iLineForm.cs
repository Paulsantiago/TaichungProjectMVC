using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MiM_iVision;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace iMearsureTest
{

    public partial class iLineForm : Form
    {
        [DllImport("kernel32.dll")]
        extern static short QueryPerformanceCounter(ref long x);
        [DllImport("kernel32.dll")]
        extern static short QueryPerformanceFrequency(ref long x);
        long ctr1 = 0, ctr2 = 0, freq = 0;

        public MainForm RefMain;

        public int DefSamplingStep = 3, DefIterationN = 100, DefIterTh = 3, DefEdgeChoice = 2, DefTransType = 2;
        public int SamplingStep, IterationN, EdgeChoice, TransType;
        public int Threshold, DefThreshold = 10;
        public double iterationTh;

        iAdvanceROI AdvROI;
        iAdvPairROI AdvPairROI;
        iRectangleROI RectangleROI;
        iTriAdvPairROI TriAdvPairROI;

        public IntPtr imeasureLine;

        public IntPtr iM_LinePair;
        public IntPtr iM_Rectangle;
        public IntPtr iM_Triangle;

        E_iVision_ERRORS g_err;

        public iLineForm()
        {
            InitializeComponent();

            txt_iLineiterationN.Text = DefIterationN.ToString();
            txt_iLineSampingStep.Text = DefSamplingStep.ToString();
            txt_iLineThreshold.Text = DefThreshold.ToString();
            txt_iLineIterThreshold.Text = DefIterTh.ToString();
            txt_iLineEdgeChoice.Text = DefEdgeChoice.ToString();
            txt_Transition.Text = DefTransType.ToString();

            Threshold = DefThreshold;
            SamplingStep = DefSamplingStep;
            IterationN = DefIterationN;
            iterationTh = DefIterTh;
            EdgeChoice = DefEdgeChoice;
            TransType = DefTransType;

            txt_iLineResultA.Text = "0";
            txt_iLineResultB.Text = "0";
            txt_iLineResultC.Text = "0";
            txt_iLineResultP1.Text = "";
            txt_iLineResultP2.Text = "";


            txt_iLineResult2A.Text = "0";
            txt_iLineResult2B.Text = "0";
            txt_iLineResult2C.Text = "0";
            txt_iLineResult2P1.Text = "";
            txt_iLineResult2P2.Text = "";

            imeasureLine = iMLine.CreateiMLine();

            iM_LinePair = iMLinePair.CreateiMLinePair();
            iM_Rectangle = iMRectangle.CreateiMRectangle();
            iM_Triangle = iMTriangle.CreateiMTriangle();

            QueryPerformanceFrequency(ref freq);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image file(*.bmp,*.jpg,*.jpeg)|*.bmp;*.jpeg;*.jpg";
            E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;
            string path;
            int wid, hei;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                RefMain.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                path = openFileDialog1.FileName;
                err = iImage.iReadImage(RefMain.GrayImg, path);
                if (err == E_iVision_ERRORS.E_OK)
                {
                    wid = iImage.GetWidth(RefMain.GrayImg);
                    hei = iImage.GetHeight(RefMain.GrayImg);
                    RefMain.pictureBox1.Size = new System.Drawing.Size(wid, hei);
                    RefMain.hbitmap = iImage.iGetBitmapAddress(RefMain.GrayImg);
                    RefMain.pictureBox1.Image = System.Drawing.Image.FromHbitmap(RefMain.hbitmap);
                    RefMain.g = RefMain.pictureBox1.CreateGraphics();
                    RefMain.hDC = RefMain.g.GetHdc();
                    RefMain.pictureBox1.Refresh();

                    iROI.iROIAttached(RefMain.ROIManager, RefMain.GrayImg, RefMain.hDC);
                    iROI.iROIPlot(RefMain.ROIManager, RefMain.hDC);
                }
                else
                {
                    MessageBox.Show(err.ToString(), "Error");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            E_iVision_ERRORS err = iMLine.iVisitingKey();
            MessageBox.Show(err.ToString(), "Error");
        }

        private void UpdateMeasurePata()
        {
            Threshold = Convert.ToInt32(txt_iLineThreshold.Text);
            SamplingStep = Convert.ToInt32(txt_iLineSampingStep.Text);
            IterationN = Convert.ToInt32(txt_iLineiterationN.Text);
            iterationTh = Convert.ToDouble(txt_iLineIterThreshold.Text);
            EdgeChoice = Convert.ToInt32(txt_iLineEdgeChoice.Text);
            TransType = Convert.ToInt32(txt_Transition.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
              UpdateMeasurePata();
            E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;
            iROI_Type ROIType;
            double   l_angle, l_angle2;
            double[] l_ptr = new double[10];

            ROIType = iROI.iROIGetInfo(RefMain.ROIManager, ref l_ptr[0]);
            if (ROIType == iROI_Type.iAdvPair)
            {

                AdvPairROI.m_center_x = Convert.ToInt32(l_ptr[0]);
                AdvPairROI.m_center_y = Convert.ToInt32(l_ptr[1]);
                AdvPairROI.m_advPair_width_1 = Convert.ToInt32(l_ptr[2]);
                AdvPairROI.m_advPair_width_2 = Convert.ToInt32(l_ptr[3]);
                AdvPairROI.m_width_1 = Convert.ToInt32(l_ptr[4]);
                AdvPairROI.m_height_1 = Convert.ToInt32(l_ptr[5]);
                AdvPairROI.m_width_2 = Convert.ToInt32(l_ptr[6]);
                AdvPairROI.m_height_2 = Convert.ToInt32(l_ptr[7]);
                AdvPairROI.m_rotation_angle = Convert.ToInt32(l_ptr[8]);


                err = iMLinePair.iMLinePairSetPara(iM_LinePair, AdvPairROI, Threshold, SamplingStep, IterationN, iterationTh, TransType, EdgeChoice);
                label_state.Text = err.ToString();
            }
            else if (ROIType == iROI_Type.iAdvance)
            {
                AdvROI.m_center_x = Convert.ToInt32(l_ptr[0]);
                AdvROI.m_center_y = Convert.ToInt32(l_ptr[1]);
                AdvROI.m_width = Convert.ToInt32(l_ptr[2]);
                AdvROI.m_height = Convert.ToInt32(l_ptr[3]);
                AdvROI.m_rotation_angle = Convert.ToInt32(l_ptr[4]);

                err = iMLine.iMLineSetPara(imeasureLine, AdvROI, Threshold, SamplingStep, IterationN, iterationTh, TransType, EdgeChoice);
                label_state.Text = err.ToString();
               
            }
            else if (ROIType == iROI_Type.iRectangle)
            {
                RectangleROI.m_center_x = Convert.ToInt32(l_ptr[0]);
                RectangleROI.m_center_y = Convert.ToInt32(l_ptr[1]);
                RectangleROI.m_width = Convert.ToInt32(l_ptr[2]);
                RectangleROI.m_height = Convert.ToInt32(l_ptr[3]);
                RectangleROI.m_gap = Convert.ToInt32(l_ptr[4]);
                RectangleROI.m_rotation_angle = Convert.ToInt32(l_ptr[5]);

                err = iMRectangle.iMRectangleSetPara(iM_Rectangle, RectangleROI, Threshold, SamplingStep, IterationN, iterationTh, TransType, EdgeChoice);
                label_state.Text = err.ToString();

            }
            else if (ROIType == iROI_Type.iTriAdvPair)
            {
                TriAdvPairROI.m_center_x = Convert.ToInt32(l_ptr[0]);
                TriAdvPairROI.m_center_y = Convert.ToInt32(l_ptr[1]);
                TriAdvPairROI.m_begin_width = Convert.ToInt32(l_ptr[2]);
                TriAdvPairROI.m_begin_height = Convert.ToInt32(l_ptr[3]);
                TriAdvPairROI.m_end_width = Convert.ToInt32(l_ptr[4]);
                TriAdvPairROI.m_end_height = Convert.ToInt32(l_ptr[5]);
                TriAdvPairROI.m_begin_angle = Convert.ToInt32(l_ptr[6]);
                TriAdvPairROI.m_end_angle = Convert.ToInt32(l_ptr[7]);
                TriAdvPairROI.m_begin_radius = Convert.ToInt32(l_ptr[8]);
                TriAdvPairROI.m_end_radius = Convert.ToInt32(l_ptr[9]);

                err = iMTriangle.iMTriangleSetPara(iM_Triangle, TriAdvPairROI, Threshold, SamplingStep, IterationN, iterationTh, TransType, EdgeChoice);
                label_state.Text = err.ToString();       

            }


            txt_degree.Text = " ";
            txt_dis.Text = " ";
            txt_CP.Text = " ";
            txt_hei.Text = " ";
            txt_wid.Text = " ";
           
            
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            AdvROI.m_center_x = 200;
            AdvROI.m_center_y = 200;
            AdvROI.m_width = 50;
            AdvROI.m_height = 50;
            AdvROI.m_rotation_angle = 20;

            g_err = iROI.iROIAddAdvanceROI(RefMain.ROIManager, AdvROI);     

            iROI.iROIPlot(RefMain.ROIManager, RefMain.hDC);
            label_state.Text = g_err.ToString();
            //RefMain.pictureBox1.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //RefMain.pictureBox1.Refresh();
            Graphics g = RefMain.pictureBox1.CreateGraphics();
            double width = 0;
            double Execute_time = 0;

            if (QueryPerformanceCounter(ref ctr1) != 0)
            {
                g_err = iMLinePair.iMeasure_LinePair(iM_LinePair, RefMain.GrayImg);
                QueryPerformanceCounter(ref ctr2);
                Execute_time = (ctr2 - ctr1) * 1000.0 / freq;
            }

            label_state.Text = g_err.ToString();

            iLine_Measured l_line_results = new iLine_Measured();
            iLine_Measured l_line_results2 = new iLine_Measured();

            width = iMLinePair.iMLinePair_GetResults(iM_LinePair, ref l_line_results, ref l_line_results2);
            //iMLinePair.iDrawMeasure_LinePair(iM_LinePair, RefMain.GrayImg, RefMain.hDC);

            Int32 l_num = 0;
            iMLinePair.iMLinePair_GetNumofFeatures(iM_LinePair, ref l_num);

            iDPoint[] l_features = new iDPoint[l_num];
            iMLinePair.iMLinePair_GetFeatures(iM_LinePair, ref  l_features[0]);

            for (int i = 0; i < l_num; i++)
               // if (l_flag[i] == 1)
                    g.DrawRectangle(new Pen(Color.Red), (int)l_features[i].x, (int)l_features[i].y, 1, 1);

            //結果輸出

            txt_iLineTime.Text = Execute_time.ToString("f3");
            txt_dis.Text = width.ToString("F2");


        }

        private void button6_Click(object sender, EventArgs e)
        {
            //RefMain.pictureBox1.Refresh();
            Graphics g = RefMain.pictureBox1.CreateGraphics();
            iLine_Measured Results = new iLine_Measured();
            double Execute_time = 0;

            if (QueryPerformanceCounter(ref ctr1) != 0)
            {
                g_err = iMLine.iMeasure_Line(imeasureLine, RefMain.GrayImg);
                QueryPerformanceCounter(ref ctr2);
                Execute_time = (ctr2 - ctr1) * 1000.0 / freq;
            }
            label_state.Text = g_err.ToString();

            E_iVision_ERRORS ERR = iMLine.iMLine_GetResults(imeasureLine, ref Results);

            int l_num = 0;
            iMLine.iMLine_GetNumofFeatures(imeasureLine, ref l_num);
            iDPoint[] l_features = new iDPoint[l_num];
            iMLine.iMLine_GetFeatures(imeasureLine, ref l_features[0]);


            iMLine.iDrawMeasure_Line(imeasureLine, RefMain.GrayImg, RefMain.hDC, 1);

            for (int i = 0; i < l_num; i++)
                //if (l_flag[i] == 1)
                g.DrawRectangle(new Pen(Color.Blue), (int)l_features[i].x, (int)l_features[i].y, 1, 1);

            //結果輸出
            txt_iLineResultA.Text = Results.A.ToString();
            txt_iLineResultB.Text = Results.B.ToString();
            txt_iLineResultC.Text = Results.C.ToString();
            txt_iLineResultP1.Text = "(" + Results.p1.x.ToString() + "," + Results.p1.y.ToString() + ")";
            txt_iLineResultP2.Text = "(" + Results.p2.x.ToString() + "," + Results.p2.y.ToString() + ")";

            txt_iLineTime.Text = Execute_time.ToString("f3");
            List<float> distance = new List<float>();
            List<iDPoint> puntos = new List<iDPoint>();
            if (ERR == E_iVision_ERRORS.E_OK)
            {
                for (int i = 0; i < l_num; i++)
                {
                    if (l_features[i].x != 0 && l_features[i].y != 0)
                    {
                        distance.Add((float)distanceLinePoint(l_features[i], Results.A, Results.B, -Results.C));
                        puntos.Add(l_features[i]);
                    }
                }
        
            }
            Debug.WriteLine($"Min {distance.Min()} Max {distance.Max()}");

            var distAndPoints = distance.Zip(puntos, (d, p) => new { Distance = d, Pointss = p });
            //Graphics m_Drawg = null;
            List<iDPoint> closePoints = new List<iDPoint>();
            List<double> closeDistance= new List<double>();
            //  m_Drawg = RefMain.pictureBox1.CreateGraphics();
            using (Graphics m_Drawg = RefMain.pictureBox1.CreateGraphics())
            {
                foreach (var dp in distAndPoints)
                {
                if (dp.Distance <= ((distance.Max() + distance.Min())/2  - (((distance.Max() + distance.Min())/2)*Convert.ToInt32(tbnum.Text)/100)))
                {

                    if (dp.Pointss.x != 0 && dp.Pointss.y != 0 && dp.Pointss.x < 480 - 10)
                    {
                        closePoints.Add(dp.Pointss);
                        closeDistance.Add(dp.Distance);
                        int x = (int)dp.Pointss.x;
                        int y = (int)dp.Pointss.y;
                        m_Drawg.DrawRectangle(new Pen(Color.Yellow), (int)dp.Pointss.x, (int)dp.Pointss.y, 1, 1);
                            //   m_Drawg.FillRectangle(Brushes.Red, x, y, 1, 1);
                        }
                    }      
                    
                }
            }
            iDPoint middlePoint;
            if (closePoints.Count > 3)
            {
                int number = closePoints.Count;
                int middle = number / 2;
                middlePoint = closePoints.ElementAt(middle);
                using (Graphics m_Drawg = RefMain.pictureBox1.CreateGraphics())
                {
                    m_Drawg.DrawRectangle(new Pen(Color.Green), (int)middlePoint.x, (int)middlePoint.y, 10, 10);
                }
           }

        }
        public double distanceLinePoint(iDPoint point, double A , double B, double C)
        {
            double distance = 0;
            distance = Math.Abs(A * point.x + B * point.y + C) / (Math.Sqrt(A * A + B * B));
            return Math.Abs(distance);
        }

        private void iLineForm_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            g_err = iROI.iROIAttached(RefMain.ROIManager, RefMain.GrayImg, RefMain.hDC);
            label_state.Text = g_err.ToString();

            iROI.iROIPlot(RefMain.ROIManager, RefMain.hDC);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            g_err = iROI.iROIDeleteROI(RefMain.ROIManager);
            label_state.Text = g_err.ToString();
            iROI.iROIPlot(RefMain.ROIManager, RefMain.hDC);
        }

        private void btn_RectangleROI_Click(object sender, EventArgs e)
        {
            RectangleROI.m_center_x = 200;
            RectangleROI.m_center_y = 200;
            RectangleROI.m_width = 100;
            RectangleROI.m_height = 100;
            RectangleROI.m_gap = 20;
            RectangleROI.m_rotation_angle = 0;

            g_err = iROI.iROIAddRectangleROI(RefMain.ROIManager, RectangleROI);

            label_state.Text = g_err.ToString();
            iROI.iROIPlot(RefMain.ROIManager, RefMain.hDC);

           
        }

        private void btn_RectangleMeasure_Click(object sender, EventArgs e)
        {
            RefMain.pictureBox1.Refresh();
            Graphics g = RefMain.pictureBox1.CreateGraphics();

             E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;
            double Execute_time = 0;
            if (QueryPerformanceCounter(ref ctr1) != 0)
            {
                g_err = iMRectangle.iMeasure_Rectangle(iM_Rectangle, RefMain.GrayImg);
                QueryPerformanceCounter(ref ctr2);
                Execute_time = (ctr2 - ctr1) * 1000.0 / freq;
            }
            txt_iLineTime.Text = Execute_time.ToString("f3");

            label_state.Text = g_err.ToString();


            int l_num = 0;
            iRectangle_Measured l_results = new iRectangle_Measured();
            iMRectangle.iMRectangle_GetNumofFeatures(iM_Rectangle, ref l_num);
            iMRectangle.iMRectangle_GetResults(iM_Rectangle, ref l_results);
            txt_wid.Text = l_results.width.ToString("F2");
            txt_hei.Text = l_results.height.ToString("F2");
            txt_degree.Text = l_results.angle.ToString("F2");
            txt_CP.Text = "(" + l_results.cp.x.ToString() + "," + l_results.cp.y.ToString() + ")";
            //iMRectangle.iDrawMeasure_Rectangle(iM_Rectangle, RefMain.GrayImg, RefMain.hDC);

            iMRectangle.iMRectangle_GetNumofFeatures(iM_Rectangle, ref l_num);

            iDPoint[] l_features = new iDPoint[l_num];
            iMRectangle.iMRectangle_GetFeatures(iM_Rectangle, ref  l_features[0]);

            for (int i = 0; i < l_num; i++)
                    g.DrawRectangle(new Pen(Color.Red), (int)l_features[i].x, (int)l_features[i].y, 1, 1);
        }

        private void button9_Click(object sender, EventArgs e)
        {

            TriAdvPairROI.m_center_x = 200;
            TriAdvPairROI.m_center_y = 200;
            TriAdvPairROI.m_begin_width = 80;
            TriAdvPairROI.m_begin_height = 50;
            TriAdvPairROI.m_end_width = 80;
            TriAdvPairROI.m_end_height = 50;
            TriAdvPairROI.m_begin_angle = 0;
            TriAdvPairROI.m_end_angle = 90;
            TriAdvPairROI.m_begin_radius = 80;
            TriAdvPairROI.m_end_radius = 80;


            g_err = iROI.iROIAddTriAdvPairROI(RefMain.ROIManager, TriAdvPairROI);

            label_state.Text = g_err.ToString();
            iROI.iROIPlot(RefMain.ROIManager, RefMain.hDC);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //RefMain.pictureBox1.Refresh();
            Graphics g = RefMain.pictureBox1.CreateGraphics();
            iTriangle_Measured l_results = new iTriangle_Measured();
            E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;
            double Execute_time = 0;

            if (QueryPerformanceCounter(ref ctr1) != 0)
            {
                g_err = iMTriangle.iMeasure_Triangle(iM_Triangle, RefMain.GrayImg);
                QueryPerformanceCounter(ref ctr2);
                Execute_time = (ctr2 - ctr1) * 1000.0 / freq;
            }
            txt_iLineTime.Text = Execute_time.ToString("f3");
            label_state.Text = g_err.ToString();

            iMTriangle.iMTriangle_GetResults(iM_Triangle, ref l_results);

            txt_degree.Text = l_results.angle.ToString("f2");
            txt_CP.Text = "(" + l_results.crosspoint.x.ToString("0.00") + "，" + l_results.crosspoint.y.ToString("0.00") + ")";

            g.DrawLine(new Pen(Color.Red), l_results.crosspoint.x - 10, l_results.crosspoint.y, l_results.crosspoint.x + 10, l_results.crosspoint.y);
            g.DrawLine(new Pen(Color.Red), l_results.crosspoint.x, l_results.crosspoint.y - 10, l_results.crosspoint.x , l_results.crosspoint.y + 10);


            int l_num = 0;
                iMTriangle.iMTriangle_GetNumofFeatures(iM_Triangle, ref l_num);
            iDPoint[] l_features = new iDPoint[l_num];
            iMTriangle.iMTriangle_GetFeatures(iM_Triangle, ref  l_features[0]);

            for (int i = 0; i < l_num; i++)
                    g.DrawRectangle(new Pen(Color.Red), (int)l_features[i].x, (int)l_features[i].y, 1, 1);
        }
   
         private void iLineForm_FormClosing(object sender, FormClosingEventArgs e)
         {
             if (iM_Rectangle != null)
                 iMRectangle.DestroyiMRectangle(iM_Rectangle);
         }

         private void btn_AddLinePair_Click(object sender, EventArgs e)
         {          
              AdvPairROI.m_center_x = 200;
              AdvPairROI.m_center_y = 200;
              AdvPairROI.m_advPair_width_1 = 80;
              AdvPairROI.m_advPair_width_2 = 80;
              AdvPairROI.m_width_1 = 50;
              AdvPairROI.m_height_1 = 50;
              AdvPairROI.m_width_2 = 50;
              AdvPairROI.m_height_2 = 50;
              AdvPairROI.m_rotation_angle = 0;

              g_err = iROI.iROIAddAdvPairROI(RefMain.ROIManager, AdvPairROI);

              label_state.Text = g_err.ToString();
              iROI.iROIPlot(RefMain.ROIManager, RefMain.hDC);
        
         }

       

         

       
       
    }
}
