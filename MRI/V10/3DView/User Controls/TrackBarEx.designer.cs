namespace _3DView
{
	partial class TrackBarEx
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
			this.lblVal = new System.Windows.Forms.Label();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.lblName = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// lblVal
			// 
			this.lblVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblVal.Location = new System.Drawing.Point(190, 6);
			this.lblVal.Name = "lblVal";
			this.lblVal.Size = new System.Drawing.Size(41, 23);
			this.lblVal.TabIndex = 7;
			this.lblVal.Text = "0";
			this.lblVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// trackBar1
			// 
			this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.trackBar1.LargeChange = 1;
			this.trackBar1.Location = new System.Drawing.Point(34, 3);
			this.trackBar1.Maximum = 300;
			this.trackBar1.Minimum = -300;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(154, 45);
			this.trackBar1.TabIndex = 6;
			this.trackBar1.TickFrequency = 20;
			this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// lblName
			// 
			this.lblName.Location = new System.Drawing.Point(4, 6);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(32, 23);
			this.lblName.TabIndex = 5;
			this.lblName.Text = "X";
			this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TrackBarEx
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblVal);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.lblName);
			this.Name = "TrackBarEx";
			this.Size = new System.Drawing.Size(235, 42);
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblVal;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Label lblName;
	}
}
