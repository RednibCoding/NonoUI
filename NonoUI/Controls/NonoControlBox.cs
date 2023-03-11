using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NonoUI.Controls
{
    [ToolboxItem(true)]
    [DefaultProperty("Click")]
    [ComVisible(true)]
    public class NonoControlBox : Control
    {
        private bool _maximizeBox = true;
        private bool _minimizeBox = true;
        private Color _closeNormalForeColor;
        private Color _closeHoverForeColor;
        private Color _closeHoverBackColor;
        private Color _maximizeHoverForeColor;
        private Color _maximizeHoverBackColor;
        private Color _maximizeNormalForeColor;
        private Color _minimizeHoverForeColor;
        private Color _minimizeHoverBackColor;
        private Color _minimizeNormalForeColor;
        private Color _disabledForeColor;

        private bool MinimizeHovered { get; set; }
        private bool MaximizeHovered { get; set; }
        private bool CloseHovered { get; set; }

        public NonoControlBox()
        {
            SetStyle(
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();
            //_utl = new Utilites();
            base.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            applyColors();
        }

		// Gets or sets a value indicating whether the Maximize button is Enabled in the caption bar of the form.
		[Category("MetroSet Framework"), Description("Gets or sets a value indicating whether the Maximize button is Enabled in the caption bar of the form.")]
        public bool MaximizeBox
        {
            get { return _maximizeBox; }
            set
            {
                _maximizeBox = value;
                Refresh();
            }
        }

        // Gets or sets a value indicating whether the Minimize button is Enabled in the caption bar of the form.
        [Category("MetroSet Framework"), Description("Gets or sets a value indicating whether the Minimize button is Enabled in the caption bar of the form.")]
        public bool MinimizeBox
        {
            get { return _minimizeBox; }
            set
            {
                _minimizeBox = value;
                Refresh();
            }
        }

        // Gets or sets Close ForeColor used by the control
        [Category("MetroSet Framework"), Description("Gets or sets Close forecolor used by the control.")]
        public Color CloseNormalForeColor
        {
            get { return _closeNormalForeColor; }
            set
            {
                _closeNormalForeColor = value;
                Refresh();
            }
        }

        // Gets or sets Close ForeColor used by the control
        [Category("MetroSet Framework"), Description("Gets or sets Close forecolor used by the control.")]
        public Color CloseHoverForeColor
        {
            get { return _closeHoverForeColor; }
            set
            {
                _closeHoverForeColor = value;
                Refresh();
            }
        }

        // Gets or sets Close BackColor used by the control
        [Category("MetroSet Framework"), Description("Gets or sets Close backcolor used by the control.")]
        public Color CloseHoverBackColor
        {
            get { return _closeHoverBackColor; }
            set
            {
                _closeHoverBackColor = value;
                Refresh();
            }
        }

        // Gets or sets Maximize ForeColor used by the control
        [Category("MetroSet Framework"), Description("Gets or sets Maximize forecolor used by the control.")]
        public Color MaximizeHoverForeColor
        {
            get { return _maximizeHoverForeColor; }
            set
            {
                _maximizeHoverForeColor = value;
                Refresh();
            }
        }

        // Gets or sets Maximize BackColor used by the control
        [Category("MetroSet Framework"), Description("Gets or sets Maximize backcolor used by the control.")]
        public Color MaximizeHoverBackColor
        {
            get { return _maximizeHoverBackColor; }
            set
            {
                _maximizeHoverBackColor = value;
                Refresh();
            }
        }

        // Gets or sets Maximize ForeColor used by the control
        [Category("MetroSet Framework"), Description("Gets or sets Maximize forecolor used by the control.")]
        public Color MaximizeNormalForeColor
        {
            get { return _maximizeNormalForeColor; }
            set
            {
                _maximizeNormalForeColor = value;
                Refresh();
            }
        }

        // Gets or sets Minimize ForeColor used by the control
        [Category("MetroSet Framework"), Description("Gets or sets Minimize forecolor used by the control.")]
        public Color MinimizeHoverForeColor
        {
            get { return _minimizeHoverForeColor; }
            set
            {
                _minimizeHoverForeColor = value;
                Refresh();
            }
        }

        // Gets or sets Minimize BackColor used by the control
        [Category("MetroSet Framework"), Description("Gets or sets Minimize backcolor used by the control.")]
        public Color MinimizeHoverBackColor
        {
            get { return _minimizeHoverBackColor; }
            set
            {
                _minimizeHoverBackColor = value;
                Refresh();
            }
        }

        // Gets or sets Minimize ForeColor used by the control
        [Category("MetroSet Framework"), Description("Gets or sets Minimize forecolor used by the control.")]
        public Color MinimizeNormalForeColor
        {
            get { return _minimizeNormalForeColor; }
            set
            {
                _minimizeNormalForeColor = value;
                Refresh();
            }
        }

        // Gets or sets disabled ForeColor used by the control
        [Category("MetroSet Framework"), Description("Gets or sets disabled forecolor used by the control.")]
        public Color DisabledForeColor
        {
            get { return _disabledForeColor; }
            set
            {
                _disabledForeColor = value;
                Refresh();
            }
        }

        // I make BackColor inaccessible cause we dont need it. 
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor => Color.Transparent;

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            using (var closeBoxState = new SolidBrush(CloseHovered ? CloseHoverBackColor : Color.Transparent))
            {
                using (var f = new Font(@"Marlett", 12))
                {
                    using (var tb = new SolidBrush(CloseHovered ? CloseHoverForeColor : CloseNormalForeColor))
                    {
                        using (var sf = new StringFormat { Alignment = StringAlignment.Center })
                        {
                            g.FillRectangle(closeBoxState, new Rectangle(70, 5, 27, Height));
                            g.DrawString("r", f, CloseHovered ? tb : Brushes.Gray, new Point(Width - 16, 8), sf);
                        }
                    }
                }
            }
            using (var maximizeBoxState = new SolidBrush(MaximizeBox ? MaximizeHovered ? MaximizeHoverBackColor : Color.Transparent : Color.Transparent))
            {
                using (var f = new Font(@"Marlett", 12))
                {
                    using (var tb = new SolidBrush(MaximizeBox ? MaximizeHovered ? MaximizeHoverForeColor : MaximizeNormalForeColor : DisabledForeColor))
                    {
                        var maxSymbol = Parent.FindForm()?.WindowState == FormWindowState.Maximized ? "2" : "1";
                        using (var sf = new StringFormat { Alignment = StringAlignment.Center })
                        {
                            g.FillRectangle(maximizeBoxState, new Rectangle(38, 5, 24, Height));
                            g.DrawString(maxSymbol, f, tb, new Point(51, 7), sf);
                        }
                    }
                }
            }
            using (var minimizeBoxState = new SolidBrush(MinimizeBox ? MinimizeHovered ? MinimizeHoverBackColor : Color.Transparent : Color.Transparent))
            {
                using (var f = new Font(@"Marlett", 12))
                {
                    using (var tb = new SolidBrush(MinimizeBox ? MinimizeHovered ? MinimizeHoverForeColor : MinimizeNormalForeColor : DisabledForeColor))
                    {
                        using (var sf = new StringFormat { Alignment = StringAlignment.Center })
                        {
                            g.FillRectangle(minimizeBoxState, new Rectangle(5, 5, 27, Height));
                            g.DrawString("0", f, tb, new Point(20, 7), sf);
                        }
                    }
                }
            }
        }

        // Here we provide the fixed size while resizing.
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size = new Size(100, 35);
        }

        // Handling mouse up event of the control so that we detect if cursor located in our need area.
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Location.Y > 0 && e.Location.Y < (Height - 2))
            {
                if (e.Location.X > 0 && e.Location.X < 34)
                {
                    Cursor = Cursors.Hand;
                    MinimizeHovered = true;
                    MaximizeHovered = false;
                    CloseHovered = false;
                }
                else if (e.Location.X > 33 && e.Location.X < 65)
                {
                    Cursor = Cursors.Hand;
                    MinimizeHovered = false;
                    MaximizeHovered = true;
                    CloseHovered = false;
                }
                else if (e.Location.X > 64 && e.Location.X < Width)
                {
                    Cursor = Cursors.Hand;
                    MinimizeHovered = false;
                    MaximizeHovered = false;
                    CloseHovered = true;
                }
                else
                {
                    Cursor = Cursors.Arrow;
                    MinimizeHovered = false;
                    MaximizeHovered = false;
                    CloseHovered = false;
                }
            }
            Invalidate();
        }

        // Handling mouse up event of the control so that we can perform action commands.
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (CloseHovered)
            {
                Parent.FindForm()?.Close();
            }
            else if (MinimizeHovered)
            {
                if (!MinimizeBox)
                    return;
                Parent.FindForm().WindowState = FormWindowState.Minimized;
            }
            else if (MaximizeHovered)
            {
                if (MaximizeBox)
                {
                    Parent.FindForm().WindowState = Parent.FindForm()?.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
                }
            }
        }

        // Handling mouse leave event of the control.
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Cursor = Cursors.Default;
            MinimizeHovered = false;
            MaximizeHovered = false;
            CloseHovered = false;
            Invalidate();
        }

        // Handling mouse down event of the control.

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Focus();
        }

        void applyColors()
        {
            CloseHoverBackColor = Color.FromArgb(183, 40, 40);
            CloseHoverForeColor = Color.White;
            CloseNormalForeColor = Color.Gray;
            MaximizeHoverBackColor = Color.FromArgb(238, 238, 238);
            MaximizeHoverForeColor = Color.Gray;
            MaximizeNormalForeColor = Color.Gray;
            MinimizeHoverBackColor = Color.FromArgb(238, 238, 238);
            MinimizeHoverForeColor = Color.Gray;
            MinimizeNormalForeColor = Color.Gray;
            DisabledForeColor = Color.DimGray;
        }
    }
}
