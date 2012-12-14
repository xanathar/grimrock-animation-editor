using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrimrockModelToolkit.Grim3d;

namespace GrimrockAnimationTweaker
{
    public partial class NodeSelectionDialog : Form
    {
        public NodeSelectionDialog()
        {
            InitializeComponent();
        }

        public static IEnumerable<string> GetSelectedNodes(GrimModel model, HashSet<string> options)
        {
            NodeSelectionDialog dlg = new NodeSelectionDialog();

            List<TreeNode> nodes = new List<TreeNode>();

            foreach(GrimModelNode n in model.Nodes)
            {
                TreeNode tn = new TreeNode();
                tn.Text = n.Name;
                tn.Tag = n.Name;
                nodes.Add(tn);

                tn.ImageIndex = (n.Type == 0) ? 1 : 0;
                tn.SelectedImageIndex = tn.ImageIndex;
                
            }

            for(int i = 0; i < model.Nodes.Count; i++)
            {
                GrimModelNode gmn = model.Nodes[i];
                if (gmn.Parent < 0)
                {
                    dlg.modelTree.Nodes.Add(nodes[i]);
                }
                else
                {
                    nodes[gmn.Parent].Nodes.Add(nodes[i]);
                }
            }

            dlg.modelTree.ExpandAll();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.AllNodes().Where(tn => tn.Checked).Select(tn => tn.Tag).OfType<string>();
            }

            return null;
        }

        IEnumerable<TreeNode> AllNodes()
        {
            foreach (TreeNode tn in modelTree.Nodes)
            {
                yield return tn;
                foreach (TreeNode tnd in Descendants(tn))
                    yield return tnd;
            }
        }

        private IEnumerable<TreeNode> Descendants(TreeNode root)
        {
            foreach (TreeNode tn in root.Nodes)
            {
                yield return tn;
                foreach (TreeNode tnd in Descendants(tn))
                    yield return tnd;
            }
        }


        private void btnAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in AllNodes())
            {
                tn.Checked = true;
            }
        }

        private void btnInv_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in AllNodes())
            {
                tn.Checked = !tn.Checked;
            }
        }

    }
}
