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
    public partial class FrameEditRowControl : UserControl
    {
        Font m_Font;
        Font m_BoldFont;
        StringFormat m_HeaderFormat = new StringFormat();

        public FrameEditRowControl()
        {
            this.DoubleBuffered = true;
            m_Font = new Font("Tahoma", 10.0f);
            m_BoldFont = new Font("Tahoma", 10.0f, FontStyle.Bold);
            m_HeaderFormat.Alignment = StringAlignment.Near;
            m_HeaderFormat.LineAlignment = StringAlignment.Center;
            m_HeaderFormat.Trimming = StringTrimming.EllipsisCharacter;
            m_HeaderFormat.FormatFlags = StringFormatFlags.NoWrap;
            InitializeComponent();
        }

        public const int SELECTION_NONE = -1;
        public const int SELECTION_HEADER = -2;

        IAnimation m_Animation;
        int m_FrameBase = 0;
        bool m_LockRedrawForChanges = false;
        bool m_HaveChangesDuringLock = false;
        int m_SelectedFrameIn = SELECTION_NONE;
        int m_SelectedFrameOut = SELECTION_NONE;

        public int SelectedFrameIn
        {
            get { return m_SelectedFrameIn; }
        }

        public int SelectedFrameOut
        {
            get { return m_SelectedFrameOut; }
        }

        public bool LockRedrawForChanges
        {
            get { return m_LockRedrawForChanges; }
            set 
            { 
                m_LockRedrawForChanges = value;

                if (m_HaveChangesDuringLock)
                    this.Invalidate();

                m_HaveChangesDuringLock = false;
            }
        }

        public IAnimation Animation
        {
            get { return m_Animation; }
            set { m_Animation = value; PropertyHasChanged(); }
        }

        public int FrameBase
        {
            get { return m_FrameBase; }
            set { m_FrameBase = value; PropertyHasChanged(); }
        }

        public void Deselect()
        {
            if (m_SelectedFrameIn != SELECTION_NONE)
            {
                m_SelectedFrameIn = m_SelectedFrameOut = SELECTION_NONE;
                this.Invalidate();
            }
        }

        public void SelectAll()
        {
            if (m_SelectedFrameIn != SELECTION_HEADER)
            {
                m_SelectedFrameIn = m_SelectedFrameOut = SELECTION_HEADER;
                this.Invalidate();
            }
        }

        public void Select(int from, int to)
        {
            int rfrom = Math.Min(from, to);
            int rto = Math.Max(from, to);

            m_SelectedFrameIn = Math.Max(0, rfrom);
            m_SelectedFrameOut = Math.Min(m_Animation.MaxFrames, rto);
            this.Invalidate();
        }

        private void PropertyHasChanged()
        {
            if (m_LockRedrawForChanges)
                m_HaveChangesDuringLock = true;
            else
                this.Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            this.BackColor = Color.White;
            base.OnPaintBackground(e);
        }

        public event EventHandler SelectionChanged;

        private const int INDENT_MULTIPLIER = 2;
        private const float HEADER_WIDTH = 200.0f;
        private const float CELL_WIDTH = 8.0f;
        private const float CELL_HEIGHT = 20.0f;
        private readonly RectangleF KFICON_RECT = new RectangleF(3.0f, 8.0f, 4.0f, 4.0f);
        private readonly RectangleF HEADER_RECT = new RectangleF(0.0f, 0.0f, HEADER_WIDTH, CELL_HEIGHT);
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics gfx = e.Graphics;

            if (m_Animation == null)
            {
                Debug.WriteLine("Anim=null");
                gfx.FillRectangle(Brushes.Purple, HEADER_RECT);
                return;
            }


            if (m_SelectedFrameIn == SELECTION_HEADER)
            {
                gfx.FillRectangle(Brushes.MediumSlateBlue, HEADER_RECT);
            }

            int indent = GetIndent();
            gfx.DrawString(new string(' ', INDENT_MULTIPLIER * indent) + this.m_Animation.Name ?? "<no-name>", indent == 0 ? m_BoldFont : m_Font, Brushes.Black, HEADER_RECT, m_HeaderFormat);

            int frameNum = m_FrameBase;

            for (float x = HEADER_WIDTH; x < (float)this.Width; x += CELL_WIDTH, frameNum++)
            {
                if (frameNum <= m_SelectedFrameOut && frameNum >= m_SelectedFrameIn && m_SelectedFrameIn >= 0)
                {
                    gfx.FillRectangle(Brushes.MediumSlateBlue, new RectangleF(x, 0.0f, CELL_WIDTH, CELL_HEIGHT));
                }
                else if (m_SelectedFrameIn == SELECTION_HEADER)
                {
                    gfx.FillRectangle(Brushes.MediumSlateBlue, new RectangleF(x, 0.0f, CELL_WIDTH, CELL_HEIGHT));
                }

                if (frameNum >= m_Animation.MaxFrames)
                {
                    gfx.FillRectangle(Brushes.DarkGray, new RectangleF(x, 0.0f, CELL_WIDTH, CELL_HEIGHT));
                }
                else if (m_Animation.IsKeyFrame(frameNum))
                {
                    gfx.FillRectangle(Brushes.Fuchsia, new RectangleF(x + KFICON_RECT.X, KFICON_RECT.Y, KFICON_RECT.Width, KFICON_RECT.Height));
                }

                if ((frameNum % 10) == 0)
                {
                    gfx.DrawLine(Pens.Black, x, 0.0f, x, CELL_HEIGHT);
                }
                else
                {
                    gfx.DrawLine(Pens.Gray, x, 0.0f, x, CELL_HEIGHT);
                }
            }

            gfx.DrawLine(Pens.Gray, 0, Height - 1, Width, Height - 1);
            gfx.DrawLine(Pens.Gray, 0, 0, 0, Height - 1);
            gfx.DrawLine(Pens.Gray, Width - 1, 0, Width - 1, Height - 1);
        }

        private int GetIndent()
        {
            int i = -1;
            for (IAnimation anim = m_Animation; anim != null; anim = anim.Parent)
                i++;

            return i;
        }

        int GetSelectionCellFromXY(int X, int Y)
        {
            if (X < ((int)HEADER_WIDTH))
            {
                return SELECTION_HEADER;
            }
            else
            {
                int x = X - ((int)HEADER_WIDTH);
                x = x / ((int)CELL_WIDTH) + m_FrameBase;
                return x;
            }
        }

        bool draggingSelection = false;

        private void AddFrameToSelection(int frame)
        {
            if (frame > m_SelectedFrameIn)
            {
                m_SelectedFrameOut = frame;
            }
            else if (frame < m_SelectedFrameIn)
            {
                m_SelectedFrameOut = Math.Max(m_SelectedFrameIn, m_SelectedFrameOut);
                m_SelectedFrameIn = frame;
            }
        }


        private Tuple<int, int> BeginSelectionChange()
        {
            return new Tuple<int, int>(m_SelectedFrameIn, m_SelectedFrameOut);
        }

        private void EndSelectionChange(Tuple<int, int> selkey)
        {
            if (selkey.Item1 != m_SelectedFrameIn || selkey.Item2 != m_SelectedFrameOut)
            {
                if (SelectionChanged != null)
                    SelectionChanged(this, EventArgs.Empty);

                PropertyHasChanged();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            var selkey = BeginSelectionChange();

            base.OnMouseDown(e);

            int frame = GetSelectionCellFromXY(e.X, e.Y);

            if (frame >= 0 && Form.ModifierKeys.HasFlag(Keys.Shift))
            {
                AddFrameToSelection(frame);
            }
            else
            {
                if (m_SelectedFrameIn == m_SelectedFrameOut && m_SelectedFrameIn == frame)
                    frame = SELECTION_NONE;

                m_SelectedFrameIn = m_SelectedFrameOut = frame;
            }

            draggingSelection = (frame >= 0);

            EndSelectionChange(selkey);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            var selkey = BeginSelectionChange();

            base.OnMouseMove(e);

            if (!draggingSelection) return;

            int frame = GetSelectionCellFromXY(e.X, e.Y);
            if (frame >= 0)
            {
                AddFrameToSelection(frame);
                EndSelectionChange(selkey);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            draggingSelection = false;
        }



 


    }
}
