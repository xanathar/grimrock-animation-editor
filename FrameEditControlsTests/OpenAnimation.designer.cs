namespace GrimJazzAnimationScaler
{
    partial class OpenAnimation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenAnimation));
            this.label1 = new System.Windows.Forms.Label();
            this.txtModelFile = new System.Windows.Forms.TextBox();
            this.btnBrowseModel = new System.Windows.Forms.Button();
            this.btnBrowseAnimation = new System.Windows.Forms.Button();
            this.txtAnimationFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Model file:";
            // 
            // txtModelFile
            // 
            this.txtModelFile.Location = new System.Drawing.Point(12, 25);
            this.txtModelFile.Name = "txtModelFile";
            this.txtModelFile.Size = new System.Drawing.Size(626, 20);
            this.txtModelFile.TabIndex = 1;
            // 
            // btnBrowseModel
            // 
            this.btnBrowseModel.Location = new System.Drawing.Point(644, 25);
            this.btnBrowseModel.Name = "btnBrowseModel";
            this.btnBrowseModel.Size = new System.Drawing.Size(30, 21);
            this.btnBrowseModel.TabIndex = 2;
            this.btnBrowseModel.Text = "...";
            this.btnBrowseModel.UseVisualStyleBackColor = true;
            this.btnBrowseModel.Click += new System.EventHandler(this.btnBrowseModel_Click);
            // 
            // btnBrowseAnimation
            // 
            this.btnBrowseAnimation.Location = new System.Drawing.Point(644, 72);
            this.btnBrowseAnimation.Name = "btnBrowseAnimation";
            this.btnBrowseAnimation.Size = new System.Drawing.Size(30, 21);
            this.btnBrowseAnimation.TabIndex = 5;
            this.btnBrowseAnimation.Text = "...";
            this.btnBrowseAnimation.UseVisualStyleBackColor = true;
            this.btnBrowseAnimation.Click += new System.EventHandler(this.btnBrowseAnimation_Click);
            // 
            // txtAnimationFolder
            // 
            this.txtAnimationFolder.Location = new System.Drawing.Point(12, 72);
            this.txtAnimationFolder.Name = "txtAnimationFolder";
            this.txtAnimationFolder.Size = new System.Drawing.Size(626, 20);
            this.txtAnimationFolder.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Animation folder (leave it empty to create animations from scratch):";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(590, 121);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 32);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(500, 121);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 32);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // OpenAnimation
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(692, 172);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBrowseAnimation);
            this.Controls.Add(this.txtAnimationFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseModel);
            this.Controls.Add(this.txtModelFile);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenAnimation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open Grimrock Model+Animation";
            this.Load += new System.EventHandler(this.OpenAnimation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModelFile;
        private System.Windows.Forms.Button btnBrowseModel;
        private System.Windows.Forms.Button btnBrowseAnimation;
        private System.Windows.Forms.TextBox txtAnimationFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}