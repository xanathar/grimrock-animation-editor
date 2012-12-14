using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using GrimrockModelToolkit.Grim3d;
using GrimrockAnimationTweaker.Grim3dAdapters;
using AnimationEditor;

namespace GrimrockAnimationTweaker
{
    public partial class TweakerWindow: UserControl
    {
        GrimModel m_Model;
        string m_ModelPath;
        Dictionary<string, string> m_Parents = new Dictionary<string, string>();

        public TweakerWindow()
        {
            InitializeComponent();
        }

        private void LoadAnimations(List<GrimAnimation> anims)
        {
            foreach (GrimAnimation ga in anims)
            {
                GrimAnimationAdapter gaa = new GrimAnimationAdapter(ga);

                this.animEditor.AddAnimation(gaa);

                IEnumerable<GrimAnimationItemAdapter> adapters = AdjustAnimationHierarchy(gaa, m_Parents);

                foreach (GrimAnimationItemAdapter gai in adapters)
                    this.animEditor.AddAnimation(gai);
            }
        }

        public void LoadAllAnimations(string path, string modelPath)
        {
            m_Model = GrimModel.LoadFromPath(modelPath);
            m_ModelPath = modelPath;
            m_Parents = m_Model.Nodes.ToDictionary(nn => nn.Name, nn => nn.Parent >= 0 ? m_Model.Nodes[nn.Parent].Name : null);

            if (!string.IsNullOrEmpty(path))
            {
                GrimAnimationCache anicache = new GrimAnimationCache();
                anicache.LoadAnimationsFromDirectory(path);

                LoadAnimations(anicache.LoadedAnimations);
            }
        }

        public void SaveOverwriteAll()
        {
            foreach (GrimAnimationAdapter gaa in this.animEditor.Animations.OfType<GrimAnimationAdapter>())
            {
                GrimAnimation anim = gaa.GetWrappedAnimation();
                anim.WriteToPath(anim.OriginalFilePath);
            }
        }


        private IEnumerable<GrimAnimationItemAdapter> AdjustAnimationHierarchy(GrimAnimationAdapter anim, Dictionary<string, string> parents)
        {
            Dictionary<string, GrimAnimationItemAdapter> items = anim.GetWrappedAnimation().Items.ToDictionary(ii => ii.NodeName, ii => new GrimAnimationItemAdapter(ii, anim));

            foreach (GrimAnimationItemAdapter ai in items.Values)
            {
                string parent = parents[ai.Name];

                if (parent != null)
                {
                    while (parent != null && !items.ContainsKey(parent))
                        parent = parents[parent];

                    if (parent != null)
                        ai.Parent = items[parent];
                }
            }

            Dictionary<string, int> distances = items.Keys.OfType<string>().ToDictionary(k => k, k => -1);

            bool someNegativeFound = true;

            int maxDistance = 0;

            while (someNegativeFound)
            {
                someNegativeFound = false;

                foreach (GrimAnimationItemAdapter gai in items.Values)
                {
                    string name = gai.Name;
                    if (distances[name] >= 0)
                        continue;

                    someNegativeFound = true;

                    if (gai.Parent == anim)
                    {
                        distances[name] = 0;
                    }
                    else if (distances[gai.Parent.Name] >= 0)
                    {
                        int dist = distances[gai.Parent.Name] + 1;
                        distances[name] = dist;
                        maxDistance = Math.Max(maxDistance, dist);
                    }
                }
            }

            List<GrimAnimationItemAdapter> adapters = new List<GrimAnimationItemAdapter>();

            for (int i = 0; i <= maxDistance; i++)
            {
                adapters.AddRange(items.Values.Where(gai => distances[gai.Name] == i));
            }

            return adapters;
        }

        private void animEditor_SelectionChanged(object sender, AnimationEditor.SelectionChangedEventArgs e)
        {
            UpdateRightPanelWithSelection(e.Selection);
        }

