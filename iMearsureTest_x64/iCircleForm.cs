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
using System.Diagnostics;

namespace iMearsureTest
{
    public partial class iCircleForm : Form
    {
        [DllImport("kernel32.dll")]
        extern static short QueryPerformanceCounter(ref long x);
        [DllImport("kernel32.dll")]
        extern static short QueryPerformanceFrequency(ref long x);
        long ctr1 = 0, ctr2 = 0, freq = 0;

        public MainForm RefMain;

        iRingROI RingROI;
        iAdvRingROI AdvRingROI;

        public Int32 DefSampling = 360, DefIterationN = 100, DefIterTh = 4, DefEdgeChoice = 2, DefTransType = 2;
        public Int32 Sampling, IterationN, EdgeChoice, TransType, StartAngle = 0, EndAngle = 360;
        public Int32 Threshold, DefThreshold = 10;
        public double iterationTh;
        public IntPtr imeasure;
        public IntPtr iMeasure1_C2C;
        public IntPtr iMeasure2_C2C;
        E_iVision_ERRORS g_err;

        public Boolean AdvRingCheck = false;

        Pen GreenPen = new Pen(Color.Green);
        Pen RedPen = new Pen(Color.Red);

        iCircle_Measured g_Results1 = new iCircle_Measured();
        iCircle_Measured g_Results2 = new iCircle_Measured();
        public struct PointDistance
        {
            public List<Point> points;
            public List<double> distance;


        }
        private void button2_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// tools for printing in real Time thread
            /// </summary>
            Image m_Drawimg = null;
            Bitmap m_Drawbmp = null;
            Graphics m_Drawg = null;

            m_Drawbmp = Image.FromHbitmap(RefMain.hbitmap);
            m_Drawg = RefMain.pictureBox1.CreateGraphics();

            iDPoint[] resultPoints = new iDPoint[360];

            //CircleManager.GetFeaturesCircle(ref resultPoints[0]);
            iMCircle.iMCircle_GetFeatures(imeasure, ref resultPoints[0]);

            Point[] points = new Point[360];
            double[] slope = new double[360];
            int j = 0;
            int skip = 10;
            int[] signs = new int[360];
            bool change = false;
            Point[] slPoints = new Point[360]; ;
            for (int i = 0; i < points.Length; i++)
            {
                if (resultPoints[i].x != 0 && resultPoints[i].y != 0)
                {
                    points[j].X = Convert.ToInt32(resultPoints[i].x * RefMain.scale);
                    points[j].Y = Convert.ToInt32(resultPoints[i].y * RefMain.scale);
                    if (j>skip)
                    {
                        if ((points[j].X - points[j - skip].X)==0)
                        {
                            slope[j - skip] = Math.Sign(slope[j - skip-1])* 9999999999;
                        }
                        else
                        {
                            slope[j - skip] = (double)(points[j].Y - points[j - skip].Y) / (double)(points[j].X - points[j - skip].X);
                            slPoints[j]=points[j];
                            dgslope.Rows.Add(i, slope[i]);
                        }
                        

                    }
                    j++;
                }
            }
            dgslope.Rows.Clear();
            int[] slopeChangeIndex = new int[10];
            int k = 0;
            for (int i = 0; i < slope.Length; i++)
            {
                dgslope.Rows.Add(i,slope[i],points[i].X.ToString());
                if (i>1)
                {
                    if (Math.Sign(slope[i-1]) != Math.Sign(slope[i]))
                    {
                        change = true;
                        Debug.WriteLine($"slope : {slope[i - 1]} slope +1 :{slope[i]} point[i] {slPoints[i]} point[i-1] {slPoints[i - 1]}");
                        slopeChangeIndex[k] = i;
                        k++;
                    }
                }
            }
             
