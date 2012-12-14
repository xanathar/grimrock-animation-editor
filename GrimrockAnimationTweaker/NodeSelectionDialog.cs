using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrimrockAnimationTweaker
{
    public partial class NodeSelectionDialog : Form
    {
        public NodeSelectionDialog()
        {
            InitializeComponent();
        }

        public static IEnumerable<string> GetSelectedNodes(HashSet<string> options)
        {
            NodeSelectionDialog dlg = new NodeSelectionDialog();
            dlg.listBox1.Items.AddRange(options.ToArray());

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.listBox1.SelectedItems.OfType<string>();
            }

            return null;
        }

    }
}
