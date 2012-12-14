using AnimationEditor;
namespace GrimrockAnimationTweaker
{
    partial class TweakerWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TweakerWindow));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolNewFile = new System.Windows.Forms.ToolStripButton();
            this.toolNewNode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolCopy = new System.Windows.Forms.ToolStripButton();
            this.toolPasteMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.pasteBeforeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.pasteOverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCut = new System.Windows.Forms.ToolStripButton();
            this.toolDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.scaleAnimationOfPredefinedMonsterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelBakeMatricesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelAddFakeBoneToNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.alwaysKeepQuaternionsNormalizedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.animEditor = new AnimationEditor.FrameEditorControl();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grpProperties = new System.Windows.Forms.GroupBox();
            this.propGrid = new System.Windows.Forms.PropertyGrid();
            this.grpAnimation = new System.Windows.Forms.GroupBox();
            this.txtExpandShrink = new System.Windows.Forms.TextBox();
            this.btnExpandShrink = new System.Windows.Forms.Button();
            this.btnInterpolate = new System.Windows.Forms.Button();
            this.txtRepeat = new System.Windows.Forms.TextBox();
            this.btnRepeat = new System.Windows.Forms.Button();
            this.grpSrt = new System.Windows.Forms.GroupBox();
            this.btnRotWiz = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnMul = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.txtTX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTY = new System.Windows.Forms.TextBox();
            this.txtTZ = new System.Windows.Forms.TextBox();
            this.txtSX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRW = new System.Windows.Forms.TextBox();
            this.txtSY = new System.Windows.Forms.TextBox();
            this.txtRZ = new System.Windows.Forms.TextBox();
            this.txtSZ = new System.Windows.Forms.TextBox();
            this.txtRY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRX = new System.Windows.Forms.TextBox();
            this.lstSnaps = new System.Windows.Forms.ListBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolSnapAdd = new System.Windows.Forms.ToolStripButton();
            this.toolSnapRestore = new System.Windows.Forms.ToolStripButton();
            this.toolSnapDel = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpProperties.SuspendLayout();
            this.grpAnimation.SuspendLayout();
            this.grpSrt.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNewFile,
            this.toolNewNode,
            this.toolStripSeparator4,
            this.toolCopy,
            this.toolPasteMenu,
            this.toolCut,
            this.toolDel,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.toolStripSeparator2,
            this.toolStripDropDownButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(904, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolNewFile
            // 
            this.toolNewFile.Image = global::GrimrockAnimationTweaker.Properties.Resources.NewDocumentHS;
            this.toolNewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNewFile.Name = "toolNewFile";
            this.toolNewFile.Size = new System.Drawing.Size(136, 22);
            this.toolNewFile.Text = "New animation file";
            this.toolNewFile.Click += new System.EventHandler(this.toolNewFile_Click);
            // 
            // toolNewNode
            // 
            this.toolNewNode.Image = global::GrimrockAnimationTweaker.Properties.Resources.AddTableHS;
            this.toolNewNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNewNode.Name = "toolNewNode";
            this.toolNewNode.Size = new System.Drawing.Size(149, 22);
            this.toolNewNode.Tag = "*15";
            this.toolNewNode.Text = "New animation node";
            this.toolNewNode.Click += new System.EventHandler(this.toolNewNode_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolCopy
            // 
            this.toolCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolCopy.Image")));
            this.toolCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCopy.Name = "toolCopy";
            this.toolCopy.Size = new System.Drawing.Size(23, 22);
            this.toolCopy.Tag = "*7";
            this.toolCopy.Text = "Copy";
            this.toolCopy.Click += new System.EventHandler(this.toolCopy_Click);
            // 
            // toolPasteMenu
            // 
            this.toolPasteMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPasteMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteBeforeToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.pasteOverToolStripMenuItem});
            this.toolPasteMenu.Image = ((System.Drawing.Image)(resources.GetObject("toolPasteMenu.Image")));
            this.toolPasteMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPasteMenu.Name = "toolPasteMenu";
            this.toolPasteMenu.Size = new System.Drawing.Size(29, 22);
            this.toolPasteMenu.Text = "Paste...";
            this.toolPasteMenu.DropDownOpening += new System.EventHandler(this.toolPasteMenu_DropDownOpening);
            // 
            // pasteBeforeToolStripMenuItem
            // 
            this.pasteBeforeToolStripMenuItem.Name = "pasteBeforeToolStripMenuItem";
            this.pasteBeforeToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.pasteBeforeToolStripMenuItem.Text = "Paste before";
            this.pasteBeforeToolStripMenuItem.Click += new System.EventHandler(this.pasteBeforeToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.pasteToolStripMenuItem.Tag = "";
            this.pasteToolStripMenuItem.Text = "Paste after";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(147, 6);
            // 
            // pasteOverToolStripMenuItem
            // 
            this.pasteOverToolStripMenuItem.Name = "pasteOverToolStripMenuItem";
            this.pasteOverToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.pasteOverToolStripMenuItem.Tag = "";
            this.pasteOverToolStripMenuItem.Text = "Paste over";
            this.pasteOverToolStripMenuItem.Click += new System.EventHandler(this.pasteOverToolStripMenuItem_Click);
            // 
            // toolCut
            // 
            this.toolCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCut.Image = ((System.Drawing.Image)(resources.GetObject("toolCut.Image")));
            this.toolCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCut.Name = "toolCut";
            this.toolCut.Size = new System.Drawing.Size(23, 22);
            this.toolCut.Tag = "A3";
            this.toolCut.Text = "Cut";
            this.toolCut.Click += new System.EventHandler(this.toolCut_Click);
            // 
            // toolDel
            // 
            this.toolDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDel.Image = ((System.Drawing.Image)(resources.GetObject("toolDel.Image")));
            this.toolDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDel.Name = "toolDel";
            this.toolDel.Size = new System.Drawing.Size(23, 22);
            this.toolDel.Tag = "A3";
            this.toolDel.Text = "Delete";
            this.toolDel.Click += new System.EventHandler(this.toolDel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scaleAnimationOfPredefinedMonsterToolStripMenuItem,
            this.modelBakeMatricesToolStripMenuItem,
            this.modelAddFakeBoneToNodeToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(79, 22);
            this.toolStripDropDownButton1.Text = "Presets";
            // 
            // scaleAnimationOfPredefinedMonsterToolStripMenuItem
            // 
            this.scaleAnimationOfPredefinedMonsterToolStripMenuItem.Name = "scaleAnimationOfPredefinedMonsterToolStripMenuItem";
            this.scaleAnimationOfPredefinedMonsterToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            this.scaleAnimationOfPredefinedMonsterToolStripMenuItem.Tag = "";
            this.scaleAnimationOfPredefinedMonsterToolStripMenuItem.Text = "Scale animation of predefined monster";
            this.scaleAnimationOfPredefinedMonsterToolStripMenuItem.Click += new System.EventHandler(this.scaleAnimationOfPredefinedMonsterToolStripMenuItem_Click);
            // 
            // modelBakeMatricesToolStripMenuItem
            // 
            this.modelBakeMatricesToolStripMenuItem.Name = "modelBakeMatricesToolStripMenuItem";
            this.modelBakeMatricesToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            this.modelBakeMatricesToolStripMenuItem.Text = "Model - Bake matrices";
            this.modelBakeMatricesToolStripMenuItem.Click += new System.EventHandler(this.modelBakeMatricesToolStripMenuItem_Click);
            // 
            // modelAddFakeBoneToNodeToolStripMenuItem
            // 
            this.modelAddFakeBoneToNodeToolStripMenuItem.Name = "modelAddFakeBoneToNodeToolStripMenuItem";
            this.modelAddFakeBoneToNodeToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            this.modelAddFakeBoneToNodeToolStripMenuItem.Text = "Model - Duplicate node to bone+mesh";
            this.modelAddFakeBoneToNodeToolStripMenuItem.Click += new System.EventHandler(this.modelAddFakeBoneToNodeToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alwaysKeepQuaternionsNormalizedToolStripMenuItem});
            this.toolStripDropDownButton2.Image = global::GrimrockAnimationTweaker.Properties.Resources.OptionsHS;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(83, 22);
            this.toolStripDropDownButton2.Text = "Options";
            // 
            // alwaysKeepQuaternionsNormalizedToolStripMenuItem
            // 
            this.alwaysKeepQuaternionsNormalizedToolStripMenuItem.Checked = true;
            this.alwaysKeepQuaternionsNormalizedToolStripMenuItem.CheckOnClick = true;
            this.alwaysKeepQuaternionsNormalizedToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.alwaysKeepQuaternionsNormalizedToolStripMenuItem.Name = "alwaysKeepQuaternionsNormalizedToolStripMenuItem";
            this.alwaysKeepQuaternionsNormalizedToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.alwaysKeepQuaternionsNormalizedToolStripMenuItem.Text = "Always keep quaternions normalized";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.animEditor);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(904, 565);
            this.splitContainer1.SplitterDistance = 615;
            this.splitContainer1.TabIndex = 1;
            // 
            // animEditor
            // 
            this.animEditor.CurFrame = 0;
            this.animEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.animEditor.Location = new System.Drawing.Point(0, 0);
            this.animEditor.MaxFrame = 50;
            this.animEditor.MinimumSize = new System.Drawing.Size(200, 0);
            this.animEditor.Name = "animEditor";
            this.animEditor.Size = new System.Drawing.Size(615, 565);
            this.animEditor.TabIndex = 0;
            this.animEditor.SelectionChanged += new System.EventHandler<AnimationEditor.SelectionChangedEventArgs>(this.animEditor_SelectionChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lstSnaps);
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Size = new System.Drawing.Size(285, 565);
            this.splitContainer2.SplitterDistance = 421;
            this.splitContainer2.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.grpProperties);
            this.panel2.Controls.Add(this.grpAnimation);
            this.panel2.Controls.Add(this.grpSrt);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(285, 421);
            this.panel2.TabIndex = 0;
            // 
            // grpProperties
            // 
            this.grpProperties.Controls.Add(this.propGrid);
            this.grpProperties.Location = new System.Drawing.Point(6, 3);
            this.grpProperties.Name = "grpProperties";
            this.grpProperties.Size = new System.Drawing.Size(250, 161);
            this.grpProperties.TabIndex = 24;
            this.grpProperties.TabStop = false;
            this.grpProperties.Tag = "";
            this.grpProperties.Text = "Properties";
            // 
            // propGrid
            // 
            this.propGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propGrid.HelpVisible = false;
            this.propGrid.Location = new System.Drawing.Point(3, 16);
            this.propGrid.Name = "propGrid";
            this.propGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propGrid.Size = new System.Drawing.Size(244, 142);
            this.propGrid.TabIndex = 1;
            this.propGrid.ToolbarVisible = false;
            // 
            // grpAnimation
            // 
            this.grpAnimation.Controls.Add(this.txtExpandShrink);
            this.grpAnimation.Controls.Add(this.btnExpandShrink);
            this.grpAnimation.Controls.Add(this.btnInterpolate);
            this.grpAnimation.Controls.Add(this.txtRepeat);
            this.grpAnimation.Controls.Add(this.btnRepeat);
            this.grpAnimation.Location = new System.Drawing.Point(6, 316);
            this.grpAnimation.Name = "grpAnimation";
            this.grpAnimation.Size = new System.Drawing.Size(250, 130);
            this.grpAnimation.TabIndex = 21;
            this.grpAnimation.TabStop = false;
            this.grpAnimation.Text = "Animation editor";
            // 
            // txtExpandShrink
            // 
            this.txtExpandShrink.Location = new System.Drawing.Point(187, 94);
            this.txtExpandShrink.Name = "txtExpandShrink";
            this.txtExpandShrink.Size = new System.Drawing.Size(49, 20);
            this.txtExpandShrink.TabIndex = 5;
            this.txtExpandShrink.Tag = "A15";
            this.txtExpandShrink.Text = "1";
            this.txtExpandShrink.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnExpandShrink
            // 
            this.btnExpandShrink.Location = new System.Drawing.Point(6, 89);
            this.btnExpandShrink.Name = "btnExpandShrink";
            this.btnExpandShrink.Size = new System.Drawing.Size(175, 29);
            this.btnExpandShrink.TabIndex = 4;
            this.btnExpandShrink.Tag = "A15";
            this.btnExpandShrink.Text = "Expand/Shrink";
            this.btnExpandShrink.UseVisualStyleBackColor = true;
            this.btnExpandShrink.Click += new System.EventHandler(this.btnExpandShrink_Click);
            // 
            // btnInterpolate
            // 
            this.btnInterpolate.Location = new System.Drawing.Point(6, 54);
            this.btnInterpolate.Name = "btnInterpolate";
            this.btnInterpolate.Size = new System.Drawing.Size(230, 29);
            this.btnInterpolate.TabIndex = 2;
            this.btnInterpolate.Tag = "*14";
            this.btnInterpolate.Text = "Recalculate contents";
            this.btnInterpolate.UseVisualStyleBackColor = true;
            this.btnInterpolate.Click += new System.EventHandler(this.btnInterpolate_Click);
            // 
            // txtRepeat
            // 
            this.txtRepeat.Location = new System.Drawing.Point(187, 24);
            this.txtRepeat.Name = "txtRepeat";
            this.txtRepeat.Size = new System.Drawing.Size(49, 20);
            this.txtRepeat.TabIndex = 1;
            this.txtRepeat.Tag = "A15";
            this.txtRepeat.Text = "1";
            this.txtRepeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnRepeat
            // 
            this.btnRepeat.Location = new System.Drawing.Point(6, 19);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(175, 29);
            this.btnRepeat.TabIndex = 0;
            this.btnRepeat.Tag = "A15";
            this.btnRepeat.Text = "Repeat in copies";
            this.btnRepeat.UseVisualStyleBackColor = true;
            this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
            // 
            // grpSrt
            // 
            this.grpSrt.Controls.Add(this.btnRotWiz);
            this.grpSrt.Controls.Add(this.btnAdd);
            this.grpSrt.Controls.Add(this.btnMul);
            this.grpSrt.Controls.Add(this.btnSet);
            this.grpSrt.Controls.Add(this.txtTX);
            this.grpSrt.Controls.Add(this.label3);
            this.grpSrt.Controls.Add(this.txtTY);
            this.grpSrt.Controls.Add(this.txtTZ);
            this.grpSrt.Controls.Add(this.txtSX);
            this.grpSrt.Controls.Add(this.label1);
            this.grpSrt.Controls.Add(this.txtRW);
            this.grpSrt.Controls.Add(this.txtSY);
            this.grpSrt.Controls.Add(this.txtRZ);
            this.grpSrt.Controls.Add(this.txtSZ);
            this.grpSrt.Controls.Add(this.txtRY);
            this.grpSrt.Controls.Add(this.label2);
            this.grpSrt.Controls.Add(this.txtRX);
            this.grpSrt.Location = new System.Drawing.Point(6, 170);
            this.grpSrt.Name = "grpSrt";
            this.grpSrt.Size = new System.Drawing.Size(250, 140);
            this.grpSrt.TabIndex = 20;
            this.grpSrt.TabStop = false;
            this.grpSrt.Text = "Transformation Editor";
            // 
            // btnRotWiz
            // 
            this.btnRotWiz.Image = global::GrimrockAnimationTweaker.Properties.Resources.redo_round16;
            this.btnRotWiz.Location = new System.Drawing.Point(214, 47);
            this.btnRotWiz.Name = "btnRotWiz";
            this.btnRotWiz.Size = new System.Drawing.Size(22, 20);
            this.btnRotWiz.TabIndex = 24;
            this.btnRotWiz.UseVisualStyleBackColor = true;
            this.btnRotWiz.Click += new System.EventHandler(this.btnRotWiz_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(112, 99);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(40, 25);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Tag = "I15";
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnMul
            // 
            this.btnMul.Location = new System.Drawing.Point(158, 99);
            this.btnMul.Name = "btnMul";
            this.btnMul.Size = new System.Drawing.Size(40, 25);
            this.btnMul.TabIndex = 22;
            this.btnMul.Tag = "I15";
            this.btnMul.Text = "Mul";
            this.btnMul.UseVisualStyleBackColor = true;
            this.btnMul.Click += new System.EventHandler(this.btnMul_Click);
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(204, 99);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(40, 25);
            this.btnSet.TabIndex = 21;
            this.btnSet.Tag = "I15";
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // txtTX
            // 
            this.txtTX.Location = new System.Drawing.Point(30, 73);
            this.txtTX.Name = "txtTX";
            this.txtTX.Size = new System.Drawing.Size(62, 20);
            this.txtTX.TabIndex = 17;
            this.txtTX.Tag = "I15";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "T:";
            // 
            // txtTY
            // 
            this.txtTY.Location = new System.Drawing.Point(98, 73);
            this.txtTY.Name = "txtTY";
            this.txtTY.Size = new System.Drawing.Size(62, 20);
            this.txtTY.TabIndex = 18;
            this.txtTY.Tag = "I15";
            // 
            // txtTZ
            // 
            this.txtTZ.Location = new System.Drawing.Point(166, 73);
            this.txtTZ.Name = "txtTZ";
            this.txtTZ.Size = new System.Drawing.Size(62, 20);
            this.txtTZ.TabIndex = 19;
            this.txtTZ.Tag = "I15";
            // 
            // txtSX
            // 
            this.txtSX.Location = new System.Drawing.Point(30, 21);
            this.txtSX.Name = "txtSX";
            this.txtSX.Size = new System.Drawing.Size(62, 20);
            this.txtSX.TabIndex = 1;
            this.txtSX.Tag = "I15";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "S:";
            // 
            // txtRW
            // 
            this.txtRW.Location = new System.Drawing.Point(168, 47);
            this.txtRW.Name = "txtRW";
            this.txtRW.Size = new System.Drawing.Size(40, 20);
            this.txtRW.TabIndex = 14;
            this.txtRW.Tag = "I15";
            // 
            // txtSY
            // 
            this.txtSY.Location = new System.Drawing.Point(98, 21);
            this.txtSY.Name = "txtSY";
            this.txtSY.Size = new System.Drawing.Size(62, 20);
            this.txtSY.TabIndex = 2;
            this.txtSY.Tag = "I15";
            // 
            // txtRZ
            // 
            this.txtRZ.Location = new System.Drawing.Point(122, 47);
            this.txtRZ.Name = "txtRZ";
            this.txtRZ.Size = new System.Drawing.Size(40, 20);
            this.txtRZ.TabIndex = 13;
            this.txtRZ.Tag = "I15";
            // 
            // txtSZ
            // 
            this.txtSZ.Location = new System.Drawing.Point(166, 21);
            this.txtSZ.Name = "txtSZ";
            this.txtSZ.Size = new System.Drawing.Size(62, 20);
            this.txtSZ.TabIndex = 3;
            this.txtSZ.Tag = "I15";
            // 
            // txtRY
            // 
            this.txtRY.Location = new System.Drawing.Point(76, 47);
            this.txtRY.Name = "txtRY";
            this.txtRY.Size = new System.Drawing.Size(40, 20);
            this.txtRY.TabIndex = 12;
            this.txtRY.Tag = "I15";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "R:";
            // 
            // txtRX
            // 
            this.txtRX.Location = new System.Drawing.Point(30, 47);
            this.txtRX.Name = "txtRX";
            this.txtRX.Size = new System.Drawing.Size(40, 20);
            this.txtRX.TabIndex = 5;
            this.txtRX.Tag = "I15";
            // 
            // lstSnaps
            // 
            this.lstSnaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSnaps.FormattingEnabled = true;
            this.lstSnaps.IntegralHeight = false;
            this.lstSnaps.Location = new System.Drawing.Point(0, 46);
            this.lstSnaps.Name = "lstSnaps";
            this.lstSnaps.Size = new System.Drawing.Size(285, 94);
            this.lstSnaps.TabIndex = 3;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSnapAdd,
            this.toolSnapRestore,
            this.toolSnapDel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 21);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(285, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolSnapAdd
            // 
            this.toolSnapAdd.Image = global::GrimrockAnimationTweaker.Properties.Resources.camera;
            this.toolSnapAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSnapAdd.Name = "toolSnapAdd";
            this.toolSnapAdd.Size = new System.Drawing.Size(55, 22);
            this.toolSnapAdd.Text = "Take";
            this.toolSnapAdd.Click += new System.EventHandler(this.toolSnapAdd_Click);
            // 
            // toolSnapRestore
            // 
            this.toolSnapRestore.Image = global::GrimrockAnimationTweaker.Properties.Resources.history_16_h;
            this.toolSnapRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSnapRestore.Name = "toolSnapRestore";
            this.toolSnapRestore.Size = new System.Drawing.Size(73, 22);
            this.toolSnapRestore.Text = "Restore";
            this.toolSnapRestore.Click += new System.EventHandler(this.toolSnapRestore_Click);
            // 
            // toolSnapDel
            // 
            this.toolSnapDel.Image = global::GrimrockAnimationTweaker.Properties.Resources.delete_x_16;
            this.toolSnapDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSnapDel.Name = "toolSnapDel";
            this.toolSnapDel.Size = new System.Drawing.Size(65, 22);
            this.toolSnapDel.Text = "Delete";
            this.toolSnapDel.Click += new System.EventHandler(this.toolSnapDel_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(285, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Snapshots";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TweakerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TweakerWindow";
            this.Size = new System.Drawing.Size(904, 590);
            this.Load += new System.EventHandler(this.TweakerWindow_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.grpProperties.ResumeLayout(false);
            this.grpAnimation.ResumeLayout(false);
            this.grpAnimation.PerformLayout();
            this.grpSrt.ResumeLayout(false);
            this.grpSrt.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private FrameEditorControl animEditor;
        private System.Windows.Forms.ToolStripButton toolCopy;
        private System.Windows.Forms.ToolStripButton toolDel;
        private System.Windows.Forms.ToolStripButton toolCut;
        private System.Windows.Forms.ToolStripDropDownButton toolPasteMenu;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grpAnimation;
        private System.Windows.Forms.TextBox txtExpandShrink;
        private System.Windows.Forms.Button btnExpandShrink;
        private System.Windows.Forms.TextBox txtRepeat;
        private System.Windows.Forms.Button btnRepeat;
        private System.Windows.Forms.GroupBox grpSrt;
        private System.Windows.Forms.TextBox txtSX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRW;
        private System.Windows.Forms.TextBox txtSY;
        private System.Windows.Forms.TextBox txtRZ;
        private System.Windows.Forms.TextBox txtSZ;
        private System.Windows.Forms.TextBox txtRY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRX;
        private System.Windows.Forms.TextBox txtTX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTY;
        private System.Windows.Forms.TextBox txtTZ;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnMul;
        private System.Windows.Forms.ToolStripMenuItem pasteOverToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem scaleAnimationOfPredefinedMonsterToolStripMenuItem;
        private System.Windows.Forms.Button btnInterpolate;
        private System.Windows.Forms.ToolStripMenuItem pasteBeforeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem alwaysKeepQuaternionsNormalizedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button btnRotWiz;
        private System.Windows.Forms.ToolStripButton toolNewFile;
        private System.Windows.Forms.ToolStripButton toolNewNode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.GroupBox grpProperties;
        private System.Windows.Forms.PropertyGrid propGrid;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox lstSnaps;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolSnapAdd;
        private System.Windows.Forms.ToolStripButton toolSnapDel;
        private System.Windows.Forms.ToolStripButton toolSnapRestore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem modelBakeMatricesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelAddFakeBoneToNodeToolStripMenuItem;
    }
}
