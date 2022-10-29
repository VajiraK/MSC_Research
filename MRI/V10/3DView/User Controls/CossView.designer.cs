namespace _3DView
{
	partial class CossView
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnSetAxis = new System.Windows.Forms.Button();
			this.btnResetAxis = new System.Windows.Forms.Button();
			this.trkPacity = new System.Windows.Forms.TrackBar();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trkPacity)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(89, 80);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(382, 248);
			this.panel1.TabIndex = 1;
			// 
			// btnSetAxis
			// 
			this.btnSetAxis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSetAxis.Enabled = false;
			this.btnSetAxis.Location = new System.Drawing.Point(310, 255);
			this.btnSetAxis.Name = "btnSetAxis";
			this.btnSetAxis.Size = new System.Drawing.Size(75, 23);
			this.btnSetAxis.TabIndex = 2;
			this.btnSetAxis.Text = "Set Axis";
			this.btnSetAxis.UseVisualStyleBackColor = true;
			this.btnSetAxis.Click += new System.EventHandler(this.cmdSetAxis_Click);
			// 
			// btnResetAxis
			// 
			this.btnResetAxis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnResetAxis.Enabled = false;
			this.btnResetAxis.Location = new System.Drawing.Point(229, 255);
			this.btnResetAxis.Name = "btnResetAxis";
			this.btnResetAxis.Size = new System.Drawing.Size(75, 23);
			this.btnResetAxis.TabIndex = 3;
			this.btnResetAxis.Text = "Reset Axis";
			this.btnResetAxis.UseVisualStyleBackColor = true;
			this.btnResetAxis.Click += new System.EventHandler(this.btnResetAxis_Click);
			// 
			// trkPacity
			// 
			this.trkPacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.trkPacity.Location = new System.Drawing.Point(3, 255);
			this.trkPacity.Maximum = 100;
			this.trkPacity.Minimum = 30;
			this.trkPacity.Name = "trkPacity";
			this.trkPacity.Size = new System.Drawing.Size(207, 45);
			this.trkPacity.TabIndex = 1;
			this.trkPacity.Value = 100;
			this.trkPacity.Scroll += new System.EventHandler(this.trkPacity_Scroll);
			// 
			// CossView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.trkPacity);
			this.Controls.Add(this.btnResetAxis);
			this.Controls.Add(this.btnSetAxis);
			this.Controls.Add(this.panel1);
			this.Name = "CossView";
			this.Size = new System.Drawing.Size(388, 283);
			this.Load += new System.EventHandler(this.CossView_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trkPacity)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSetAxis;
		private System.Windows.Forms.Button btnResetAxis;
		private System.Windows.Forms.TrackBar trkPacity;
	}
}