        private void UpdateRightPanelWithSelection(AnimationEditor.AnimSelection animSelection)
        {
            HashSet<char> modes = new HashSet<char>();

            if (animSelection.Type != AnimationEditor.SelectionType.None)
            {
                modes.Add('*');

                if (animSelection.Animation is GrimAnimationAdapter)
                    modes.Add('A');
                else if (!animSelection.Animations.Any(aa => aa is GrimAnimationAdapter))
                    modes.Add('I');
            }

            SetEnabledByTag(panel2, modes, (int)animSelection.Type);
            SetEnabledByTag(toolStrip1, modes, (int)animSelection.Type);

            // special
            if (animSelection.Animation is IPropertyGridProvider)
            {
                IPropertyGridProvider provider = animSelection.Animation as IPropertyGridProvider;
                grpProperties.Enabled = true;
                propGrid.SelectedObject = provider.GetPropertyGridObject();
            }
            else
            {
                grpProperties.Enabled = false;
                propGrid.SelectedObject = null;
            }

            // special: fill/empty txtXX
            if (animSelection.Type == AnimationEditor.SelectionType.Frame && animSelection.Animation is GrimAnimationItemAdapter)
            {
                GrimAnimationItem gai = ((GrimAnimationItemAdapter)(animSelection.Animation)).GetWrappedAnimationItem();
                if (animSelection.FrameIn >= 0 && animSelection.FrameIn < gai.KeyFrames.Count)
                {
                    GrimAnimationKeyFrame kf = gai.KeyFrames[animSelection.FrameIn ?? 0];
                    txtSX.Text = kf.Scale.X.ToString();
                    txtSY.Text = kf.Scale.Y.ToString();
                    txtSZ.Text = kf.Scale.Z.ToString();
                    txtTX.Text = kf.Position.X.ToString();
                    txtTY.Text = kf.Position.Y.ToString();
                    txtTZ.Text = kf.Position.Z.ToString();
                    txtRX.Text = kf.Rotation.X.ToString();
                    txtRY.Text = kf.Rotation.Y.ToString();
                    txtRZ.Text = kf.Rotation.Z.ToString();
                    txtRW.Text = kf.Rotation.W.ToString();
                }
                else
                {
                    foreach (TextBox txt in grpSrt.Controls.OfType<TextBox>())
                        txt.Text = string.Empty;
                }
            }
            else
            {
                foreach (TextBox txt in grpSrt.Controls.OfType<TextBox>())
                    txt.Text = string.Empty;
            }
        }

        private void SetEnabledByTag(Control container, HashSet<char> modes, int types)
        {
            System.Collections.IEnumerable ctrls = container.Controls.OfType<Control>();
            if (container is ToolStrip)
                ctrls = (container as ToolStrip).Items.OfType<ToolStripItem>();

            foreach (dynamic ctrl in ctrls)
            {
                if (!string.IsNullOrWhiteSpace(ctrl.Tag as string))
                {
                    char mode = ctrl.Tag.ToString()[0];
                    int type = int.Parse(ctrl.Tag.ToString().Substring(1));

                    ctrl.Enabled = (modes.Contains(mode)) && ((type & types) != 0);
                }

                if (ctrl is Control)
                    SetEnabledByTag((Control)ctrl, modes, types);
            }
        }

        float TextBoxToFloat(string text, float def)
        {
            float v;
            if (float.TryParse(text, out v)) return v;
            return def;
        }

