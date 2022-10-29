namespace MeshCreator
{
	partial class DoubleSlider
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
			this.trkMin = new System.Windows.Forms.TrackBar();
			this.trkMax = new System.Windows.Forms.TrackBar();
			this.lblMin = new System.Windows.Forms.Label();
			this.lblMax = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.trkMin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trkMax)).BeginInit();
			this.SuspendLayout();
			// 
			// trkMin
			// 
			this.trkMin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.trkMin.Location = new System.Drawing.Point(22, 0);
			this.trkMin.Maximum = 255;
			this.trkMin.Name = "trkMin";
			this.trkMin.Size = new System.Drawing.Size(221, 45);
			this.trkMin.TabIndex = 0;
			this.trkMin.TickFrequency = 5;
			this.trkMin.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			this.trkMin.Scroll += new System.EventHandler(this.trkMin_Scroll);
			// 
			// trkMax
			// 
			this.trkMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.trkMax.Location = new System.Drawing.Point(22, 30);
			this.trkMax.Maximum = 255;
			this.trkMax.Name = "trkMax";
			this.trkMax.Size = new System.Drawing.Size(221, 45);
			this.trkMax.TabIndex = 1;
			this.trkMax.TickFrequency = 5;
			this.trkMax.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			this.trkMax.Scroll += new System.EventHandler(this.trkMax_Scroll);
			// 
			// lblMin
			// 
			this.lblMin.AutoSize = true;
			this.lblMin.BackColor = System.Drawing.Color.Black;
			this.lblMin.ForeColor = System.Drawing.Color.White;
			this.lblMin.Location = new System.Drawing.Point(3, 4);
			this.lblMin.Name = "lblMin";
			this.lblMin.Size = new System.Drawing.Size(13, 13);
			this.lblMin.TabIndex = 11;
			this.lblMin.Text = "0";
			// 
			// lblMax
			// 
			this.lblMax.AutoSize = true;
			this.lblMax.BackColor = System.Drawing.Color.Black;
			this.lblMax.ForeColor = System.Drawing.Color.White;
			this.lblMax.Location = new System.Drawing.Point(3, 32);
			this.lblMax.Name = "lblMax";
			this.lblMax.Size = new System.Drawing.Size(13, 13);
			this.lblMax.TabIndex = 12;
			this.lblMax.Text = "0";
			// 
			// DoubleSlider
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblMax);
			this.Controls.Add(this.lblMin);
			this.Controls.Add(this.trkMax);
			this.Controls.Add(this.trkMin);
			this.Name = "DoubleSlider";
			this.Size = new System.Drawing.Size(241, 65);
			this.Load += new System.EventHandler(this.DoubleSlider_Load);
			((System.ComponentModel.ISupportInitialize)(this.trkMin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trkMax)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TrackBar trkMin;
		private System.Windows.Forms.TrackBar trkMax;
		private System.Windows.Forms.Label lblMin;
		private System.Windows.Forms.Label lblMax;
	}
}
