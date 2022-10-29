namespace _3DView
{
	partial class frmControlPanel
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.grpTran = new System.Windows.Forms.GroupBox();
			this.trkTraZ = new _3DView.TrackBarEx();
			this.trkTraY = new _3DView.TrackBarEx();
			this.trkTraX = new _3DView.TrackBarEx();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.trkLghPos = new _3DView.TrackBarEx();
			this.trkLghY = new _3DView.TrackBarEx();
			this.trkLghX = new _3DView.TrackBarEx();
			this.grpRot = new System.Windows.Forms.GroupBox();
			this.trkRotZ = new _3DView.TrackBarEx();
			this.trkRotY = new _3DView.TrackBarEx();
			this.trkRotX = new _3DView.TrackBarEx();
			this.picCossView = new _3DView.CossView();
			this.panel1.SuspendLayout();
			this.grpTran.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.grpRot.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.grpTran);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.grpRot);
			this.panel1.Location = new System.Drawing.Point(503, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(261, 521);
			this.panel1.TabIndex = 5;
			// 
			// grpTran
			// 
			this.grpTran.Controls.Add(this.trkTraZ);
			this.grpTran.Controls.Add(this.trkTraY);
			this.grpTran.Controls.Add(this.trkTraX);
			this.grpTran.Location = new System.Drawing.Point(6, 4);
			this.grpTran.Name = "grpTran";
			this.grpTran.Size = new System.Drawing.Size(249, 159);
			this.grpTran.TabIndex = 7;
			this.grpTran.TabStop = false;
			this.grpTran.Text = "Transform";
			// 
			// trkTraZ
			// 
			this.trkTraZ.Location = new System.Drawing.Point(5, 113);
			this.trkTraZ.Name = "trkTraZ";
			this.trkTraZ.Size = new System.Drawing.Size(237, 41);
			this.trkTraZ.TabIndex = 2;
			// 
			// trkTraY
			// 
			this.trkTraY.Location = new System.Drawing.Point(5, 66);
			this.trkTraY.Name = "trkTraY";
			this.trkTraY.Size = new System.Drawing.Size(237, 41);
			this.trkTraY.TabIndex = 1;
			// 
			// trkTraX
			// 
			this.trkTraX.Location = new System.Drawing.Point(5, 19);
			this.trkTraX.Name = "trkTraX";
			this.trkTraX.Size = new System.Drawing.Size(237, 41);
			this.trkTraX.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.trkLghPos);
			this.groupBox1.Controls.Add(this.trkLghY);
			this.groupBox1.Controls.Add(this.trkLghX);
			this.groupBox1.Location = new System.Drawing.Point(6, 326);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(249, 158);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Lights";
			// 
			// trkLghPos
			// 
			this.trkLghPos.Location = new System.Drawing.Point(7, 113);
			this.trkLghPos.Name = "trkLghPos";
			this.trkLghPos.Size = new System.Drawing.Size(237, 41);
			this.trkLghPos.TabIndex = 2;
			// 
			// trkLghY
			// 
			this.trkLghY.Location = new System.Drawing.Point(7, 66);
			this.trkLghY.Name = "trkLghY";
			this.trkLghY.Size = new System.Drawing.Size(237, 41);
			this.trkLghY.TabIndex = 1;
			// 
			// trkLghX
			// 
			this.trkLghX.Location = new System.Drawing.Point(5, 19);
			this.trkLghX.Name = "trkLghX";
			this.trkLghX.Size = new System.Drawing.Size(237, 41);
			this.trkLghX.TabIndex = 0;
			// 
			// grpRot
			// 
			this.grpRot.Controls.Add(this.trkRotZ);
			this.grpRot.Controls.Add(this.trkRotY);
			this.grpRot.Controls.Add(this.trkRotX);
			this.grpRot.Location = new System.Drawing.Point(6, 165);
			this.grpRot.Name = "grpRot";
			this.grpRot.Size = new System.Drawing.Size(249, 159);
			this.grpRot.TabIndex = 6;
			this.grpRot.TabStop = false;
			this.grpRot.Text = "Rotate";
			// 
			// trkRotZ
			// 
			this.trkRotZ.Location = new System.Drawing.Point(5, 113);
			this.trkRotZ.Name = "trkRotZ";
			this.trkRotZ.Size = new System.Drawing.Size(237, 41);
			this.trkRotZ.TabIndex = 2;
			// 
			// trkRotY
			// 
			this.trkRotY.Location = new System.Drawing.Point(5, 66);
			this.trkRotY.Name = "trkRotY";
			this.trkRotY.Size = new System.Drawing.Size(237, 41);
			this.trkRotY.TabIndex = 1;
			// 
			// trkRotX
			// 
			this.trkRotX.Location = new System.Drawing.Point(5, 19);
			this.trkRotX.Name = "trkRotX";
			this.trkRotX.Size = new System.Drawing.Size(237, 41);
			this.trkRotX.TabIndex = 0;
			// 
			// picCossView
			// 
			this.picCossView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.picCossView.AutoScroll = true;
			this.picCossView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picCossView.Location = new System.Drawing.Point(4, 3);
			this.picCossView.Name = "picCossView";
			this.picCossView.Size = new System.Drawing.Size(493, 521);
			this.picCossView.TabIndex = 9;
			// 
			// frmControlPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(767, 527);
			this.Controls.Add(this.picCossView);
			this.Controls.Add(this.panel1);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(664, 300);
			this.Name = "frmControlPanel";
			this.Text = "Controller";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmControlPanel_FormClosing);
			this.panel1.ResumeLayout(false);
			this.grpTran.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.grpRot.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox grpTran;
		private TrackBarEx trkTraZ;
		private TrackBarEx trkTraY;
		private TrackBarEx trkTraX;
		private System.Windows.Forms.GroupBox groupBox1;
		private TrackBarEx trkLghPos;
		private TrackBarEx trkLghY;
		private TrackBarEx trkLghX;
		private System.Windows.Forms.GroupBox grpRot;
		private TrackBarEx trkRotZ;
		private TrackBarEx trkRotY;
		private TrackBarEx trkRotX;
		private CossView picCossView;
	}
}