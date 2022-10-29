namespace MeshCreator
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
			this.btnSelect = new System.Windows.Forms.ToolStripButton();
			this.cmbTolerance = new System.Windows.Forms.ToolStripComboBox();
			this.btnUndo = new System.Windows.Forms.ToolStripButton();
			this.btnProBackward = new System.Windows.Forms.ToolStripButton();
			this.btnProFull = new System.Windows.Forms.ToolStripButton();
			this.btnProForward = new System.Windows.Forms.ToolStripButton();
			this.btnDiscard = new System.Windows.Forms.ToolStripButton();
			this.btnNextSel = new System.Windows.Forms.ToolStripButton();
			this.btnSaveCube = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSlideDev = new System.Windows.Forms.ToolStripButton();
			this.toolStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip2
			// 
			this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSelect,
            this.cmbTolerance,
            this.btnUndo,
            this.btnProBackward,
            this.btnProFull,
            this.btnProForward,
            this.btnDiscard,
            this.btnNextSel,
            this.btnSaveCube,
            this.toolStripSeparator1,
            this.btnSlideDev});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(617, 39);
			this.toolStrip2.TabIndex = 0;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// btnSelect
			// 
			this.btnSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
			this.btnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(36, 36);
			this.btnSelect.ToolTipText = "Mark object";
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// cmbTolerance
			// 
			this.cmbTolerance.DropDownHeight = 120;
			this.cmbTolerance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTolerance.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmbTolerance.IntegralHeight = false;
			this.cmbTolerance.Name = "cmbTolerance";
			this.cmbTolerance.Size = new System.Drawing.Size(75, 39);
			this.cmbTolerance.ToolTipText = "Tolerance level";
			// 
			// btnUndo
			// 
			this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
			this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnUndo.Name = "btnUndo";
			this.btnUndo.Size = new System.Drawing.Size(36, 36);
			this.btnUndo.ToolTipText = "Undo select object";
			this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
			// 
			// btnProBackward
			// 
			this.btnProBackward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnProBackward.Image = ((System.Drawing.Image)(resources.GetObject("btnProBackward.Image")));
			this.btnProBackward.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnProBackward.Name = "btnProBackward";
			this.btnProBackward.Size = new System.Drawing.Size(36, 36);
			this.btnProBackward.Text = "Backward Propergate object";
			this.btnProBackward.Click += new System.EventHandler(this.btnProBackward_Click);
			// 
			// btnProFull
			// 
			this.btnProFull.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnProFull.Image = ((System.Drawing.Image)(resources.GetObject("btnProFull.Image")));
			this.btnProFull.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnProFull.Name = "btnProFull";
			this.btnProFull.Size = new System.Drawing.Size(36, 36);
			this.btnProFull.Text = "Full Propergate object";
			this.btnProFull.Click += new System.EventHandler(this.btnProFull_Click);
			// 
			// btnProForward
			// 
			this.btnProForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnProForward.Image = ((System.Drawing.Image)(resources.GetObject("btnProForward.Image")));
			this.btnProForward.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnProForward.Name = "btnProForward";
			this.btnProForward.Size = new System.Drawing.Size(36, 36);
			this.btnProForward.ToolTipText = "Forward Propergate object";
			this.btnProForward.Click += new System.EventHandler(this.btnProForward_Click);
			// 
			// btnDiscard
			// 
			this.btnDiscard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnDiscard.Image = ((System.Drawing.Image)(resources.GetObject("btnDiscard.Image")));
			this.btnDiscard.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDiscard.Name = "btnDiscard";
			this.btnDiscard.Size = new System.Drawing.Size(36, 36);
			this.btnDiscard.ToolTipText = "Discard current object";
			this.btnDiscard.Click += new System.EventHandler(this.btnDiscard_Click);
			// 
			// btnNextSel
			// 
			this.btnNextSel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNextSel.Image = ((System.Drawing.Image)(resources.GetObject("btnNextSel.Image")));
			this.btnNextSel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNextSel.Name = "btnNextSel";
			this.btnNextSel.Size = new System.Drawing.Size(36, 36);
			this.btnNextSel.ToolTipText = "Select another object";
			this.btnNextSel.Click += new System.EventHandler(this.btnNextSel_Click);
			// 
			// btnSaveCube
			// 
			this.btnSaveCube.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnSaveCube.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveCube.Image")));
			this.btnSaveCube.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSaveCube.Name = "btnSaveCube";
			this.btnSaveCube.Size = new System.Drawing.Size(36, 36);
			this.btnSaveCube.ToolTipText = "Create 3D Data File";
			this.btnSaveCube.Click += new System.EventHandler(this.btnSaveCube_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
			// 
			// btnSlideDev
			// 
			this.btnSlideDev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnSlideDev.Image = ((System.Drawing.Image)(resources.GetObject("btnSlideDev.Image")));
			this.btnSlideDev.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSlideDev.Name = "btnSlideDev";
			this.btnSlideDev.Size = new System.Drawing.Size(36, 36);
			this.btnSlideDev.ToolTipText = "Calculate Slide deviation ";
			this.btnSlideDev.Click += new System.EventHandler(this.btnSlideDev_Click);
			// 
			// MRIToolBar
			// 
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.toolStrip2);
			this.Name = "MRIToolBar";
			this.Size = new System.Drawing.Size(617, 39);
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripButton btnSelect;
		private System.Windows.Forms.ToolStripButton btnUndo;
		private System.Windows.Forms.ToolStripButton btnProForward;
		private System.Windows.Forms.ToolStripButton btnDiscard;
		private System.Windows.Forms.ToolStripButton btnNextSel;
		private System.Windows.Forms.ToolStripComboBox cmbTolerance;
		private System.Windows.Forms.ToolStripButton btnSaveCube;
		private System.Windows.Forms.ToolStripButton btnProBackward;
		private System.Windows.Forms.ToolStripButton btnProFull;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnSlideDev;
	}
}
