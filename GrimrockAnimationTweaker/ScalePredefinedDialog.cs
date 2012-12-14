using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnimationEditor;
using GrimrockAnimationTweaker.Grim3dAdapters;
using GrimrockModelToolkit.Grim3d;

namespace GrimrockAnimationTweaker
{
    public partial class ScalePredefinedDialog : Form
    {
        public ScalePredefinedDialog()
        {
            InitializeComponent();
        }

        IEnumerable<IAnimation> m_Animations;
        GrimModel m_Model;

        enum AdaptationMethod
        {
            Disabled,
            None,
            Model,
            AnimKf0,
            Cheat
        }

        [Flags]
        enum ScaleOptions
        {
            AdaptX = 0x1,
            AdaptY = 0x2,
            AdaptZ = 0x4,
            Rotate = 0x8,
            RotateAndInv = 0x10
        }

        private GrimVec3 GetScaleByCheat(string filename, float factor)
        {
            string file = Path.GetFileNameWithoutExtension(filename);
            GrimVec3 scale = new GrimVec3();
            float K = 3.0f - (3.0f * Math.Abs(factor));

            if (file.EndsWith("_walk") || file.EndsWith("_move_forward") || file.EndsWith("_fly"))
            {
                scale.Z = K;
            }
            else if (file.EndsWith("_move_backward"))
            {
                scale.Z = -K;
            }
            else if (file.EndsWith("_strafe_left"))
            {
                scale.X = -K;
            }
            else if (file.EndsWith("_strafe_right"))
            {
                scale.X = K;
            }

            return scale;
        }

        private void ScaleMonster(float factor, AdaptationMethod method, ScaleOptions options)
        {
            foreach (GrimAnimationItemAdapter gai in m_Animations.OfType<GrimAnimationItemAdapter>())
            {
                if (gai.Parent is GrimAnimationAdapter)
                {
                    foreach (GrimAnimationKeyFrame kf in gai.GetWrappedAnimationItem().KeyFrames)
                    {
                        kf.Scale.X *= factor;
                        kf.Scale.Y *= factor;
                        kf.Scale.Z *= factor;
                    }
                }
                else if (gai.Parent != null && gai.Parent.Parent is GrimAnimationAdapter && method != AdaptationMethod.Disabled)
                {
                    GrimVec3 orig_pos = null;

                    switch (method)
                    {
                        case AdaptationMethod.None:
                            orig_pos = null;
                            break;
                        case AdaptationMethod.Model:
                            {
                                GrimModelNode node = m_Model.FindNode(gai.GetWrappedAnimationItem().NodeName);
                                if (node != null)
                                {
                                    GrimMat4x3 matrix = node.LocalToParent;
                                    orig_pos = matrix.Translation;
                                }
                            }
                            break;
                        case AdaptationMethod.AnimKf0:
                            {
                                orig_pos = gai.GetWrappedAnimationItem().KeyFrames[0].Position.Clone();
                                if (options.HasFlag(ScaleOptions.Rotate) && options.HasFlag(ScaleOptions.RotateAndInv))
                                    orig_pos = gai.GetWrappedAnimationItem().KeyFrames[0].Rotation.RotateInverse(orig_pos);
                            }
                            break;
                        default:
                            break;
                    }

                    GrimVec3 cheater = null;
                    if (method == AdaptationMethod.Cheat)
                        cheater = GetScaleByCheat(((GrimAnimationAdapter)gai.Parent.Parent).GetWrappedAnimation().OriginalFilePath, factor);

                    List<GrimAnimationKeyFrame> listThis = gai.GetWrappedAnimationItem().KeyFrames;
                    for (int i = 0; i < listThis.Count; i++)
                    {
                        GrimAnimationKeyFrame kf = listThis[i];

                        if (method == AdaptationMethod.Cheat)
                        {
                            float K = Interpolator.Smooth(((float)i) / ((float)listThis.Count));

                            if (options.HasFlag(ScaleOptions.AdaptX)) kf.Position.X += cheater.X * K;
                            if (options.HasFlag(ScaleOptions.AdaptY)) kf.Position.Y += cheater.Y * K;
                            if (options.HasFlag(ScaleOptions.AdaptZ)) kf.Position.Z += cheater.Z * K;
                        }
                        else if (orig_pos == null)
                        {
                            if (options.HasFlag(ScaleOptions.AdaptX)) kf.Position.X = (kf.Position.X) / factor;
                            if (options.HasFlag(ScaleOptions.AdaptY)) kf.Position.Y = (kf.Position.Y) / factor;
                            if (options.HasFlag(ScaleOptions.AdaptZ)) kf.Position.Z = (kf.Position.Z) / factor;
                        }
                        else
                        {
                            GrimVec3 pos = options.HasFlag(ScaleOptions.Rotate) ? listThis[i].Rotation.Rotate(orig_pos) : orig_pos;
                            if (options.HasFlag(ScaleOptions.AdaptX)) kf.Position.X = (kf.Position.X - pos.X) / factor + pos.X;
                            if (options.HasFlag(ScaleOptions.AdaptY)) kf.Position.Y = (kf.Position.Y - pos.Y) / factor + pos.Y;
                            if (options.HasFlag(ScaleOptions.AdaptZ)) kf.Position.Z = (kf.Position.Z - pos.Z) / factor + pos.Z;
                        }
                    }
                }
            }

        }



        public static void Execute(IEnumerable<IAnimation> allAnimations, GrimModel model)
        {
            ScalePredefinedDialog dlg = new ScalePredefinedDialog();
            dlg.m_Animations = allAnimations;
            dlg.m_Model = model;
            dlg.ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            AdaptationMethod method;

            if (rdoDisable.Checked) method = AdaptationMethod.Disabled;
            else if (rdoAdaptedFromKf0.Checked) method = AdaptationMethod.AnimKf0;
            else if (rdoAdaptedFromModel.Checked) method = AdaptationMethod.Model;
            else if (rdoCheatAtTheProblem.Checked) method = AdaptationMethod.Cheat;
            else method = AdaptationMethod.None;

            float factor = (float)numScale.Value / 100.0f;

            ScaleOptions options = 0;

            if (chkX.Checked) options |= ScaleOptions.AdaptX;
            if (chkY.Checked) options |= ScaleOptions.AdaptY;
            if (chkZ.Checked) options |= ScaleOptions.AdaptZ;

            if (chkDoRotateTransl.Checked) options |= ScaleOptions.Rotate;
            if (chkRotateByInverted.Checked) options |= ScaleOptions.RotateAndInv;

            ScaleMonster(factor, method, options);

            Close();
        }

        private void chkDoRotateTransl_CheckedChanged(object sender, EventArgs e)
        {
            chkRotateByInverted.Enabled = chkDoRotateTransl.Checked;
        }

        private void btnPresets_Click(object sender, EventArgs e)
        {
            presetMenu.Show(btnPresets, new Point(0, btnPresets.Height));
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rdoAdaptedFromModel.Checked = true;
            chkX.Checked = chkY.Checked = chkZ.Checked = chkDoRotateTransl.Checked = true;
            chkRotateByInverted.Checked = false;
        }

        private void slimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rdoDisable.Checked = true;
            chkX.Checked = chkY.Checked = chkZ.Checked = chkDoRotateTransl.Checked = true;
            chkRotateByInverted.Checked = false;
        }
    }
}
