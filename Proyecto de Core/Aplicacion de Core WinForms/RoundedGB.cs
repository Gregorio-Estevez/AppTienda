using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Aplicacion_de_Core_WinForms
{
    public class RoundedGroupBox : GroupBox
    {
        private int radius = 25;
        public RoundedGroupBox()
        {
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawRoundedGroupBox(e.Graphics);
        }

        private void DrawRoundedGroupBox(Graphics graphics)
        {
            using (var path = new GraphicsPath())
            {
                int arc = this.radius * 2;
                Rectangle rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);

                path.AddArc(rect.X, rect.Y, arc, arc, 180, 90);
                path.AddArc(rect.X + rect.Width - arc, rect.Y, arc, arc, 270, 90);
                path.AddArc(rect.X + rect.Width - arc, rect.Y + rect.Height - arc, arc, arc, 0, 90);
                path.AddArc(rect.X, rect.Y + rect.Height - arc, arc, arc, 90, 90);
                path.CloseFigure();

                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.DrawPath(new Pen(this.ForeColor), path);
                graphics.FillPath(new SolidBrush(this.BackColor), path);
            }
        }
    }
 

}