        GrimAnimationKeyFrame ReadKeyFrameXForm(float def)
        {
            GrimAnimationKeyFrame kf = new GrimAnimationKeyFrame();
            kf.Position.X = TextBoxToFloat(txtTX.Text, def);
            kf.Position.Y = TextBoxToFloat(txtTY.Text, def);
            kf.Position.Z = TextBoxToFloat(txtTZ.Text, def);
            kf.Scale.X = TextBoxToFloat(txtSX.Text, def);
            kf.Scale.Y = TextBoxToFloat(txtSY.Text, def);
            kf.Scale.Z = TextBoxToFloat(txtSZ.Text, def);
            kf.Rotation.X = TextBoxToFloat(txtRX.Text, def);
            kf.Rotation.Y = TextBoxToFloat(txtRY.Text, def);
            kf.Rotation.Z = TextBoxToFloat(txtRZ.Text, def);
            kf.Rotation.W = TextBoxToFloat(txtRW.Text, def);
            return kf;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GrimAnimationKeyFrame K = ReadKeyFrameXForm(0.0f);

            foreach (GrimAnimationKeyFrame kf in FrameRange.FromSelection(animEditor.Selection, false).KeyFrames())
            {
                kf.Position.X += K.Position.X;
                kf.Position.Y += K.Position.Y;
                kf.Position.Z += K.Position.Z;
                kf.Scale.X += K.Scale.X;
                kf.Scale.Y += K.Scale.Y;
                kf.Scale.Z += K.Scale.Z;
                kf.Rotation.X += K.Rotation.X;
                kf.Rotation.Y += K.Rotation.Y;
                kf.Rotation.Z += K.Rotation.Z;
                kf.Rotation.W += K.Rotation.W;

                if (alwaysKeepQuaternionsNormalizedToolStripMenuItem.Checked)
                    kf.Rotation.Normalize();
            }
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            GrimAnimationKeyFrame K = ReadKeyFrameXForm(1.0f);

            foreach (GrimAnimationKeyFrame kf in FrameRange.FromSelection(animEditor.Selection, false).KeyFrames())
            {
                kf.Position.X *= K.Position.X;
                kf.Position.Y *= K.Position.Y;
                kf.Position.Z *= K.Position.Z;
                kf.Scale.X *= K.Scale.X;
                kf.Scale.Y *= K.Scale.Y;
                kf.Scale.Z *= K.Scale.Z;
                kf.Rotation.X *= K.Rotation.X;
                kf.Rotation.Y *= K.Rotation.Y;
                kf.Rotation.Z *= K.Rotation.Z;
                kf.Rotation.W *= K.Rotation.W;

                if (alwaysKeepQuaternionsNormalizedToolStripMenuItem.Checked)
                    kf.Rotation.Normalize();
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            GrimAnimationKeyFrame K = ReadKeyFrameXForm(float.NaN);

            foreach (GrimAnimationKeyFrame kf in FrameRange.FromSelection(animEditor.Selection, false).KeyFrames())
            {
                kf.Position.X = float.IsNaN(K.Position.X) ? kf.Position.X : K.Position.X;
                kf.Position.Y = float.IsNaN(K.Position.Y) ? kf.Position.Y : K.Position.Y;
                kf.Position.Z = float.IsNaN(K.Position.Z) ? kf.Position.Z : K.Position.Z;
                kf.Scale.X = float.IsNaN(K.Scale.X) ? kf.Scale.X : K.Scale.X;
                kf.Scale.Y = float.IsNaN(K.Scale.Y) ? kf.Scale.Y : K.Scale.Y;
                kf.Scale.Z = float.IsNaN(K.Scale.Z) ? kf.Scale.Z : K.Scale.Z;
                kf.Rotation.X = float.IsNaN(K.Rotation.X) ? kf.Rotation.X : K.Rotation.X;
                kf.Rotation.Y = float.IsNaN(K.Rotation.Y) ? kf.Rotation.Y : K.Rotation.Y;
                kf.Rotation.Z = float.IsNaN(K.Rotation.Z) ? kf.Rotation.Z : K.Rotation.Z;
                kf.Rotation.W = float.IsNaN(K.Rotation.W) ? kf.Rotation.W : K.Rotation.W;

                if (alwaysKeepQuaternionsNormalizedToolStripMenuItem.Checked)
                    kf.Rotation.Normalize();
            }
        }

        private void btnInterpolate_Click(object sender, EventArgs e)
        {
            RecalculateDialog.Interpolate(this, animEditor.Selection);
        }

        private void TweakerWindow_Load(object sender, EventArgs e)
        {
            UpdateRightPanelWithSelection(new AnimSelection() { Type = SelectionType.None });
        }

        private object Clipboard { get; set; }

        private void CopySelectionToClipboard(bool allowItemRange)
        {
            if (animEditor.Selection.Animation is GrimAnimationAdapter)
            {
                Clipboard = MultiframeClip.FromSelection(animEditor.Selection);
            }
            else if (animEditor.Selection.Animation is GrimAnimationItemAdapter && allowItemRange)
            {
                Clipboard = FrameRange.FromSelection(animEditor.Selection, false).KeyFrames().Select(kf => kf.Clone()).ToList();
            }
            else
            {
                Clipboard = null;
            }
        }

        private void DeleteSelection()
        {
            GrimAnimationAdapter animadp = animEditor.Selection.Animation as GrimAnimationAdapter;

            if (animadp != null)
            {
                GrimAnimation ga = animadp.GetWrappedAnimation();

                foreach (GrimAnimationItem gai in ga.Items)
                {
                    int fin = Math.Max(animEditor.Selection.FrameIn ?? 0, 0);
                    int fout = Math.Min(animEditor.Selection.FrameOut ?? gai.KeyFrames.Count - 1, gai.KeyFrames.Count - 1);
                    int fcount = fout - fin + 1;

                    gai.KeyFrames.RemoveRange(fin, fcount);
                }

                CheckAnimationSizeChange(ga);
            }
        }

        GrimAnimationKeyFrame GetDefaultKf()
        {
            return new GrimAnimationKeyFrame()
                {
                    Position = new GrimVec3() { X = 0.0f, Y = 0.0f, Z = 0.0f },
                    Scale = new GrimVec3() { X = 1.0f, Y = 1.0f, Z = 1.0f },
                    Rotation = new GrimQuaternion() { X = 0.0f, Y = 0.0f, Z = 0.0f, W = 1.0f }
                };
        }


        List<GrimAnimationKeyFrame> GetManyDefaultKfs(int count)
        {
            List<GrimAnimationKeyFrame> list = new List<GrimAnimationKeyFrame>(count);

            for (int i = 0; i < count; i++)
                list.Add(GetDefaultKf());

            return list;
        }

        private void CheckAnimationSizeChange(GrimAnimation ga)
        {
            ga.NumFrames = -1;

            foreach (GrimAnimationItem gai in ga.Items)
            {
                if (gai.KeyFrames.Count != ga.NumFrames)
                {
                    if (ga.NumFrames < 0)
                        ga.NumFrames = gai.KeyFrames.Count;
                    else
                        MessageBox.Show(this, "Animation '" + ga.AnimationName + "' has inconsistent length in item " + gai.NodeName + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (ga.NumFrames == 0)
            {
                foreach (GrimAnimationItem gai in ga.Items)
                {
                    if (gai.KeyFrames.Count == 0)
                    {
                        gai.KeyFrames.Add(GetDefaultKf());
                    }
                }
                ga.NumFrames = 1;
            }

            animEditor.Deselect();
            animEditor.Invalidate();
        }

        private void CutSelection()
        {
            CopySelectionToClipboard(false);

            if (Clipboard != null)
                DeleteSelection();
        }


        private void toolCopy_Click(object sender, EventArgs e)
        {
            CopySelectionToClipboard(true);
        }

        private void toolDel_Click(object sender, EventArgs e)
        {
            DeleteSelection();
        }

        private void toolCut_Click(object sender, EventArgs e)
        {
            CutSelection();
        }

        private void toolPasteMenu_DropDownOpening(object sender, EventArgs e)
        {
            if (Clipboard == null)
            {
                pasteBeforeToolStripMenuItem.Enabled = pasteToolStripMenuItem.Enabled = pasteOverToolStripMenuItem.Enabled = false;
            }
            else if (animEditor.Selection != null && animEditor.Selection.Type == SelectionType.Frame)
            {
                pasteOverToolStripMenuItem.Enabled = true;
                pasteBeforeToolStripMenuItem.Enabled = pasteToolStripMenuItem.Enabled = Clipboard is MultiframeClip;
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste(Clipboard as MultiframeClip, GetAnimationFromSelection(animEditor.Selection), (animEditor.Selection.FrameIn ?? 0));
        }

        private void pasteBeforeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste(Clipboard as MultiframeClip, GetAnimationFromSelection(animEditor.Selection), (animEditor.Selection.FrameIn ?? 0) - 1);
        }

        private GrimAnimation GetAnimationFromSelection(AnimSelection animSelection)
        {
            if (animSelection.Animation == null) 
                return null;

            for (IAnimation a = animSelection.Animation; a != null; a = a.Parent)
            {
                GrimAnimationAdapter gaa = a as GrimAnimationAdapter;
                if (gaa != null)
                    return gaa.GetWrappedAnimation();
            }

            return null;
        }

        private void pasteOverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard is MultiframeClip)
            {
                PasteOverAnimation(Clipboard as MultiframeClip, GetAnimationFromSelection(animEditor.Selection), (animEditor.Selection.FrameIn ?? 0));
            }
            else if (Clipboard is List<GrimAnimationKeyFrame>)
            {
                var gaia = animEditor.Selection.Animation as GrimAnimationItemAdapter;
                var gai = gaia.GetWrappedAnimationItem();
                PasteOverItem(Clipboard as List<GrimAnimationKeyFrame>, gai, (animEditor.Selection.FrameIn ?? 0));
            }
        }

        private void PasteOverAnimation(MultiframeClip data, GrimAnimation ga, int frameStart)
        {
            if (ga == null || data == null) 
                return;

            foreach (GrimAnimationItem gai in ga.Items)
            {
                IEnumerable<GrimAnimationKeyFrame> framesToPaste = data.GetKeyFramesForAnimationItem(gai).Select(kf => kf.Clone());

                int index = frameStart;
                foreach (GrimAnimationKeyFrame kf in framesToPaste)
                {
                    if (index < gai.KeyFrames.Count)
                    {
                        gai.KeyFrames[index] = kf;
                    }
                    else
                    {
                        gai.KeyFrames.Add(kf);
                    }

                    ++index;
                }
            }

            CheckAnimationSizeChange(ga);
        }


        private void PasteOverItem(List<GrimAnimationKeyFrame> clipContents, GrimAnimationItem gai, int frameStart)
        {
            if (gai == null || clipContents == null)
                return;

            int index = frameStart;

            foreach (GrimAnimationKeyFrame kf in clipContents.Select(kf => kf.Clone()))
            {
                if (index >= gai.KeyFrames.Count)
                    break;

                gai.KeyFrames[index] = kf;

                ++index;
            }
        }

        private void Paste(MultiframeClip data, GrimAnimation ga, int insertAfterFrame)
        {
            if (data == null || ga == null) 
                return;

            int insertionPoint = insertAfterFrame + 1;

            foreach (GrimAnimationItem gai in ga.Items)
            {
                IEnumerable<GrimAnimationKeyFrame> framesToPaste = data.GetKeyFramesForAnimationItem(gai).Select(kf => kf.Clone());

                if (insertionPoint >= gai.KeyFrames.Count)
                {
                    gai.KeyFrames.AddRange(framesToPaste);
                }
                else
                {
                    gai.KeyFrames.InsertRange(insertionPoint, framesToPaste);
                }
            }

            CheckAnimationSizeChange(ga);
        }

        private void btnRepeat_Click(object sender, EventArgs e)
        {
            object originalClipboard = Clipboard;

            try
            {
                int copies = int.Parse(txtRepeat.Text);
                int frame = (animEditor.Selection.FrameIn ?? 0) - 1;

                this.CopySelectionToClipboard(false);
                GrimAnimation anim = GetAnimationFromSelection(animEditor.Selection);

                for (int i = 0; i < copies; i++)
                    this.Paste(Clipboard as MultiframeClip, anim, frame);
            }
            finally
            {
                Clipboard = originalClipboard;
            }
        }

        private void btnExpandShrink_Click(object sender, EventArgs e)
        {
            object originalClipboard = Clipboard;

            try
            {
                int frameNum = animEditor.Selection.FrameIn ?? 0;
                GrimAnimation anim = GetAnimationFromSelection(animEditor.Selection);
                this.CutSelection();

                MultiframeClip clip = Clipboard as MultiframeClip;

                if (clip == null)
                    return;

                clip.ExpandShrink(int.Parse(txtExpandShrink.Text));

                this.Paste(clip, anim, frameNum);
            }
            finally
            {
                Clipboard = originalClipboard;
            }
        }

        private void scaleAnimationOfPredefinedMonsterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScalePredefinedDialog.Execute(animEditor.Animations, m_Model);
        }

        private void btnRotWiz_Click(object sender, EventArgs e)
        {
            GrimQuaternion q = RotationInput.GetQuaternion();

            if (q != null)
            {
                txtRX.Text = q.X.ToString();
                txtRY.Text = q.Y.ToString();
                txtRZ.Text = q.Z.ToString();
                txtRW.Text = q.W.ToString();
            }
        }

        private void toolNewFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save animation file";
            sfd.OverwritePrompt = true;
            sfd.DefaultExt = "animation";
            sfd.Filter = "Animation files (*.animation)|*.animation|All files (*.*)|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                GrimAnimation ga = new GrimAnimation();
                ga.Items = new  GrimAnimationItem[0];
                ga.NumFrames = 0;
                ga.OriginalFilePath = sfd.FileName;
                ga.Version = 1;
                ga.FramesPerSecond = 30;
                ga.AnimationName = string.Empty;

                this.animEditor.AddAnimation(new GrimAnimationAdapter(ga));
            }
        }

