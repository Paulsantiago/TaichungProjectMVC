using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;
//using MiM_iVision;
using System.Diagnostics;

using MVC_ModelLibrary.MVC_Managers;
using MVC.Vision.MiM;



namespace Warp_Csharp
{
    public partial class DemoDialog :Form 
    {
        [DllImport("kernel32.dll")]
        extern static short QueryPerformanceCounter(ref long x);
        [DllImport("kernel32.dll")]
        extern static short QueryPerformanceFrequency(ref long x);

        long ctr1 = 0, ctr2 = 0, freq = 0;


        Stopwatch sw = new Stopwatch();

        public Mainfrm refMain;
        string path;
        Graphics g_Results;
        bool IsUsingImageProcessing = false;

        #region variable for measure
        public int DefSampling = 360, DefIterationN = 100, DefIterTh = 4, DefEdgeChoice = 1, DefTransType = 2;
        public int Sampling, IterationN, EdgeChoice, TransType, StartAngle = 0, EndAngle = 360;
        public int Threshold, DefThreshold = 10;
        public double iterationTh;
        public MVC_MeasureCircleManager CircleManager;
        public MVC_MeasureLineManager LineManager;
        CircleParameters circleParameters;
        iCircle_Measured[] CircleResults = new iCircle_Measured[1];
        #endregion

        #region variable for matching
        public MVC_ROIManager ROIIPCircleManager;
        public MVC_ROIManager ROIIPLineManager;
        public MVC_ROIManager ROIMatchingManager;
        public MVC_ROIManager ROINoIPCircleMeasureManager;
        public MVC_MatchManager MatchingManager;
        
        
        public bool isColor { get; set; }
        MatchParameters MParameters;
        private NCCFind objfind;
        internal MVC_ROIManager ROINoIPLineMeasureManager;
        private bool b_testing = false;

        #endregion




        public DemoDialog( Mainfrm mainForm)
        {
            refMain = mainForm;
            InitializeComponent();

            MatchingManager = new MVC_MatchManager();
            CircleManager = new MVC_MeasureCircleManager();
            LineManager = new MVC_MeasureLineManager();
            MatchingManager.matchParameters.UsingMask = false;
            MatchingManager.matchParameters.UsingRotation = false;
            MatchingManager.matchParameters.UsingScale = false;


            #region Initial Matching
            cbx_rotation.CheckState = CheckState.Checked;
            cbx_scale.CheckState = CheckState.Unchecked;
            cbx_dontcare.CheckState = CheckState.Unchecked;

            cbx_rotation.CheckState = CheckState.Unchecked;
            cbx_scale.CheckState = CheckState.Unchecked;
            cbx_dontcare.CheckState = CheckState.Unchecked;
            /// add in case of more rpoperties needed
            //cbx_usingrobust.CheckState = CheckState.Unchecked;
            //cbx_ColorSimilarity.CheckState = CheckState.Unchecked;
            //cbx_usingsubpixel.CheckState = CheckState.Checked;

            MParameters = MatchingManager.GetMatchParameters();

            tbx_objnums.Text = MParameters.Max_objs.ToString();
            tbx_maxang.Text = MParameters.MaxAng.ToString();
            tbx_minang.Text = MParameters.MinAng.ToString();
            tbx_maxscale.Text = MParameters.MaxScale.ToString();
            tbx_minscale.Text = MParameters.MinScale.ToString();
            tbx_minscore.Text = MParameters.MinScore.ToString();
            tbx_dontcarethreshold.Text = MParameters.DontCarevalue.ToString();
            tbx_MinReduceArea.Text = MParameters.MinReduceArea.ToString();
            //tbx_sensitivy.Text = MParameters.ColorSensitivy.ToString();
            tbx_FinalReduction.Text = MParameters.FinalReduction.ToString();
            #endregion



            #region Initial Measure
            txt_iterationN.Text = DefIterationN.ToString();
            txt_SampingPoints.Text = DefSampling.ToString();
            txt_Threshold.Text = DefThreshold.ToString();
            txt_IterThreshold.Text = DefIterTh.ToString();
            txt_EdgeChoice.Text = DefEdgeChoice.ToString();
            txt_StartAngle.Text = StartAngle.ToString();
            txt_EndAngle.Text = EndAngle.ToString();
            txt_Transition.Text = DefTransType.ToString();

            txbLineThreshold.Text = Convert.ToString(10);
            txbSamplePoints.Text = Convert.ToString(3);
            txbIteration.Text = Convert.ToString(100);
            txbIterationTH.Text = Convert.ToString(3);
            txbEdgeChoise.Text = Convert.ToString(2);
            txbTransitionType.Text = Convert.ToString(2);

            Threshold = DefThreshold;
            Sampling = DefSampling;
            IterationN = DefIterationN;
            iterationTh = DefIterTh;
            EdgeChoice = DefEdgeChoice;
            TransType = DefTransType;
            #endregion

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cbImageP.Checked)
            {
                ROIIPCircleManager.DeleteROIfromImage();
            }
            else
            {
                ROINoIPCircleMeasureManager.DeleteROIfromImage();
            }
        }
        public struct PointDistance
        {
            public List<Point> points ;
            public List<double> distance;
          

        }
        private void btnFindLine_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// tools for printing in real Time thread
            /// </summary>
            Image m_Drawimg = null;
            Bitmap m_Drawbmp = null;
            Graphics m_Drawg = null;

            m_Drawbmp = Image.FromHbitmap(refMain.hbitmap);
            m_Drawg = refMain.pictureBox1.CreateGraphics();

            iDPoint[] resultPoints = new iDPoint[360];
            CircleManager.GetFeaturesCircle(ref resultPoints[0]);
            //iMCircle.iMCircle_GetFeatures(refMain.imeasure, ref resultPoints[0]);

