namespace MeshCreator
{
	partial class PointInfo
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
			this.lblInfo = new System.Windows.Forms.Label();
			this.picColor = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picColor)).BeginInit();
			this.SuspendLayout();
			// 
			// lblInfo
			// 
			this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblInfo.Location = new System.Drawing.Point(3, 33);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(55, 33);
			this.lblInfo.TabIndex = 0;
			this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// picColor
			// 
			this.picColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picColor.Location = new System.Drawing.Point(3, 3);
			this.picColor.Name = "picColor";
			this.picColor.Size = new System.Drawing.Size(55, 27);
			this.picColor.TabIndex = 1;
			this.picColor.TabStop = false;
			// 
			// PointInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.picColor);
			this.Controls.Add(this.lblInfo);
			this.Name = "PointInfo";
			this.Size = new System.Drawing.Size(62, 70);
			this.Load += new System.EventHandler(this.PointInfo_Load);
			((System.ComponentModel.ISupportInitialize)(this.picColor)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.PictureBox picColor;
	}
}