        private void toolNewNode_Click(object sender, EventArgs e)
        {
            HashSet<string> nodeNames = new HashSet<string>();

            GrimAnimation ga = this.GetAnimationFromSelection(animEditor.Selection);

            if (ga == null) return;

            foreach (var n in m_Model.Nodes)
                nodeNames.Add(n.Name);

            foreach (GrimAnimationItem gai in ga.Items)
                nodeNames.Remove(gai.NodeName);

            if (nodeNames.Count == 0)
            {
                MessageBox.Show(this, "No nodes to add", "Can't add");
                return;
            }

            IEnumerable<string> nodesToAdd = NodeSelectionDialog.GetSelectedNodes(nodeNames);

            if (nodesToAdd == null) 
                return;

            List<GrimAnimationItem> gaiList = ga.Items.ToList();

            foreach (string node in nodesToAdd)
            {
                GrimAnimationItem gai = new GrimAnimationItem(node, GetManyDefaultKfs(ga.NumFrames));
                gaiList.Add(gai);
            }

            ga.Items = gaiList.ToArray();

            ReloadAll();

            CheckAnimationSizeChange(ga);
        }

        private void ReloadAll()
        {
            UpdateRightPanelWithSelection(new AnimSelection() { Type = SelectionType.None });
            List<GrimAnimation> anims = animEditor.Animations.OfType<GrimAnimationAdapter>().Select(aa => aa.GetWrappedAnimation()).ToList();
            animEditor.Clear();

            LoadAnimations(anims);
        }

