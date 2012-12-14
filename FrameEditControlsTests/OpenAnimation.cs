using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace GrimJazzAnimationScaler
{
    public partial class OpenAnimation : Form
    {
        public OpenAnimation()
        {
            InitializeComponent();
        }

        private void btnBrowseModel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Load monster model";
            ofd.DefaultExt = "model";
            ofd.Filter = "Grimrock model files (*.model)|*.model|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtModelFile.Text = ofd.FileName;
            }
        }

        private void btnBrowseAnimation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Load animation files";
            fbd.ShowNewFolderButton = false;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtAnimationFolder.Text = fbd.SelectedPath;
            }
        }

        public static Tuple<string, string> ShowOpenDialog()
        {
            OpenAnimation od = new OpenAnimation();
            DialogResult res = od.ShowDialog();
            if (res == DialogResult.OK)
            {
                return new Tuple<string, string>(od.txtModelFile.Text, od.txtAnimationFolder.Text);
            }

            return null; 
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtModelFile.Text))
            {
                MessageBox.Show(this, "The specified model file cannot be found.", "Invalid selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            //if (!Directory.Exists(txtAnimationFolder.Text))
            //{
            //    MessageBox.Show(this, "The specified animation folder cannot be found.", "Invalid selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    return;
            //}

            //if (!Directory.EnumerateFiles(txtAnimationFolder.Text, "*.animation").Any())
            //{
            //    MessageBox.Show(this, "The specified animation folder doesn't contain any animation files.", "Invalid selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    return;
            //}

            this.DialogResult = DialogResult.OK;
        }

        private void OpenAnimation_Load(object sender, EventArgs e)
        {
            if (Debugger.IsAttached)
            {
                txtModelFile.Text = @"C:\gr\slime\slime.model";
                txtAnimationFolder.Text = @"C:\gr\Tsg\mod_assets\animations\monsters\slime"; //C:\gr\tsg\mod_assets\animations\monsters\spider";
            }
        }



    }
}