            using (m_Drawg)
            {
                Pen myPen = new Pen(Color.Violet);
                

                myPen.Width = 2;
                for (int i = 0; i < slopeChangeIndex.Length; i++)
                {
                    m_Drawg.FillRectangle(Brushes.Red ,points[slopeChangeIndex[i]].X, points[slopeChangeIndex[i]].Y,10,10);
                }
                //m_Drawg.DrawLines(myPen, points);
                
                m_Drawg.DrawCurve(myPen, points.Take(100).ToArray());
                myPen.Color = Color.BlueViolet;
                m_Drawg.DrawCurve(myPen, points.Skip(100).ToArray());
            }
            //////////////////////////////////////////
            ///
            iCircle_Measured Results = new iCircle_Measured();
            //CircleManager.GetResultsCircle(ref Results);
            iMCircle.iMCircle_GetResults(imeasure, ref Results);
            double distance = 0.0;

            PointDistance resultsDistance = new PointDistance();
            resultsDistance.points = new List<Point>();
            resultsDistance.distance = new List<double>();
            for (int i = 0; i < points.Length; i++)
            {
                DistanceFromCenterToPoint(Results, points[i], ref distance);
                resultsDistance.points.Add(points[i]);
                resultsDistance.distance.Add(distance);
            }
            double minVal = resultsDistance.distance.Min();
            int index = resultsDistance.distance.IndexOf(resultsDistance.distance.Min());
            Point minPoint = resultsDistance.points.ElementAt(index);

            /////// draw  the line 
            ///
            m_Drawg = RefMain.pictureBox1.CreateGraphics();
            using (m_Drawg)
            {
                Pen newPen = new Pen(Color.Red);
                newPen.Width = 2;
                m_Drawg.DrawLine(newPen, Convert.ToInt32(Results.Cp.x * RefMain.scale), Convert.ToInt32(Results.Cp.y * RefMain.scale), minPoint.X, minPoint.Y);
                // m_Drawg.DrawLine(newPen,323,209,342,214);
            }
        }


        private void DistanceFromCenterToPoint(iCircle_Measured Results, Point points, ref double a_Distance)
        {
            a_Distance = Math.Sqrt((Results.Cp.x - points.X) * (Results.Cp.x - points.X) + (Results.Cp.y - points.Y) * (Results.Cp.y - points.Y));

        }

        public iCircleForm()
        {
            InitializeComponent();
            txt_iterationN.Text = DefIterationN.ToString();
            txt_SampingPoints.Text = DefSampling.ToString();
            txt_Threshold.Text = DefThreshold.ToString();
            txt_IterThreshold.Text = DefIterTh.ToString();
            txt_EdgeChoice.Text = DefEdgeChoice.ToString();
            txt_Transition.Text = DefTransType.ToString();
            txt_StartAngle.Text = StartAngle.ToString();
            txt_EndAngle.Text = EndAngle.ToString();

            Threshold = DefThreshold;
            Sampling = DefSampling;
            IterationN = DefIterationN;
            iterationTh = DefIterTh;
            EdgeChoice = DefEdgeChoice;
            TransType = DefTransType;

            txt_ResultCx.Text = "0";
            txt_ResultCy.Text = "0";
            txt_ResultR.Text = "0";
            
            imeasure = iMCircle.CreateiMCircle();
            iMeasure1_C2C = iMCircle.CreateiMCircle();
            iMeasure2_C2C = iMCircle.CreateiMCircle();

            QueryPerformanceFrequency(ref freq);
        }


        private void btn_LoadImg_Click(object sender, EventArgs e)
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
                    if (RefMain.pictureBox1.Image != null)
                        RefMain.pictureBox1.Image.Dispose();
                    RefMain.pictureBox1.Image = System.Drawing.Image.FromHbitmap(RefMain.hbitmap);
                    RefMain.g = RefMain.pictureBox1.CreateGraphics();
                    RefMain.hDC = RefMain.g.GetHdc();
                    RefMain.pictureBox1.Refresh();

