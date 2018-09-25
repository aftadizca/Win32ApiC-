using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace QuantumConcepts.Common.Forms.UI.Controls
{
    internal class ProgressBarEx : ProgressBar
    {
        public ProgressBarEx()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush brush = null;
            Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);

            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec);

            var text = this.Tag == null ? "IN HERE" : this.Tag.ToString();

            rec.Width = (int)(rec.Width * ((double)base.Value / Maximum))+1;
            rec.Height -= 4;
            brush = new LinearGradientBrush(rec, this.ForeColor, this.BackColor, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brush, 2, 2, rec.Width, rec.Height);
            e.Graphics.DrawString(text, new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new PointF(this.Width / 2 - text.Length*8.25F/2, this.Height / 2 - 9));
        }
    }
}