using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnimationEditor
{
    public partial class FrameEditorHeaderControl : UserControl
    {
        public FrameEditorHeaderControl()
        {
            m_Font = new Font("Tahoma", 10.0f);
            m_HeaderFormat.Alignment = StringAlignment.Center;
            m_HeaderFormat.LineAlignment = StringAlignment.Center;
            m_HeaderFormat.Trimming = StringTrimming.EllipsisCharacter;
            m_HeaderFormat.FormatFlags = StringFormatFlags.NoWrap;
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        public int FrameBase
        {
            get { return m_FrameBase; }
            set { m_FrameBase = value; PropertyHasChanged(); }
        }

        int m_FrameBase = 0;
        bool m_LockRedrawForChanges = false;
        bool m_HaveChangesDuringLock = false;
        Font m_Font = new Font("Tahoma", 9.0f);
        StringFormat m_HeaderFormat = new StringFormat();

        private void PropertyHasChanged()
        {
            if (m_LockRedrawForChanges)
                m_HaveChangesDuringLock = true;
            else
                this.Invalidate();
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

            //gfx.FillRectangle(Brushes.LimeGreen, 0, 0, Width, Height);

            int frameNum = m_FrameBase;

            gfx.DrawLine(Pens.Gray, 0, CELL_HEIGHT - 1, Width, CELL_HEIGHT - 1);
            
            for (float x = HEADER_WIDTH; x < (float)this.Width; x += CELL_WIDTH, frameNum++)
            {
                if ((frameNum % 10) == 0)
                {
                    gfx.FillRectangle(Brushes.LightSteelBlue, new RectangleF(x, CELL_HEIGHT, CELL_WIDTH, 2.0f* CELL_HEIGHT));

                    SizeF size = gfx.MeasureString(frameNum.ToString(), m_Font, 70, m_HeaderFormat);

                    float center = (CELL_WIDTH - size.Width) / 2.0f + x;

                    RectangleF rect = new RectangleF(center, 0.0f, size.Width, CELL_HEIGHT);

                    gfx.FillRectangle(Brushes.LightSteelBlue, rect);

                    gfx.DrawString(frameNum.ToString(), m_Font, Brushes.Black, rect, m_HeaderFormat);

                    gfx.DrawRectangle(Pens.Gray, rect.X, rect.Y, rect.Width, rect.Height - 1);
                    gfx.DrawLine(Pens.LightSteelBlue, x, CELL_HEIGHT - 1, x + CELL_WIDTH, CELL_HEIGHT - 1);

                    gfx.DrawLine(Pens.Black, x, CELL_HEIGHT, x, 2.0f * CELL_HEIGHT);
                }
                else
                    gfx.DrawLine(Pens.Gray, x, CELL_HEIGHT, x, 2.0f * CELL_HEIGHT);
            }

            gfx.DrawLine(Pens.Gray, 0, Height - 1, Width, Height - 1);
            gfx.DrawLine(Pens.Gray, 0, CELL_HEIGHT, 0, Height - 1);
            gfx.DrawLine(Pens.Gray, Width - 1, CELL_HEIGHT, Width - 1, Height - 1);
        }






















    }
}
