using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Text;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace NonoUI.Controls
{
    [ToolboxBitmap(typeof(SimpleButton), "Assets.Icons.simple_button.png")]
    public partial class SimpleButton : Button
    {
        private Color _buttonColor = Color.FromArgb(255, 98, 0, 238);
        private Color _buttonToggleColor = Color.FromArgb(255, 20, 0, 80);
        private Color _textColor = Color.White;
        private Font _font = new Font("Sans Serif", 10, FontStyle.Regular);
        private bool _isToggled = false;
        private bool _isToggleable = false;
        private string _toggleText = string.Empty;
        private string _buttonText = string.Empty;

        public SimpleButton() : base()
        {
            InitializeComponent();
            BackColor = _buttonColor;
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            ForeColor = _textColor;
            Font = _font;
            Width = 100;
            Height = 30;

            MouseUp += new MouseEventHandler(on_MouseUp);
        }

        [Category("Nono")]
        [Description("Specifies whether the button is toggleable or not.")]
        [Browsable(true)]
        public bool IsToggleable
        {
            get { return _isToggleable; }
            set { _isToggleable = value; }
        }

        [Category("Nono")]
        [Description("Specifies whether the button is toggled or not (Only works if the button is toggleable.")]
        [Browsable(true)]
        public bool IsToggled
        {
            get { return _isToggled; }
            set
            {
                _isToggled = value;
                if (_isToggled == true)
                {
                    BackColor = _buttonToggleColor;
                    if (string.IsNullOrWhiteSpace(_toggleText))
                        _toggleText = Text;
                    var btext = Text;
                    Text = _toggleText;
                    _buttonText = btext;
                }
                else
                {
                    BackColor = _buttonColor;
                    Text = _buttonText;
                }
            }
        }

        [Category("Nono")]
        [Description("The background color of the button when it is being toggled.")]
        [Browsable(true)]
        public Color ButtonToggleColor
        {
            get { return _buttonToggleColor; }
            set { _buttonToggleColor = value; }
        }

        [Category("Nono")]
        [Description("The text displayed on the button.")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override string Text
        {
            get { return base.Text; }
            set {
                _buttonText = value;
                base.Text = value;
                if (string.IsNullOrWhiteSpace(_toggleText))
                    _toggleText = value;
            }
        }

        [Category("Nono")]
        [Description("The text displayed on the button when toggled.")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public string ToggleText
        {
            get { return _toggleText; }
            set { _toggleText = value; }
        }

        [Category("Nono")]
        [Description("The background color of the button.")]
        [Browsable(true)]
        public Color ButtonColor
        {
            get { return _buttonColor; }
            set { _buttonColor = value; BackColor = value; }
        }

        [Category("Nono")]
        [Description("The color of the text on the button.")]
        [Browsable(true)]
        public Color TextColor
        {
            get { return _textColor; }
            set { _textColor = value; ForeColor = value; }
        }

        private void on_MouseUp(object? sender, MouseEventArgs e)
        {
            if (IsToggleable)
            {
                IsToggled = !IsToggled;
            }
        }
    }
}
