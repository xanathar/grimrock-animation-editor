using AnimationEditor;
using GrimrockAnimationTweaker;
namespace FrameEditControlsTests
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolAbout = new System.Windows.Forms.ToolStripButton();
            this.toolSaveModel = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new GrimrockAnimationTweaker.TweakerWindow();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolAbout,
            this.toolSaveModel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(849, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::FrameEditControlsTests.Properties.Resources.save_16_h;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(123, 22);
            this.toolStripButton1.Text = "Save Animations";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolAbout
            // 
            this.toolAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAbout.Image = global::FrameEditControlsTests.Properties.Resources.Information;
            this.toolAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAbout.Name = "toolAbout";
            this.toolAbout.Size = new System.Drawing.Size(23, 22);
            this.toolAbout.Text = "About";
            this.toolAbout.Click += new System.EventHandler(this.toolAbout_Click);
            // 
            // toolSaveModel
            // 
            this.toolSaveModel.Enabled = false;
            this.toolSaveModel.Image = global::FrameEditControlsTests.Properties.Resources.save_green_16;
            this.toolSaveModel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveModel.Name = "toolSaveModel";
            this.toolSaveModel.Size = new System.Drawing.Size(97, 22);
            this.toolSaveModel.Text = "Save Model";
            this.toolSaveModel.Click += new System.EventHandler(this.toolSaveModel_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.MinimumSize = new System.Drawing.Size(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(849, 565);
            this.panel1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(849, 590);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "**BETA** - GrimRock Animation Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private TweakerWindow panel1;
        private System.Windows.Forms.ToolStripButton toolAbout;
        private System.Windows.Forms.ToolStripButton toolSaveModel;
    }
}