            Point[] points = new Point[360];
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X = Convert.ToInt32(resultPoints[i].x * refMain.scale) ;
                points[i].Y = Convert.ToInt32(resultPoints[i].y * refMain.scale);
            }
            using (m_Drawg)
            {
                Pen myPen = new Pen(Color.Violet);
                myPen.Width = 2;
                
                m_Drawg.DrawLines(myPen, points );
            }
            //////////////////////////////////////////
            ///
            iCircle_Measured Results = new iCircle_Measured();
            CircleManager.GetResultsCircle(ref Results);
            //iMCircle.iMCircle_GetResults(refMain.imeasure, ref Results);
            double distance = 0.0;

            PointDistance resultsDistance = new PointDistance();
            resultsDistance.points = new List<Point>();
            resultsDistance.distance = new List<double>();
            for (int i = 0; i < points.Length; i++)
            {
                DistanceFromCenterToPoint(Results , points[i],ref distance);
                resultsDistance.points.Add(points[i]);
                resultsDistance.distance.Add(distance);
            }
            double minVal = resultsDistance.distance.Min();
            int index = resultsDistance.distance.IndexOf(resultsDistance.distance.Min());
            Point minPoint = resultsDistance.points.ElementAt(index);

            /////// draw  the line 
            ///
            m_Drawg = refMain.pictureBox1.CreateGraphics();
            using (m_Drawg)
            {
                Pen newPen = new Pen(Color.Red);
                newPen.Width = 2;
                m_Drawg.DrawLine(newPen, Convert.ToInt32(Results.Cp.x * refMain.scale), Convert.ToInt32(Results.Cp.y * refMain.scale), minPoint.X, minPoint.Y);
               // m_Drawg.DrawLine(newPen,323,209,342,214);
            }
        }




        private void DistanceFromCenterToPoint(iCircle_Measured Results, Point points,ref double a_Distance)
        {
            a_Distance = Math.Sqrt((Results.Cp.x - points.X) * (Results.Cp.x - points.X) + (Results.Cp.y - points.Y) * (Results.Cp.y - points.Y));

        }

        private void btn_Line_Click(object sender, EventArgs e)
        {
            refMain.ShowMatchingROI = false;
            refMain.ShowCircleNoIPMeasure = false;
            refMain.ShowCircleIPMeasure = false;
            E_iVision_ERRORS err = E_iVision_ERRORS.E_FAILED;
            if (cbImgProcLine.Checked)
            {
                refMain.ShowLineIPMeasure = true;

                ROIIPLineManager = new MVC_ROIManager(refMain.GetImageProcessedImg(), refMain.hDC);
                ROIIPLineManager.numROI = 1;
                ROIIPLineManager.SetDrawScale(refMain.scale);
                err = ROIIPLineManager.MVC_AddROI(ROI_types.AdvanceLine);

            }
            else
            {
                refMain.ShowLineNoIPMeasure = true;
                ROINoIPLineMeasureManager.numROI = 1;
                ROINoIPLineMeasureManager.SetDrawScale(refMain.scale);
                err = ROINoIPLineMeasureManager.MVC_AddROI(ROI_types.AdvanceLine);
            }
            label2.Text = err.ToString();
            if (err != E_iVision_ERRORS.E_OK)
            {
                MessageBox.Show(err.ToString(), "Error Adding roi line");
                label2.Text = "Error";
                return;
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            refMain.showImgProcessDlg();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cbImageP_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                refMain.showImgProcessDlg();
                IsUsingImageProcessing = true;
            }
            else
            {
                refMain.HideImgProcessDlg();
                IsUsingImageProcessing = false;
            }
            
        }

      

        private void btn_NCCtraining_Click(object sender, EventArgs e)
        {
            E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;
           
            refMain.ShowMatchingROI = true;
            refMain.ShowCircleNoIPMeasure = false;
            refMain.ShowCircleIPMeasure = false;

            if (ROIMatchingManager.ROISize() == 0)
            {
                MessageBox.Show("Select a ROI for Matching", "Error");
                return;
            }

            UpData_NCC_Parameter();

            MatchingManager.MinReduceAreaParameter = Convert.ToInt32(tbx_MinReduceArea.Text);

            MatchingManager.DontCareThresholdParameter = Convert.ToInt32(tbx_dontcarethreshold.Text);

            //MinReduceArea = Convert.ToInt32(tbx_MinReduceArea.Text);
            //err = iMatch.iSetMinReduceArea(refMain.NCCmodel, MinReduceArea);
            //MatchingManager.MinReduceAreaParameter = Convert.ToInt32(tbx_MinReduceArea.Text);
            //if (err != E_iVision_ERRORS.E_OK)
            //{ MessageBox.Show(err.ToString(), "Error"); label2.Text = "Error"; }
            //else label2.Text = "E_OK";

            //err = iMatch.iSetDontCareThreshold(refMain.NCCmodel, DontCarevalue);
            //if (err != E_iVision_ERRORS.E_OK)
            //{ MessageBox.Show(err.ToString(), "Error"); label2.Text = "Error"; }
            //else label2.Text = "E_OK";

            //iRingROI l_RingROI = new iRingROI();

            //iBaseROI l_rect = new iBaseROI();
            //double[] l_data = new double[10];
            //iROI_Type l_type = iROI.iROIGetInfo(refMain.MatchingROIToolManager, ref l_data[0]);

            //if (l_type == iROI_Type.iBase)
            //{
            //    l_rect.OrgX = Convert.ToInt32(l_data[0]);
            //    l_rect.OrgY = Convert.ToInt32(l_data[1]);
            //    l_rect.Width = Convert.ToInt32(l_data[2]);
            //    l_rect.Height = Convert.ToInt32(l_data[3]);
            //    label2.Text = err.ToString();
            //}
            //else
            //{
            //    label2.Text = "ROI type Error!";
            //    return;
            //}

            //mRect rect;
            //rect.top = l_rect.OrgY;
            //rect.down = l_rect.OrgY + l_rect.Height;
            //rect.left = l_rect.OrgX;
            //rect.right = l_rect.OrgX + l_rect.Width;
            mRect rect;
            rect = ROIMatchingManager.ConvertFromROIBaseToRect();

            refMain.CpofMatch.x = Convert.ToInt32((rect.right + rect.left) / 2.0);
            refMain.CpofMatch.y = Convert.ToInt32((rect.down + rect.top) / 2.0);
            
            err = MatchingManager.CreateModelFromROI(refMain.ImageManager.GetWorkingImage() ,rect);

            if (err != E_iVision_ERRORS.E_OK)
            { MessageBox.Show(err.ToString(), "Error"); label2.Text = "Error"; }
            else label2.Text = "E_OK";




            ////double[] l_data = new double[10];

            ////iROI_Type l_type = ROIMeasureManager.GetROIInfo(ref l_data[0]);
            //////l_type = iROI.iROIGetInfo(refMain.MeasureROIToolManager, ref l_data[0]);
            ////if (l_type == iROI_Type.iRing)
            ////{
            ////    l_RingROI.m_center_x = Convert.ToInt32(l_data[0]);
            ////    l_RingROI.m_center_y = Convert.ToInt32(l_data[1]);
            ////}
            ////else
            ////{
            ////    label2.Text = "ROI type Error!";
            ////    return;
            ////}

            ////refMain.ROIVectorCircle.x = Convert.ToInt32(l_RingROI.m_center_x - refMain.CpofMatch.x);
            ////refMain.ROIVectorCircle.y = Convert.ToInt32(l_RingROI.m_center_y - refMain.CpofMatch.y);


            ////refMain.ShowMatchingROI = refMain.ShowMeasureROI = false;
            ////ROIMatchingManager.DeleteROIfromImage();
            //////iROI.iROIDeleteAll(refMain.MatchingROIToolManager);
            ROIMatchingManager.DeleteROIfromImage();



        }

        private void cbImgProcLine_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                refMain.showImgProcessDlg();
                IsUsingImageProcessing = true;
            }
            else
            {
                refMain.HideImgProcessDlg();
                IsUsingImageProcessing = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cbImgProcLine.Checked)
            {
                if (ROIIPLineManager == null)
                {
                    MessageBox.Show("Select a ROI for Matching", "Error");
                    return;
                }
                if (ROIIPLineManager.ROISize() == 0)
                {
                    MessageBox.Show("Select a ROI for Matching", "Error");
                    return;
                }
            }
            else
            {
                if (ROINoIPLineMeasureManager == null)
                {
                    MessageBox.Show("Select a ROI for Matching", "Error");
                    return;
                }
                if (ROINoIPLineMeasureManager.ROISize() == 0)
                {
                    MessageBox.Show("Select a ROI for Matching", "Error");
                    return;
                }
            }

            E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;
            int findnum = 0;
            string[] str = new string[6];
            double Execute_time = 0;
            double t1 = 0;
            double t2 = 0;
            dataGridView1.Rows.Clear();
            refMain.pictureBox1.Refresh();

            g_Results = refMain.pictureBox1.CreateGraphics();

            iIPoint[] Cp = new iIPoint[1];
            double[] Inner = new double[1];
            double[] Outer = new double[1];
             
            iLine_Measured[] Results = new iLine_Measured[1];
            double[] N_Roundness = new double[1];
            double shiftROI_x, shiftROI_y;

            double[] rAng = new double[4];
            Point[] RegionPoint = new Point[4];

            UpData_NCC_Parameter();


            err = MatchingManager.IsPatternLearn();
            //err = iMatch.iIsPatternLearn(refMain.NCCmodel);
            if (err != E_iVision_ERRORS.E_TRUE)
            {
                MessageBox.Show(err.ToString(), "Error");
                label2.Text = "Error";
                return;
            }

            MatchingManager.SetScaleParameter(refMain.scale, refMain.scale);
            err = MatchingManager.MatchModel(refMain.ImageManager.GetWorkingImage());
            t1 = MatchingManager.calculationTime;
            if (err != E_iVision_ERRORS.E_OK)
            {
                MessageBox.Show(err.ToString(), "Error");
                label2.Text = "Error";
                return;
            }
            else
                label2.Text = E_iVision_ERRORS.E_OK.ToString();
            err = MatchingManager.GetNCCMatchNum(ref findnum);
            if (err != E_iVision_ERRORS.E_OK)
            {
                MessageBox.Show(err.ToString(), "Error");
                label2.Text = "Error";
                return;
            }
            // check vector
            iIPoint aux = new iIPoint();
            double[] ROIMeasureInfo = new double[10];
            aux = CalculateVectorBetweenMatchingAndLineROI(ROIMeasureInfo, refMain.CpofMatch);
            refMain.ROIVectorLine.x = aux.x;
            refMain.ROIVectorLine.y = aux.y;

            if (findnum != 0)
            {
                Array.Resize(ref Results, findnum);
                Array.Resize(ref N_Roundness, findnum);
                Array.Resize(ref Cp, findnum);
                Array.Resize(ref Inner, findnum);
                Array.Resize(ref Outer, findnum);

                iROI_Type ROIType;
                iAdvanceROI l_AdvvROI;
                double[] l_ptr = new double[10];
                //ROIType = iROI.iROIGetInfo(refMain.MeasureROIToolManager, ref l_ptr[0]);
                if (cbImgProcLine.Checked)
                {
                    ROIType = ROIIPLineManager.GetROIInfo(ref l_ptr[0]);
                }
                else
                {
                    ROIType = ROINoIPLineMeasureManager.GetROIInfo(ref l_ptr[0]);
                }
                if (ROIType != iROI_Type.iAdvance)
                    return;

                for (int i = 0; i < findnum; i++)
                {
                    err = MatchingManager.GetNCCMatchResultsInObjFind(i, ref objfind);
                    //err = iMatch.iGetNCCMatchResults(refMain.NCCmodel, i, ref objfind);
                    shiftROI_x = refMain.ROIVectorLine.x * Math.Cos(objfind.Angle * Math.PI / 180) + refMain.ROIVectorLine.y * Math.Sin(objfind.Angle * Math.PI / 180);
                    shiftROI_y = -refMain.ROIVectorLine.x * Math.Sin(objfind.Angle * Math.PI / 180) + refMain.ROIVectorLine.y * Math.Cos(objfind.Angle * Math.PI / 180);
                    l_AdvvROI.m_center_x = Convert.ToInt32(objfind.CX + shiftROI_x);
                    l_AdvvROI.m_center_y = Convert.ToInt32(objfind.CY + shiftROI_y);
                    l_AdvvROI.m_width = Convert.ToInt32(l_ptr[2]); //CHECK 
                    l_AdvvROI.m_height = Convert.ToInt32(l_ptr[3]);
                    l_AdvvROI.m_rotation_angle = Convert.ToInt32(l_ptr[4]);

                    E_iVision_ERRORS error=  updateLineParameters(l_AdvvROI);
                    // err = LineManager.SetParamLine(l_RingROI);
                    sw.Reset();
                    sw.Start();
                    if (cbImgProcLine.Checked)
                    {
                        err = LineManager.MeasureLine(refMain.GetImageProcessedImg());
                    }
                    else
                    {
                        err = LineManager.MeasureLine(refMain.ImageManager.GetWorkingImage());
                    }
                    sw.Stop();
                    t2 = sw.ElapsedMilliseconds;
                    label2.Text = err.ToString();
                    if (err != E_iVision_ERRORS.E_FAILED)
                    {
                        err = LineManager.GetResultsLine(ref Results[i]);
                    }
                    else
                    {
                        MessageBox.Show(err.ToString(), "Error Line Results");
                        return;
                    }
                }
                if (err != E_iVision_ERRORS.E_OK)
                {
                    MessageBox.Show(err.ToString(), "Error ");
                    return;
                }
             
                Execute_time = t1 + t2;
                txt_iLineTime.Text = Execute_time.ToString("f3");
                int l_num = 0;
                for (int i = 0; i < findnum; i++)
                {
                    MatchingManager.GetNCCMatchResultsInText(i, ref str);
                    dataGridView1.Rows.Add(str[0], str[1], str[2], str[3], str[4], str[5]);

                    LineManager.GetNumofFeaturesLine(ref l_num);
                    iDPoint[] l_features = new iDPoint[l_num];
                    LineManager.GetFeaturesLine(ref l_features[0]);
                    for (int j = 0; j < l_num; j++)
                        g_Results.DrawRectangle(new Pen(Color.Blue), (int)l_features[j].x * refMain.scale, (int)l_features[j].y * refMain.scale, 1, 1);

                    //print results 
                    txt_iLineResultA.Text = Results[i].A.ToString();
                    txt_iLineResultB.Text = Results[i].B.ToString();
                    txt_iLineResultC.Text = Results[i].C.ToString();
                    txt_iLineResultP1.Text = "(" + Results[i].p1.x.ToString() + "," + Results[i].p1.y.ToString() + ")";
                    txt_iLineResultP2.Text = "(" + Results[i].p2.x.ToString() + "," + Results[i].p2.y.ToString() + ")";

                    if (double.IsNaN(Results[i].A) == true)
                        return;

                    List<float> distance = new List<float>();
                    List<iDPoint> puntos = new List<iDPoint>();
                    /// get the distance for every point
                    for (int K = 0; K < l_num; K++)
                        {
                            if (l_features[K].x != 0 && l_features[K].y != 0)
                            {
                                distance.Add((float)distanceLinePoint(l_features[K], Results[i].A, Results[i].B, -Results[i].C));
                                puntos.Add(l_features[K]);
                            }
                        }
                    Debug.WriteLine($"Min {distance.Min()} Max {distance.Max()}");

                    var distAndPoints = distance.Zip(puntos, (d, p) => new { Distance = d, Pointss = p });
                    //
                    List<iDPoint> closePoints = new List<iDPoint>();
                    List<double> closeDistance = new List<double>();
                    //set a threshold for the close points

                    ///p.X = (float)CircleResults[0].Cp.x;
                    /// Mappint the Range of the vaklues between 0 -100
                    ///  y = (x-a)*(d-c)/(b-a) + c
                    double distThreshold = (Convert.ToInt32(tbError.Text) - 0) * ((distance.Max() - distance.Min()) / (100 - 0)) + distance.Min();

                    using (Graphics m_Drawg = refMain.pictureBox1.CreateGraphics())
                    {
                        foreach (var dp in distAndPoints)
                        {
                            if (dp.Distance <= distThreshold)
                            {
                                if (dp.Pointss.x != 0 && dp.Pointss.y != 0 && dp.Pointss.x < refMain.ImageManager.GetWidth() - 10)
                                {
                                    closePoints.Add(dp.Pointss);
                                    closeDistance.Add(dp.Distance);
                                    int x = (int)dp.Pointss.x;
                                    int y = (int)dp.Pointss.y;
                                    m_Drawg.DrawRectangle(new Pen(Color.Yellow), (int)dp.Pointss.x * refMain.scale, (int)dp.Pointss.y * refMain.scale,1, 1);
                                }
                            }
                        }
                    }
                    // get the middle Point
                    iDPoint middlePoint;
                    middlePoint.x = 0;
                    middlePoint.y = 0;
                    if (closePoints.Count > 2)
                    {
                        int number = closePoints.Count;
                        int middle = number / 2;
                        middlePoint = closePoints.ElementAt(middle);
                        using (Graphics m_Drawg = refMain.pictureBox1.CreateGraphics())
                        {
                            m_Drawg.DrawRectangle(new Pen(Color.Green), (int)middlePoint.x * refMain.scale,(int)middlePoint.y * refMain.scale, 10, 10);
                            m_Drawg.DrawLine(new Pen(Color.Red), Convert.ToInt32(CircleResults[0].Cp.x * refMain.scale), Convert.ToInt32(CircleResults[0].Cp.y * refMain.scale), Convert.ToInt32(middlePoint.x * refMain.scale), Convert.ToInt32(middlePoint.y * refMain.scale));
                        }
                    }
                    double angle = 0;
                    angle = Math.Atan2(middlePoint.y - CircleResults[0].Cp.y, middlePoint.x - CircleResults[0].Cp.x) * 180 / Math.PI + 90;
                    // draw the angles 
                    using (Graphics m_Drawg = refMain.pictureBox1.CreateGraphics())
                    {
                        m_Drawg.DrawLine(new Pen(Color.Black), Convert.ToInt32((CircleResults[0].Cp.x -20) * refMain.scale), Convert.ToInt32((CircleResults[0].Cp.y) * refMain.scale), 
                                                               Convert.ToInt32((CircleResults[0].Cp.x + 20) * refMain.scale), Convert.ToInt32((CircleResults[0].Cp.y) * refMain.scale));
                        m_Drawg.DrawLine(new Pen(Color.Black), Convert.ToInt32((CircleResults[0].Cp.x) * refMain.scale), Convert.ToInt32((CircleResults[0].Cp.y-20) * refMain.scale),
                                                               Convert.ToInt32((CircleResults[0].Cp.x) * refMain.scale), Convert.ToInt32((CircleResults[0].Cp.y +20) * refMain.scale));
                        PointF p = new PointF();
                        
                        p.X = (float)refMain.ImageManager.GetWidth() - 50 ;
                        p.Y = (float)CircleResults[0].Cp.y;
                        p.X = p.X * refMain.scale;
                        p.Y = p.Y * refMain.scale;
                        m_Drawg.DrawString("0", new Font("Arial",15), Brushes.Black, p);
                        p.X =  50;
                        p.Y = (float)CircleResults[0].Cp.y;
                        p.X = p.X * refMain.scale;
                        p.Y = p.Y * refMain.scale;
                        m_Drawg.DrawString("180", new Font("Arial", 15), Brushes.Black, p);
                        p.X = (float)CircleResults[0].Cp.x;
                        p.Y = (float)refMain.ImageManager.GetHeight()-50;
                        p.X = p.X * refMain.scale;
                        p.Y = p.Y * refMain.scale;
                        m_Drawg.DrawString("270", new Font("Arial", 15), Brushes.Black, p);
                        p.X = (float)CircleResults[0].Cp.x;
                        p.Y = 50;
                        p.X = p.X * refMain.scale;
                        p.Y = p.Y * refMain.scale;
                        m_Drawg.DrawString("90", new Font("Arial", 15), Brushes.Black, p);

                    }
                    dgLineResults.Rows.Clear();
                    str[0] = "1";
                    str[1] = middlePoint.x.ToString();
                    str[2] = middlePoint.y.ToString();
                    str[3] = angle.ToString();
                    dgLineResults.Rows.Add(str);

                }
                // print the line result 
                if (refMain.scale != 1)
                {
                    err = MatchingManager.DrawMatchResults(g_Results.GetHdc(), refMain.scale);
                    //err = iMatch.iDrawiMatchResults(refMain.NCCmodel, g_Results.GetHdc(), refMain.scale);
                }
                else
                {
                    err = MatchingManager.DrawMatchResults(g_Results.GetHdc(), 1);
                    //err = iMatch.iDrawiMatchResults(refMain.NCCmodel, g_Results.GetHdc(), 1);
                }

                refMain.ShowLineIPMeasure = refMain.ShowMatchingROI = refMain.ShowLineNoIPMeasure = false;
            }
        }


        public double distanceLinePoint(iDPoint point, double A, double B, double C)
        {
            double distance = 0;
            distance = Math.Abs(A * point.x + B * point.y + C) / (Math.Sqrt(A * A + B * B));
            return Math.Abs(distance);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            refMain.saveFileDialog1.Filter = "iMatchModel file |*.irc";
            refMain.saveFileDialog1.AddExtension = true;
            E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;

            if (refMain.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = refMain.saveFileDialog1.FileName;
                err = refMain.ImageManager.iImageIsNULL();
                if (err == E_iVision_ERRORS.E_TRUE)
                {
                    MessageBox.Show(err.ToString(), "Error");
                    label2.Text = "Error No Image Loaded";
                    return;
                }
                if (cbImageP.Checked)
                {
                    err = ROIIPCircleManager.SaveROIModel(path);
                }
                else
                {
                    err = ROINoIPCircleMeasureManager.SaveROIModel(path);
                }
                
                if (err != E_iVision_ERRORS.E_OK)
                {
                    MessageBox.Show(err.ToString(), "Error");
                    label2.Text = "Error Can't save the image";
                }
                else
                    label2.Text = "OK";

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            refMain.openFileDialog1.Filter = "iMatchModel file |*.irc";
            E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;
            if (refMain.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = refMain.openFileDialog1.FileName;
                if (cbImageP.Checked)
                {
                    err = ROIIPCircleManager.LoadROIModel(path);
                    ROIIPCircleManager.SetDrawScale(refMain.scale);
                }
                else
                {
                    err = ROINoIPCircleMeasureManager.LoadROIModel(path);
                    err=ROINoIPCircleMeasureManager.SetDrawScale(refMain.scale);
                    err=ROINoIPCircleMeasureManager.PlotModel();
                    refMain.ShowLineIPMeasure = false;
                    refMain.ShowCircleIPMeasure = false;
                    refMain.ShowCircleNoIPMeasure = true;
                    
                }

                if (err == E_iVision_ERRORS.E_OK)
                {
                    label2.Text = "OK";
                }
                else
                {
                    MessageBox.Show(err.ToString(), "Error Loading roi");
                    label2.Text = "Error";
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (cbImgProcLine.Checked)
            {
                ROIIPLineManager.DeleteROIfromImage();
            }
            else
            {
                ROINoIPLineMeasureManager.DeleteROIfromImage();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            refMain.saveFileDialog1.Filter = "iMatchModel file |*.irc";
            refMain.saveFileDialog1.AddExtension = true;
            E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;

            if (refMain.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = refMain.saveFileDialog1.FileName;
                err = refMain.ImageManager.iImageIsNULL();
                if (err == E_iVision_ERRORS.E_TRUE)
                {
                    MessageBox.Show(err.ToString(), "Error");
                    label2.Text = "Error No Image Loaded";
                    return;
                }
                if (cbImgProcLine.Checked)
                {
                    err = ROIIPLineManager.SaveROIModel(path);
                }
                else
                {
                    err = ROINoIPLineMeasureManager.SaveROIModel(path);
                }

                if (err != E_iVision_ERRORS.E_OK)
                {
                    MessageBox.Show(err.ToString(), "Error");
                    label2.Text = "Error Can't save the image";
                }
                else
                    label2.Text = "OK";

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            refMain.openFileDialog1.Filter = "iMatchModel file |*.irc";
            E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;
            if (refMain.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = refMain.openFileDialog1.FileName;
                if (cbImgProcLine.Checked)
                {
                    err = ROIIPLineManager.LoadROIModel(path);
                    ROIIPLineManager.SetDrawScale(refMain.scale);
                    refMain.ShowLineIPMeasure = false;
                    refMain.ShowCircleIPMeasure = false;
                    refMain.ShowCircleNoIPMeasure = false;
                    refMain.ShowLineIPMeasure = true;
                }
                else
                {
                    err = ROINoIPLineMeasureManager.LoadROIModel(path);
                    err = ROINoIPLineMeasureManager.SetDrawScale(refMain.scale);
                    err = ROINoIPLineMeasureManager.PlotModel();
                    refMain.ShowLineIPMeasure = false;
                    refMain.ShowCircleIPMeasure = false;
                    refMain.ShowCircleNoIPMeasure = false;
                    refMain.ShowLineNoIPMeasure = true;

                }

                if (err == E_iVision_ERRORS.E_OK)
                {
                    label2.Text = "OK";
                }
                else
                {
                    MessageBox.Show(err.ToString(), "Error Loading roi");
                    label2.Text = "Error";
                }
            }
        }

        iIPoint CalculateVectorBetweenMatchingAndROIandMeasureROI(double[] ROIMeasureInfo, iIPoint point)
        {
            iRingROI l_RingROI = new iRingROI();
            iROI_Type l_type = iROI_Type.iNULL;

            if (cbImageP.Checked)
            {
                l_type = ROIIPCircleManager.GetROIInfo(ref ROIMeasureInfo[0]);
            }
            else
            {
                l_type = ROINoIPCircleMeasureManager.GetROIInfo(ref ROIMeasureInfo[0]);
            }
            //l_type = iROI.iROIGetInfo(refMain.MeasureROIToolManager, ref l_data[0]);
            if (l_type == iROI_Type.iRing)
            {
                l_RingROI.m_center_x = Convert.ToInt32(ROIMeasureInfo[0]);
                l_RingROI.m_center_y = Convert.ToInt32(ROIMeasureInfo[1]);
            }
            else
            {
                label2.Text = "ROI type Error!";
            }
            iIPoint vector = new iIPoint();
            vector.x = Convert.ToInt32(l_RingROI.m_center_x - point.x);
            vector.y = Convert.ToInt32(l_RingROI.m_center_y - point.y);

            refMain.ShowMatchingROI = refMain.ShowCircleNoIPMeasure = refMain.ShowCircleIPMeasure= false;
            ROIMatchingManager.DeleteROIfromImage();

            return vector;
        }
        iIPoint CalculateVectorBetweenMatchingAndLineROI(double[] ROIMeasureInfo, iIPoint point)
        {
            iAdvanceROI lAdvROI = new iAdvanceROI();
            iROI_Type l_type = iROI_Type.iNULL;
            if (cbImgProcLine.Checked)
            {
                l_type = ROIIPLineManager.GetROIInfo(ref ROIMeasureInfo[0]);
            }
            else
            {
                l_type = ROINoIPLineMeasureManager.GetROIInfo(ref ROIMeasureInfo[0]);
            }
            //l_type = iROI.iROIGetInfo(refMain.MeasureROIToolManager, ref l_data[0]);
            if (l_type == iROI_Type.iAdvance)
            {
                lAdvROI.m_center_x = Convert.ToInt32(ROIMeasureInfo[0]);
                lAdvROI.m_center_y = Convert.ToInt32(ROIMeasureInfo[1]);
                
            }
            else
            {
                label2.Text = "ROI type Error!";
            }
            iIPoint vector = new iIPoint();
            vector.x = Convert.ToInt32(lAdvROI.m_center_x - point.x);
            vector.y = Convert.ToInt32(lAdvROI.m_center_y - point.y);

            refMain.ShowMatchingROI = refMain.ShowLineIPMeasure =refMain.ShowLineNoIPMeasure = false;
            ROIMatchingManager.DeleteROIfromImage();
            return vector;
        }


        private void NCCDialog_Load(object sender, EventArgs e)
        {
            label2.Text = "NULL";

            btn_SetMatchingROI.Text =  "Set Matching/nROI (Template)";
            btn_SetMeasureROI.Text = "Set Measure/nROI";  
            dataGridView1.Rows.Clear();
        }

        void UpData_NCC_Parameter()
        {
            if (cbx_rotation.CheckState == CheckState.Checked) 
                MatchingManager.IsRotatedParameter = true;
            else
                MatchingManager.IsRotatedParameter = false;

            if (cbx_scale.CheckState == CheckState.Checked)
                MatchingManager.IsScaledParameter = true;
            else
                MatchingManager.IsScaledParameter = false;

            if (cbx_dontcare.CheckState == CheckState.Checked)
                MatchingManager.IsDontAreaParameter = true;
            else
                MatchingManager.IsDontAreaParameter = false;

            MatchingManager.MinScoreParameter = Convert.ToDouble(tbx_minscore.Text);
            MatchingManager.OccurrenceParameter = Convert.ToInt32(tbx_objnums.Text);
            MatchingManager.SetAngleParameters(Convert.ToDouble(tbx_maxang.Text),
                                               Convert.ToDouble(tbx_minang.Text));
            MatchingManager.SetScaleParameter(Convert.ToDouble(tbx_maxscale.Text),
                                               Convert.ToDouble(tbx_minscale.Text));
            MatchingManager.DontCareThresholdParameter = Convert.ToInt32(tbx_dontcarethreshold.Text);
            //MatchingManager.ColorSensitivityParameter = Convert.ToInt32(tbx_sensitivy.Text);
            MatchingManager.FinalReductionParameter = Convert.ToInt32(tbx_FinalReduction.Text);
            //Max_objs = Convert.ToInt32(tbx_objnums.Text);
            //MaxAng = Convert.ToDouble(tbx_maxang.Text);
            //MinAng = Convert.ToDouble(tbx_minang.Text);
            //MaxScale = Convert.ToDouble(tbx_maxscale.Text);
            //MinScale = Convert.ToDouble(tbx_minscale.Text);
            //MinScore = Convert.ToDouble(tbx_minscore.Text);
            //DontCarevalue = Convert.ToInt32(tbx_dontcarethreshold.Text);
            //FinalReduction = Convert.ToInt32(tbx_FinalReduction.Text);
        }
       

        private void btn_NCCmatching_Click(object sender, EventArgs e)
        {

            if (cbImageP.Checked)
            {
                if (ROIIPCircleManager == null)
                {
                    MessageBox.Show("Select a ROIIPCircleManager for Matching", "Error");
                    return;
                }
                if (ROIIPCircleManager.ROISize() == 0)
                {
                    MessageBox.Show("Select a ROIIPCircleManager.ROISize for Matching", "Error");
                    return;
                }
            }
            else
            {
                if (ROINoIPCircleMeasureManager == null)
                {
                    MessageBox.Show("Select a ROINoIPCircleMeasureManager for Matching", "Error");
                    return;
                }
                if (ROINoIPCircleMeasureManager.ROISize() == 0)
                {
                    MessageBox.Show("Select a ROINoIPCircleMeasureManager for Matching", "Error");
                    return;
                }
            }


          
            E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;
            int findnum = 0;
            string[] str = new string [6];
            double Execute_time = 0;
            double t1 = 0;
            double t2 = 0;
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            refMain.pictureBox1.Refresh();
            
            g_Results = refMain.pictureBox1.CreateGraphics();

            iIPoint[] Cp = new iIPoint[1];
            double[] Inner = new double[1];
            double [] Outer = new double[1];
            
            double[] N_Roundness = new double[1];
            double shiftROI_x, shiftROI_y;

            double[] rAng = new double [4];
            Point[] RegionPoint = new Point [4];

            UpData_NCC_Parameter();

            err = MatchingManager.IsPatternLearn();
            if (err != E_iVision_ERRORS.E_TRUE)
            {
                MessageBox.Show(err.ToString(), "Error");
                label2.Text = "Error";
                return;
            }

            MatchingManager.SetScaleParameter(refMain.scale, refMain.scale);
            err=MatchingManager.MatchModel(refMain.ImageManager.GetWorkingImage());
            t1 = MatchingManager.calculationTime;
            //iMatch.iSetScale(refMain.NCCmodel, refMain.scale, refMain.scale);
            //sw.Reset();
            //sw.Start();
            //err = iMatch.MatchNCCModel(refMain.GrayImg, refMain.NCCmodel);
            //sw.Stop();
            //t1 = sw.ElapsedMilliseconds;
            if (err != E_iVision_ERRORS.E_OK) 
            {
                MessageBox.Show(err.ToString(), "Error");
                label2.Text = "Error";
                return;
            }
            else 
                label2.Text = E_iVision_ERRORS.E_OK.ToString();

            //err = iMatch.iGetNCCMatchNum(refMain.NCCmodel, ref findnum);
            err = MatchingManager.GetNCCMatchNum(ref findnum);
            if (err != E_iVision_ERRORS.E_OK)
            {
                MessageBox.Show(err.ToString(), "Error");
                label2.Text = "Error";
                return;
            }

            // check vector
            iIPoint aux = new iIPoint();
            double[] ROIMeasureInfo = new double[10];
            aux = CalculateVectorBetweenMatchingAndROIandMeasureROI(ROIMeasureInfo, refMain.CpofMatch);
            refMain.ROIVectorCircle.x = aux.x;
            refMain.ROIVectorCircle.y = aux.y;

            if (findnum != 0)
            {
                UpdateMeasurePata();
                Array.Resize(ref CircleResults, findnum);
                Array.Resize(ref N_Roundness, findnum);
                Array.Resize(ref Cp, findnum);
                Array.Resize(ref Inner, findnum);
                Array.Resize(ref Outer, findnum);

                iROI_Type ROIType;
                iRingROI l_RingROI;
                double[] l_ptr = new double[10];

                //ROIType = iROI.iROIGetInfo(refMain.MeasureROIToolManager, ref l_ptr[0]);
                if (cbImageP.Checked)
                {
                    ROIType = ROIIPCircleManager.GetROIInfo(ref l_ptr[0]);
                }
                else
                {
                    ROIType = ROINoIPCircleMeasureManager.GetROIInfo(ref l_ptr[0]);
                }
                
                if (ROIType != iROI_Type.iRing)
                    return;

                for (int i = 0; i < findnum; i++)
                {
                    err = MatchingManager.GetNCCMatchResultsInObjFind(i, ref objfind);
                    //err = iMatch.iGetNCCMatchResults(refMain.NCCmodel, i, ref objfind);
                    shiftROI_x = refMain.ROIVectorCircle.x * Math.Cos(objfind.Angle * Math.PI / 180) + refMain.ROIVectorCircle.y * Math.Sin(objfind.Angle * Math.PI / 180);
                    shiftROI_y = -refMain.ROIVectorCircle.x * Math.Sin(objfind.Angle * Math.PI / 180) + refMain.ROIVectorCircle.y * Math.Cos(objfind.Angle * Math.PI / 180);
                    l_RingROI.m_center_x = Convert.ToInt32(objfind.CX + shiftROI_x);
                    l_RingROI.m_center_y = Convert.ToInt32(objfind.CY + shiftROI_y);
                    l_RingROI.m_gap = Convert.ToInt32(l_ptr[2]);
                    l_RingROI.m_radius = Convert.ToInt32(l_ptr[3]);

                    // CircleManager.setParameters()
                    err = CircleManager.UpdateParametesInThisRing(l_RingROI);
                    //err = iMCircle.iMCircleSetPara2(refMain.imeasure, l_RingROI, Threshold, Sampling, IterationN, iterationTh, TransType, EdgeChoice);
                    if (err != E_iVision_ERRORS.E_OK)
                    {
                        MessageBox.Show(err.ToString(), "Error");
                        return;
                    }
                    //err = CircleManager.MeasureCircle(refMain.ImageManager.GetWorkingImage());

                    sw.Reset();
                    sw.Start();
                    if (cbImageP.Checked)
                    {
                        err = CircleManager.MeasureCircle(refMain.GetImageProcessedImg());
                    }
                    else if (cbImageP.Checked== false || b_testing==true)
                    {
                        err = CircleManager.MeasureCircle(refMain.ImageManager.GetWorkingImage());
                    }
                    sw.Stop();
                    t2 = sw.ElapsedMilliseconds;
                    if (err != E_iVision_ERRORS.E_FAILED)
                    {
                        CircleManager.GetResultsCircle(ref CircleResults[i]);
                        //iMCircle.iMCircle_GetResults(refMain.imeasure, ref Results[i]);
                        N_Roundness[i] = 100 * ((CircleResults[i].Diameter / 2) - CircleResults[i].Roundness) / (CircleResults[i].Diameter / 2);
                    }
                    else
                    {
                        MessageBox.Show(err.ToString(), "Error");
                        return;
                    }

                }
            }
            Execute_time = t1+t2;
            for (int i = 0; i < findnum; i++)
            {
                MatchingManager.GetNCCMatchResultsInText(i, ref str);
                //err = iMatch.iGetNCCMatchResults(refMain.NCCmodel, i, ref objfind);

                //str[0] = objfind.Score.ToString("F4", CultureInfo.InvariantCulture);
                //str[1] = objfind.CX.ToString("F4", CultureInfo.InvariantCulture);
                //str[2] = objfind.CY.ToString("F4", CultureInfo.InvariantCulture);
                //str[3] = objfind.Angle.ToString("F4", CultureInfo.InvariantCulture);
                //str[4] = objfind.Scale.ToString("F4", CultureInfo.InvariantCulture);
                //str[5] = Execute_time.ToString("F4", CultureInfo.InvariantCulture);
                // match
                dataGridView1.Rows.Add(str[0], str[1], str[2], str[3], str[4], str[5]);

                //measure
                str[0] = i.ToString();
                str[1] = double.IsNaN(CircleResults[i].Cp.x) ? "0" : CircleResults[i].Cp.x.ToString("f3");
                str[2] = double.IsNaN(CircleResults[i].Cp.y) ? "0" : CircleResults[i].Cp.y.ToString("f3");
                str[3] = double.IsNaN(CircleResults[i].Diameter) ? "0" : CircleResults[i].Diameter.ToString("f3");
                str[4] = double.IsNaN(N_Roundness[i]) ? "0" : N_Roundness[i].ToString("f3");
                str[5] = double.IsNaN(CircleResults[i].PL_Difference) ? "0" : CircleResults[i].PL_Difference.ToString("f3");

                if (double.IsNaN(CircleResults[i].Cp.x) == true)
                    return;

                g_Results.DrawEllipse(Pens.Red, Convert.ToInt32((CircleResults[i].Cp.x  - CircleResults[i].Diameter / 2) * refMain.scale) , Convert.ToInt32(CircleResults[i].Cp.y - CircleResults[i].Diameter / 2) * refMain.scale, Convert.ToInt32(CircleResults[i].Diameter) * refMain.scale, Convert.ToInt32(CircleResults[i].Diameter) * refMain.scale);
                g_Results.DrawLine(Pens.Red, Convert.ToInt32(CircleResults[i].Cp.x * refMain.scale - 10) , Convert.ToInt32(CircleResults[i].Cp.y) * refMain.scale, Convert.ToInt32(CircleResults[i].Cp.x * refMain.scale + 10), Convert.ToInt32(CircleResults[i].Cp.y * refMain.scale));
                g_Results.DrawLine(Pens.Red, Convert.ToInt32(CircleResults[i].Cp.x) * refMain.scale, Convert.ToInt32(CircleResults[i].Cp.y * refMain.scale - 10) , Convert.ToInt32(CircleResults[i].Cp.x * refMain.scale) , Convert.ToInt32(CircleResults[i].Cp.y * refMain.scale + 10));

                g_Results.DrawEllipse(Pens.Yellow, Convert.ToInt32(Cp[i].x - Inner[i]) * refMain.scale, Convert.ToInt32(Cp[i].y - Inner[i]) * refMain.scale, Convert.ToInt32(Inner[i] * 2), Convert.ToInt32(Inner[i] * 2));
                g_Results.DrawEllipse(Pens.Yellow, Convert.ToInt32(Cp[i].x - Outer[i]) * refMain.scale, Convert.ToInt32(Cp[i].y - Outer[i]) * refMain.scale, Convert.ToInt32(Outer[i] * 2), Convert.ToInt32(Outer[i] * 2));

                dataGridView2.Rows.Add(str[0], str[1], str[2], str[3], str[4], str[5]);
            }
            if (refMain.scale != 1)
            {
                err= MatchingManager.DrawMatchResults(g_Results.GetHdc(), refMain.scale);
                //err = iMatch.iDrawiMatchResults(refMain.NCCmodel, g_Results.GetHdc(), refMain.scale);
            }
            else
            {
                err = MatchingManager.DrawMatchResults(g_Results.GetHdc(), 1);
                //err = iMatch.iDrawiMatchResults(refMain.NCCmodel, g_Results.GetHdc(), 1);
            }

            //iROI.iROIDeleteROI
            //var error = iROI.iROIDeleteROI(refMain.MatchingROIToolManager);
            //iROI.iROIDeleteAll(refMain.MeasureROIToolManager);
            // iROI.iROIPlot(refMain.MatchingROIToolManager, refMain.hDC);
            refMain.ShowCircleNoIPMeasure = refMain.ShowMatchingROI = refMain.ShowCircleIPMeasure= false;
      
        }

        private void btn_ReadModel_Click(object sender, EventArgs e)
        {
            refMain.openFileDialog1.Filter = "iMatchModel file |*.imm";
            E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;
            if (refMain.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = refMain.openFileDialog1.FileName;
                err = MatchingManager.LoadMatchModel(path);
                //err = iMatch.LoadiMatchModel(refMain.NCCmodel, path);

                if (err == E_iVision_ERRORS.E_OK)
                {
                    //更新參數到介面
                    MatchParameters matchParameters = MatchingManager.GetMatchParameters();
                    
                    tbx_objnums.Text = matchParameters.Max_objs.ToString();
                    tbx_maxang.Text = matchParameters.MaxAng.ToString();
                    tbx_minang.Text = matchParameters.MinAng.ToString();
                    tbx_maxscale.Text = matchParameters.MaxScale.ToString();
                    tbx_minscale.Text = matchParameters.MinScale.ToString();
                    tbx_minscore.Text = matchParameters.MinScore.ToString();
                    tbx_dontcarethreshold.Text = matchParameters.DontCarevalue.ToString();
                    tbx_MinReduceArea.Text = matchParameters.MinReduceArea.ToString();
                    tbx_FinalReduction.Text = matchParameters.FinalReduction.ToString();

                    if (matchParameters.UsingRotation)
                        cbx_rotation.CheckState = CheckState.Checked;
                    else
                        cbx_rotation.CheckState = CheckState.Unchecked;

                    if (matchParameters.UsingScale)
                        cbx_scale.CheckState = CheckState.Checked;
                    else
                        cbx_scale.CheckState = CheckState.Unchecked;

                    if (matchParameters.UsingMask)
                        cbx_dontcare.CheckState = CheckState.Checked;
                    else
                        cbx_dontcare.CheckState = CheckState.Unchecked;

                    label2.Text = "OK";
                }
                else
                {
                    MessageBox.Show(err.ToString(), "Error");
                    label2.Text = "Error";
                }
            }
        }

        private void btn_SaveModel_Click(object sender, EventArgs e)
        {
            refMain.saveFileDialog1.Filter = "iMatchModel file |*.imm";
            refMain.saveFileDialog1.AddExtension = true;
            E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;
 
            UpData_NCC_Parameter();
           
            if (refMain.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = refMain.saveFileDialog1.FileName;
                //ImageManager.iImageIsNULL();
                err = refMain.ImageManager.iImageIsNULL();
                if (err == E_iVision_ERRORS.E_TRUE)
                {
                    MessageBox.Show(err.ToString(), "Error");
                    label2.Text = "Error";
                    return;
                }

                err = MatchingManager.SaveMatchModel(path);
                if (err != E_iVision_ERRORS.E_OK)
                {
                    MessageBox.Show(err.ToString(), "Error");
                    label2.Text = "Error";
                }
                else
                    label2.Text = "OK";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;

            //err = iMatch.iVisitingKey();
            err = MatchingManager.VisitingKey();
            if (err != E_iVision_ERRORS.E_OK)
            {
                MessageBox.Show(err.ToString(), "Error");
                label2.Text = "Error";
            }
            else
                label2.Text = "OK";
            err = CircleManager.VisitingKeyCircle();
            //err = iMCircle.iVisitingKey();
            if (err != E_iVision_ERRORS.E_OK)
            {
                MessageBox.Show(err.ToString(), "Error");
                label2.Text = "Error";
            }
            else
                label2.Text = "OK";
        }

        private void UpdateMeasurePata()
        {
            CircleManager.Parameters.edgeThreshold  = Convert.ToInt32(txt_Threshold.Text);
            CircleManager.Parameters.samplingStep   = Convert.ToInt32(txt_SampingPoints .Text);
            CircleManager.Parameters.iterations     = Convert.ToInt32(txt_iterationN.Text);
            CircleManager.Parameters.iterThreshold  = Convert.ToInt32(txt_IterThreshold.Text);
            CircleManager.Parameters.edgeChoice     = Convert.ToInt32(txt_EdgeChoice.Text);
            CircleManager.Parameters.transitionType = Convert.ToInt32(txt_Transition.Text);
            StartAngle = Convert.ToInt32(txt_StartAngle.Text);
            EndAngle = Convert.ToInt32(txt_EndAngle.Text);
        }
        E_iVision_ERRORS updateLineParameters(iAdvanceROI AdvROI)
        {
            LineParameters LinePar = new LineParameters();
            LinePar.edgeThreshold = Convert.ToInt32(txbLineThreshold.Text);
            LinePar.samplingStep = Convert.ToInt32(txbSamplePoints.Text);
            LinePar.iterations = Convert.ToInt32(txbIteration.Text);
            LinePar.iterThreshold = Convert.ToInt32(txbIterationTH.Text);
            LinePar.edgeChoice = Convert.ToInt32(txbEdgeChoise.Text);
            LinePar.transitionType = Convert.ToInt32(txbTransitionType.Text);

            LinePar.advROI = AdvROI;
            return LineManager.SetParamLine(LinePar);

           
        }
        private void btn_SetMatchingROI_Click(object sender, EventArgs e)
        {
            //refMain.pictureBox1.Refresh();
            refMain.ShowCircleNoIPMeasure = false;
            refMain.ShowCircleIPMeasure = false;
            refMain.ShowLineIPMeasure = false;
            refMain.ShowLineNoIPMeasure = false;
            ROIMatchingManager.numROI = 1;
            E_iVision_ERRORS err = ROIMatchingManager.MVC_AddROI(ROI_types.BaseROI);
            label2.Text = err.ToString();
            refMain.ShowMatchingROI = true;
            

            //if (iROI.iROISize(refMain.MatchingROIToolManager) <3 )
            //{
            //    iBaseROI l_base_roi;
            //    l_base_roi.OrgX = 150;
            //    l_base_roi.OrgY = 150;
            //    l_base_roi.Width = 50;
            //    l_base_roi.Height = 50;
            //    iROI.iROIAddBaseROI(refMain.MatchingROIToolManager, l_base_roi);
            //    iROI.iROIPlot(refMain.MatchingROIToolManager, refMain.hDC);
            //    refMain.ShowMatchingROI = true;
            //}
            //else
            //    label2.Text = "the size of ROI is > 2.";
        }

        private void btn_SetMeasureROI_Click(object sender, EventArgs e)
        {
            refMain.ShowMatchingROI = false;
            
            ROINoIPCircleMeasureManager.numROI = 1;
            E_iVision_ERRORS err = E_iVision_ERRORS.E_FAILED;
            if (cbImageP.Checked)
            {
                refMain.ShowLineNoIPMeasure = false;
                refMain.ShowLineIPMeasure = false;
                refMain.ShowCircleNoIPMeasure = false;
                refMain.ShowCircleIPMeasure = true;
                ROIIPCircleManager = new MVC_ROIManager(refMain.GetImageProcessedImg(), refMain.hDC);
                ROIIPCircleManager.SetDrawScale(refMain.scale);
                err = ROIIPCircleManager.MVC_AddROI(ROI_types.Ring);
            }
            else
            {
                refMain.ShowLineNoIPMeasure = false;
                refMain.ShowLineIPMeasure = false;
                refMain.ShowCircleNoIPMeasure = true;
                refMain.ShowCircleIPMeasure = false;
                err = ROINoIPCircleMeasureManager.MVC_AddROI(ROI_types.Ring);
            }
            label2.Text = err.ToString();

        }

    }
}
