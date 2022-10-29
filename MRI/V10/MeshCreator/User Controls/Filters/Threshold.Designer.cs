namespace MeshCreator
{
    partial class Threshold
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
			this.components = new System.ComponentModel.Container();
			this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
			this.picThreshold = new System.Windows.Forms.PictureBox();
			this.btnApply = new System.Windows.Forms.Button();
			this.doubleSlider1 = new MeshCreator.DoubleSlider();
			((System.ComponentModel.ISupportInitialize)(this.picThreshold)).BeginInit();
			this.SuspendLayout();
			// 
			// tmrRefresh
			// 
			this.tmrRefresh.Interval = 50;
			this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
			// 
			// picThreshold
			// 
			this.picThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.picThreshold.BackColor = System.Drawing.Color.White;
			this.picThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picThreshold.Location = new System.Drawing.Point(5, 5);
			this.picThreshold.Margin = new System.Windows.Forms.Padding(5, 5, 5, 3);
			this.picThreshold.Name = "picThreshold";
			this.picThreshold.Size = new System.Drawing.Size(276, 193);
			this.picThreshold.TabIndex = 8;
			this.picThreshold.TabStop = false;
			this.picThreshold.Paint += new System.Windows.Forms.PaintEventHandler(this.picThreshold_Paint);
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(206, 267);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 23);
			this.btnApply.TabIndex = 13;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// doubleSlider1
			// 
			this.doubleSlider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.doubleSlider1.Location = new System.Drawing.Point(5, 200);
			this.doubleSlider1.Name = "doubleSlider1";
			this.doubleSlider1.Size = new System.Drawing.Size(276, 65);
			this.doubleSlider1.TabIndex = 12;
			// 
			// Threshold
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.doubleSlider1);
			this.Controls.Add(this.picThreshold);
			this.Name = "Threshold";
			this.Size = new System.Drawing.Size(287, 294);
			this.Load += new System.EventHandler(this.Threshold_Load);
			((System.ComponentModel.ISupportInitialize)(this.picThreshold)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.Timer tmrRefresh;
		private System.Windows.Forms.PictureBox picThreshold;
		private DoubleSlider doubleSlider1;
		private System.Windows.Forms.Button btnApply;
    }
}
