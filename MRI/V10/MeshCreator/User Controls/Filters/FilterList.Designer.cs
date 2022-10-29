namespace MeshCreator
{
	partial class FilterList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMedian = new System.Windows.Forms.Button();
            this.btnConseSmooth = new System.Windows.Forms.Button();
            this.cmdHisEqualization = new System.Windows.Forms.Button();
            this.btnSharpen = new System.Windows.Forms.Button();
            this.btnInvers = new System.Windows.Forms.Button();
            this.dilaEroCon1 = new MeshCreator.DilaEroCon();
            this.threshold1 = new MeshCreator.Threshold();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnMedian);
            this.panel1.Controls.Add(this.btnConseSmooth);
            this.panel1.Controls.Add(this.cmdHisEqualization);
            this.panel1.Controls.Add(this.btnSharpen);
            this.panel1.Controls.Add(this.btnInvers);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 105);
            this.panel1.TabIndex = 1;
            // 
            // btnMedian
            // 
            this.btnMedian.Location = new System.Drawing.Point(205, 61);
            this.btnMedian.Name = "btnMedian";
            this.btnMedian.Size = new System.Drawing.Size(78, 23);
            this.btnMedian.TabIndex = 3;
            this.btnMedian.Text = "Median";
            this.btnMedian.UseVisualStyleBackColor = true;
            this.btnMedian.Click += new System.EventHandler(this.btnMedian_Click);
            // 
            // btnConseSmooth
            // 
            this.btnConseSmooth.Location = new System.Drawing.Point(98, 3);
            this.btnConseSmooth.Name = "btnConseSmooth";
            this.btnConseSmooth.Size = new System.Drawing.Size(91, 52);
            this.btnConseSmooth.TabIndex = 2;
            this.btnConseSmooth.Text = "Conservative Smoothing ";
            this.btnConseSmooth.UseVisualStyleBackColor = true;
            this.btnConseSmooth.Click += new System.EventHandler(this.btnConseSmooth_Click);
            // 
            // cmdHisEqualization
            // 
            this.cmdHisEqualization.Location = new System.Drawing.Point(3, 3);
            this.cmdHisEqualization.Name = "cmdHisEqualization";
            this.cmdHisEqualization.Size = new System.Drawing.Size(89, 52);
            this.cmdHisEqualization.TabIndex = 1;
            this.cmdHisEqualization.Text = "Histogram Equalization";
            this.cmdHisEqualization.UseVisualStyleBackColor = true;
            this.cmdHisEqualization.Click += new System.EventHandler(this.cmdHisEqualization_Click);
            // 
            // btnSharpen
            // 
            this.btnSharpen.Location = new System.Drawing.Point(205, 32);
            this.btnSharpen.Name = "btnSharpen";
            this.btnSharpen.Size = new System.Drawing.Size(78, 23);
            this.btnSharpen.TabIndex = 0;
            this.btnSharpen.Text = "Sharpen";
            this.btnSharpen.UseVisualStyleBackColor = true;
            this.btnSharpen.Click += new System.EventHandler(this.btnSharpen_Click);
            // 
            // btnInvers
            // 
            this.btnInvers.Location = new System.Drawing.Point(205, 3);
            this.btnInvers.Name = "btnInvers";
            this.btnInvers.Size = new System.Drawing.Size(78, 23);
            this.btnInvers.TabIndex = 0;
            this.btnInvers.Text = "Invert";
            this.btnInvers.UseVisualStyleBackColor = true;
            this.btnInvers.Click += new System.EventHandler(this.btnInvers_Click);
            // 
            // dilaEroCon1
            // 
            this.dilaEroCon1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dilaEroCon1.Location = new System.Drawing.Point(3, 114);
            this.dilaEroCon1.MaximumSize = new System.Drawing.Size(288, 95);
            this.dilaEroCon1.MinimumSize = new System.Drawing.Size(288, 95);
            this.dilaEroCon1.Name = "dilaEroCon1";
            this.dilaEroCon1.Size = new System.Drawing.Size(288, 95);
            this.dilaEroCon1.TabIndex = 3;
            // 
            // threshold1
            // 
            this.threshold1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.threshold1.Location = new System.Drawing.Point(3, 215);
            this.threshold1.Name = "threshold1";
            this.threshold1.Size = new System.Drawing.Size(289, 236);
            this.threshold1.TabIndex = 0;
            this.threshold1.Visible = false;
            this.threshold1.Load += new System.EventHandler(this.threshold1_Load);
            // 
            // FilterList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dilaEroCon1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.threshold1);
            this.Name = "FilterList";
            this.Size = new System.Drawing.Size(291, 525);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private Threshold threshold1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnInvers;
		private System.Windows.Forms.Button btnSharpen;
		private DilaEroCon dilaEroCon1;
		private System.Windows.Forms.Button cmdHisEqualization;
		private System.Windows.Forms.Button btnConseSmooth;
		private System.Windows.Forms.Button btnMedian;
	}
}
