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
            this.gbThreshold = new System.Windows.Forms.GroupBox();
            this.lbValue = new System.Windows.Forms.Label();
            this.sldThreshold = new Bunifu.Framework.UI.BunifuSlider();
            this.btn_Otsu = new System.Windows.Forms.Button();
            this.btn_Threshold = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_threshold = new System.Windows.Forms.TextBox();
            this.gbEdge = new System.Windows.Forms.GroupBox();
            this.btn_Edge = new System.Windows.Forms.Button();
            this.cmbBox_Edge = new System.Windows.Forms.ComboBox();
            this.gbConvolution = new System.Windows.Forms.GroupBox();
            this.btn_Convolution = new System.Windows.Forms.Button();
            this.cmbBox_Convolution = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbChoices = new System.Windows.Forms.ComboBox();
            this.lbImgProcessing = new System.Windows.Forms.ListBox();
            this.gbThreshold.SuspendLayout();
            this.gbEdge.SuspendLayout();
            this.gbConvolution.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            // gbThreshold
            // 
            this.gbThreshold.Controls.Add(this.lbValue);
            this.gbThreshold.Controls.Add(this.sldThreshold);
            this.gbThreshold.Controls.Add(this.btn_Otsu);
            this.gbThreshold.Controls.Add(this.btn_Threshold);
            this.gbThreshold.Controls.Add(this.label1);
            this.gbThreshold.Controls.Add(this.txt_threshold);
            this.gbThreshold.Location = new System.Drawing.Point(12, 12);
            this.gbThreshold.Name = "gbThreshold";
            this.gbThreshold.Size = new System.Drawing.Size(284, 62);
            this.gbThreshold.TabIndex = 1;
            this.gbThreshold.TabStop = false;
            this.gbThreshold.Text = "Threshold";
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
            this.txt_threshold.Text = "125";
            this.txt_threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbEdge
            // 
            this.gbEdge.Controls.Add(this.btn_Edge);
            this.gbEdge.Controls.Add(this.cmbBox_Edge);
            this.gbEdge.Location = new System.Drawing.Point(12, 80);
            this.gbEdge.Name = "gbEdge";
            this.gbEdge.Size = new System.Drawing.Size(284, 62);
            this.gbEdge.TabIndex = 2;
            this.gbEdge.TabStop = false;
            this.gbEdge.Text = "Edge";
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
            // gbConvolution
            // 
            this.gbConvolution.Controls.Add(this.btn_Convolution);
            this.gbConvolution.Controls.Add(this.cmbBox_Convolution);
            this.gbConvolution.Location = new System.Drawing.Point(12, 148);
            this.gbConvolution.Name = "gbConvolution";
            this.gbConvolution.Size = new System.Drawing.Size(284, 62);
            this.gbConvolution.TabIndex = 3;
            this.gbConvolution.TabStop = false;
            this.gbConvolution.Text = "Convolution";
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
            // cbChoices
            // 
            this.cbChoices.FormattingEnabled = true;
            this.cbChoices.Location = new System.Drawing.Point(335, 42);
            this.cbChoices.Name = "cbChoices";
            this.cbChoices.Size = new System.Drawing.Size(100, 20);
            this.cbChoices.TabIndex = 20;
            this.cbChoices.SelectedIndexChanged += new System.EventHandler(this.cbChoices_SelectedIndexChanged);
            // 
            // lbImgProcessing
            // 
            this.lbImgProcessing.FormattingEnabled = true;
            this.lbImgProcessing.ItemHeight = 12;
            this.lbImgProcessing.Items.AddRange(new object[] {
            "0. None",
            "1. None",
            "2. None"});
            this.lbImgProcessing.Location = new System.Drawing.Point(333, 98);
            this.lbImgProcessing.Name = "lbImgProcessing";
            this.lbImgProcessing.Size = new System.Drawing.Size(103, 76);
            this.lbImgProcessing.TabIndex = 19;
            // 
            // iImgProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 424);
            this.ControlBox = false;
            this.Controls.Add(this.cbChoices);
            this.Controls.Add(this.lbImgProcessing);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbConvolution);
            this.Controls.Add(this.gbEdge);
            this.Controls.Add(this.gbThreshold);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "iImgProcessForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "iImageProcess Demo";
            this.Load += new System.EventHandler(this.iImgProcessForm_Load);
            this.gbThreshold.ResumeLayout(false);
            this.gbThreshold.PerformLayout();
            this.gbEdge.ResumeLayout(false);
            this.gbConvolution.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gbThreshold;
        private System.Windows.Forms.Button btn_Threshold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_threshold;
        private System.Windows.Forms.Button btn_Otsu;
        private System.Windows.Forms.GroupBox gbEdge;
        private System.Windows.Forms.Button btn_Edge;
        private System.Windows.Forms.ComboBox cmbBox_Edge;
        private System.Windows.Forms.GroupBox gbConvolution;
        private System.Windows.Forms.Button btn_Convolution;
        private System.Windows.Forms.ComboBox cmbBox_Convolution;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private Bunifu.Framework.UI.BunifuSlider sldThreshold;
        private System.Windows.Forms.Label lbValue;
        private System.Windows.Forms.ComboBox cbChoices;
        private System.Windows.Forms.ListBox lbImgProcessing;
    }
}