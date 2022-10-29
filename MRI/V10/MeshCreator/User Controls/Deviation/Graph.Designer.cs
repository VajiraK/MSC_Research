namespace MeshCreator
{
	partial class Graph
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
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblAxis = new System.Windows.Forms.Label();
			this.lblAxisMax = new System.Windows.Forms.Label();
			this.lblAxisMin = new System.Windows.Forms.Label();
			this.lblAxisMid = new System.Windows.Forms.Label();
			this.lblSlideMax = new System.Windows.Forms.Label();
			this.lblSlideMid = new System.Windows.Forms.Label();
			this.lblSlideMin = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(193, 295);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Slides";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.White;
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(35, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(370, 250);
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// lblAxis
			// 
			this.lblAxis.AutoSize = true;
			this.lblAxis.Location = new System.Drawing.Point(35, 0);
			this.lblAxis.Name = "lblAxis";
			this.lblAxis.Size = new System.Drawing.Size(84, 13);
			this.lblAxis.TabIndex = 7;
			this.lblAxis.Text = "X Axis Deviation";
			// 
			// lblAxisMax
			// 
			this.lblAxisMax.AutoSize = true;
			this.lblAxisMax.ForeColor = System.Drawing.Color.Blue;
			this.lblAxisMax.Location = new System.Drawing.Point(3, 16);
			this.lblAxisMax.Name = "lblAxisMax";
			this.lblAxisMax.Size = new System.Drawing.Size(27, 13);
			this.lblAxisMax.TabIndex = 8;
			this.lblAxisMax.Text = "Max";
			// 
			// lblAxisMin
			// 
			this.lblAxisMin.AutoSize = true;
			this.lblAxisMin.ForeColor = System.Drawing.Color.Blue;
			this.lblAxisMin.Location = new System.Drawing.Point(3, 253);
			this.lblAxisMin.Name = "lblAxisMin";
			this.lblAxisMin.Size = new System.Drawing.Size(13, 13);
			this.lblAxisMin.TabIndex = 9;
			this.lblAxisMin.Text = "0";
			// 
			// lblAxisMid
			// 
			this.lblAxisMid.AutoSize = true;
			this.lblAxisMid.ForeColor = System.Drawing.Color.Blue;
			this.lblAxisMid.Location = new System.Drawing.Point(3, 132);
			this.lblAxisMid.Name = "lblAxisMid";
			this.lblAxisMid.Size = new System.Drawing.Size(24, 13);
			this.lblAxisMid.TabIndex = 10;
			this.lblAxisMid.Text = "Mid";
			// 
			// lblSlideMax
			// 
			this.lblSlideMax.AutoSize = true;
			this.lblSlideMax.ForeColor = System.Drawing.Color.Blue;
			this.lblSlideMax.Location = new System.Drawing.Point(378, 269);
			this.lblSlideMax.Name = "lblSlideMax";
			this.lblSlideMax.Size = new System.Drawing.Size(27, 13);
			this.lblSlideMax.TabIndex = 11;
			this.lblSlideMax.Text = "Max";
			// 
			// lblSlideMid
			// 
			this.lblSlideMid.AutoSize = true;
			this.lblSlideMid.ForeColor = System.Drawing.Color.Blue;
			this.lblSlideMid.Location = new System.Drawing.Point(193, 269);
			this.lblSlideMid.Name = "lblSlideMid";
			this.lblSlideMid.Size = new System.Drawing.Size(24, 13);
			this.lblSlideMid.TabIndex = 12;
			this.lblSlideMid.Text = "Mid";
			// 
			// lblSlideMin
			// 
			this.lblSlideMin.AutoSize = true;
			this.lblSlideMin.ForeColor = System.Drawing.Color.Blue;
			this.lblSlideMin.Location = new System.Drawing.Point(32, 269);
			this.lblSlideMin.Name = "lblSlideMin";
			this.lblSlideMin.Size = new System.Drawing.Size(13, 13);
			this.lblSlideMin.TabIndex = 13;
			this.lblSlideMin.Text = "0";
			// 
			// Graph
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblSlideMin);
			this.Controls.Add(this.lblSlideMid);
			this.Controls.Add(this.lblSlideMax);
			this.Controls.Add(this.lblAxisMid);
			this.Controls.Add(this.lblAxisMin);
			this.Controls.Add(this.lblAxisMax);
			this.Controls.Add(this.lblAxis);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Graph";
			this.Size = new System.Drawing.Size(424, 316);
			this.Load += new System.EventHandler(this.Graph_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblAxis;
		private System.Windows.Forms.Label lblAxisMax;
		private System.Windows.Forms.Label lblAxisMin;
		private System.Windows.Forms.Label lblAxisMid;
		private System.Windows.Forms.Label lblSlideMax;
		private System.Windows.Forms.Label lblSlideMid;
		private System.Windows.Forms.Label lblSlideMin;
	}
}
