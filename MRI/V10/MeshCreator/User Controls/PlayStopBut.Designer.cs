namespace MeshCreator
{
	partial class PlayStopBut
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
			this.button1 = new System.Windows.Forms.Button();
			this.trkPlaySpeed = new System.Windows.Forms.TrackBar();
			this.tmrPlay = new System.Windows.Forms.Timer(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.trkPlaySpeed)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Image = global::MeshCreator.Properties.Resources.img_play;
			this.button1.Location = new System.Drawing.Point(119, 1);
			this.button1.Margin = new System.Windows.Forms.Padding(0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(32, 24);
			this.button1.TabIndex = 0;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// trkPlaySpeed
			// 
			this.trkPlaySpeed.LargeChange = 100;
			this.trkPlaySpeed.Location = new System.Drawing.Point(-2, -2);
			this.trkPlaySpeed.Maximum = 1000;
			this.trkPlaySpeed.Minimum = 50;
			this.trkPlaySpeed.Name = "trkPlaySpeed";
			this.trkPlaySpeed.Size = new System.Drawing.Size(120, 45);
			this.trkPlaySpeed.SmallChange = 100;
			this.trkPlaySpeed.TabIndex = 8;
			this.trkPlaySpeed.TickFrequency = 50;
			this.trkPlaySpeed.Value = 400;
			this.trkPlaySpeed.Scroll += new System.EventHandler(this.trkPlaySpeed_Scroll);
			// 
			// tmrPlay
			// 
			this.tmrPlay.Interval = 1000;
			this.tmrPlay.Tick += new System.EventHandler(this.tmrPlay_Tick);
			// 
			// PlayStopBut
			// 
			this.Controls.Add(this.trkPlaySpeed);
			this.Controls.Add(this.button1);
			this.Name = "PlayStopBut";
			this.Size = new System.Drawing.Size(153, 42);
			this.Load += new System.EventHandler(this.PlayStopBut_Load);
			((System.ComponentModel.ISupportInitialize)(this.trkPlaySpeed)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TrackBar trkPlaySpeed;
		private System.Windows.Forms.Timer tmrPlay;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}
