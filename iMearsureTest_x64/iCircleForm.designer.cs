namespace iMearsureTest
{
    partial class iCircleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Transition = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_EndAngle = new System.Windows.Forms.TextBox();
            this.txt_StartAngle = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_EdgeChoice = new System.Windows.Forms.TextBox();
            this.txt_IterThreshold = new System.Windows.Forms.TextBox();
            this.txt_iterationN = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_SampingPoints = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Threshold = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_ResultR = new System.Windows.Forms.TextBox();
            this.txt_ResultCy = new System.Windows.Forms.TextBox();
            this.txt_ResultCx = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Time = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_PL_Difference = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_Roundness_per = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Roundness = new System.Windows.Forms.TextBox();
            this.btn_LoadImg = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_SetRingROI = new System.Windows.Forms.Button();
            this.btn_SetRingParaiM = new System.Windows.Forms.Button();
            this.btn_Measurement = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label_State = new System.Windows.Forms.Label();
            this.btn_AdvRing = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dgslope = new System.Windows.Forms.DataGridView();
            this.puntos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slope = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgslope)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Transition);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_EndAngle);
            this.groupBox1.Controls.Add(this.txt_StartAngle);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txt_EdgeChoice);
            this.groupBox1.Controls.Add(this.txt_IterThreshold);
            this.groupBox1.Controls.Add(this.txt_iterationN);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_SampingPoints);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_Threshold);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 230);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // txt_Transition
            // 
            this.txt_Transition.Location = new System.Drawing.Point(114, 202);
            this.txt_Transition.Name = "txt_Transition";
            this.txt_Transition.Size = new System.Drawing.Size(67, 22);
            this.txt_Transition.TabIndex = 26;
            this.txt_Transition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(7, 205);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 16);
            this.label10.TabIndex = 25;
            this.label10.Text = "TransitionType";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(3, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Sampling Points";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(37, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Threshold";
            // 
            // txt_EndAngle
            // 
            this.txt_EndAngle.Location = new System.Drawing.Point(114, 153);
            this.txt_EndAngle.Name = "txt_EndAngle";
            this.txt_EndAngle.Size = new System.Drawing.Size(67, 22);
            this.txt_EndAngle.TabIndex = 22;
            this.txt_EndAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_StartAngle
            // 
            this.txt_StartAngle.Location = new System.Drawing.Point(114, 126);
            this.txt_StartAngle.Name = "txt_StartAngle";
            this.txt_StartAngle.Size = new System.Drawing.Size(67, 22);
            this.txt_StartAngle.TabIndex = 21;
            this.txt_StartAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(32, 151);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 16);
            this.label12.TabIndex = 20;
            this.label12.Text = "End Angle";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(32, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 16);
            this.label11.TabIndex = 19;
            this.label11.Text = "Start Angle";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(24, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "EdgeChoice";
            // 
            // txt_EdgeChoice
            // 
            this.txt_EdgeChoice.Location = new System.Drawing.Point(114, 178);
            this.txt_EdgeChoice.Name = "txt_EdgeChoice";
            this.txt_EdgeChoice.Size = new System.Drawing.Size(67, 22);
            this.txt_EdgeChoice.TabIndex = 13;
            this.txt_EdgeChoice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_IterThreshold
            // 
            this.txt_IterThreshold.Location = new System.Drawing.Point(114, 99);
            this.txt_IterThreshold.Name = "txt_IterThreshold";
            this.txt_IterThreshold.Size = new System.Drawing.Size(67, 22);
            this.txt_IterThreshold.TabIndex = 11;
            this.txt_IterThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_iterationN
            // 
            this.txt_iterationN.Location = new System.Drawing.Point(114, 73);
            this.txt_iterationN.Name = "txt_iterationN";
            this.txt_iterationN.Size = new System.Drawing.Size(67, 22);
            this.txt_iterationN.TabIndex = 3;
            this.txt_iterationN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(32, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "iteration Th";
            // 
            // txt_SampingPoints
            // 
            this.txt_SampingPoints.Location = new System.Drawing.Point(114, 45);
            this.txt_SampingPoints.Name = "txt_SampingPoints";
            this.txt_SampingPoints.Size = new System.Drawing.Size(67, 22);
            this.txt_SampingPoints.TabIndex = 2;
            this.txt_SampingPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(34, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "iteration N";
            // 
            // txt_Threshold
            // 
            this.txt_Threshold.Location = new System.Drawing.Point(114, 17);
            this.txt_Threshold.Name = "txt_Threshold";
            this.txt_Threshold.Size = new System.Drawing.Size(67, 22);
            this.txt_Threshold.TabIndex = 1;
            this.txt_Threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_ResultR);
            this.groupBox2.Controls.Add(this.txt_ResultCy);
            this.groupBox2.Controls.Add(this.txt_ResultCx);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 89);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // txt_ResultR
            // 
            this.txt_ResultR.Location = new System.Drawing.Point(40, 48);
            this.txt_ResultR.Name = "txt_ResultR";
            this.txt_ResultR.Size = new System.Drawing.Size(52, 22);
            this.txt_ResultR.TabIndex = 15;
            this.txt_ResultR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_ResultCy
            // 
            this.txt_ResultCy.Location = new System.Drawing.Point(127, 18);
            this.txt_ResultCy.Name = "txt_ResultCy";
            this.txt_ResultCy.Size = new System.Drawing.Size(52, 22);
            this.txt_ResultCy.TabIndex = 14;
            this.txt_ResultCy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_ResultCx
            // 
            this.txt_ResultCx.Location = new System.Drawing.Point(41, 18);
            this.txt_ResultCx.Name = "txt_ResultCx";
            this.txt_ResultCx.Size = new System.Drawing.Size(52, 22);
            this.txt_ResultCx.TabIndex = 4;
            this.txt_ResultCx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(14, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "R";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(97, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Cy";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(13, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Cx";
            // 
            // txt_Time
            // 
            this.txt_Time.Location = new System.Drawing.Point(327, 211);
            this.txt_Time.Name = "txt_Time";
            this.txt_Time.Size = new System.Drawing.Size(79, 22);
            this.txt_Time.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(412, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "ms";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(222, 305);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 16);
            this.label16.TabIndex = 37;
            this.label16.Text = "PL_Difference";
            // 
            // txt_PL_Difference
            // 
            this.txt_PL_Difference.Location = new System.Drawing.Point(327, 302);
            this.txt_PL_Difference.Name = "txt_PL_Difference";
            this.txt_PL_Difference.Size = new System.Drawing.Size(72, 22);
            this.txt_PL_Difference.TabIndex = 36;
            this.txt_PL_Difference.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(405, 279);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 12);
            this.label15.TabIndex = 35;
            this.label15.Text = "%";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(244, 275);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 16);
            this.label14.TabIndex = 34;
            this.label14.Text = "Roundness";
            // 
            // txt_Roundness_per
            // 
            this.txt_Roundness_per.Location = new System.Drawing.Point(327, 271);
            this.txt_Roundness_per.Name = "txt_Roundness_per";
            this.txt_Roundness_per.Size = new System.Drawing.Size(72, 22);
            this.txt_Roundness_per.TabIndex = 33;
            this.txt_Roundness_per.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(239, 245);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 16);
            this.label13.TabIndex = 32;
            this.label13.Text = "Roundness";
            // 
            // txt_Roundness
            // 
            this.txt_Roundness.Location = new System.Drawing.Point(327, 242);
            this.txt_Roundness.Name = "txt_Roundness";
            this.txt_Roundness.Size = new System.Drawing.Size(72, 22);
            this.txt_Roundness.TabIndex = 31;
            this.txt_Roundness.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_LoadImg
            // 
            this.btn_LoadImg.Location = new System.Drawing.Point(235, 22);
            this.btn_LoadImg.Name = "btn_LoadImg";
            this.btn_LoadImg.Size = new System.Drawing.Size(86, 32);
            this.btn_LoadImg.TabIndex = 38;
            this.btn_LoadImg.Text = "Load Image";
            this.btn_LoadImg.UseVisualStyleBackColor = true;
            this.btn_LoadImg.Click += new System.EventHandler(this.btn_LoadImg_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_SetRingROI
            // 
            this.btn_SetRingROI.Location = new System.Drawing.Point(235, 60);
            this.btn_SetRingROI.Name = "btn_SetRingROI";
            this.btn_SetRingROI.Size = new System.Drawing.Size(86, 32);
            this.btn_SetRingROI.TabIndex = 39;
            this.btn_SetRingROI.Text = "Add Ring";
            this.btn_SetRingROI.UseVisualStyleBackColor = true;
            this.btn_SetRingROI.Click += new System.EventHandler(this.btn_SetRingROI_Click);
            // 
            // btn_SetRingParaiM
            // 
            this.btn_SetRingParaiM.Location = new System.Drawing.Point(235, 98);
            this.btn_SetRingParaiM.Name = "btn_SetRingParaiM";
            this.btn_SetRingParaiM.Size = new System.Drawing.Size(86, 32);
            this.btn_SetRingParaiM.TabIndex = 40;
            this.btn_SetRingParaiM.Text = "SetPara";
            this.btn_SetRingParaiM.UseVisualStyleBackColor = true;
            this.btn_SetRingParaiM.Click += new System.EventHandler(this.btn_SetParaiM_Click);
            // 
            // btn_Measurement
            // 
            this.btn_Measurement.Location = new System.Drawing.Point(235, 136);
            this.btn_Measurement.Name = "btn_Measurement";
            this.btn_Measurement.Size = new System.Drawing.Size(86, 32);
            this.btn_Measurement.TabIndex = 41;
            this.btn_Measurement.Text = "Measurement";
            this.btn_Measurement.UseVisualStyleBackColor = true;
            this.btn_Measurement.Click += new System.EventHandler(this.btn_Measurement_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(235, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 32);
            this.button1.TabIndex = 42;
            this.button1.Text = "iVisitingKey";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(333, 22);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(86, 31);
            this.button7.TabIndex = 44;
            this.button7.Text = "ROI_Attached";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(333, 99);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(86, 29);
            this.button8.TabIndex = 45;
            this.button8.Text = "Delete ROI";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label_State
            // 
            this.label_State.AutoSize = true;
            this.label_State.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_State.Location = new System.Drawing.Point(341, 184);
            this.label_State.Name = "label_State";
            this.label_State.Size = new System.Drawing.Size(0, 16);
            this.label_State.TabIndex = 47;
            // 
            // btn_AdvRing
            // 
            this.btn_AdvRing.Location = new System.Drawing.Point(333, 62);
            this.btn_AdvRing.Name = "btn_AdvRing";
            this.btn_AdvRing.Size = new System.Drawing.Size(86, 29);
            this.btn_AdvRing.TabIndex = 48;
            this.btn_AdvRing.Text = "Add AdvRing";
            this.btn_AdvRing.UseVisualStyleBackColor = true;
            this.btn_AdvRing.Click += new System.EventHandler(this.btn_AdvRing_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(336, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 29);
            this.button2.TabIndex = 49;
            this.button2.Text = "plot val";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgslope
            // 
            this.dgslope.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgslope.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.puntos,
            this.slope,
            this.pts});
            this.dgslope.Location = new System.Drawing.Point(457, -3);
            this.dgslope.Name = "dgslope";
            this.dgslope.RowTemplate.Height = 24;
            this.dgslope.Size = new System.Drawing.Size(345, 395);
            this.dgslope.TabIndex = 50;
            // 
            // puntos
            // 
            this.puntos.HeaderText = "num";
            this.puntos.Name = "puntos";
            // 
            // slope
            // 
            this.slope.HeaderText = "slope";
            this.slope.Name = "slope";
            // 
            // pts
            // 
            this.pts.HeaderText = "Puntos";
            this.pts.Name = "pts";
            // 
            // iCircleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 404);
            this.Controls.Add(this.dgslope);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_AdvRing);
            this.Controls.Add(this.label_State);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Measurement);
            this.Controls.Add(this.btn_SetRingParaiM);
            this.Controls.Add(this.btn_SetRingROI);
            this.Controls.Add(this.btn_LoadImg);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txt_PL_Difference);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txt_Roundness_per);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt_Roundness);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_Time);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "iCircleForm";
            this.Text = "iCircleForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgslope)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_EndAngle;
        private System.Windows.Forms.TextBox txt_StartAngle;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_EdgeChoice;
        private System.Windows.Forms.TextBox txt_IterThreshold;
        private System.Windows.Forms.TextBox txt_iterationN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_SampingPoints;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Threshold;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_ResultR;
        private System.Windows.Forms.TextBox txt_ResultCy;
        private System.Windows.Forms.TextBox txt_ResultCx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Time;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_PL_Difference;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_Roundness_per;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_Roundness;
        private System.Windows.Forms.Button btn_LoadImg;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_SetRingROI;
        private System.Windows.Forms.Button btn_SetRingParaiM;
        private System.Windows.Forms.Button btn_Measurement;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label_State;
        private System.Windows.Forms.Button btn_AdvRing;
        private System.Windows.Forms.TextBox txt_Transition;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgslope;
        private System.Windows.Forms.DataGridViewTextBoxColumn puntos;
        private System.Windows.Forms.DataGridViewTextBoxColumn slope;
        private System.Windows.Forms.DataGridViewTextBoxColumn pts;
    }
}