namespace MeshCreator
{
    partial class PicContainer
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
			this.splitBackHor = new System.Windows.Forms.SplitContainer();
			this.splitTop = new System.Windows.Forms.SplitContainer();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.splitBottom = new System.Windows.Forms.SplitContainer();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.picExFinal1 = new MeshCreator.PicExFinal();
			this.picExIntermediate1 = new MeshCreator.PicExIntermediate();
			this.picExOriginal1 = new MeshCreator.picExOriginal();
			this.picExOverLay1 = new MeshCreator.PicExOverLay();
			this.splitBackHor.Panel1.SuspendLayout();
			this.splitBackHor.Panel2.SuspendLayout();
			this.splitBackHor.SuspendLayout();
			this.splitTop.Panel1.SuspendLayout();
			this.splitTop.Panel2.SuspendLayout();
			this.splitTop.SuspendLayout();
			this.splitBottom.Panel1.SuspendLayout();
			this.splitBottom.Panel2.SuspendLayout();
			this.splitBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitBackHor
			// 
			this.splitBackHor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitBackHor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitBackHor.Location = new System.Drawing.Point(0, 0);
			this.splitBackHor.Name = "splitBackHor";
			this.splitBackHor.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitBackHor.Panel1
			// 
			this.splitBackHor.Panel1.Controls.Add(this.splitTop);
			// 
			// splitBackHor.Panel2
			// 
			this.splitBackHor.Panel2.Controls.Add(this.splitBottom);
			this.splitBackHor.Size = new System.Drawing.Size(599, 401);
			this.splitBackHor.SplitterDistance = 198;
			this.splitBackHor.TabIndex = 0;
			// 
			// splitTop
			// 
			this.splitTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitTop.Location = new System.Drawing.Point(0, 0);
			this.splitTop.Name = "splitTop";
			// 
			// splitTop.Panel1
			// 
			this.splitTop.Panel1.Controls.Add(this.label1);
			this.splitTop.Panel1.Controls.Add(this.picExFinal1);
			// 
			// splitTop.Panel2
			// 
			this.splitTop.Panel2.Controls.Add(this.label2);
			this.splitTop.Panel2.Controls.Add(this.picExIntermediate1);
			this.splitTop.Size = new System.Drawing.Size(599, 198);
			this.splitTop.SplitterDistance = 271;
			this.splitTop.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Silver;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(267, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Final";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Silver;
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(320, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Intermediate ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// splitBottom
			// 
			this.splitBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitBottom.Location = new System.Drawing.Point(0, 0);
			this.splitBottom.Name = "splitBottom";
			// 
			// splitBottom.Panel1
			// 
			this.splitBottom.Panel1.Controls.Add(this.label4);
			this.splitBottom.Panel1.Controls.Add(this.picExOriginal1);
			// 
			// splitBottom.Panel2
			// 
			this.splitBottom.Panel2.Controls.Add(this.label3);
			this.splitBottom.Panel2.Controls.Add(this.picExOverLay1);
			this.splitBottom.Size = new System.Drawing.Size(599, 199);
			this.splitBottom.SplitterDistance = 275;
			this.splitBottom.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Silver;
			this.label4.Dock = System.Windows.Forms.DockStyle.Top;
			this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(0, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(271, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "Original";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Silver;
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(316, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Overlay";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// picExFinal1
			// 
			this.picExFinal1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.picExFinal1.AutoScroll = true;
			this.picExFinal1.BackColor = System.Drawing.Color.Gray;
			this.picExFinal1.Location = new System.Drawing.Point(0, 17);
			this.picExFinal1.Name = "picExFinal1";
			this.picExFinal1.Size = new System.Drawing.Size(267, 177);
			this.picExFinal1.TabIndex = 0;
			// 
			// picExIntermediate1
			// 
			this.picExIntermediate1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.picExIntermediate1.AutoScroll = true;
			this.picExIntermediate1.BackColor = System.Drawing.Color.Gray;
			this.picExIntermediate1.Location = new System.Drawing.Point(0, 17);
			this.picExIntermediate1.Name = "picExIntermediate1";
			this.picExIntermediate1.Size = new System.Drawing.Size(320, 177);
			this.picExIntermediate1.TabIndex = 0;
			// 
			// picExOriginal1
			// 
			this.picExOriginal1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.picExOriginal1.AutoScroll = true;
			this.picExOriginal1.BackColor = System.Drawing.Color.Gray;
			this.picExOriginal1.Location = new System.Drawing.Point(0, 17);
			this.picExOriginal1.Name = "picExOriginal1";
			this.picExOriginal1.Size = new System.Drawing.Size(271, 178);
			this.picExOriginal1.TabIndex = 0;
			// 
			// picExOverLay1
			// 
			this.picExOverLay1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.picExOverLay1.AutoScroll = true;
			this.picExOverLay1.AxisPoint = new System.Drawing.Point(0, 0);
			this.picExOverLay1.BackColor = System.Drawing.Color.Gray;
			this.picExOverLay1.Location = new System.Drawing.Point(0, 17);
			this.picExOverLay1.Name = "picExOverLay1";
			this.picExOverLay1.Size = new System.Drawing.Size(316, 178);
			this.picExOverLay1.TabIndex = 0;
			// 
			// PicContainer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitBackHor);
			this.Name = "PicContainer";
			this.Size = new System.Drawing.Size(599, 401);
			this.splitBackHor.Panel1.ResumeLayout(false);
			this.splitBackHor.Panel2.ResumeLayout(false);
			this.splitBackHor.ResumeLayout(false);
			this.splitTop.Panel1.ResumeLayout(false);
			this.splitTop.Panel2.ResumeLayout(false);
			this.splitTop.ResumeLayout(false);
			this.splitBottom.Panel1.ResumeLayout(false);
			this.splitBottom.Panel2.ResumeLayout(false);
			this.splitBottom.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitBackHor;
        private System.Windows.Forms.SplitContainer splitTop;
        private System.Windows.Forms.SplitContainer splitBottom;
        private PicExFinal picExFinal1;
        private PicExIntermediate picExIntermediate1;
        private picExOriginal picExOriginal1;
        private PicExOverLay picExOverLay1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
    }
}
