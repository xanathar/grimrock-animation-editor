namespace GrimrockAnimationTweaker
{
    partial class RotationInput
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
            this.rdoX = new System.Windows.Forms.RadioButton();
            this.rdoY = new System.Windows.Forms.RadioButton();
            this.rdoZ = new System.Windows.Forms.RadioButton();
            this.rdoCustom = new System.Windows.Forms.RadioButton();
            this.numCustomX = new System.Windows.Forms.NumericUpDown();
            this.numCustomY = new System.Windows.Forms.NumericUpDown();
            this.numCustomZ = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoDeg = new System.Windows.Forms.RadioButton();
            this.rdoRad = new System.Windows.Forms.RadioButton();
            this.numAngle = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCustomX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCustomY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCustomZ)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // rdoX
            // 
            this.rdoX.AutoSize = true;
            this.rdoX.Checked = true;
            this.rdoX.Location = new System.Drawing.Point(6, 19);
            this.rdoX.Name = "rdoX";
            this.rdoX.Size = new System.Drawing.Size(54, 17);
            this.rdoX.TabIndex = 0;
            this.rdoX.TabStop = true;
            this.rdoX.Text = "X Axis";
            this.rdoX.UseVisualStyleBackColor = true;
            // 
            // rdoY
            // 
            this.rdoY.AutoSize = true;
            this.rdoY.Location = new System.Drawing.Point(6, 42);
            this.rdoY.Name = "rdoY";
            this.rdoY.Size = new System.Drawing.Size(54, 17);
            this.rdoY.TabIndex = 1;
            this.rdoY.Text = "Y Axis";
            this.rdoY.UseVisualStyleBackColor = true;
            // 
            // rdoZ
            // 
            this.rdoZ.AutoSize = true;
            this.rdoZ.Location = new System.Drawing.Point(6, 65);
            this.rdoZ.Name = "rdoZ";
            this.rdoZ.Size = new System.Drawing.Size(54, 17);
            this.rdoZ.TabIndex = 2;
            this.rdoZ.Text = "Z Axis";
            this.rdoZ.UseVisualStyleBackColor = true;
            // 
            // rdoCustom
            // 
            this.rdoCustom.AutoSize = true;
            this.rdoCustom.Location = new System.Drawing.Point(6, 88);
            this.rdoCustom.Name = "rdoCustom";
            this.rdoCustom.Size = new System.Drawing.Size(84, 17);
            this.rdoCustom.TabIndex = 3;
            this.rdoCustom.Text = "Custom axis:";
            this.rdoCustom.UseVisualStyleBackColor = true;
            // 
            // numCustomX
            // 
            this.numCustomX.DecimalPlaces = 4;
            this.numCustomX.Location = new System.Drawing.Point(96, 88);
            this.numCustomX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numCustomX.Name = "numCustomX";
            this.numCustomX.Size = new System.Drawing.Size(97, 20);
            this.numCustomX.TabIndex = 4;
            // 
            // numCustomY
            // 
            this.numCustomY.DecimalPlaces = 4;
            this.numCustomY.Location = new System.Drawing.Point(199, 88);
            this.numCustomY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numCustomY.Name = "numCustomY";
            this.numCustomY.Size = new System.Drawing.Size(97, 20);
            this.numCustomY.TabIndex = 5;
            // 
            // numCustomZ
            // 
            this.numCustomZ.DecimalPlaces = 4;
            this.numCustomZ.Location = new System.Drawing.Point(302, 88);
            this.numCustomZ.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numCustomZ.Name = "numCustomZ";
            this.numCustomZ.Size = new System.Drawing.Size(97, 20);
            this.numCustomZ.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoX);
            this.groupBox1.Controls.Add(this.numCustomZ);
            this.groupBox1.Controls.Add(this.rdoY);
            this.groupBox1.Controls.Add(this.numCustomY);
            this.groupBox1.Controls.Add(this.rdoZ);
            this.groupBox1.Controls.Add(this.numCustomX);
            this.groupBox1.Controls.Add(this.rdoCustom);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 131);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Axis of rotation";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoDeg);
            this.groupBox2.Controls.Add(this.rdoRad);
            this.groupBox2.Controls.Add(this.numAngle);
            this.groupBox2.Location = new System.Drawing.Point(12, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(411, 100);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Angle";
            // 
            // rdoDeg
            // 
            this.rdoDeg.AutoSize = true;
            this.rdoDeg.Checked = true;
            this.rdoDeg.Location = new System.Drawing.Point(121, 53);
            this.rdoDeg.Name = "rdoDeg";
            this.rdoDeg.Size = new System.Drawing.Size(65, 17);
            this.rdoDeg.TabIndex = 2;
            this.rdoDeg.TabStop = true;
            this.rdoDeg.Text = "Degrees";
            this.rdoDeg.UseVisualStyleBackColor = true;
            // 
            // rdoRad
            // 
            this.rdoRad.AutoSize = true;
            this.rdoRad.Location = new System.Drawing.Point(121, 30);
            this.rdoRad.Name = "rdoRad";
            this.rdoRad.Size = new System.Drawing.Size(64, 17);
            this.rdoRad.TabIndex = 1;
            this.rdoRad.Text = "Radians";
            this.rdoRad.UseVisualStyleBackColor = true;
            // 
            // numAngle
            // 
            this.numAngle.DecimalPlaces = 5;
            this.numAngle.Location = new System.Drawing.Point(14, 41);
            this.numAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numAngle.Name = "numAngle";
            this.numAngle.Size = new System.Drawing.Size(71, 20);
            this.numAngle.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(526, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(104, 39);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(526, 57);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 39);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // RotationInput
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(642, 261);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RotationInput";
            this.Text = "Insert rotation from axis+angle";
            ((System.ComponentModel.ISupportInitialize)(this.numCustomX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCustomY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCustomZ)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAngle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoX;
        private System.Windows.Forms.RadioButton rdoY;
        private System.Windows.Forms.RadioButton rdoZ;
        private System.Windows.Forms.RadioButton rdoCustom;
        private System.Windows.Forms.NumericUpDown numCustomX;
        private System.Windows.Forms.NumericUpDown numCustomY;
        private System.Windows.Forms.NumericUpDown numCustomZ;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoDeg;
        private System.Windows.Forms.RadioButton rdoRad;
        private System.Windows.Forms.NumericUpDown numAngle;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}