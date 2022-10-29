namespace MeshCreator
{
	partial class frmDeviationGraph
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
			this.btnDivNormalize = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// btnDivNormalize
			// 
			this.btnDivNormalize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDivNormalize.Location = new System.Drawing.Point(619, 385);
			this.btnDivNormalize.Name = "btnDivNormalize";
			this.btnDivNormalize.Size = new System.Drawing.Size(174, 27);
			this.btnDivNormalize.TabIndex = 0;
			this.btnDivNormalize.Text = "Normalize Slide Deviation ";
			this.btnDivNormalize.UseVisualStyleBackColor = true;
			this.btnDivNormalize.Click += new System.EventHandler(this.btnDivNormalize_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(781, 367);
			this.flowLayoutPanel1.TabIndex = 1;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// frmDeviationGraph
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(799, 418);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.btnDivNormalize);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmDeviationGraph";
			this.Text = "Slide Deviation Graph";
			this.Load += new System.EventHandler(this.frmDeviationGraph_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnDivNormalize;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
	}
}