namespace MeshCreator
{
    partial class ImageListEx
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
            this.floImages = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSlices = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblSelected = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrKeyPress = new System.Windows.Forms.Timer(this.components);
            this.btnPlay = new MeshCreator.PlayStopBut();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // floImages
            // 
            this.floImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.floImages.AutoScroll = true;
            this.floImages.BackColor = System.Drawing.Color.White;
            this.floImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.floImages.Location = new System.Drawing.Point(3, 3);
            this.floImages.Name = "floImages";
            this.floImages.Size = new System.Drawing.Size(487, 69);
            this.floImages.TabIndex = 0;
            this.floImages.WrapContents = false;
            // 
            // lblSlices
            // 
            this.lblSlices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSlices.AutoSize = true;
            this.lblSlices.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlices.Location = new System.Drawing.Point(12, 80);
            this.lblSlices.Margin = new System.Windows.Forms.Padding(12, 0, 3, 0);
            this.lblSlices.Name = "lblSlices";
            this.lblSlices.Size = new System.Drawing.Size(62, 19);
            this.lblSlices.TabIndex = 4;
            this.lblSlices.Text = "0 Slices";
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(404, 78);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(83, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load Slices";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 100;
            this.toolTip1.AutoPopDelay = 3000;
            this.toolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 20;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // lblSelected
            // 
            this.lblSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelected.Location = new System.Drawing.Point(122, 79);
            this.lblSelected.Margin = new System.Windows.Forms.Padding(12, 0, 3, 0);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(111, 19);
            this.lblSelected.TabIndex = 5;
            this.lblSelected.Text = "Selected - N/A";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSelectAll});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 26);
            // 
            // mnuSelectAll
            // 
            this.mnuSelectAll.Name = "mnuSelectAll";
            this.mnuSelectAll.Size = new System.Drawing.Size(122, 22);
            this.mnuSelectAll.Text = "Select All";
            this.mnuSelectAll.Click += new System.EventHandler(this.mnuSelectAll_Click);
            // 
            // tmrKeyPress
            // 
            this.tmrKeyPress.Tick += new System.EventHandler(this.tmrKeyPress_Tick);
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlay.Enabled = false;
            this.btnPlay.Location = new System.Drawing.Point(239, 75);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(159, 31);
            this.btnPlay.TabIndex = 8;
            // 
            // ImageListEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.lblSlices);
            this.Controls.Add(this.floImages);
            this.Controls.Add(this.btnLoad);
            this.Name = "ImageListEx";
            this.Size = new System.Drawing.Size(493, 109);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel floImages;
        private System.Windows.Forms.Label lblSlices;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblSelected;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem mnuSelectAll;
		private PlayStopBut btnPlay;
        private System.Windows.Forms.Timer tmrKeyPress;
    }
}
