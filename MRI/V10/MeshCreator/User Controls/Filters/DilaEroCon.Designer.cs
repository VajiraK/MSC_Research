namespace MeshCreator
{
	partial class DilaEroCon
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
			this.btnDilatate = new System.Windows.Forms.Button();
			this.btnErode = new System.Windows.Forms.Button();
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.EleConClose = new MeshCreator.StructureEleCon();
			this.EleConOpen = new MeshCreator.StructureEleCon();
			this.EleConDialate = new MeshCreator.StructureEleCon();
			this.EleConErode = new MeshCreator.StructureEleCon();
			this.SuspendLayout();
			// 
			// btnDilatate
			// 
			this.btnDilatate.Location = new System.Drawing.Point(223, 58);
			this.btnDilatate.Name = "btnDilatate";
			this.btnDilatate.Size = new System.Drawing.Size(58, 23);
			this.btnDilatate.TabIndex = 1;
			this.btnDilatate.Text = "Dilatate";
			this.btnDilatate.UseVisualStyleBackColor = true;
			this.btnDilatate.Click += new System.EventHandler(this.btnDilatate_Click);
			// 
			// btnErode
			// 
			this.btnErode.Location = new System.Drawing.Point(150, 58);
			this.btnErode.Name = "btnErode";
			this.btnErode.Size = new System.Drawing.Size(58, 23);
			this.btnErode.TabIndex = 2;
			this.btnErode.Text = "Erode";
			this.btnErode.UseVisualStyleBackColor = true;
			this.btnErode.Click += new System.EventHandler(this.btnErode_Click);
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(77, 58);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(58, 23);
			this.btnOpen.TabIndex = 7;
			this.btnOpen.Text = "Open";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(4, 58);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(58, 23);
			this.btnClose.TabIndex = 6;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// EleConClose
			// 
			this.EleConClose.Location = new System.Drawing.Point(9, 4);
			this.EleConClose.MaximumSize = new System.Drawing.Size(48, 48);
			this.EleConClose.MinimumSize = new System.Drawing.Size(48, 48);
			this.EleConClose.Name = "EleConClose";
			this.EleConClose.Size = new System.Drawing.Size(48, 48);
			this.EleConClose.TabIndex = 5;
			// 
			// EleConOpen
			// 
			this.EleConOpen.Location = new System.Drawing.Point(82, 4);
			this.EleConOpen.MaximumSize = new System.Drawing.Size(48, 48);
			this.EleConOpen.MinimumSize = new System.Drawing.Size(48, 48);
			this.EleConOpen.Name = "EleConOpen";
			this.EleConOpen.Size = new System.Drawing.Size(48, 48);
			this.EleConOpen.TabIndex = 4;
			// 
			// EleConDialate
			// 
			this.EleConDialate.Location = new System.Drawing.Point(228, 4);
			this.EleConDialate.MaximumSize = new System.Drawing.Size(48, 48);
			this.EleConDialate.MinimumSize = new System.Drawing.Size(48, 48);
			this.EleConDialate.Name = "EleConDialate";
			this.EleConDialate.Size = new System.Drawing.Size(48, 48);
			this.EleConDialate.TabIndex = 3;
			// 
			// EleConErode
			// 
			this.EleConErode.Location = new System.Drawing.Point(155, 4);
			this.EleConErode.MaximumSize = new System.Drawing.Size(48, 48);
			this.EleConErode.MinimumSize = new System.Drawing.Size(48, 48);
			this.EleConErode.Name = "EleConErode";
			this.EleConErode.Size = new System.Drawing.Size(48, 48);
			this.EleConErode.TabIndex = 0;
			// 
			// DilaEroCon
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.EleConClose);
			this.Controls.Add(this.EleConOpen);
			this.Controls.Add(this.EleConDialate);
			this.Controls.Add(this.btnErode);
			this.Controls.Add(this.btnDilatate);
			this.Controls.Add(this.EleConErode);
			this.MaximumSize = new System.Drawing.Size(288, 95);
			this.MinimumSize = new System.Drawing.Size(288, 95);
			this.Name = "DilaEroCon";
			this.Size = new System.Drawing.Size(286, 93);
			this.ResumeLayout(false);

		}

		#endregion

		private StructureEleCon EleConErode;
		private System.Windows.Forms.Button btnDilatate;
		private System.Windows.Forms.Button btnErode;
		private StructureEleCon EleConDialate;
		private StructureEleCon EleConOpen;
		private StructureEleCon EleConClose;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Button btnClose;
	}
}
