using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using GrimrockModelToolkit.Grim3d;

namespace GrimrockAnimationTweaker
{
    public partial class RotationInput : Form
    {
        public RotationInput()
        {
            InitializeComponent();
        }

        public static GrimQuaternion GetQuaternion()
        {
            try
            {
                RotationInput dlg = new RotationInput();
                if (dlg.ShowDialog() != DialogResult.OK)
                    return null;

                Vector3D v = new Vector3D(1.0, 0.0, 0.0);
                double angle = ((double)dlg.numAngle.Value);

                if (dlg.rdoX.Checked)
                    v = new Vector3D(1.0, 0.0, 0.0);
                else if (dlg.rdoY.Checked)
                    v = new Vector3D(0.0, 1.0, 0.0);
                else if (dlg.rdoZ.Checked)
                    v = new Vector3D(0.0, 0.0, 1.0);
                else if (dlg.rdoCustom.Checked)
                    v = new Vector3D((double)dlg.numCustomX.Value, (double)dlg.numCustomY.Value, (double)dlg.numCustomZ.Value);

                if (dlg.rdoRad.Checked)
                    angle = angle / Math.PI * 180.0;

                Quaternion q = new Quaternion(v, angle);

                GrimQuaternion qq = new GrimQuaternion();
                qq.SetFromClrQuaternion(q);
                qq.Normalize();
                return qq;
            }
            catch { return null; }
        }





    }
}