                    iROI.iROIAttached(RefMain.ROIManager, RefMain.GrayImg, RefMain.hDC);
                    iROI.iROIPlot(RefMain.ROIManager, RefMain.hDC);
                    label_State.Text = g_err.ToString();
                }
                else
                {
                    MessageBox.Show(err.ToString(), "Error");
                }
            }
        }

        private void btn_SetRingROI_Click(object sender, EventArgs e)
        {

            RingROI.m_center_x = 60;
            RingROI.m_center_y = 60;
            RingROI.m_gap = 20;
            RingROI.m_radius = 50;
            g_err = iROI.iROIAddRingROI(RefMain.ROIManager, RingROI);
           
            label_State.Text = g_err.ToString();
            iROI.iROIPlot(RefMain.ROIManager, RefMain.hDC);
        }

        private void UpdateMeasurePata()
        {
            Threshold = Convert.ToInt32(txt_Threshold.Text);
            Sampling = Convert.ToInt32(txt_SampingPoints.Text);
            IterationN = Convert.ToInt32(txt_iterationN.Text);
            iterationTh = Convert.ToDouble(txt_IterThreshold.Text);
            StartAngle = Convert.ToInt32(txt_StartAngle.Text);
            EndAngle = Convert.ToInt32(txt_EndAngle.Text);
            EdgeChoice = Convert.ToInt32(txt_EdgeChoice.Text);
            TransType = Convert.ToInt32(txt_Transition.Text);

        }

        private void btn_SetParaiM_Click(object sender, EventArgs e)
        {
            UpdateMeasurePata();
            iROI_Type ROIType;

             E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;
           

            double[] l_ptr = new double[10];
          

            ROIType = iROI.iROIGetInfo(RefMain.ROIManager, ref l_ptr[0]);
            if (ROIType == iROI_Type.iRing)
            {
                AdvRingCheck = false;

                RingROI.m_center_x = Convert.ToInt32(l_ptr[0]);
                RingROI.m_center_y = Convert.ToInt32(l_ptr[1]);
                RingROI.m_gap = Convert.ToInt32(l_ptr[2]);
                RingROI.m_radius = Convert.ToInt32(l_ptr[3]);

                g_err = iMCircle.iMCircleSetPara2(imeasure, RingROI, Threshold, Sampling, IterationN, iterationTh, TransType, EdgeChoice);
                label_State.Text = g_err.ToString();
                
            }
            else if (ROIType == iROI_Type.iAdvRing)
            {
                AdvRingCheck = true;

                AdvRingROI.m_center_x = Convert.ToInt32(l_ptr[0]);
                AdvRingROI.m_center_y = Convert.ToInt32(l_ptr[1]);
                AdvRingROI.m_ring_gap = Convert.ToInt32(l_ptr[2]);
                AdvRingROI.m_begin_angle = l_ptr[3];
                AdvRingROI.m_end_angle = l_ptr[4];
                AdvRingROI.m_radius = l_ptr[5];

                g_err = iMCircle.iMCircleSetPara(imeasure, AdvRingROI, Threshold, Sampling, IterationN, iterationTh, TransType, EdgeChoice);
                label_State.Text = g_err.ToString();
                
            }
               
            
        }

        private void btn_Measurement_Click(object sender, EventArgs e)
        {
            //RefMain.pictureBox1.Refresh();
            Graphics g = RefMain.pictureBox1.CreateGraphics();
            iCircle_Measured Results = new iCircle_Measured();

            double Execute_time = 0;
            E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;

            if (QueryPerformanceCounter(ref ctr1) != 0) //question
            {
                err = iMCircle.iMeasure_Circle(imeasure, RefMain.GrayImg);
                QueryPerformanceCounter(ref ctr2);
                Execute_time = (ctr2 - ctr1) * 1000.0 / freq;
            }
            

            iDPoint[] features = new iDPoint[Sampling];

            err = iMCircle.iMCircle_GetFeatures(imeasure, ref features[0]); // question
            if (err != E_iVision_ERRORS.E_OK)
            {
                MessageBox.Show(err.ToString(), "Error");
                return;
            }

            //for (int i = 0; i < Sampling; i++)
            //{
            //    g.DrawEllipse(RedPen, (int)features[i].x, (int)features[i].y, 1, 1);
            //}

            if (err != E_iVision_ERRORS.E_FAILED)
            {
                double N_Roundness = 0;

                iMCircle.iMCircle_GetResults(imeasure, ref Results);

                N_Roundness = 100 * (Results.Diameter/2 - Results.Roundness) / (Results.Diameter/2);

                double l_Diameter = Results.Diameter / 2;
                //結果輸出
                label_State.Text = err.ToString();
                txt_ResultCx.Text = double.IsNaN(Results.Cp.x) ? "0" : Results.Cp.x.ToString();
                txt_ResultCy.Text = double.IsNaN(Results.Cp.y) ? "0" : Results.Cp.y.ToString();
                txt_ResultR.Text = double.IsNaN(l_Diameter) ? "0" : l_Diameter.ToString();
                txt_Roundness.Text = double.IsNaN(Results.Roundness) ? "0" : Results.Roundness.ToString();
                txt_Roundness_per.Text = double.IsNaN(N_Roundness) ? "0" : N_Roundness.ToString();
                txt_PL_Difference.Text = double.IsNaN(Results.PL_Difference) ? "0" : Results.PL_Difference.ToString();
                txt_Time.Text = Execute_time.ToString("f3");

                if (double.IsNaN(Results.Cp.x) == true)
                    return;
                //g.DrawEllipse(GreenPen, Convert.ToInt32(Results.Cp.x - Results.Radius), Convert.ToInt32(Results.Cp.y - Results.Radius), Convert.ToInt32(Results.Radius * 2), Convert.ToInt32(Results.Radius * 2));
                //g.DrawLine(GreenPen, Convert.ToInt32(Results.Cp.x - 10), Convert.ToInt32(Results.Cp.y), Convert.ToInt32(Results.Cp.x + 10), Convert.ToInt32(Results.Cp.y));
                //g.DrawLine(GreenPen, Convert.ToInt32(Results.Cp.x), Convert.ToInt32(Results.Cp.y - 10), Convert.ToInt32(Results.Cp.x), Convert.ToInt32(Results.Cp.y + 10));

                iMCircle.iDrawMeasure_Circle(imeasure, RefMain.GrayImg, RefMain.hDC,1);
                //if (!AdvRingCheck)
                //{
                //    g.DrawEllipse(RedPen, Convert.ToInt32(RingROI.m_center_x - (RingROI.m_radius - RingROI.m_width)), Convert.ToInt32(RingROI.m_center_y - (RingROI.m_radius - RingROI.m_width)), Convert.ToInt32((RingROI.m_radius - RingROI.m_width) * 2), Convert.ToInt32((RingROI.m_radius - RingROI.m_width) * 2));
                //    g.DrawEllipse(RedPen, Convert.ToInt32(RingROI.m_center_x - (RingROI.m_radius + RingROI.m_width)), Convert.ToInt32(RingROI.m_center_y - (RingROI.m_radius + RingROI.m_width)), Convert.ToInt32((RingROI.m_radius + RingROI.m_width) * 2), Convert.ToInt32((RingROI.m_radius + RingROI.m_width) * 2));
                //}
            }
            else
            {
                txt_ResultCx.Text = "0";
                txt_ResultCy.Text = "0";
                txt_ResultR.Text = "0";
                txt_Time.Text = Execute_time.ToString("f3");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            E_iVision_ERRORS err = iMCircle.iVisitingKey();
            MessageBox.Show(err.ToString(), "Error");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            g_err = iROI.iROIAttached(RefMain.ROIManager, RefMain.GrayImg, RefMain.hDC);

            label_State.Text = g_err.ToString();
            iROI.iROIPlot(RefMain.ROIManager, RefMain.hDC);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            g_err = iROI.iROIDeleteROI(RefMain.ROIManager);
            label_State.Text = g_err.ToString();
            iROI.iROIPlot(RefMain.ROIManager, RefMain.hDC);
        }

        private void btn_AdvRing_Click(object sender, EventArgs e)
        {
            AdvRingROI.m_center_x = 200;
            AdvRingROI.m_center_y = 200;
            AdvRingROI.m_begin_angle = 90;
            AdvRingROI.m_end_angle = 220;
            AdvRingROI.m_ring_gap = 80;
            AdvRingROI.m_radius = 50;
            g_err = iROI.iROIAddAdvRingROI(RefMain.ROIManager, AdvRingROI);

            label_State.Text = g_err.ToString();
            iROI.iROIPlot(RefMain.ROIManager, RefMain.hDC);
        }

        private void btn_Set1_Click(object sender, EventArgs e)
        {
            UpdateMeasurePata();
            iROI_Type ROIType;

            E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;


            double[] l_ptr = new double[10];


            ROIType = iROI.iROIGetInfo(RefMain.ROIManager, ref l_ptr[0]);
            if (ROIType == iROI_Type.iRing)
            {
                AdvRingCheck = false;

                RingROI.m_center_x = Convert.ToInt32(l_ptr[0]);
                RingROI.m_center_y = Convert.ToInt32(l_ptr[1]);
                RingROI.m_gap = Convert.ToInt32(l_ptr[2]);
                RingROI.m_radius = Convert.ToInt32(l_ptr[3]);


                g_err = iMCircle.iMCircleSetPara2(iMeasure1_C2C, RingROI, Threshold, Sampling, IterationN, iterationTh, TransType, EdgeChoice);
                label_State.Text = g_err.ToString();

            }
            else if (ROIType == iROI_Type.iAdvRing)
            {
                AdvRingCheck = true;

                AdvRingROI.m_center_x = Convert.ToInt32(l_ptr[0]);
                AdvRingROI.m_center_y = Convert.ToInt32(l_ptr[1]);
                AdvRingROI.m_ring_gap = Convert.ToInt32(l_ptr[2]);
                AdvRingROI.m_begin_angle = l_ptr[3];
                AdvRingROI.m_end_angle = l_ptr[4];
                AdvRingROI.m_radius = l_ptr[5];

                g_err = iMCircle.iMCircleSetPara(iMeasure1_C2C, AdvRingROI, Threshold, Sampling, IterationN, iterationTh, TransType, EdgeChoice);
                label_State.Text = g_err.ToString();

            }
        }

        private void btn_Set2_Click(object sender, EventArgs e)
        {
            UpdateMeasurePata();
            iROI_Type ROIType;

            E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;


            double[] l_ptr = new double[10];


            ROIType = iROI.iROIGetInfo(RefMain.ROIManager, ref l_ptr[0]);
            if (ROIType == iROI_Type.iRing)
            {
                AdvRingCheck = false;

                RingROI.m_center_x = Convert.ToInt32(l_ptr[0]);
                RingROI.m_center_y = Convert.ToInt32(l_ptr[1]);
                RingROI.m_gap = Convert.ToInt32(l_ptr[2]);
                RingROI.m_radius = Convert.ToInt32(l_ptr[3]);


                g_err = iMCircle.iMCircleSetPara2(iMeasure2_C2C, RingROI, Threshold, Sampling, IterationN, iterationTh, TransType, EdgeChoice);
                label_State.Text = g_err.ToString();

            }
            else if (ROIType == iROI_Type.iAdvRing)
            {
                AdvRingCheck = true;

                AdvRingROI.m_center_x = Convert.ToInt32(l_ptr[0]);
                AdvRingROI.m_center_y = Convert.ToInt32(l_ptr[1]);
                AdvRingROI.m_ring_gap = Convert.ToInt32(l_ptr[2]);
                AdvRingROI.m_begin_angle = l_ptr[3];
                AdvRingROI.m_end_angle = l_ptr[4];
                AdvRingROI.m_radius = l_ptr[5];

                g_err = iMCircle.iMCircleSetPara(iMeasure2_C2C, AdvRingROI, Threshold, Sampling, IterationN, iterationTh, TransType, EdgeChoice);
                label_State.Text = g_err.ToString();

            }
        }

       
        
       
        
    }
}
