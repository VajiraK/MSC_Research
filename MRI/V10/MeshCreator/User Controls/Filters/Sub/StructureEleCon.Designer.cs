namespace MeshCreator
{
	partial class StructureEleCon
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
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.styleOneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.style2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.style3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.style4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.styleOneToolStripMenuItem,
            this.style2ToolStripMenuItem,
            this.style3ToolStripMenuItem,
            this.style4ToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(153, 114);
			// 
			// styleOneToolStripMenuItem
			// 
			this.styleOneToolStripMenuItem.Name = "styleOneToolStripMenuItem";
			this.styleOneToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.styleOneToolStripMenuItem.Text = "Style 1";
			this.styleOneToolStripMenuItem.Click += new System.EventHandler(this.styleOneToolStripMenuItem_Click);
			// 
			// style2ToolStripMenuItem
			// 
			this.style2ToolStripMenuItem.Name = "style2ToolStripMenuItem";
			this.style2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.style2ToolStripMenuItem.Text = "Style 2";
			this.style2ToolStripMenuItem.Click += new System.EventHandler(this.style2ToolStripMenuItem_Click);
			// 
			// style3ToolStripMenuItem
			// 
			this.style3ToolStripMenuItem.Name = "style3ToolStripMenuItem";
			this.style3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.style3ToolStripMenuItem.Text = "Style 3";
			this.style3ToolStripMenuItem.Click += new System.EventHandler(this.style3ToolStripMenuItem_Click);
			// 
			// style4ToolStripMenuItem
			// 
			this.style4ToolStripMenuItem.Name = "style4ToolStripMenuItem";
			this.style4ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.style4ToolStripMenuItem.Text = "Style 4";
			this.style4ToolStripMenuItem.Click += new System.EventHandler(this.style4ToolStripMenuItem_Click);
			// 
			// StructureEleCon
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ContextMenuStrip = this.contextMenuStrip1;
			this.MaximumSize = new System.Drawing.Size(48, 48);
			this.MinimumSize = new System.Drawing.Size(48, 48);
			this.Name = "StructureEleCon";
			this.Size = new System.Drawing.Size(48, 48);
			this.Load += new System.EventHandler(this.StructureEleCon_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem styleOneToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem style2ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem style3ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem style4ToolStripMenuItem;

	}
}
