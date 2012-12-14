namespace GrimrockAnimationTweaker
{
    partial class RecalculateDialog
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
            this.lstSMode = new System.Windows.Forms.ComboBox();
            this.lstRMode = new System.Windows.Forms.ComboBox();
            this.lstTMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstSMode
            // 
            this.lstSMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstSMode.FormattingEnabled = true;
            this.lstSMode.Items.AddRange(new object[] {
            "None",
            "Interpolate linear",
            "Interpolate smooth",
            "Reverse"});
            this.lstSMode.Location = new System.Drawing.Point(124, 12);
            this.lstSMode.Name = "lstSMode";
            this.lstSMode.Size = new System.Drawing.Size(129, 21);
            this.lstSMode.TabIndex = 0;
            // 
            // lstRMode
            // 
            this.lstRMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstRMode.FormattingEnabled = true;
            this.lstRMode.Items.AddRange(new object[] {
            "None",
            "Interpolate linear",
            "Interpolate smooth",
            "Reverse"});
            this.lstRMode.Location = new System.Drawing.Point(124, 39);
            this.lstRMode.Name = "lstRMode";
            this.lstRMode.Size = new System.Drawing.Size(129, 21);
            this.lstRMode.TabIndex = 1;
            // 
            // lstTMode
            // 
            this.lstTMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstTMode.FormattingEnabled = true;
            this.lstTMode.Items.AddRange(new object[] {
            "None",
            "Interpolate linear",
            "Interpolate smooth",
            "Reverse"});
            this.lstTMode.Location = new System.Drawing.Point(124, 66);
            this.lstTMode.Name = "lstTMode";
            this.lstTMode.Size = new System.Drawing.Size(129, 21);
            this.lstTMode.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Scaling";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Rotation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Position";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(289, 118);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 41);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(171, 118);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 41);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // RecalculateDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(413, 173);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstTMode);
            this.Controls.Add(this.lstRMode);
            this.Controls.Add(this.lstSMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecalculateDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recalculate range";
            this.Load += new System.EventHandler(this.InterpolationDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox lstSMode;
        private System.Windows.Forms.ComboBox lstRMode;
        private System.Windows.Forms.ComboBox lstTMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}