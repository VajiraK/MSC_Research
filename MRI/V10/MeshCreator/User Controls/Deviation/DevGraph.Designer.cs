namespace MeshCreator
{
	partial class DevGraph
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
			this.lblObjectName = new System.Windows.Forms.Label();
			this.picObjColor = new System.Windows.Forms.PictureBox();
			this.graphY = new MeshCreator.Graph();
			this.graphX = new MeshCreator.Graph();
			((System.ComponentModel.ISupportInitialize)(this.picObjColor)).BeginInit();
			this.SuspendLayout();
			// 
			// lblObjectName
			// 
			this.lblObjectName.AutoSize = true;
			this.lblObjectName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblObjectName.ForeColor = System.Drawing.Color.Blue;
			this.lblObjectName.Location = new System.Drawing.Point(26, 5);
			this.lblObjectName.Name = "lblObjectName";
			this.lblObjectName.Size = new System.Drawing.Size(48, 13);
			this.lblObjectName.TabIndex = 0;
			this.lblObjectName.Text = "Object 0";
			// 
			// picObjColor
			// 
			this.picObjColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picObjColor.Location = new System.Drawing.Point(3, 3);
			this.picObjColor.Name = "picObjColor";
			this.picObjColor.Size = new System.Drawing.Size(16, 16);
			this.picObjColor.TabIndex = 3;
			this.picObjColor.TabStop = false;
			// 
			// graphY
			// 
			this.graphY.Location = new System.Drawing.Point(413, 20);
			this.graphY.Name = "graphY";
			this.graphY.Size = new System.Drawing.Size(411, 286);
			this.graphY.TabIndex = 2;
			// 
			// graphX
			// 
			this.graphX.Location = new System.Drawing.Point(3, 21);
			this.graphX.Name = "graphX";
			this.graphX.Size = new System.Drawing.Size(409, 286);
			this.graphX.TabIndex = 1;
			// 
			// DevGraph
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.picObjColor);
			this.Controls.Add(this.graphY);
			this.Controls.Add(this.graphX);
			this.Controls.Add(this.lblObjectName);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "DevGraph";
			this.Size = new System.Drawing.Size(826, 309);
			this.Load += new System.EventHandler(this.DevGraph_Load);
			((System.ComponentModel.ISupportInitialize)(this.picObjColor)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblObjectName;
		private Graph graphX;
		private Graph graphY;
		private System.Windows.Forms.PictureBox picObjColor;
	}
}
