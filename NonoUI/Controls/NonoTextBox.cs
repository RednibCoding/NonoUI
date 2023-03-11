using NonoUI.Enums;
using NonoUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NonoUI.Controls
{
    [ToolboxItem(true)]
    [DefaultProperty("Text")]
    [ComVisible(true)]
    public partial class NonoTextBox : Control
    {
        private HorizontalAlignment _textAlign;
        private int _maxLength;
        private bool _readOnly;
        private bool _useSystemPasswordChar;
        private string _watermarkText;
        private Image _image;
        private MouseMode _state;
        private AutoCompleteSource _autoCompleteSource;
        private AutoCompleteMode _autoCompleteMode;
        private AutoCompleteStringCollection _autoCompleteCustomSource;
        private bool _multiline;
        private string[] _lines;
        private Color _backColor;
        private Color _foreColor;
        private Color _borderColor;
        private Color _hoverColor;

        private Color _disabledForeColor;
        private Color _disabledBackColor;
        private Color _disabledBorderColor;
        private TextBox _textBox = new TextBox();

        public NonoTextBox()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.UserPaint, true);
            UpdateStyles();
            Font = new Font("Segoe UI", 12, FontStyle.Regular);
            applyColors();
            initDefautls();
            if (!Multiline)
                Size = new Size(135, 30);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            if (Enabled)
            {
                using (var bg = new SolidBrush(BackColor))
                {
                    using (var p = new Pen(BorderColor))
                    {
                        using (var ph = new Pen(HoverColor))
                        {
                            g.FillRectangle(bg, rect);
                            if (_state == MouseMode.Normal)
                                g.DrawRectangle(p, rect);
                            else if (_state == MouseMode.Hovered)
                            {
                                g.DrawRectangle(ph, rect);
                            }
                        }
                    }
                }
            }
            else
            {
                using (var bg = new SolidBrush(DisabledBackColor))
                {
                    using (var p = new Pen(DisabledBorderColor))
                    {
                        g.FillRectangle(bg, rect);
                        g.DrawRectangle(p, rect);
                        _textBox.BackColor = DisabledBackColor;
                        _textBox.ForeColor = DisabledForeColor;
                    }
                }
            }
            if (Image != null)
            {
                _textBox.Location = new Point(31, 4);
                _textBox.Width = Width - 60;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(Image, new Rectangle(7, 6, 18, 18));
            }
            else
            {
                _textBox.Location = new Point(7, 4);
                _textBox.Width = Width - 10;
            }

        }

		// Gets the border style.
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BorderStyle BorderStyle => BorderStyle.None;

        // Gets or sets how text is aligned in a TextBox control.
        [Category("Nono"), Description("Gets or sets how text is aligned in a TextBox control.")]
        public HorizontalAlignment TextAlign
        {
            get => _textAlign;
            set
            {
                _textAlign = value;
                var text = _textBox;
                if (text != null)
                {
                    text.TextAlign = value;
                }
                Invalidate();
            }
        }


        // Gets or sets how text is aligned in a TextBox control.
        [Category("Nono"), Description("Gets or sets how text is aligned in a TextBox control.")]
        public int MaxLength
        {
            get => _maxLength;
            set
            {
                _maxLength = value;
                if (_textBox != null)
                {
                    _textBox.MaxLength = value;
                }
                Invalidate();
            }
        }


        // Gets or sets the background color of the control.
        [Category("Nono")]
        [Description("Gets or sets the background color of the control.")]
        public override Color BackColor
        {
            get => _backColor;
            set
            {
                _backColor = value;
                _textBox.BackColor = value;
                Invalidate();
            }
        }


        // Gets or sets the color of the control whenever hovered.
        [Category("Nono")]
        [Description("Gets or sets the color of the control whenever hovered.")]
        public Color HoverColor
        {
            get => _hoverColor;
            set
            {
                _hoverColor = value;
                Invalidate();
            }
        }


        // Gets or sets the border color of the control.
        [Category("Nono")]
        [Description("Gets or sets the border color of the control.")]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }


        // Gets or sets the foreground color of the control.
        [Category("Nono")]
        [Description("Gets or sets the foreground color of the control.")]
        [Browsable(false)]
        public override Color ForeColor
        {
            get => _foreColor;
            set
            {
                _foreColor = value;
                _textBox.ForeColor = value;
                Invalidate();
            }
        }


        // Gets or sets a value indicating whether text in the text box is read-only.
        [Category("Nono"), Description("Gets or sets a value indicating whether text in the text box is read-only.")]
        public bool ReadOnly
        {
            get => _readOnly;
            set
            {
                _readOnly = value;
                if (_textBox != null)
                {
                    _textBox.ReadOnly = value;
                }
            }
        }


        // Gets or sets a value indicating whether the text in the TextBox control should appear as the default password character.
        [Category("Nono"), Description("Gets or sets a value indicating whether the text in the TextBox control should appear as the default password character.")]
        public bool UseSystemPasswordChar
        {
            get => _useSystemPasswordChar;
            set
            {
                _useSystemPasswordChar = value;
                if (_textBox != null)
                {
                    _textBox.UseSystemPasswordChar = value;
                }
            }
        }


        // Gets or sets a value indicating whether this is a multiline TextBox control.
        [Category("Nono"), Description("Gets or sets a value indicating whether this is a multiline TextBox control.")]
        public bool Multiline
        {
            get => _multiline;
            set
            {
                _multiline = value;
                if (_textBox == null)
                { return; }
                _textBox.Multiline = value;
                if (value)
                {
                    _textBox.Height = Height - 10;
                }
                else
                {
                    Height = _textBox.Height + 10;
                }
            }
        }

        // Gets or sets the background image.
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Image BackgroundImage => null;


        // Gets or sets the current text in the TextBox.
        [Category("Nono"), Description("Gets or sets the current text in the TextBox.")]
        public override string Text
        {
            get => _textBox.Text;
            set
            {
                base.Text = value;
                if (_textBox != null)
                {
                    _textBox.Text = value;
                }
            }
        }


        // Gets or sets the text in the TextBox while being empty.
        [Category("Nono"), Description("Gets or sets the text in the TextBox while being empty.")]
        public string WatermarkText
        {
            get => _watermarkText;
            set
            {
                _watermarkText = value;
                User32.SendMessage(_textBox.Handle, 5377, 0, value);
                Invalidate();
            }
        }


        // Gets or sets the image of the control.
        [Category("Nono"), Description("Gets or sets the image of the control.")]
        public Image Image
        {
            get => _image;
            set
            {
                _image = value;
                Invalidate();
            }
        }


        // Gets or sets a value specifying the source of complete strings used for automatic completion.
        [Category("Nono"), Description("Gets or sets a value specifying the source of complete strings used for automatic completion.")]
        public AutoCompleteSource AutoCompleteSource
        {
            get => _autoCompleteSource;
            set
            {
                _autoCompleteSource = value;
                if (_textBox != null)
                {
                    _textBox.AutoCompleteSource = value;
                }
                Invalidate();
            }
        }


        // Gets or sets a value specifying the source of complete strings used for automatic completion.
        [Category("Nono"), Description("Gets or sets a value specifying the source of complete strings used for automatic completion.")]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get => _autoCompleteCustomSource;
            set
            {
                _autoCompleteCustomSource = value;
                if (_textBox != null)
                {
                    _textBox.AutoCompleteCustomSource = value;
                }
                Invalidate();
            }
        }

        // Gets or sets an option that controls how automatic completion works for the TextBox.
        [Category("Nono"), Description("Gets or sets an option that controls how automatic completion works for the TextBox.")]
        public AutoCompleteMode AutoCompleteMode
        {
            get => _autoCompleteMode;
            set
            {
                _autoCompleteMode = value;
                if (_textBox != null)
                {
                    _textBox.AutoCompleteMode = value;
                }
                Invalidate();
            }
        }

        // Gets or sets the font of the text displayed by the control.
        [Category("Nono"), Description("Gets or sets the font of the text displayed by the control.")]
        public sealed override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                if (_textBox == null)
                    return;
                _textBox.Font = value;
                _textBox.Location = new Point(5, 5);
                _textBox.Width = Width - 8;
                if (!Multiline)
                    Height = _textBox.Height + 11;
            }
        }

        // Gets or sets the lines of text in the control.
        [Category("Nono"), Description("Gets or sets the lines of text in the control.")]
        public string[] Lines
        {
            get => _lines;
            set
            {
                _lines = value;
                if (_textBox != null)
                    _textBox.Lines = value;
                Invalidate();
            }
        }


        // Gets or sets the ContextMenuStrip associated with this control.
        [Category("Nono"), Description("Gets or sets the ContextMenuStrip associated with this control.")]
        public override ContextMenuStrip ContextMenuStrip
        {
            get => base.ContextMenuStrip;
            set
            {
                base.ContextMenuStrip = value;
                if (_textBox == null)
                    return;
                _textBox.ContextMenuStrip = value;
                Invalidate();
            }
        }

        // Gets or sets the forecolor of the control whenever while disabled
        [Category("Nono"), Description("Gets or sets the forecolor of the control whenever while disabled.")]
        public Color DisabledForeColor
        {
            get { return _disabledForeColor; }
            set
            {
                _disabledForeColor = value;
                Refresh();
            }
        }

        /// Gets or sets disabled backcolor used by the control
        [Category("Nono"), Description("Gets or sets disabled backcolor used by the control.")]
        public Color DisabledBackColor
        {
            get { return _disabledBackColor; }
            set
            {
                _disabledBackColor = value;
                Refresh();
            }
        }

        // Gets or sets the border color while the control disabled.
        [Category("Nono"), Description("Gets or sets the border color while the control disabled.")]
        public Color DisabledBorderColor
        {
            get { return _disabledBorderColor; }
            set
            {
                _disabledBorderColor = value;
                Refresh();
            }
        }

        public new event EventHandler TextChanged;
        public event KeyPressEventHandler KeyPressed;
        public new event EventHandler Leave;

        // Handling textbox leave event and raising the same event here.
        public void OnLeave(object sender, EventArgs e)
        {
            base.OnMouseLeave(e);
            Leave?.Invoke(sender, e);
        }

        public void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressed?.Invoke(this, e);
            Invalidate();
        }

        // Handling mouse leave event of the control.
        protected override void OnMouseLeave(EventArgs e)
        {
            _state = MouseMode.Normal;
            base.OnMouseLeave(e);
        }

        // Handling mouse up event of the control.
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _state = MouseMode.Hovered;
            Invalidate();
        }

        // Handling mouse entering event of the control.
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _state = MouseMode.Pushed;
            Invalidate();
        }

        // Handling mouse hover event of the control.
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            _state = MouseMode.Hovered;
            Invalidate();
        }

        // Handling the mouse hover event on text box control.
        public void T_MouseHover(object sender, EventArgs e)
        {
            base.OnMouseHover(e);
            Invalidate();
        }

        // Raises the Control.Resize event.
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            _textBox.Size = new Size(Width - 10, Height - 10);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            _textBox.Focus();
        }

        // Raises the Control.Enter event.
        public void T_Enter(object sender, EventArgs e)
        {
            base.OnMouseEnter(e);
            Invalidate();
        }

        // Handling Keydown event of text box control.
        private void T_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
                e.SuppressKeyPress = true;
            if (!e.Control || e.KeyCode != Keys.C)
                return;
            _textBox.Copy();
            e.SuppressKeyPress = true;
        }

        // An System.EventArgs that contains the event data.
        private void T_TextChanged(object sender, EventArgs e)
        {
            Text = _textBox.Text;
            TextChanged?.Invoke(this, e);
            Invalidate();
        }

        // Override the control creating , here we add the base textbox to the main control.
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (!Controls.Contains(_textBox))
                Controls.Add(_textBox);
        }

        // Appends text to the current text of a text box.
        public void AppendText(string text)
        {
            _textBox?.AppendText(text);
        }

        // Undoes the last edit operation in the text box.
        public void Undo()
        {
            if (_textBox == null)
                return;
            if (_textBox.CanUndo)
            {
                _textBox.Undo();
            }
        }

        // Retrieves the line number from the specified character position within the text of the control.
        public int GetLineFromCharIndex(int index)
        {
            return _textBox?.GetLineFromCharIndex(index) ?? 0;
        }

        // Retrieves the location within the control at the specified character index.am>
        public Point GetPositionFromCharIndex(int index)
        {
            return _textBox.GetPositionFromCharIndex(index);
        }

        // Retrieves the index of the character nearest to the specified location.
        public int GetCharIndexFromPosition(Point pt)
        {
            return _textBox?.GetCharIndexFromPosition(pt) ?? 0;
        }

        // Clears information about the most recent operation from the undo buffer of the text box.
        public void ClearUndo()
        {
            _textBox?.ClearUndo();
        }

        // Copies the current selection in the text box to the Clipboard.
        public void Copy()
        {
            _textBox?.Copy();
        }

        // Moves the current selection in the text box to the Clipboard.
        public void Cut()
        {
            _textBox?.Cut();
        }

        // Selects all text in the text box.
        public void SelectAll()
        {
            _textBox?.SelectAll();
        }

        // Specifies that the value of the TextBoxBase.SelectionLength property is zero so that no characters are selected in the control.
        public void DeselectAll()
        {
            _textBox?.DeselectAll();
        }


        // Replaces the current selection in the text box with the contents of the Clipboard.
        public void Paste(string clipFormat)
        {
            _textBox?.Paste(clipFormat);
        }


        // Selects a range of text in the text box.
        public void Select(int start, int length)
        {
            _textBox?.Select(start, length);
        }

        void initDefautls()
        {
            _watermarkText = string.Empty;
            _useSystemPasswordChar = false;
            _readOnly = false;
            _maxLength = 32767;
            _textAlign = HorizontalAlignment.Left;
            _state = MouseMode.Normal;
            _autoCompleteMode = AutoCompleteMode.None;
            _autoCompleteSource = AutoCompleteSource.None;
            _lines = null;
            _multiline = false;
            _textBox.Multiline = _multiline;
            _textBox.Cursor = Cursors.IBeam;
            _textBox.BackColor = BackColor;
            _textBox.ForeColor = ForeColor;
            _textBox.BorderStyle = BorderStyle.None;
            _textBox.Location = new Point(7, 8);
            _textBox.Font = Font;
            _textBox.UseSystemPasswordChar = UseSystemPasswordChar;
            if (Multiline)
            {
                _textBox.Height = Height - 11;
            }
            else
            {
                Height = _textBox.Height + 11;
            }

            _textBox.MouseHover += T_MouseHover;
            _textBox.Leave += OnLeave;
            _textBox.Enter += T_Enter;
            _textBox.KeyDown += T_KeyDown;
            _textBox.TextChanged += T_TextChanged;
            _textBox.KeyPress += OnKeyPress;
        }

        void applyColors()
        {
            ForeColor = Color.FromArgb(20, 20, 20);
            BackColor = Color.FromArgb(238, 238, 238);
            HoverColor = Color.FromArgb(102, 102, 102);
            BorderColor = Color.FromArgb(155, 155, 155);
            DisabledBackColor = Color.FromArgb(204, 204, 204);
            DisabledBorderColor = Color.FromArgb(155, 155, 155);
            DisabledForeColor = Color.FromArgb(136, 136, 136);
        }

    }
}
