using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace AnimationEditor
{
    public partial class FrameEditorControl : UserControl
    {
        public FrameEditorControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private Dictionary<IAnimation, FrameEditRowControl> m_Rows = new Dictionary<IAnimation, FrameEditRowControl>();

        public int MaxFrame
        {
            get { return trkFrame.Maximum; }
            set { trkFrame.Maximum = value; }
        }

        public int CurFrame
        {
            get { return trkFrame.Value; }
            set { trkFrame.Value = value; }
        }

        public void AddAnimation(IAnimation anim)
        {
            MaxFrame = Math.Max(anim.MaxFrames, MaxFrame);

            FrameEditRowControl ctrl = new FrameEditRowControl();

            ctrl.Width = this.Width - SystemInformation.VerticalScrollBarWidth;

            ctrl.Animation = anim;
            m_Rows.Add(anim, ctrl);

            flowLayoutPanel1.Controls.Add(ctrl);

            if (anim.Parent != null)
            {
                FrameEditRowControl c2 = m_Rows[anim.Parent];
                int indexBase = flowLayoutPanel1.Controls.IndexOf(c2) + 1;
                int currentIndex = flowLayoutPanel1.Controls.IndexOf(ctrl);

                while (indexBase < flowLayoutPanel1.Controls.Count)
                {
                    FrameEditRowControl cc = (FrameEditRowControl)flowLayoutPanel1.Controls[indexBase];
                    if (cc.Animation == ctrl)
                    {
                        indexBase = currentIndex;
                        break;
                    }

                    if (cc.Animation.Parent != anim.Parent)
                        break;

                    indexBase++;
                }

                if (indexBase != currentIndex)
                    flowLayoutPanel1.Controls.SetChildIndex(ctrl, indexBase);
            }

            ctrl.SelectionChanged += ctrl_SelectionChanged;
        }

        public IEnumerable<IAnimation> Animations { get { return m_Rows.Keys; } }

        public void Clear()
        {
            Deselect();
            flowLayoutPanel1.Controls.Clear();
            m_Rows.Clear();
        }


        void ctrl_SelectionChanged(object sender, EventArgs e)
        {
            FrameEditRowControl ctrl = (FrameEditRowControl)sender;

            if (ctrl.SelectedFrameIn == FrameEditRowControl.SELECTION_NONE)
            {
                RefreshSelectionObject();
                return;
            }

            if (ctrl.SelectedFrameIn == FrameEditRowControl.SELECTION_HEADER && Form.ModifierKeys.HasFlag(Keys.Control))
            {
                foreach (FrameEditRowControl cc in m_Rows.Values.Where(_cc => _cc.SelectedFrameIn != FrameEditRowControl.SELECTION_HEADER))
                {
                    cc.Deselect();
                }

                RefreshSelectionObject();
            }
            else
            {
                foreach (FrameEditRowControl cc in m_Rows.Values.Where(_cc => _cc != ctrl))
                {
                    cc.Deselect();
                }

                RefreshSelectionObject();
            }
        }

        public void Deselect()
        {
            foreach (FrameEditRowControl cc in m_Rows.Values)
            {
                cc.Deselect();
            }

            RefreshSelectionObject();
        }

        private void RefreshSelectionObject()
        {
            AnimSelection sel = new AnimSelection();
            sel.Type = SelectionType.None;

            foreach (FrameEditRowControl cc in m_Rows.Values.Where(_cc => _cc.SelectedFrameIn != FrameEditRowControl.SELECTION_NONE))
            {
                if (cc.SelectedFrameIn == FrameEditRowControl.SELECTION_HEADER)
                {
                    if (sel.Type == SelectionType.None)
                    {
                        sel.Animation = cc.Animation;
                        sel.Type = SelectionType.Animation;
                    }
                    else if (sel.Type == SelectionType.Animation)
                    {
                        sel.Animations.Add(sel.Animation);
                        sel.Animations.Add(cc.Animation);
                        sel.Animation = null;
                        sel.Type = SelectionType.MultipleAnimations;
                    }
                    else if (sel.Type == SelectionType.MultipleAnimations)
                    {
                        sel.Animations.Add(cc.Animation);
                    }
                    else
                    {
                        throw new Exception("Invalid state");
                    }
                }
                else
                {
                    sel.Animation = cc.Animation;
                    sel.FrameIn = cc.SelectedFrameIn;
                    sel.FrameOut = cc.SelectedFrameOut;
                    sel.Type = (cc.SelectedFrameIn == cc.SelectedFrameOut) ? SelectionType.Frame : SelectionType.FrameRange;
                }
            }

            Selection =  sel;

            if (SelectionChanged != null)
                SelectionChanged(this, new SelectionChangedEventArgs(sel));
        }

        public AnimSelection Selection { get; private set; }

        public event EventHandler<SelectionChangedEventArgs> SelectionChanged;

        protected override void OnResize(EventArgs e)
        {
            foreach (FrameEditRowControl row in m_Rows.Values)
            {
                row.Width = this.Width - SystemInformation.VerticalScrollBarWidth;
            }

            base.OnResize(e);
        }

        private bool m_FastScroll = false;

        private void trkFrame_ValueChanged(object sender, EventArgs e)
        {
            headerControl.FrameBase = trkFrame.Value;

            if (!m_FastScroll)
                foreach (FrameEditRowControl row in m_Rows.Values)
                    row.FrameBase = trkFrame.Value;
        }

        private void trkFrame_MouseDown(object sender, MouseEventArgs e)
        {
            m_FastScroll = true;
        }

        private void trkFrame_MouseUp(object sender, MouseEventArgs e)
        {
            m_FastScroll = false;

            foreach (FrameEditRowControl row in m_Rows.Values)
                row.FrameBase = trkFrame.Value;
        }

        public new void Invalidate()
        {
            foreach (FrameEditRowControl row in m_Rows.Values)
                row.Invalidate();
        }


    }
}
