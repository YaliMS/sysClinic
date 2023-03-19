using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz.btn
{
    [DefaultEvent("_TextChanged")]

    public partial class ucBtn : DevExpress.XtraEditors.XtraUserControl
    {
        //fields
        // Color de borde
        private Color borderColor = Color.MediumSlateBlue;

        //tamaño de border
        private int borderSize = 2;

        //estilo del cuadro de texto o subrayado
        private bool underlineStyle = false;

        private Color borderFocusColor = Color.HotPink;
        private bool isFocused = false;


        //Eventos
        public event EventHandler _TextChanged;


        //Constructor
        public ucBtn()
        {
            InitializeComponent();
        }


        






        [Category("AlquimiaSoft")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
                this.Invalidate();
            }
            set
            {
                borderColor = value;
            }
        }

        [Category("AlquimiaSoft")]
        public int BorderSize
        {
            get
            {
                return borderSize;
                this.Invalidate();
            }
            set
            {
                borderSize = value;
            }
        }


        [Category("AlquimiaSoft")]
        public bool UnderlineStyle
        {
            get
            {
                return underlineStyle;
                this.Invalidate();
            }
            set
            {
                underlineStyle = value;
            }
        }

        [Category("AlquimiaSoft")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }

        [Category("AlquimiaSoft")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }

        [Category("AlquimiaSoft")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                textBox1.Font = value;
                if (this.DesignMode)
                    UpdateControlHeight();
            }
        }

        [Category("AlquimiaSoft")]
        public string Texts
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }

        [Category("AlquimiaSoft")]
        public Color BorderFocusColor
        {
            get
            {
                return borderFocusColor;
            }
            set
            {
                borderFocusColor = value;
            }
        }

        //Anular metodos de eventos o sobreescribirlos
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            //dibujar el border del cuadro de texto
            using (Pen penBorder=new Pen(borderColor,borderSize))
            {
                penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                if (!isFocused)
                {
                    if (underlineStyle)//dibuja el estilo de linea o subrayado
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    else  //se dibuja el estilo normal del rectangulo
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }
                else
                {
                    penBorder.Color = borderFocusColor;

                    if (underlineStyle)//dibuja el estilo de linea o subrayado
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    else  //se dibuja el estilo normal del rectangulo
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }
                
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if(this.DesignMode)
            UpdateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false)
            {
                int txtHeigth = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeigth);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
                _TextChanged.Invoke(sender, e);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
        }
    }
}
