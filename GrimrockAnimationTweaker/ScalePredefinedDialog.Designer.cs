namespace GrimrockAnimationTweaker
{
    partial class ScalePredefinedDialog
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.numScale = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkRotateByInverted = new System.Windows.Forms.CheckBox();
            this.rdoDisable = new System.Windows.Forms.RadioButton();
            this.rdoCheatAtTheProblem = new System.Windows.Forms.RadioButton();
            this.chkDoRotateTransl = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkZ = new System.Windows.Forms.CheckBox();
            this.chkX = new System.Windows.Forms.CheckBox();
            this.chkY = new System.Windows.Forms.CheckBox();
            this.rdoAdaptedFromKf0 = new System.Windows.Forms.RadioButton();
            this.rdoAdaptedFromModel = new System.Windows.Forms.RadioButton();
            this.rdoNonAdapted = new System.Windows.Forms.RadioButton();
            this.presetMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPresets = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numScale)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.presetMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please, insert the desired size, in percentage:";
            // 
            // numScale
            // 
            this.numScale.Location = new System.Drawing.Point(257, 11);
            this.numScale.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numScale.Name = "numScale";
            this.numScale.Size = new System.Drawing.Size(75, 20);
            this.numScale.TabIndex = 0;
            this.numScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numScale.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(265, 298);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 35);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(173, 298);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 35);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkRotateByInverted);
            this.groupBox1.Controls.Add(this.rdoDisable);
            this.groupBox1.Controls.Add(this.rdoCheatAtTheProblem);
            this.groupBox1.Controls.Add(this.chkDoRotateTransl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkZ);
            this.groupBox1.Controls.Add(this.chkX);
            this.groupBox1.Controls.Add(this.chkY);
            this.groupBox1.Controls.Add(this.rdoAdaptedFromKf0);
            this.groupBox1.Controls.Add(this.rdoAdaptedFromModel);
            this.groupBox1.Controls.Add(this.rdoNonAdapted);
            this.groupBox1.Location = new System.Drawing.Point(64, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 226);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Re-Translation method";
            // 
            // chkRotateByInverted
            // 
            this.chkRotateByInverted.AutoSize = true;
            this.chkRotateByInverted.Location = new System.Drawing.Point(146, 154);
            this.chkRotateByInverted.Name = "chkRotateByInverted";
            this.chkRotateByInverted.Size = new System.Drawing.Size(47, 17);
            this.chkRotateByInverted.TabIndex = 10;
            this.chkRotateByInverted.Text = "+Inv";
            this.chkRotateByInverted.UseVisualStyleBackColor = true;
            // 
            // rdoDisable
            // 
            this.rdoDisable.AutoSize = true;
            this.rdoDisable.Location = new System.Drawing.Point(17, 26);
            this.rdoDisable.Name = "rdoDisable";
            this.rdoDisable.Size = new System.Drawing.Size(123, 17);
            this.rdoDisable.TabIndex = 1;
            this.rdoDisable.Text = "Disable re-translation";
            this.rdoDisable.UseVisualStyleBackColor = true;
            // 
            // rdoCheatAtTheProblem
            // 
            this.rdoCheatAtTheProblem.AutoSize = true;
            this.rdoCheatAtTheProblem.Location = new System.Drawing.Point(17, 118);
            this.rdoCheatAtTheProblem.Name = "rdoCheatAtTheProblem";
            this.rdoCheatAtTheProblem.Size = new System.Drawing.Size(149, 17);
            this.rdoCheatAtTheProblem.TabIndex = 5;
            this.rdoCheatAtTheProblem.Text = "Compensated by file name";
            this.rdoCheatAtTheProblem.UseVisualStyleBackColor = true;
            // 
            // chkDoRotateTransl
            // 
            this.chkDoRotateTransl.AutoSize = true;
            this.chkDoRotateTransl.Checked = true;
            this.chkDoRotateTransl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDoRotateTransl.Location = new System.Drawing.Point(13, 154);
            this.chkDoRotateTransl.Name = "chkDoRotateTransl";
            this.chkDoRotateTransl.Size = new System.Drawing.Size(127, 17);
            this.chkDoRotateTransl.TabIndex = 6;
            this.chkDoRotateTransl.Text = "Rotate compensation";
            this.chkDoRotateTransl.UseVisualStyleBackColor = true;
            this.chkDoRotateTransl.CheckedChanged += new System.EventHandler(this.chkDoRotateTransl_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Apply to:";
            // 
            // chkZ
            // 
            this.chkZ.AutoSize = true;
            this.chkZ.Checked = true;
            this.chkZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkZ.Location = new System.Drawing.Point(193, 186);
            this.chkZ.Name = "chkZ";
            this.chkZ.Size = new System.Drawing.Size(33, 17);
            this.chkZ.TabIndex = 9;
            this.chkZ.Text = "Z";
            this.chkZ.UseVisualStyleBackColor = true;
            // 
            // chkX
            // 
            this.chkX.AutoSize = true;
            this.chkX.Checked = true;
            this.chkX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkX.Location = new System.Drawing.Point(115, 186);
            this.chkX.Name = "chkX";
            this.chkX.Size = new System.Drawing.Size(33, 17);
            this.chkX.TabIndex = 7;
            this.chkX.Text = "X";
            this.chkX.UseVisualStyleBackColor = true;
            // 
            // chkY
            // 
            this.chkY.AutoSize = true;
            this.chkY.Checked = true;
            this.chkY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkY.Location = new System.Drawing.Point(154, 186);
            this.chkY.Name = "chkY";
            this.chkY.Size = new System.Drawing.Size(33, 17);
            this.chkY.TabIndex = 8;
            this.chkY.Text = "Y";
            this.chkY.UseVisualStyleBackColor = true;
            // 
            // rdoAdaptedFromKf0
            // 
            this.rdoAdaptedFromKf0.AutoSize = true;
            this.rdoAdaptedFromKf0.Location = new System.Drawing.Point(17, 95);
            this.rdoAdaptedFromKf0.Name = "rdoAdaptedFromKf0";
            this.rdoAdaptedFromKf0.Size = new System.Drawing.Size(168, 17);
            this.rdoAdaptedFromKf0.TabIndex = 4;
            this.rdoAdaptedFromKf0.Text = "Compensated from keyframe 0";
            this.rdoAdaptedFromKf0.UseVisualStyleBackColor = true;
            // 
            // rdoAdaptedFromModel
            // 
            this.rdoAdaptedFromModel.AutoSize = true;
            this.rdoAdaptedFromModel.Checked = true;
            this.rdoAdaptedFromModel.Location = new System.Drawing.Point(17, 72);
            this.rdoAdaptedFromModel.Name = "rdoAdaptedFromModel";
            this.rdoAdaptedFromModel.Size = new System.Drawing.Size(144, 17);
            this.rdoAdaptedFromModel.TabIndex = 3;
            this.rdoAdaptedFromModel.TabStop = true;
            this.rdoAdaptedFromModel.Text = "Compensated from model";
            this.rdoAdaptedFromModel.UseVisualStyleBackColor = true;
            // 
            // rdoNonAdapted
            // 
            this.rdoNonAdapted.AutoSize = true;
            this.rdoNonAdapted.Location = new System.Drawing.Point(17, 49);
            this.rdoNonAdapted.Name = "rdoNonAdapted";
            this.rdoNonAdapted.Size = new System.Drawing.Size(112, 17);
            this.rdoNonAdapted.TabIndex = 2;
            this.rdoNonAdapted.Text = "Non-compensated";
            this.rdoNonAdapted.UseVisualStyleBackColor = true;
            // 
            // presetMenu
            // 
            this.presetMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem,
            this.slimeToolStripMenuItem});
            this.presetMenu.Name = "presetMenu";
            this.presetMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.presetMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.defaultToolStripMenuItem.Text = "Default";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
            // 
            // slimeToolStripMenuItem
            // 
            this.slimeToolStripMenuItem.Name = "slimeToolStripMenuItem";
            this.slimeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.slimeToolStripMenuItem.Text = "Slime";
            this.slimeToolStripMenuItem.Click += new System.EventHandler(this.slimeToolStripMenuItem_Click);
            // 
            // btnPresets
            // 
            this.btnPresets.Location = new System.Drawing.Point(12, 298);
            this.btnPresets.Name = "btnPresets";
            this.btnPresets.Size = new System.Drawing.Size(74, 35);
            this.btnPresets.TabIndex = 13;
            this.btnPresets.Text = "Presets ->";
            this.btnPresets.UseVisualStyleBackColor = true;
            this.btnPresets.Click += new System.EventHandler(this.btnPresets_Click);
            // 
            // ScalePredefinedDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(363, 348);
            this.Controls.Add(this.btnPresets);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.numScale);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScalePredefinedDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scale Predefined Monster Animation";
            ((System.ComponentModel.ISupportInitialize)(this.numScale)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.presetMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numScale;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoAdaptedFromKf0;
        private System.Windows.Forms.RadioButton rdoAdaptedFromModel;
        private System.Windows.Forms.RadioButton rdoNonAdapted;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkZ;
        private System.Windows.Forms.CheckBox chkX;
        private System.Windows.Forms.CheckBox chkY;
        private System.Windows.Forms.CheckBox chkDoRotateTransl;
        private System.Windows.Forms.RadioButton rdoDisable;
        private System.Windows.Forms.RadioButton rdoCheatAtTheProblem;
        private System.Windows.Forms.CheckBox chkRotateByInverted;
        private System.Windows.Forms.ContextMenuStrip presetMenu;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slimeToolStripMenuItem;
        private System.Windows.Forms.Button btnPresets;
    }
}