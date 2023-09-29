using ExtremeKaraokeMng.cls;

namespace ExtremeKaraokeMng.frm
{
    partial class frmMain
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
            this.btnRunNCN = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRunEMK = new System.Windows.Forms.Button();
            this.myProgressBar2 = new TORServices.Forms.MyProgressBar();
            this.myProgressBar1 = new TORServices.Forms.MyProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.textboxOpenPath3 = new ExtremeKaraokeMng.cls.TextboxOpenPath();
            this.label3 = new System.Windows.Forms.Label();
            this.textboxOpenPath1 = new ExtremeKaraokeMng.cls.TextboxOpenPath();
            this.label1 = new System.Windows.Forms.Label();
            this.sONGDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sONGDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRunNCN
            // 
            this.btnRunNCN.Location = new System.Drawing.Point(592, 19);
            this.btnRunNCN.Name = "btnRunNCN";
            this.btnRunNCN.Size = new System.Drawing.Size(160, 23);
            this.btnRunNCN.TabIndex = 9;
            this.btnRunNCN.Text = "ย้ายไฟล์เพลง NCN";
            this.btnRunNCN.UseVisualStyleBackColor = true;
            this.btnRunNCN.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRunEMK);
            this.panel1.Controls.Add(this.myProgressBar2);
            this.panel1.Controls.Add(this.myProgressBar1);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.btnCheck);
            this.panel1.Controls.Add(this.textboxOpenPath3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textboxOpenPath1);
            this.panel1.Controls.Add(this.btnRunNCN);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1263, 272);
            this.panel1.TabIndex = 1;
            // 
            // btnRunEMK
            // 
            this.btnRunEMK.Location = new System.Drawing.Point(771, 19);
            this.btnRunEMK.Name = "btnRunEMK";
            this.btnRunEMK.Size = new System.Drawing.Size(160, 23);
            this.btnRunEMK.TabIndex = 15;
            this.btnRunEMK.Text = "ย้ายไฟล์เพลง EMK";
            this.btnRunEMK.UseVisualStyleBackColor = true;
            this.btnRunEMK.Click += new System.EventHandler(this.btnRunEMK_Click);
            // 
            // myProgressBar2
            // 
            this.myProgressBar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.myProgressBar2.Location = new System.Drawing.Point(0, 196);
            this.myProgressBar2.Name = "myProgressBar2";
            this.myProgressBar2.Size = new System.Drawing.Size(1263, 38);
            this.myProgressBar2.TabIndex = 14;
            // 
            // myProgressBar1
            // 
            this.myProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.myProgressBar1.Location = new System.Drawing.Point(0, 234);
            this.myProgressBar1.Name = "myProgressBar1";
            this.myProgressBar1.Size = new System.Drawing.Size(1263, 38);
            this.myProgressBar1.TabIndex = 13;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(23, 86);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(22, 13);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = ".....";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(592, 51);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(160, 23);
            this.btnCheck.TabIndex = 12;
            this.btnCheck.Text = "ตรวจสอบเพลงซ้ำ";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // textboxOpenPath3
            // 
            this.textboxOpenPath3.Direvtory = "";
            this.textboxOpenPath3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textboxOpenPath3.Location = new System.Drawing.Point(109, 44);
            this.textboxOpenPath3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textboxOpenPath3.Name = "textboxOpenPath3";
            this.textboxOpenPath3.Size = new System.Drawing.Size(475, 33);
            this.textboxOpenPath3.TabIndex = 11;
            this.textboxOpenPath3.DirevtoryChanged += new System.EventHandler(this.textboxOpenPath3_DirevtoryChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Path Karaoke run:";
            // 
            // textboxOpenPath1
            // 
            this.textboxOpenPath1.Direvtory = "";
            this.textboxOpenPath1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textboxOpenPath1.Location = new System.Drawing.Point(109, 13);
            this.textboxOpenPath1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textboxOpenPath1.Name = "textboxOpenPath1";
            this.textboxOpenPath1.Size = new System.Drawing.Size(475, 33);
            this.textboxOpenPath1.TabIndex = 6;
            this.textboxOpenPath1.DirevtoryChanged += new System.EventHandler(this.textboxOpenPath1_DirevtoryChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "PathKaraoke:";
            // 
            // sONGDataGridView
            // 
            this.sONGDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sONGDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.sONGDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sONGDataGridView.Location = new System.Drawing.Point(0, 272);
            this.sONGDataGridView.Name = "sONGDataGridView";
            this.sONGDataGridView.Size = new System.Drawing.Size(1263, 314);
            this.sONGDataGridView.TabIndex = 10;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "CODE";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 586);
            this.Controls.Add(this.sONGDataGridView);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sONGDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private TextboxOpenPath textboxOpenPath1;
        private System.Windows.Forms.Button btnRunNCN;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnCheck;
        private TextboxOpenPath textboxOpenPath3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView sONGDataGridView;
        private TORServices.Forms.MyProgressBar myProgressBar1;
        private TORServices.Forms.MyProgressBar myProgressBar2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button btnRunEMK;
    }
}