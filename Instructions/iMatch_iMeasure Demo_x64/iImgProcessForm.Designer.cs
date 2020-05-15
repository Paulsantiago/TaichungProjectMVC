namespace Warp_Csharp
{
    partial class iImgProcessForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Otsu = new System.Windows.Forms.Button();
            this.btn_Threshold = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_threshold = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Edge = new System.Windows.Forms.Button();
            this.cmbBox_Edge = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_Convolution = new System.Windows.Forms.Button();
            this.cmbBox_Convolution = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_Mophology = new System.Windows.Forms.Button();
            this.cmbBox_Mophology = new System.Windows.Forms.ComboBox();
            this.txt_MaskSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rb_MaskTyp_Circle = new System.Windows.Forms.RadioButton();
            this.rb_MaskType_Diamond = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rb_MaskType_Rect = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_Arithmetic = new System.Windows.Forms.Button();
            this.cmbBox_Arithmetic = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txt_Offset = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Gain = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_LogicValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Logic = new System.Windows.Forms.Button();
            this.cmbBox_Logic = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rb_Scale = new System.Windows.Forms.RadioButton();
            this.rb_Shift = new System.Windows.Forms.RadioButton();
            this.rb_Rotation = new System.Windows.Forms.RadioButton();
            this.btn_Transform = new System.Windows.Forms.Button();
            this.txt_Shift = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Scale = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Rotation = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btn_Color = new System.Windows.Forms.Button();
            this.rb_Color2Gray = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.sldThreshold = new Bunifu.Framework.UI.BunifuSlider();
            this.lbValue = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(496, 335);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbValue);
            this.groupBox1.Controls.Add(this.sldThreshold);
            this.groupBox1.Controls.Add(this.btn_Otsu);
            this.groupBox1.Controls.Add(this.btn_Threshold);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_threshold);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 62);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Threshold";
            // 
            // btn_Otsu
            // 
            this.btn_Otsu.Location = new System.Drawing.Point(197, 14);
            this.btn_Otsu.Name = "btn_Otsu";
            this.btn_Otsu.Size = new System.Drawing.Size(75, 22);
            this.btn_Otsu.TabIndex = 3;
            this.btn_Otsu.Text = "Otsu";
            this.btn_Otsu.UseVisualStyleBackColor = true;
            this.btn_Otsu.Click += new System.EventHandler(this.btn_Otsu_Click);
            // 
            // btn_Threshold
            // 
            this.btn_Threshold.Location = new System.Drawing.Point(120, 14);
            this.btn_Threshold.Name = "btn_Threshold";
            this.btn_Threshold.Size = new System.Drawing.Size(65, 22);
            this.btn_Threshold.TabIndex = 2;
            this.btn_Threshold.Text = "Threshold";
            this.btn_Threshold.UseVisualStyleBackColor = true;
            this.btn_Threshold.Click += new System.EventHandler(this.btn_Threshold_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Value";
            // 
            // txt_threshold
            // 
            this.txt_threshold.Location = new System.Drawing.Point(66, 14);
            this.txt_threshold.Name = "txt_threshold";
            this.txt_threshold.Size = new System.Drawing.Size(45, 22);
            this.txt_threshold.TabIndex = 0;
            this.txt_threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Edge);
            this.groupBox2.Controls.Add(this.cmbBox_Edge);
            this.groupBox2.Location = new System.Drawing.Point(12, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 62);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edge";
            // 
            // btn_Edge
            // 
            this.btn_Edge.Location = new System.Drawing.Point(197, 18);
            this.btn_Edge.Name = "btn_Edge";
            this.btn_Edge.Size = new System.Drawing.Size(81, 33);
            this.btn_Edge.TabIndex = 5;
            this.btn_Edge.Text = "Go Edge";
            this.btn_Edge.UseVisualStyleBackColor = true;
            this.btn_Edge.Click += new System.EventHandler(this.btn_Edge_Click);
            // 
            // cmbBox_Edge
            // 
            this.cmbBox_Edge.FormattingEnabled = true;
            this.cmbBox_Edge.Items.AddRange(new object[] {
            "Sobel",
            "Lapliacian",
            "Robert",
            "Prewitt",
            "LaplacianSharping"});
            this.cmbBox_Edge.Location = new System.Drawing.Point(6, 25);
            this.cmbBox_Edge.Name = "cmbBox_Edge";
            this.cmbBox_Edge.Size = new System.Drawing.Size(162, 20);
            this.cmbBox_Edge.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_Convolution);
            this.groupBox3.Controls.Add(this.cmbBox_Convolution);
            this.groupBox3.Location = new System.Drawing.Point(302, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(284, 62);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Convolution";
            // 
            // btn_Convolution
            // 
            this.btn_Convolution.Location = new System.Drawing.Point(197, 17);
            this.btn_Convolution.Name = "btn_Convolution";
            this.btn_Convolution.Size = new System.Drawing.Size(81, 33);
            this.btn_Convolution.TabIndex = 1;
            this.btn_Convolution.Text = "Go Convolution";
            this.btn_Convolution.UseVisualStyleBackColor = true;
            this.btn_Convolution.Click += new System.EventHandler(this.btn_Convolution_Click);
            // 
            // cmbBox_Convolution
            // 
            this.cmbBox_Convolution.FormattingEnabled = true;
            this.cmbBox_Convolution.Items.AddRange(new object[] {
            "GaussianSmoothing 3*3",
            "GaussianSmoothing 5*5",
            "GaussianSmoothing 7*7",
            "MeanSmoothing 3*3",
            "MeanSmoothing 5*5",
            "MeanSmoothing 7*7",
            "MedianFilter 3*3",
            "MedianFilter 5*5"});
            this.cmbBox_Convolution.Location = new System.Drawing.Point(6, 24);
            this.cmbBox_Convolution.Name = "cmbBox_Convolution";
            this.cmbBox_Convolution.Size = new System.Drawing.Size(162, 20);
            this.cmbBox_Convolution.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_Mophology);
            this.groupBox4.Controls.Add(this.cmbBox_Mophology);
            this.groupBox4.Controls.Add(this.txt_MaskSize);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.rb_MaskTyp_Circle);
            this.groupBox4.Controls.Add(this.rb_MaskType_Diamond);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.rb_MaskType_Rect);
            this.groupBox4.Location = new System.Drawing.Point(14, 148);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(282, 130);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mophology";
            // 
            // btn_Mophology
            // 
            this.btn_Mophology.Location = new System.Drawing.Point(195, 87);
            this.btn_Mophology.Name = "btn_Mophology";
            this.btn_Mophology.Size = new System.Drawing.Size(81, 33);
            this.btn_Mophology.TabIndex = 10;
            this.btn_Mophology.Text = "Go Mophology";
            this.btn_Mophology.UseVisualStyleBackColor = true;
            this.btn_Mophology.Click += new System.EventHandler(this.btn_Mophology_Click);
            // 
            // cmbBox_Mophology
            // 
            this.cmbBox_Mophology.FormattingEnabled = true;
            this.cmbBox_Mophology.Items.AddRange(new object[] {
            "Dilation",
            "Erosion",
            "Opening",
            "Closing",
            "Gradient"});
            this.cmbBox_Mophology.Location = new System.Drawing.Point(5, 94);
            this.cmbBox_Mophology.Name = "cmbBox_Mophology";
            this.cmbBox_Mophology.Size = new System.Drawing.Size(161, 20);
            this.cmbBox_Mophology.TabIndex = 9;
            // 
            // txt_MaskSize
            // 
            this.txt_MaskSize.Location = new System.Drawing.Point(64, 61);
            this.txt_MaskSize.Name = "txt_MaskSize";
            this.txt_MaskSize.Size = new System.Drawing.Size(48, 22);
            this.txt_MaskSize.TabIndex = 8;
            this.txt_MaskSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mask Size";
            // 
            // rb_MaskTyp_Circle
            // 
            this.rb_MaskTyp_Circle.AutoSize = true;
            this.rb_MaskTyp_Circle.Location = new System.Drawing.Point(166, 38);
            this.rb_MaskTyp_Circle.Name = "rb_MaskTyp_Circle";
            this.rb_MaskTyp_Circle.Size = new System.Drawing.Size(51, 16);
            this.rb_MaskTyp_Circle.TabIndex = 6;
            this.rb_MaskTyp_Circle.Text = "Circle";
            this.rb_MaskTyp_Circle.UseVisualStyleBackColor = true;
            // 
            // rb_MaskType_Diamond
            // 
            this.rb_MaskType_Diamond.AutoSize = true;
            this.rb_MaskType_Diamond.Location = new System.Drawing.Point(77, 38);
            this.rb_MaskType_Diamond.Name = "rb_MaskType_Diamond";
            this.rb_MaskType_Diamond.Size = new System.Drawing.Size(66, 16);
            this.rb_MaskType_Diamond.TabIndex = 5;
            this.rb_MaskType_Diamond.Text = "Diamond";
            this.rb_MaskType_Diamond.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mask Type";
            // 
            // rb_MaskType_Rect
            // 
            this.rb_MaskType_Rect.AutoSize = true;
            this.rb_MaskType_Rect.Checked = true;
            this.rb_MaskType_Rect.Location = new System.Drawing.Point(10, 38);
            this.rb_MaskType_Rect.Name = "rb_MaskType_Rect";
            this.rb_MaskType_Rect.Size = new System.Drawing.Size(44, 16);
            this.rb_MaskType_Rect.TabIndex = 0;
            this.rb_MaskType_Rect.TabStop = true;
            this.rb_MaskType_Rect.Text = "Rect";
            this.rb_MaskType_Rect.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_Arithmetic);
            this.groupBox5.Controls.Add(this.cmbBox_Arithmetic);
            this.groupBox5.Location = new System.Drawing.Point(302, 80);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(284, 62);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Arithmetic";
            // 
            // btn_Arithmetic
            // 
            this.btn_Arithmetic.Location = new System.Drawing.Point(197, 17);
            this.btn_Arithmetic.Name = "btn_Arithmetic";
            this.btn_Arithmetic.Size = new System.Drawing.Size(81, 33);
            this.btn_Arithmetic.TabIndex = 8;
            this.btn_Arithmetic.Text = "Go Arithmetic";
            this.btn_Arithmetic.UseVisualStyleBackColor = true;
            this.btn_Arithmetic.Click += new System.EventHandler(this.btn_Arithmetic_Click);
            // 
            // cmbBox_Arithmetic
            // 
            this.cmbBox_Arithmetic.FormattingEnabled = true;
            this.cmbBox_Arithmetic.Items.AddRange(new object[] {
            "Image_ADD",
            "Image_SUB",
            "Image_Mul",
            "Image_DIV"});
            this.cmbBox_Arithmetic.Location = new System.Drawing.Point(6, 24);
            this.cmbBox_Arithmetic.Name = "cmbBox_Arithmetic";
            this.cmbBox_Arithmetic.Size = new System.Drawing.Size(162, 20);
            this.cmbBox_Arithmetic.TabIndex = 7;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txt_Offset);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.txt_Gain);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.txt_LogicValue);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.btn_Logic);
            this.groupBox6.Controls.Add(this.cmbBox_Logic);
            this.groupBox6.Location = new System.Drawing.Point(302, 148);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(284, 86);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Logic";
            // 
            // txt_Offset
            // 
            this.txt_Offset.Location = new System.Drawing.Point(230, 20);
            this.txt_Offset.Name = "txt_Offset";
            this.txt_Offset.Size = new System.Drawing.Size(48, 22);
            this.txt_Offset.TabIndex = 18;
            this.txt_Offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(192, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "Offset";
            // 
            // txt_Gain
            // 
            this.txt_Gain.Location = new System.Drawing.Point(136, 21);
            this.txt_Gain.Name = "txt_Gain";
            this.txt_Gain.Size = new System.Drawing.Size(48, 22);
            this.txt_Gain.TabIndex = 16;
            this.txt_Gain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(98, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "Gain";
            // 
            // txt_LogicValue
            // 
            this.txt_LogicValue.Location = new System.Drawing.Point(44, 23);
            this.txt_LogicValue.Name = "txt_LogicValue";
            this.txt_LogicValue.Size = new System.Drawing.Size(48, 22);
            this.txt_LogicValue.TabIndex = 14;
            this.txt_LogicValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "Value";
            // 
            // btn_Logic
            // 
            this.btn_Logic.Location = new System.Drawing.Point(197, 44);
            this.btn_Logic.Name = "btn_Logic";
            this.btn_Logic.Size = new System.Drawing.Size(81, 33);
            this.btn_Logic.TabIndex = 8;
            this.btn_Logic.Text = "Go Logic";
            this.btn_Logic.UseVisualStyleBackColor = true;
            this.btn_Logic.Click += new System.EventHandler(this.btn_Logic_Click);
            // 
            // cmbBox_Logic
            // 
            this.cmbBox_Logic.FormattingEnabled = true;
            this.cmbBox_Logic.Items.AddRange(new object[] {
            "ShiftLeft",
            "ShiftRight",
            "BitwiseAND",
            "BitwiseOR",
            "BitwiseXOR",
            "Equal",
            "NOTEqual",
            "Invert",
            "GainOffect"});
            this.cmbBox_Logic.Location = new System.Drawing.Point(6, 51);
            this.cmbBox_Logic.Name = "cmbBox_Logic";
            this.cmbBox_Logic.Size = new System.Drawing.Size(162, 20);
            this.cmbBox_Logic.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 402);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(601, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rb_Scale);
            this.groupBox7.Controls.Add(this.rb_Shift);
            this.groupBox7.Controls.Add(this.rb_Rotation);
            this.groupBox7.Controls.Add(this.btn_Transform);
            this.groupBox7.Controls.Add(this.txt_Shift);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.txt_Scale);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.txt_Rotation);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Location = new System.Drawing.Point(302, 240);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(284, 91);
            this.groupBox7.TabIndex = 13;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Transformation";
            // 
            // rb_Scale
            // 
            this.rb_Scale.AutoSize = true;
            this.rb_Scale.Location = new System.Drawing.Point(124, 57);
            this.rb_Scale.Name = "rb_Scale";
            this.rb_Scale.Size = new System.Drawing.Size(47, 16);
            this.rb_Scale.TabIndex = 32;
            this.rb_Scale.Text = "Scale";
            this.rb_Scale.UseVisualStyleBackColor = true;
            // 
            // rb_Shift
            // 
            this.rb_Shift.AutoSize = true;
            this.rb_Shift.Location = new System.Drawing.Point(73, 57);
            this.rb_Shift.Name = "rb_Shift";
            this.rb_Shift.Size = new System.Drawing.Size(45, 16);
            this.rb_Shift.TabIndex = 31;
            this.rb_Shift.Text = "Shift";
            this.rb_Shift.UseVisualStyleBackColor = true;
            // 
            // rb_Rotation
            // 
            this.rb_Rotation.AutoSize = true;
            this.rb_Rotation.Checked = true;
            this.rb_Rotation.Location = new System.Drawing.Point(8, 57);
            this.rb_Rotation.Name = "rb_Rotation";
            this.rb_Rotation.Size = new System.Drawing.Size(63, 16);
            this.rb_Rotation.TabIndex = 30;
            this.rb_Rotation.TabStop = true;
            this.rb_Rotation.Text = "Rotation";
            this.rb_Rotation.UseVisualStyleBackColor = true;
            // 
            // btn_Transform
            // 
            this.btn_Transform.Location = new System.Drawing.Point(197, 49);
            this.btn_Transform.Name = "btn_Transform";
            this.btn_Transform.Size = new System.Drawing.Size(81, 33);
            this.btn_Transform.TabIndex = 29;
            this.btn_Transform.Text = "Go Transform";
            this.btn_Transform.UseVisualStyleBackColor = true;
            this.btn_Transform.Click += new System.EventHandler(this.btn_Transform_Click);
            // 
            // txt_Shift
            // 
            this.txt_Shift.Location = new System.Drawing.Point(140, 21);
            this.txt_Shift.Name = "txt_Shift";
            this.txt_Shift.Size = new System.Drawing.Size(48, 22);
            this.txt_Shift.TabIndex = 28;
            this.txt_Shift.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(107, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "Shift";
            // 
            // txt_Scale
            // 
            this.txt_Scale.Location = new System.Drawing.Point(227, 21);
            this.txt_Scale.Name = "txt_Scale";
            this.txt_Scale.Size = new System.Drawing.Size(48, 22);
            this.txt_Scale.TabIndex = 26;
            this.txt_Scale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(194, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "Scale";
            // 
            // txt_Rotation
            // 
            this.txt_Rotation.Location = new System.Drawing.Point(53, 21);
            this.txt_Rotation.Name = "txt_Rotation";
            this.txt_Rotation.Size = new System.Drawing.Size(48, 22);
            this.txt_Rotation.TabIndex = 24;
            this.txt_Rotation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 12);
            this.label8.TabIndex = 23;
            this.label8.Text = "Rotation";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btn_Color);
            this.groupBox8.Controls.Add(this.rb_Color2Gray);
            this.groupBox8.Location = new System.Drawing.Point(12, 284);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(284, 54);
            this.groupBox8.TabIndex = 14;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "iColor";
            // 
            // btn_Color
            // 
            this.btn_Color.Location = new System.Drawing.Point(197, 12);
            this.btn_Color.Name = "btn_Color";
            this.btn_Color.Size = new System.Drawing.Size(81, 33);
            this.btn_Color.TabIndex = 36;
            this.btn_Color.Text = "Go Color";
            this.btn_Color.UseVisualStyleBackColor = true;
            this.btn_Color.Click += new System.EventHandler(this.btn_Color_Click);
            // 
            // rb_Color2Gray
            // 
            this.rb_Color2Gray.AutoSize = true;
            this.rb_Color2Gray.Checked = true;
            this.rb_Color2Gray.Location = new System.Drawing.Point(12, 21);
            this.rb_Color2Gray.Name = "rb_Color2Gray";
            this.rb_Color2Gray.Size = new System.Drawing.Size(86, 16);
            this.rb_Color2Gray.TabIndex = 33;
            this.rb_Color2Gray.TabStop = true;
            this.rb_Color2Gray.Text = "ColorToGray";
            this.rb_Color2Gray.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 349);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 33);
            this.button2.TabIndex = 15;
            this.button2.Text = "iVisitingKey";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // sldThreshold
            // 
            this.sldThreshold.BackColor = System.Drawing.Color.Transparent;
            this.sldThreshold.BackgroudColor = System.Drawing.Color.DarkGray;
            this.sldThreshold.BorderRadius = 0;
            this.sldThreshold.IndicatorColor = System.Drawing.Color.SeaGreen;
            this.sldThreshold.Location = new System.Drawing.Point(26, 42);
            this.sldThreshold.MaximumValue = 255;
            this.sldThreshold.Name = "sldThreshold";
            this.sldThreshold.Size = new System.Drawing.Size(183, 28);
            this.sldThreshold.TabIndex = 4;
            this.sldThreshold.Value = 0;
            this.sldThreshold.ValueChanged += new System.EventHandler(this.sldThreshold_ValueChanged);
            // 
            // lbValue
            // 
            this.lbValue.AutoSize = true;
            this.lbValue.Location = new System.Drawing.Point(225, 47);
            this.lbValue.Name = "lbValue";
            this.lbValue.Size = new System.Drawing.Size(32, 12);
            this.lbValue.TabIndex = 5;
            this.lbValue.Text = "00.00";
            // 
            // iImgProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 424);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "iImgProcessForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "iImageProcess Demo";
            this.Load += new System.EventHandler(this.iImgProcessForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Threshold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_threshold;
        private System.Windows.Forms.Button btn_Otsu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Edge;
        private System.Windows.Forms.ComboBox cmbBox_Edge;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_Convolution;
        private System.Windows.Forms.ComboBox cmbBox_Convolution;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rb_MaskTyp_Circle;
        private System.Windows.Forms.RadioButton rb_MaskType_Diamond;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rb_MaskType_Rect;
        private System.Windows.Forms.TextBox txt_MaskSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Mophology;
        private System.Windows.Forms.ComboBox cmbBox_Mophology;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_Arithmetic;
        private System.Windows.Forms.ComboBox cmbBox_Arithmetic;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btn_Logic;
        private System.Windows.Forms.ComboBox cmbBox_Logic;
        private System.Windows.Forms.TextBox txt_LogicValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.TextBox txt_Offset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Gain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btn_Transform;
        private System.Windows.Forms.TextBox txt_Shift;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Scale;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Rotation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rb_Scale;
        private System.Windows.Forms.RadioButton rb_Shift;
        private System.Windows.Forms.RadioButton rb_Rotation;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton rb_Color2Gray;
        private System.Windows.Forms.Button btn_Color;
        private System.Windows.Forms.Button button2;
        private Bunifu.Framework.UI.BunifuSlider sldThreshold;
        private System.Windows.Forms.Label lbValue;
    }
}