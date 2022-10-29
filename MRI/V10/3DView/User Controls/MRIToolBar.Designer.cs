namespace _3DView
{
	partial class MRIToolBar
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MRIToolBar));
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.btnOpen = new System.Windows.Forms.ToolStripButton();
			this.btnShowController = new System.Windows.Forms.ToolStripButton();
			this.toolStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip2
			// 
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.btnShowController});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(617, 25);
			this.toolStrip2.TabIndex = 0;
			// 
			// btnOpen
			// 
			this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
			this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(23, 22);
			this.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnOpen.ToolTipText = "Open MRI 3D File";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// btnShowController
			// 
			this.btnShowController.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnShowController.Image = ((System.Drawing.Image)(resources.GetObject("btnShowController.Image")));
			this.btnShowController.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnShowController.Name = "btnShowController";
			this.btnShowController.Size = new System.Drawing.Size(23, 22);
			this.btnShowController.ToolTipText = "Show Controller";
			this.btnShowController.Click += new System.EventHandler(this.btnShowController_Click);
			// 
			// MRIToolBar
			// 
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.toolStrip2);
			this.Name = "MRIToolBar";
			this.Size = new System.Drawing.Size(617, 24);
			this.Load += new System.EventHandler(this.MRIToolBar_Load);
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripButton btnOpen;
		private System.Windows.Forms.ToolStripButton btnShowController;
	}
}
