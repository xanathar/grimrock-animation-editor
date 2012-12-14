using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using AnimationEditor;
using GrimrockModelToolkit.Grim3d;

namespace GrimrockAnimationTweaker
{
    public partial class RecalculateDialog : Form
    {
        public RecalculateDialog()
        {
            InitializeComponent();
        }

        private void InterpolationDialog_Load(object sender, EventArgs e)
        {
            lstSMode.SelectedIndex = 0;
            lstRMode.SelectedIndex = 0;
            lstTMode.SelectedIndex = 0;
        }

        public static void Interpolate(Control parent, AnimSelection sel)
        {
            RecalculateDialog dlg = new RecalculateDialog();
            DialogResult res = dlg.ShowDialog();

            if (dlg.DialogResult == DialogResult.OK)
            {
                foreach (FrameRange fr in FrameRange.FromSelection(sel, true))
                {
                    if (dlg.lstSMode.SelectedIndex == 1)
                        Interpolator.Interpolate<GrimVec3>(fr, kf => kf.Scale, (kf, v) => { kf.Scale = v; }, Interpolator.Vec3Interpolator, f => f);
                    else if (dlg.lstSMode.SelectedIndex == 2)
                        Interpolator.Interpolate<GrimVec3>(fr, kf => kf.Scale, (kf, v) => { kf.Scale = v; }, Interpolator.Vec3Interpolator, f => Interpolator.Smooth(f));
                    else if (dlg.lstSMode.SelectedIndex == 3)
                        Interpolator.Invert<GrimVec3>(fr, kf => kf.Scale, (kf, v) => { kf.Scale = v; });

                    if (dlg.lstTMode.SelectedIndex == 1)
                        Interpolator.Interpolate<GrimVec3>(fr, kf => kf.Position, (kf, v) => { kf.Position = v; }, Interpolator.Vec3Interpolator, f => f);
                    else if (dlg.lstTMode.SelectedIndex == 2)
                        Interpolator.Interpolate<GrimVec3>(fr, kf => kf.Position, (kf, v) => { kf.Position = v; }, Interpolator.Vec3Interpolator, f => Interpolator.Smooth(f));
                    else if (dlg.lstTMode.SelectedIndex == 3)
                        Interpolator.Invert<GrimVec3>(fr, kf => kf.Position, (kf, v) => { kf.Position = v; });

                    if (dlg.lstRMode.SelectedIndex == 1)
                        Interpolator.Interpolate<GrimQuaternion>(fr, kf => kf.Rotation, (kf, v) => { kf.Rotation = v; }, Interpolator.Slerp, f => f);
                    else if (dlg.lstRMode.SelectedIndex == 2)
                        Interpolator.Interpolate<GrimQuaternion>(fr, kf => kf.Rotation, (kf, v) => { kf.Rotation = v; }, Interpolator.Slerp, f => Interpolator.Smooth(f));
                    else if (dlg.lstRMode.SelectedIndex == 3)
                        Interpolator.Invert<GrimQuaternion>(fr, kf => kf.Rotation, (kf, v) => { kf.Rotation = v; });
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }




    }
}