        private void toolSnapAdd_Click(object sender, EventArgs e)
        {
            Snapshot sn = new Snapshot(DateTime.Now.ToLongTimeString(), GetEditingAnimations());
            lstSnaps.Items.Insert(0, sn);
        }

        private IEnumerable<GrimAnimation> GetEditingAnimations()
        {
            return animEditor.Animations.OfType<GrimAnimationAdapter>().Select(aa => aa.GetWrappedAnimation());
        }

        private void toolSnapDel_Click(object sender, EventArgs e)
        {
            if (lstSnaps.SelectedIndex >= 0)
                lstSnaps.Items.RemoveAt(lstSnaps.SelectedIndex);
        }

        private void toolSnapRestore_Click(object sender, EventArgs e)
        {
            Snapshot sn = lstSnaps.SelectedItem as Snapshot;
            if (sn != null)
            {
                bool reload = sn.RestoreOver(GetEditingAnimations());

                if (reload)
                    ReloadAll();
                else
                    animEditor.Invalidate();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string[] names = { "local_srt", "Offset7", "Offset8", "Offset9", "Offset10", "Offset11", "Offset12", "Offset13" };

            List<GrimAnimationItem> anims = animEditor.Animations.OfType<GrimAnimationItemAdapter>().Select(aa => aa.GetWrappedAnimationItem()).ToList();

            foreach (GrimAnimationItem aa in anims)
            {
                if (names.Contains(aa.NodeName))
                    continue;

                foreach (var kf in aa.KeyFrames)
                    kf.Scale.X = kf.Scale.Y = kf.Scale.Z = 0.0f;
            }

            MessageBox.Show("Done");
        }

        IEnumerable<string> GetNodesSelection()
        {
            HashSet<string> nodeNames = new HashSet<string>();

            foreach (var n in m_Model.Nodes)
                nodeNames.Add(n.Name);

            IEnumerable<string> nodesToAdd = NodeSelectionDialog.GetSelectedNodes(nodeNames);

            return nodesToAdd;
        }


        private void modelBakeMatricesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnumerable<string> nodes = GetNodesSelection();
            if (nodes == null) return;

            ModelBaker mb = new ModelBaker(m_Model);
            mb.BakeNodes(nodes);

            ReportModelChanged();
        }

        private void modelAddFakeBoneToNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnumerable<string> nodes = GetNodesSelection();
            if (nodes == null) return;

            foreach (string nodename in nodes)
            {
                GrimModelNode node = m_Model.FindNode(nodename);

                GrimModelNode bone = new GrimModelNode();
                bone.Name = nodename + "_bone";
                bone.Parent = node.Parent;
                bone.LocalToParent = GrimMat4x3.IdentityMatrix();
                bone.MeshEntity = null;
                bone.Type = -1;

                int boneidx = m_Model.Nodes.Count;
                m_Model.Nodes.Add(bone);

                GrimModelMeshEntity meshn = node.MeshEntity;
                meshn.Bones = new GrimModelBone[] { new GrimModelBone() { BoneNodeIndex = boneidx, InvRestMatrix = GrimMat4x3.IdentityMatrix() } };

                ReportModelChanged();
            }


        }

        private void ReportModelChanged()
        {
            if (ModelChanged != null)
                ModelChanged(this, EventArgs.Empty);
        }

        public event EventHandler ModelChanged;


        public void SaveOverwriteModel()
        {
            m_Model.WriteToPath(m_ModelPath);
        }
    }
}
