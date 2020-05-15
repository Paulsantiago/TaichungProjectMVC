namespace Warp_Csharp
{
    partial class Mainfrm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nCCMatchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openNCCDialogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImgProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_LoadGrayImg = new System.Windows.Forms.Button();
            this.cbScale = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nCCMatchingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(831, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nCCMatchingToolStripMenuItem
            // 
            this.nCCMatchingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openNCCDialogToolStripMenuItem,
            this.openImgProcessingToolStripMenuItem});
            this.nCCMatchingToolStripMenuItem.Name = "nCCMatchingToolStripMenuItem";
            this.nCCMatchingToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.nCCMatchingToolStripMenuItem.Text = "Dialog";
            // 
            // openNCCDialogToolStripMenuItem
            // 
            this.openNCCDialogToolStripMenuItem.Name = "openNCCDialogToolStripMenuItem";
            this.openNCCDialogToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.openNCCDialogToolStripMenuItem.Text = "Open Matching Measure";
            this.openNCCDialogToolStripMenuItem.Click += new System.EventHandler(this.openNCCDialogToolStripMenuItem_Click);
            // 
            // openImgProcessingToolStripMenuItem
            // 
            this.openImgProcessingToolStripMenuItem.Name = "openImgProcessingToolStripMenuItem";
            this.openImgProcessingToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.openImgProcessingToolStripMenuItem.Text = "Open Img Processing";
            this.openImgProcessingToolStripMenuItem.Click += new System.EventHandler(this.openImgProcessingToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(21, 82);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(780, 600);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Picbox_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Picbox_MouseMove);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_LoadGrayImg);
            this.panel1.Controls.Add(this.cbScale);
            this.panel1.Location = new System.Drawing.Point(20, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 41);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(406, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "NULL";
            // 
            // btn_LoadGrayImg
            // 
            this.btn_LoadGrayImg.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_LoadGrayImg.Location = new System.Drawing.Point(21, 3);
            this.btn_LoadGrayImg.Name = "btn_LoadGrayImg";
            this.btn_LoadGrayImg.Size = new System.Drawing.Size(115, 32);
            this.btn_LoadGrayImg.TabIndex = 3;
            this.btn_LoadGrayImg.Text = "Load Gray Img";
            this.btn_LoadGrayImg.UseVisualStyleBackColor = true;
            this.btn_LoadGrayImg.Click += new System.EventHandler(this.btn_LoadGrayImg_Click);
            // 
            // cbScale
            // 
            this.cbScale.DisplayMember = "1 : 1";
            this.cbScale.FormattingEnabled = true;
            this.cbScale.Items.AddRange(new object[] {
            "1 : 0.5",
            "1 : 0.75",
            "1 : 1",
            "1 : 1.5",
            "1 : 0.25"});
            this.cbScale.Location = new System.Drawing.Point(251, 0);
            this.cbScale.Name = "cbScale";
            this.cbScale.Size = new System.Drawing.Size(125, 20);
            this.cbScale.TabIndex = 0;
            this.cbScale.SelectedIndexChanged += new System.EventHandler(this.cbScale_SelectedIndexChanged);
            // 
            // Mainfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 692);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Mainfrm";
            this.Text = "MiM Tech. iMatch_iMeasure Demo_x64";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Mainfrm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nCCMatchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openNCCDialogToolStripMenuItem;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbScale;
        private System.Windows.Forms.Button btn_LoadGrayImg;
        private System.Windows.Forms.ToolStripMenuItem openImgProcessingToolStripMenuItem;
        private System.Windows.Forms.Label label2;
    }
}

