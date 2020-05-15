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
using MiM_iVision;
using System.Diagnostics;

namespace Warp_Csharp
{
    public partial class DemoDialog :Form 
    {
        Stopwatch sw = new Stopwatch();

        public Mainfrm refMain;
        string path;
        Graphics g_Results;

        #region variable for measure
        public int DefSampling = 360, DefIterationN = 100, DefIterTh = 4, DefEdgeChoice = 2, DefTransType = 2;
        public int Sampling, IterationN, EdgeChoice, TransType, StartAngle = 0, EndAngle = 360;
        public int Threshold, DefThreshold = 10;
        public double iterationTh;
        #endregion

        #region variable for matching
        bool UsingMask;
        bool UsingRotation;
        bool UsingScale;
        int  Max_objs;
        double MaxAng, MinAng;
        double MaxScale, MinScale;
        double MinScore;
        int DontCarevalue;
        int MinReduceArea;
        int FinalReduction;
        NCCFind objfind;
        #endregion

        #region CoWork variable

        #endregion


        public DemoDialog()
        {
            InitializeComponent();

            UsingMask = false;
            UsingRotation = false;
            UsingScale = false;
            cbx_rotation.CheckState = CheckState.Checked;
            cbx_scale.CheckState = CheckState.Unchecked;
            cbx_dontcare.CheckState = CheckState.Unchecked;

            #region Initial Matching
            Max_objs = 1;
            MaxAng = 180; MinAng = -180;
            MaxScale = 1.1; MinScale = 0.9;
            MinScore = 0.75;
            DontCarevalue = 0;
            MinReduceArea = 64;
            FinalReduction = 0;

            tbx_objnums.Text = Max_objs.ToString();
            tbx_maxang.Text = MaxAng.ToString();
            tbx_minang.Text = MinAng.ToString();
            tbx_maxscale.Text = MaxScale.ToString();
            tbx_minscale.Text = MinScale.ToString();
            tbx_minscore.Text = MinScore.ToString();
            tbx_dontcarethreshold.Text = DontCarevalue.ToString();
            tbx_MinReduceArea.Text = MinReduceArea.ToString();
            tbx_FinalReduction.Text = FinalReduction.ToString();
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
            iMCircle.iMCircle_GetFeatures(refMain.imeasure, ref resultPoints[0]);
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
            iMCircle.iMCircle_GetResults(refMain.imeasure, ref Results);
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
            refMain.showLineDlg();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refMain.showImgProcessDlg();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_LoadGrayImg_Click(object sender, EventArgs e)
        {
            refMain.openFileDialog1.Filter = "BMP file |*.bmp";
            E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;
            if (refMain.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = refMain.openFileDialog1.FileName;
                err = iImage.iReadImage(refMain.GrayImg, path);
                if (err == E_iVision_ERRORS.E_OK)
                {
                    refMain.hbitmap = iImage.iGetBitmapAddress(refMain.GrayImg);
                    if (refMain.pictureBox1.Image != null)
                        refMain.pictureBox1.Image.Dispose();
                    refMain.pictureBox1.Image = System.Drawing.Image.FromHbitmap(refMain.hbitmap);
                    refMain.pictureBox1.Refresh();
                    refMain.g_ROIs = refMain.pictureBox1.CreateGraphics();
                    refMain.hDC = refMain.g_ROIs.GetHdc();
                    iROI.iROIAttached(refMain.MatchingROIToolManager, refMain.GrayImg, refMain.hDC);
                    iROI.iROIAttached(refMain.MeasureROIToolManager, refMain.GrayImg, refMain.hDC);
                }
                else
                {
                    MessageBox.Show(err.ToString(), "Error");
                    label2.Text = "Error";
                }
            }
        }

        private void btn_NCCtraining_Click(object sender, EventArgs e)
        {
            E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;
           
            refMain.ShowMatchingROI = true;
            if (iROI.iROISize(refMain.MatchingROIToolManager) == 0)
            {
                MessageBox.Show("Select a ROI for Matching", "Error");
                return;
            }

            if (iROI.iROISize(refMain.MeasureROIToolManager) == 0)
            {
                label2.Text = "the size of ROI is 0.";
                return;
            }

            UpData_NCC_Parameter();

            MinReduceArea = Convert.ToInt32(tbx_MinReduceArea.Text);
            err = iMatch.iSetMinReduceArea(refMain.NCCmodel, MinReduceArea);
            if (err != E_iVision_ERRORS.E_OK)
            { MessageBox.Show(err.ToString(), "Error"); label2.Text = "Error"; }
            else label2.Text = "E_OK";

            err = iMatch.iSetDontCareThreshold(refMain.NCCmodel, DontCarevalue);
            if (err != E_iVision_ERRORS.E_OK)
            { MessageBox.Show(err.ToString(), "Error"); label2.Text = "Error"; }
            else label2.Text = "E_OK";

            iBaseROI l_rect = new iBaseROI();
            iRingROI l_RingROI = new iRingROI();
            double[] l_data = new double[10];


            iROI_Type l_type = iROI.iROIGetInfo(refMain.MatchingROIToolManager, ref l_data[0]);

            if (l_type == iROI_Type.iBase)
            {
                l_rect.OrgX = Convert.ToInt32(l_data[0]);
                l_rect.OrgY = Convert.ToInt32(l_data[1]);
                l_rect.Width = Convert.ToInt32(l_data[2]);
                l_rect.Height = Convert.ToInt32(l_data[3]);
                label2.Text = err.ToString();
            }
            else
            {
                label2.Text = "ROI type Error!";
                return;
            }

            mRect rect;
            rect.top = l_rect.OrgY;
            rect.down = l_rect.OrgY + l_rect.Height;
            rect.left = l_rect.OrgX;
            rect.right = l_rect.OrgX + l_rect.Width;
            refMain.CpofMatch.x = Convert.ToInt32((rect.right + rect.left) / 2.0);
            refMain.CpofMatch.y = Convert.ToInt32((rect.down + rect.top) / 2.0);
            
            err = iMatch.CreateNCCModelFromROI(refMain.GrayImg, refMain.NCCmodel, rect, UsingMask);
            if (err != E_iVision_ERRORS.E_OK)
            { MessageBox.Show(err.ToString(), "Error"); label2.Text = "Error"; }
            else label2.Text = "E_OK";

            l_type = iROI.iROIGetInfo(refMain.MeasureROIToolManager, ref l_data[0]);
            if (l_type == iROI_Type.iRing)
            {
                l_RingROI.m_center_x = Convert.ToInt32(l_data[0]);
                l_RingROI.m_center_y = Convert.ToInt32(l_data[1]);
            }
            else
            {
                label2.Text = "ROI type Error!";
                return;
            }

            refMain.ROIVectorCircle.x = Convert.ToInt32(l_RingROI.m_center_x - refMain.CpofMatch.x);
            refMain.ROIVectorCircle.y = Convert.ToInt32(l_RingROI.m_center_y - refMain.CpofMatch.y);


            refMain.ShowMatchingROI = refMain.ShowMeasureROI = false;
            iROI.iROIDeleteAll(refMain.MatchingROIToolManager);
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
                UsingRotation = true;
            else 
                UsingRotation = false;

            if (cbx_scale.CheckState == CheckState.Checked)
                UsingScale = true;
            else
                UsingScale = false;

            if (cbx_dontcare.CheckState == CheckState.Checked)
                UsingMask = true;
            else
                UsingMask = false;


            Max_objs = Convert.ToInt32(tbx_objnums.Text);
            MaxAng = Convert.ToDouble(tbx_maxang.Text);
            MinAng = Convert.ToDouble(tbx_minang.Text);
            MaxScale = Convert.ToDouble(tbx_maxscale.Text);
            MinScale = Convert.ToDouble(tbx_minscale.Text);
            MinScore = Convert.ToDouble(tbx_minscore.Text);
            DontCarevalue = Convert.ToInt32(tbx_dontcarethreshold.Text);
            FinalReduction = Convert.ToInt32(tbx_FinalReduction.Text);
        }

        private void btn_NCCmatching_Click(object sender, EventArgs e)
        {
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
            iCircle_Measured[] Results = new iCircle_Measured[1];
            double[] N_Roundness = new double[1];
            double shiftROI_x, shiftROI_y;

            double[] rAng = new double [4];
            Point[] RegionPoint = new Point [4];

            UpData_NCC_Parameter();

            iMatch.iSetMinScore(refMain.NCCmodel, MinScore);
            iMatch.iSetIsRotated(refMain.NCCmodel, UsingRotation);
            iMatch.iSetIsScaled(refMain.NCCmodel, UsingScale);
            iMatch.iSetOccurrence(refMain.NCCmodel, Max_objs);
            iMatch.iSetAngle(refMain.NCCmodel, MaxAng, MinAng);
            iMatch.iSetScale(refMain.NCCmodel, MaxScale, MinScale);
            iMatch.iSetDontCareThreshold(refMain.NCCmodel, DontCarevalue);
            iMatch.iSetFinalReduction(refMain.NCCmodel, FinalReduction);

            err = iMatch.iIsPatternLearn(refMain.NCCmodel);
            if (err != E_iVision_ERRORS.E_TRUE)
            {
                MessageBox.Show(err.ToString(), "Error");
                label2.Text = "Error";
                return;
            }
            iMatch.iSetScale(refMain.NCCmodel, refMain.scale, refMain.scale);
            sw.Reset();
            sw.Start();
            err = iMatch.MatchNCCModel(refMain.GrayImg, refMain.NCCmodel);
            sw.Stop();
            t1 = sw.ElapsedMilliseconds;
            if (err != E_iVision_ERRORS.E_OK) 
            {
                MessageBox.Show(err.ToString(), "Error");
                label2.Text = "Error";
                return;
            }
            else 
                label2.Text = E_iVision_ERRORS.E_OK.ToString();

            err = iMatch.iGetNCCMatchNum(refMain.NCCmodel, ref findnum);
            if (err != E_iVision_ERRORS.E_OK)
            {
                MessageBox.Show(err.ToString(), "Error");
                label2.Text = "Error";
                return;
            }

            if (findnum != 0)
            {
                UpdateMeasurePata();
                Array.Resize(ref Results, findnum);
                Array.Resize(ref N_Roundness, findnum);
                Array.Resize(ref Cp, findnum);
                Array.Resize(ref Inner, findnum);
                Array.Resize(ref Outer, findnum);

                iROI_Type ROIType;
                iRingROI l_RingROI;
                double[] l_ptr = new double[10];

                ROIType = iROI.iROIGetInfo(refMain.MeasureROIToolManager, ref l_ptr[0]);
                if (ROIType != iROI_Type.iRing)
                    return;

                for (int i = 0; i < findnum; i++)
                {
                    err = iMatch.iGetNCCMatchResults(refMain.NCCmodel, i, ref objfind);
                    shiftROI_x = refMain.ROIVectorCircle.x * Math.Cos(objfind.Angle * Math.PI / 180) + refMain.ROIVectorCircle.y * Math.Sin(objfind.Angle * Math.PI / 180);
                    shiftROI_y = -refMain.ROIVectorCircle.x * Math.Sin(objfind.Angle * Math.PI / 180) + refMain.ROIVectorCircle.y * Math.Cos(objfind.Angle * Math.PI / 180);
                    l_RingROI.m_center_x = Convert.ToInt32(objfind.CX + shiftROI_x);
                    l_RingROI.m_center_y = Convert.ToInt32(objfind.CY + shiftROI_y);
                    l_RingROI.m_gap = Convert.ToInt32(l_ptr[2]);
                    l_RingROI.m_radius = Convert.ToInt32(l_ptr[3]);
                    err = iMCircle.iMCircleSetPara2(refMain.imeasure, l_RingROI, Threshold, Sampling, IterationN, iterationTh, TransType, EdgeChoice);
                    if (err != E_iVision_ERRORS.E_OK)
                    {
                        MessageBox.Show(err.ToString(), "Error");
                        return;
                    }
                    
                    sw.Reset();
                    sw.Start(); 
                     err = iMCircle.iMeasure_Circle(refMain.imeasure, refMain.GrayImg);
                    sw.Stop();
                    t2 = sw.ElapsedMilliseconds;
                    if (err != E_iVision_ERRORS.E_FAILED)
                    {
                        iMCircle.iMCircle_GetResults(refMain.imeasure, ref Results[i]);
                       
                        N_Roundness[i] = 100 * ((Results[i].Diameter / 2) - Results[i].Roundness) / (Results[i].Diameter / 2);
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
                err = iMatch.iGetNCCMatchResults(refMain.NCCmodel, i, ref objfind);

                str[0] = objfind.Score.ToString("F4", CultureInfo.InvariantCulture);
                str[1] = objfind.CX.ToString("F4", CultureInfo.InvariantCulture);
                str[2] = objfind.CY.ToString("F4", CultureInfo.InvariantCulture);
                str[3] = objfind.Angle.ToString("F4", CultureInfo.InvariantCulture);
                str[4] = objfind.Scale.ToString("F4", CultureInfo.InvariantCulture);
                str[5] = Execute_time.ToString("F4", CultureInfo.InvariantCulture);

                dataGridView1.Rows.Add(str[0], str[1], str[2], str[3], str[4], str[5]);

                //結果輸出
                str[0] = i.ToString();
                str[1] = double.IsNaN(Results[i].Cp.x) ? "0" : Results[i].Cp.x.ToString("f3");
                str[2] = double.IsNaN(Results[i].Cp.y) ? "0" : Results[i].Cp.y.ToString("f3");
                str[3] = double.IsNaN(Results[i].Diameter) ? "0" : Results[i].Diameter.ToString("f3");
                str[4] = double.IsNaN(N_Roundness[i]) ? "0" : N_Roundness[i].ToString("f3");
                str[5] = double.IsNaN(Results[i].PL_Difference) ? "0" : Results[i].PL_Difference.ToString("f3");

                if (double.IsNaN(Results[i].Cp.x) == true)
                    return;

                g_Results.DrawEllipse(Pens.Red, Convert.ToInt32((Results[i].Cp.x  - Results[i].Diameter / 2) * refMain.scale) , Convert.ToInt32(Results[i].Cp.y - Results[i].Diameter / 2) * refMain.scale, Convert.ToInt32(Results[i].Diameter) * refMain.scale, Convert.ToInt32(Results[i].Diameter) * refMain.scale);
                g_Results.DrawLine(Pens.Red, Convert.ToInt32(Results[i].Cp.x * refMain.scale - 10) , Convert.ToInt32(Results[i].Cp.y) * refMain.scale, Convert.ToInt32(Results[i].Cp.x * refMain.scale + 10), Convert.ToInt32(Results[i].Cp.y * refMain.scale));
                g_Results.DrawLine(Pens.Red, Convert.ToInt32(Results[i].Cp.x) * refMain.scale, Convert.ToInt32(Results[i].Cp.y * refMain.scale - 10) , Convert.ToInt32(Results[i].Cp.x * refMain.scale) , Convert.ToInt32(Results[i].Cp.y * refMain.scale + 10));

                g_Results.DrawEllipse(Pens.Yellow, Convert.ToInt32(Cp[i].x - Inner[i]) * refMain.scale, Convert.ToInt32(Cp[i].y - Inner[i]) * refMain.scale, Convert.ToInt32(Inner[i] * 2), Convert.ToInt32(Inner[i] * 2));
                g_Results.DrawEllipse(Pens.Yellow, Convert.ToInt32(Cp[i].x - Outer[i]) * refMain.scale, Convert.ToInt32(Cp[i].y - Outer[i]) * refMain.scale, Convert.ToInt32(Outer[i] * 2), Convert.ToInt32(Outer[i] * 2));

                dataGridView2.Rows.Add(str[0], str[1], str[2], str[3], str[4], str[5]);
            }
            if (refMain.scale != 1)
            {
                err = iMatch.iDrawiMatchResults(refMain.NCCmodel, g_Results.GetHdc(), refMain.scale);
            }
            else
            {
                err = iMatch.iDrawiMatchResults(refMain.NCCmodel, g_Results.GetHdc(), 1);
            }

            //iROI.iROIDeleteROI
            //var error = iROI.iROIDeleteROI(refMain.MatchingROIToolManager);
            //iROI.iROIDeleteAll(refMain.MeasureROIToolManager);
            // iROI.iROIPlot(refMain.MatchingROIToolManager, refMain.hDC);
            refMain.ShowMeasureROI = refMain.ShowMatchingROI = false;
            
        }

        private void btn_ReadModel_Click(object sender, EventArgs e)
        {
            refMain.openFileDialog1.Filter = "iMatchModel file |*.imm";
            E_iVision_ERRORS err = E_iVision_ERRORS.E_NULL;
            if (refMain.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = refMain.openFileDialog1.FileName;

                err = iMatch.LoadiMatchModel(refMain.NCCmodel, path);

                if (err == E_iVision_ERRORS.E_OK)
                {
                    //更新參數到介面
                    iMatch.iGetOccurrence(refMain.NCCmodel,ref Max_objs);
                    iMatch.iGetAngle(refMain.NCCmodel, ref MaxAng, ref MinAng);
                    iMatch.iGetScale(refMain.NCCmodel, ref MaxScale, ref MinScale);
                    iMatch.iGetMinScore(refMain.NCCmodel, ref MinScore);
                    iMatch.iGetDontCareThreshold(refMain.NCCmodel, ref DontCarevalue);
                    iMatch.iGetMinReduceArea(refMain.NCCmodel, ref MinReduceArea);
                    iMatch.iGetFinalReduction(refMain.NCCmodel, ref FinalReduction);

                    iMatch.iGetIsRotated(refMain.NCCmodel,ref UsingRotation);
                    iMatch.iGetIsScaled(refMain.NCCmodel,ref UsingScale);
                    iMatch.iGetIsDontArea(refMain.NCCmodel, ref UsingMask);

                    tbx_objnums.Text = Max_objs.ToString();
                    tbx_maxang.Text = MaxAng.ToString();
                    tbx_minang.Text = MinAng.ToString();
                    tbx_maxscale.Text = MaxScale.ToString();
                    tbx_minscale.Text = MinScale.ToString();
                    tbx_minscore.Text = MinScore.ToString();
                    tbx_dontcarethreshold.Text = DontCarevalue.ToString();
                    tbx_MinReduceArea.Text = MinReduceArea.ToString();
                    tbx_FinalReduction.Text = FinalReduction.ToString();

                    if (UsingRotation)
                        cbx_rotation.CheckState = CheckState.Checked;
                    else
                        cbx_rotation.CheckState = CheckState.Unchecked;

                    if (UsingScale)
                        cbx_scale.CheckState = CheckState.Checked;
                    else
                        cbx_scale.CheckState = CheckState.Unchecked;

                    if (UsingMask)
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

            iMatch.iSetMinReduceArea(refMain.NCCmodel, MinReduceArea);
            iMatch.iSetMinScore(refMain.NCCmodel, MinScore);
            iMatch.iSetIsRotated(refMain.NCCmodel, UsingRotation);
            iMatch.iSetIsScaled(refMain.NCCmodel, UsingScale);
            iMatch.iSetIsDontArea(refMain.NCCmodel,UsingMask);
            iMatch.iSetOccurrence(refMain.NCCmodel, Max_objs);
            iMatch.iSetAngle(refMain.NCCmodel, MaxAng, MinAng);
            iMatch.iSetScale(refMain.NCCmodel, MaxScale, MinScale);
            iMatch.iSetDontCareThreshold(refMain.NCCmodel, DontCarevalue);
            iMatch.iGetFinalReduction(refMain.NCCmodel, ref FinalReduction);

            if (refMain.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = refMain.saveFileDialog1.FileName;

                err = iImage.iImageIsNULL(refMain.GrayImg);
                if (err == E_iVision_ERRORS.E_TRUE)
                {
                    MessageBox.Show(err.ToString(), "Error");
                    label2.Text = "Error";
                    return;
                }

                err = iMatch.SaveiMatchModel(refMain.NCCmodel, path);
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

            err = iMatch.iVisitingKey();
            if (err != E_iVision_ERRORS.E_OK)
            {
                MessageBox.Show(err.ToString(), "Error");
                label2.Text = "Error";
            }
            else
                label2.Text = "OK";

            err = iMCircle.iVisitingKey();
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
            Threshold = Convert.ToInt32(txt_Threshold.Text);
            Sampling = Convert.ToInt32(txt_SampingPoints.Text);
            IterationN = Convert.ToInt32(txt_iterationN.Text);
            iterationTh = Convert.ToDouble(txt_IterThreshold.Text);
            StartAngle = Convert.ToInt32(txt_StartAngle.Text);
            EndAngle = Convert.ToInt32(txt_EndAngle.Text);
            EdgeChoice = Convert.ToInt32(txt_EdgeChoice.Text);
            TransType = Convert.ToInt32(txt_Transition.Text);
        }
        private void btn_SetMatchingROI_Click(object sender, EventArgs e)
        {
            refMain.ShowMeasureROI = false;
            if (iROI.iROISize(refMain.MatchingROIToolManager) <3 )
            {
                iBaseROI l_base_roi;
                l_base_roi.OrgX = 150;
                l_base_roi.OrgY = 150;
                l_base_roi.Width = 50;
                l_base_roi.Height = 50;
                iROI.iROIAddBaseROI(refMain.MatchingROIToolManager, l_base_roi);
                iROI.iROIPlot(refMain.MatchingROIToolManager, refMain.hDC);
                refMain.ShowMatchingROI = true;
            }
            else
                label2.Text = "the size of ROI is > 2.";
        }

        private void btn_SetMeasureROI_Click(object sender, EventArgs e)
        {
            refMain.ShowMatchingROI = false;
            refMain.ShowMeasureROI = true;
            if (iROI.iROISize(refMain.MeasureROIToolManager) == 0)
            {
                iRingROI l_RingROI;
                l_RingROI.m_center_x = 80;
                l_RingROI.m_center_y = 80;
                l_RingROI.m_gap = 20;
                l_RingROI.m_radius = 50;
                iROI.iROIAddRingROI(refMain.MeasureROIToolManager, l_RingROI);
                iROI.iROIPlot(refMain.MeasureROIToolManager, refMain.hDC);
                refMain.ShowMeasureROI = true;
            }
            else
                label2.Text = "the size of ROI is > 1.";
        }

    }
}
