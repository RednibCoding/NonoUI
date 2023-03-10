using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonoUI.Controls
{
    [ToolboxBitmap(typeof(ControlButton), "Assets.Icons.control_button.png")]
    public partial class ControlButton : Button
    {
        ButtonType _buttonType = ButtonType.Close;
        private Font _font = new Font("Sans Serif", 16, FontStyle.Regular);
        private string _closeStr = "🗙";
        private string _maximizeStr = "🗖";
        private string _minimizeStr = "🗕";

        public enum ButtonType
        {
            Close,
            Minimize,
            Maximize,
        }

        public ControlButton() : base()
        {
            InitializeComponent();
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            //AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //AutoSize = true;
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BackColor = Color.FromArgb(255, 128, 128, 255);
            ForeColor = Color.White;
            Font = _font;
            Width = 50;
            Height = 50;
            MouseUp += on_MouseUp;
            
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                if (base.Text != _closeStr || base.Text != _minimizeStr || base.Text != _maximizeStr || base.Text != string.Empty)
                    base.Text = _closeStr;
            }
        }

        [Category("Nono")]
        [Description("The button type (Close, Minimize or Maximize")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public ButtonType ControlType
        {
            get { return _buttonType; }
            set {
                _buttonType = value;
                switch (_buttonType)
                {
                    case ButtonType.Close:
                        base.Text = _closeStr;
                        break;
                    case ButtonType.Minimize:
                        base.Text = _minimizeStr;
                        break;
                    case ButtonType.Maximize:
                        base.Text = _maximizeStr;
                        break;
                }
            }
        }

        private void on_MouseUp(object? sender, MouseEventArgs e)
        {
            switch (_buttonType)
            {
                case ButtonType.Close:
                    Environment.Exit(0);
                    break;
                case ButtonType.Minimize:
                    if (Application.OpenForms.Count <= 0) return;
                    Application.OpenForms[0]!.WindowState = FormWindowState.Minimized;
                    break;
                case ButtonType.Maximize:
                    if (Application.OpenForms.Count <= 0) return;
                    if (Application.OpenForms[0]!.WindowState == FormWindowState.Normal)
                        Application.OpenForms[0]!.WindowState = FormWindowState.Maximized;
                    else
                        Application.OpenForms[0]!.WindowState = FormWindowState.Normal;
                    break;
            }
        }
    }
}
