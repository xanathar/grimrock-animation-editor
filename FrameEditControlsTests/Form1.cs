using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrimJazzAnimationScaler;

namespace FrameEditControlsTests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Tuple<string, string> pars = OpenAnimation.ShowOpenDialog();

            if (pars == null)
            {
                Environment.Exit(0);
                return;
            }

            panel1.LoadAllAnimations(pars.Item2, pars.Item1);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            panel1.SaveOverwriteAll();
        }

        private void toolAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Program by Xanathar, 2012\n\nPlease report all bugs in GrimRock forums.", "About");
        }
    }
}
