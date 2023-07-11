using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion_de_Core_WinForms
{
    [DefaultEvent("_TextChanged")]
    public partial class RoundedTextBox : UserControl
    {
        //Fields
        private Color bordercolor = Color.MediumSlateBlue;
        private int bordersize = 2;
        private bool underlinedstryle = false;
        private Color borderColorFocus = Color.HotPink;
        private bool isFocused = false;
        private int borderRadius = 0;
        private bool isPlaceHolder = false;
        private Color placeHolderColor = Color.DarkGray;
        private string placeholderText = "";
        private bool isPasswordChar = false;

        public RoundedTextBox()
        {
            InitializeComponent();
        }
        //EVENTOS
        public event EventHandler _TextChanged;

        //Propiedades

        [Category("Elementos Nuevos")]
        public Color Bordercolor
        {
            get
            {
                return bordercolor;
            }
            set
            {
                bordercolor = value; Invalidate();
            }
        }

        [Category("Elementos Nuevos")]
        public int Bordersize
        {
            get
            {
                return bordersize;
            }
            set
            {
                bordersize = value; Invalidate();
            }
        }

        [Category("Elementos Nuevos")]
        public bool Underlinedstryle
        {
            get
            {
                return underlinedstryle;
            }
            set
            {
                underlinedstryle = value; Invalidate();
            }
        }

        [Category("Elementos Nuevos")]
        public bool PasswordChar
        {
            get { return isPasswordChar; }
            set { isPasswordChar = value; textBox1.UseSystemPasswordChar = value; }
        }

        [Category("Elementos Nuevos")]
        public bool Multiline
        {
            get { return textBox1.Multiline; }
            set { textBox1.Multiline = value; }
        }

        [Category("Elementos Nuevos")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; textBox1.BackColor = value; }
        }

        [Category("Elementos Nuevos")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; textBox1.ForeColor = value; }
        }

        [Category("Elementos Nuevos")]
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; textBox1.Font = value; if (DesignMode) UpdateControlHeight(); }
        }

        [Category("Elementos Nuevos")]
        public string Texts
        {
            get { if (isPlaceHolder) return ""; else return textBox1.Text; }
            set { textBox1.Text = value; SetPlaceHolder(); }
        }


        [Category("Elementos Nuevos")]
        public Color BorderColorFocus { get => borderColorFocus; set => borderColorFocus = value; }

        [Category("Elementos Nuevos")]
        public int BorderRadius 
        {
            get
            {
                return borderRadius;
            }
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Elementos Nuevos")]
        public Color PlaceHolderColor { 
            get
            {
                return placeHolderColor;
            } 
            set
            {
                placeHolderColor = value;
                if (isPasswordChar) textBox1.ForeColor = value;
            }
        }

        [Category("Elementos Nuevos")]
        public string PlaceholderText
        {
            get
            {
                return placeholderText;
            }
            set
            {
                placeholderText = value;
                textBox1.Text = "";
                SetPlaceHolder();
            }
        }

        [Category("Elementos Nuevos")]
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            if(borderRadius > 1)
            {
                //Fields
                var rectangleSmooth = this.ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectangleSmooth, -bordersize, -bordersize);
                int smoothSize = bordersize >0 ? bordersize : 1;

                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectangleSmooth, borderRadius)) 
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - bordersize)) 
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize)) 
                using (Pen penBorder = new Pen(bordercolor,bordersize))
                {
                    //Drawing
                    this.Region = new Region(pathBorderSmooth);//ROUNDED rEGION OF UserControl
                    if (borderRadius > 15) setTextBoxRoundedRegion();//CUANDRO DE TEXTO REDONDEADO
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;

                        if (isFocused)
                        {
                            penBorder.Color = borderColorFocus;
                        }

                        if (underlinedstryle)
                        {
                            graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                            graph.SmoothingMode = SmoothingMode.None;
                            graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                        }
                        else
                        {
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                            graph.DrawPath(penBorder, pathBorder);
                        }
                    }

            }
            else
            {
                using (Pen penBorder = new Pen(Bordercolor, bordersize))
                {
                    this.Region = new Region(this.ClientRectangle);
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                    if (isFocused)
                    {
                        penBorder.Color = borderColorFocus;
                    }

                    if (underlinedstryle)
                    {
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else
                    {
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5f, this.Height - 0.5F);
                    }
                }
            }
        }


        private void SetPlaceHolder()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) && placeholderText != "")
            {
                isPlaceHolder = true;
                textBox1.Text = placeholderText;
                textBox1.ForeColor = placeHolderColor;
                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = false;
            }
        }

        private void RemovePlaceHolder()
        {
            if (isPlaceHolder && placeholderText != "")
            {
                isPlaceHolder = false;
                textBox1.Text = "";
                textBox1.ForeColor = this.ForeColor;
                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = true;
            }
        }

        private void setTextBoxRoundedRegion()
        {
            GraphicsPath pathText;
            if (Multiline)
            {
                pathText = GetFigurePath(textBox1.ClientRectangle,BorderRadius-bordersize);
                textBox1.Region = new Region(pathText);
            }
            else
            {
                pathText = GetFigurePath(textBox1.ClientRectangle, BorderRadius*2);
                textBox1.Region = new Region(pathText);
            }
        }

        private GraphicsPath GetFigurePath(Rectangle rect,int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curvesize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curvesize, curvesize, 180, 90);
            path.AddArc(rect.Right-curvesize, rect.Y, curvesize, curvesize, 270, 90);
            path.AddArc(rect.Right-curvesize, rect.Bottom-curvesize, curvesize, curvesize, 0, 90);
            path.AddArc(rect.X, rect.Bottom-curvesize, curvesize, curvesize, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
            {
                UpdateControlHeight();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        private void UpdateControlHeight()
        {
            if(textBox1.Multiline == false)
            {
                int textHeight = TextRenderer.MeasureText("Text",this.Font).Height+1;
                textBox1.Multiline = true;
                textBox1.MinimumSize=new Size(0, textHeight);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
            {
                _TextChanged.Invoke(sender, e);
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            this.OnMouseHover(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            RemovePlaceHolder();
            this.Invalidate();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused=false;
            SetPlaceHolder();
            this.Invalidate();
        }
    }
}
