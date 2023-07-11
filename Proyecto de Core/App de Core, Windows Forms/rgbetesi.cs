using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace App_de_Core__Windows_Forms
{
    public class RoundedGroupBox3 : GroupBox
    {
        public int _cornerRadius ;

        public RoundedGroupBox3()
        {
            _cornerRadius = 25;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SizeF textsize = e.Graphics.MeasureString(this.Text, this.Font);
            Rectangle rect = new Rectangle(ClientRectangle.X, ClientRectangle.Y + (int)textsize.Height / 2, ClientRectangle.Width - 1, ClientRectangle.Height - (int)textsize.Height / 2 - 1);

            using (GraphicsPath path = RoundedRectangle(rect, _cornerRadius))
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.White, 2))
                {
                    e.Graphics.DrawPath(pen, path);
                }
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }

            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new PointF(ClientRectangle.X + (ClientRectangle.Width - textsize.Width) / 2, ClientRectangle.Y));
        }

        private GraphicsPath RoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath roundedRect = new GraphicsPath();
            roundedRect.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
            roundedRect.AddLine(rect.X + radius, rect.Y, rect.Right - radius * 2, rect.Y);
            roundedRect.AddArc(rect.X + rect.Width - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
            roundedRect.AddLine(rect.Right, rect.Y + radius * 2, rect.Right, rect.Y + rect.Height - radius * 2);
            roundedRect.AddArc(rect.X + rect.Width - radius * 2, rect.Y + rect.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            roundedRect.AddLine(rect.Right - radius * 2, rect.Bottom, rect.X + radius * 2, rect.Bottom);
            roundedRect.AddArc(rect.X, rect.Y + rect.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            roundedRect.AddLine(rect.X, rect.Bottom - radius * 2, rect.X, rect.Y + radius * 2);
            roundedRect.CloseFigure();
            return roundedRect;
        }
    }
}
