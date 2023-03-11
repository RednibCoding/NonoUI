using NonoUI.Enums;
using NonoUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Text;

namespace NonoUI.Controls
{
    [ToolboxBitmap(typeof(NonoButton), "Assets.Icons.simple_button.png")]
    [ToolboxItem(true)]
    [DefaultEvent("Click")]
    [DefaultProperty("Text")]
    public partial class NonoButton : Control
    {
        private MouseMode _mouseMode;
        private Color _normalColor;
        private Color _normalBorderColor;
        private Color _normalTextColor;
        private Color _hoverColor;
        private Color _hoverBorderColor;
        private Color _hoverTextColor;
        private Color _pressColor;
        private Color _pressBorderColor;
        private Color _pressTextColor;
        private Color _disabledBackColor;
        private Color _disabledForeColor;
        private Color _disabledBorderColor;

        private readonly Drawing? _drawing;

        public NonoButton()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw | ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor, true
            );
            base.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            _drawing = new Drawing();
            applyColors();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            var r = new Rectangle(0, 0, Width - 1, Height - 1);
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            switch (_mouseMode)
            {
                case MouseMode.Normal:

                    using (var bg = new SolidBrush(NormalColor))
                    using (var p = new Pen(NormalBorderColor))
                    using (var tb = new SolidBrush(NormalTextColor))
                    {
                        g.FillRectangle(bg, r);
                        g.DrawRectangle(p, r);
                        g.DrawString(Text, Font, tb, r, _drawing?.SetPosition());
                    }

                    break;

                case MouseMode.Hovered:

                    Cursor = Cursors.Hand;
                    using (var bg = new SolidBrush(HoverColor))
                    using (var p = new Pen(HoverBorderColor))
                    using (var tb = new SolidBrush(HoverTextColor))
                    {
                        g.FillRectangle(bg, r);
                        g.DrawRectangle(p, r);
                        g.DrawString(Text, Font, tb, r, _drawing?.SetPosition());
                    }

                    break;

                case MouseMode.Pushed:

                    using (var bg = new SolidBrush(PressColor))
                    using (var p = new Pen(PressBorderColor))
                    using (var tb = new SolidBrush(PressTextColor))
                    {
                        g.FillRectangle(bg, r);
                        g.DrawRectangle(p, r);
                        g.DrawString(Text, Font, tb, r, _drawing?.SetPosition());
                    }

                    break;

                case MouseMode.Disabled:

                    using (var bg = new SolidBrush(DisabledBackColor))
                    using (var p = new Pen(DisabledBorderColor))
                    using (var tb = new SolidBrush(DisabledForeColor))
                    {
                        g.FillRectangle(bg, r);
                        g.DrawRectangle(p, r);
                        g.DrawString(Text, Font, tb, r, _drawing?.SetPosition());
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void applyColors()
        {
            NormalColor = Color.FromArgb(65, 177, 225);
            NormalBorderColor = Color.FromArgb(65, 177, 225);
            NormalTextColor = Color.White;
            HoverColor = Color.FromArgb(95, 207, 255);
            HoverBorderColor = Color.FromArgb(95, 207, 255);
            HoverTextColor = Color.White;
            PressColor = Color.FromArgb(35, 147, 195);
            PressBorderColor = Color.FromArgb(35, 147, 195);
            PressTextColor = Color.White;
            DisabledBackColor = Color.FromArgb(120, 65, 177, 225);
            DisabledBorderColor = Color.FromArgb(120, 65, 177, 225);
            DisabledForeColor = Color.Gray;
        }

		// Make BackColor inaccessible cause we dont need it 
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]

        public override Color BackColor => Color.Transparent;

        // Handling Control Enable state to detect the disability state.
        [Category("Nono")]
        [Description("Gets or sets the button enabled state.")]
        public new bool Enabled
        {
            get => base.Enabled;
            set
            {
                base.Enabled = value;
                _mouseMode = value ? MouseMode.Normal : MouseMode.Disabled;
                Invalidate();
            }
        }

        // Gets or sets the button background color in normal mouse sate
        [Category("Nono")]
        [Description("Gets or sets the button background color in normal mouse sate.")]
        public Color NormalColor
        {
            get { return _normalColor; }
            set
            {
                _normalColor = value;
                Refresh();
            }
        }

        // Gets or sets the button border color in normal mouse sate
        [Category("Nono")]
        [Description("Gets or sets the button border color in normal mouse sate.")]
        public Color NormalBorderColor
        {
            get { return _normalBorderColor; }
            set
            {
                _normalBorderColor = value;
                Refresh();
            }
        }

        // Gets or sets the button Text color in normal mouse sate
        [Category("Nono")]
        [Description("Gets or sets the button Text color in normal mouse sate.")]
        public Color NormalTextColor
        {
            get { return _normalTextColor; }
            set
            {
                _normalTextColor = value;
                Refresh();
            }
        }

        // Gets or sets the button background color in hover mouse sate.
        [Category("Nono")]
        [Description("Gets or sets the button background color in hover mouse sate.")]
        public Color HoverColor
        {
            get { return _hoverColor; }
            set
            {
                _hoverColor = value;
                Refresh();
            }
        }

        // Gets or sets the button border color in hover mouse sate.
        [Category("Nono")]
        [Description("Gets or sets the button border color in hover mouse sate.")]
        public Color HoverBorderColor
        {
            get { return _hoverBorderColor; }
            set
            {
                _hoverBorderColor = value;
                Refresh();
            }
        }


        // Gets or sets the button Text color in hover mouse sate.
        [Category("Nono")]
        [Description("Gets or sets the button Text color in hover mouse sate.")]
        public Color HoverTextColor
        {
            get { return _hoverTextColor; }
            set
            {
                _hoverTextColor = value;
                Refresh();
            }
        }

        // Gets or sets the button background color in pushed mouse sate.
        [Category("Nono")]
        [Description("Gets or sets the button background color in pushed mouse sate.")]
        public Color PressColor
        {
            get { return _pressColor; }
            set
            {
                _pressColor = value;
                Refresh();
            }
        }

        // Gets or sets the button border color in pushed mouse sate.
        [Category("Nono")]
        [Description("Gets or sets the button border color in pushed mouse sate.")]
        public Color PressBorderColor
        {
            get { return _pressBorderColor; }
            set
            {
                _pressBorderColor = value;
                Refresh();
            }
        }

        // Gets or sets the button Text color in pushed mouse sate.
        [Category("Nono")]
        [Description("Gets or sets the button Text color in pushed mouse sate.")]
        public Color PressTextColor
        {
            get { return _pressTextColor; }
            set
            {
                _pressTextColor = value;
                Refresh();
            }
        }

        // Gets or sets BackColor used by the control while disabled.
        [Category("Nono")]
        [Description("Gets or sets backcolor used by the control while disabled.")]
        public Color DisabledBackColor
        {
            get { return _disabledBackColor; }
            set
            {
                _disabledBackColor = value;
                Refresh();
            }
        }

        // Gets or sets the ForeColor of the control whenever while disabled.
        [Category("Nono")]
        [Description("Gets or sets the forecolor of the control whenever while disabled.")]
        public Color DisabledForeColor
        {
            get { return _disabledForeColor; }
            set
            {
                _disabledForeColor = value;
                Refresh();
            }
        }

        // Gets or sets the border color of the control while disabled.
        [Category("Nono")]
        [Description("Gets or sets the border color of the control while disabled.")]
        public Color DisabledBorderColor
        {
            get { return _disabledBorderColor; }
            set
            {
                _disabledBorderColor = value;
                Refresh();
            }
        }

        private bool _isDerivedStyle = true;

        // Gets or sets the whether this control reflect to parent form style.
        // Set it to false if you want the style of this control be independent. 
        [Category("Nono")]
        [Description("Gets or sets the whether this control reflect to parent(s) style. \n " +
                     "Set it to false if you want the style of this control be independent. ")]
        public bool IsDerivedStyle
        {
            get { return _isDerivedStyle; }
            set
            {
                _isDerivedStyle = value;
                Refresh();
            }
        }


        // Handling mouse up event of the control.
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _mouseMode = MouseMode.Hovered;
            Invalidate();
        }


        // Handling mouse down event of the control.
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _mouseMode = MouseMode.Pushed;
            Invalidate();
        }

        // Handling mouse entering event of the control.
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _mouseMode = MouseMode.Hovered;
            Invalidate();
        }

        // Handling mouse leave event of the control.
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseEnter(e);
            _mouseMode = MouseMode.Normal;
            Invalidate();
        }
    }
}
