namespace AnimationEditor
{
    partial class FrameEditorControl
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
            this.trkFrame = new System.Windows.Forms.TrackBar();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.headerControl = new AnimationEditor.FrameEditorHeaderControl();
            ((System.ComponentModel.ISupportInitialize)(this.trkFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // trkFrame
            // 
            this.trkFrame.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trkFrame.LargeChange = 10;
            this.trkFrame.Location = new System.Drawing.Point(0, 264);
            this.trkFrame.Maximum = 1;
            this.trkFrame.Name = "trkFrame";
            this.trkFrame.Size = new System.Drawing.Size(386, 45);
            this.trkFrame.TabIndex = 1;
            this.trkFrame.TickFrequency = 10;
            this.trkFrame.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trkFrame.ValueChanged += new System.EventHandler(this.trkFrame_ValueChanged);
            this.trkFrame.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trkFrame_MouseDown);
            this.trkFrame.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trkFrame_MouseUp);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 40);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(200, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(386, 224);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // headerControl
            // 
            this.headerControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerControl.FrameBase = 0;
            this.headerControl.Location = new System.Drawing.Point(0, 0);
            this.headerControl.LockRedrawForChanges = false;
            this.headerControl.MaximumSize = new System.Drawing.Size(99999, 40);
            this.headerControl.MinimumSize = new System.Drawing.Size(200, 40);
            this.headerControl.Name = "headerControl";
            this.headerControl.Size = new System.Drawing.Size(386, 40);
            this.headerControl.TabIndex = 0;
            // 
            // FrameEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.trkFrame);
            this.Controls.Add(this.headerControl);
            this.MinimumSize = new System.Drawing.Size(200, 0);
            this.Name = "FrameEditorControl";
            this.Size = new System.Drawing.Size(386, 309);
            ((System.ComponentModel.ISupportInitialize)(this.trkFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FrameEditorHeaderControl headerControl;
        private System.Windows.Forms.TrackBar trkFrame;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

    }
}
