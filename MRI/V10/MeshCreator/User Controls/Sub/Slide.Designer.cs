namespace MeshCreator
{
	partial class Slide
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
			this.PicBookmark = new System.Windows.Forms.PictureBox();
			this.picSelect = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.PicBookmark)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picSelect)).BeginInit();
			this.SuspendLayout();
			// 
			// PicBookmark
			// 
			this.PicBookmark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.PicBookmark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PicBookmark.Location = new System.Drawing.Point(0, 32);
			this.PicBookmark.Name = "PicBookmark";
			this.PicBookmark.Size = new System.Drawing.Size(16, 15);
			this.PicBookmark.TabIndex = 0;
			this.PicBookmark.TabStop = false;
			this.PicBookmark.Click += new System.EventHandler(this.PicBookmark_Click);
			// 
			// picSelect
			// 
			this.picSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.picSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picSelect.Location = new System.Drawing.Point(0, 0);
			this.picSelect.Name = "picSelect";
			this.picSelect.Size = new System.Drawing.Size(16, 31);
			this.picSelect.TabIndex = 1;
			this.picSelect.TabStop = false;
			this.picSelect.DoubleClick += new System.EventHandler(this.picSelect_DoubleClick);
			this.picSelect.Click += new System.EventHandler(this.picSelect_Click);
			// 
			// Slide
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.picSelect);
			this.Controls.Add(this.PicBookmark);
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Margin = new System.Windows.Forms.Padding(1, 1, 0, 3);
			this.Name = "Slide";
			this.Size = new System.Drawing.Size(16, 51);
			((System.ComponentModel.ISupportInitialize)(this.PicBookmark)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picSelect)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox PicBookmark;
		private System.Windows.Forms.PictureBox picSelect;
	}
}
