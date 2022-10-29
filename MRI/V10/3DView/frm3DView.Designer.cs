namespace _3DView
{
	partial class frm3DView
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
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.mriToolBar1 = new _3DView.MRIToolBar();
			this.scrMain = new _3DView.GLScreeen();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 377);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(592, 22);
			this.statusStrip1.TabIndex = 7;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// mriToolBar1
			// 
			this.mriToolBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mriToolBar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.mriToolBar1.Location = new System.Drawing.Point(0, 0);
			this.mriToolBar1.Name = "mriToolBar1";
			this.mriToolBar1.Size = new System.Drawing.Size(592, 28);
			this.mriToolBar1.TabIndex = 8;
			// 
			// scrMain
			// 
			this.scrMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.scrMain.BackColor = System.Drawing.Color.Gray;
			this.scrMain.Cursor = System.Windows.Forms.Cursors.Hand;
			this.scrMain.Location = new System.Drawing.Point(0, 28);
			this.scrMain.Name = "scrMain";
			this.scrMain.Size = new System.Drawing.Size(592, 350);
			this.scrMain.TabIndex = 0;
			// 
			// frm3DView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 399);
			this.Controls.Add(this.mriToolBar1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.scrMain);
			this.Name = "frm3DView";
			this.Text = "3DView";
			this.Load += new System.EventHandler(this.frm3DView_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private GLScreeen scrMain;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private MRIToolBar mriToolBar1;
	}
}

