using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonoUI.Controls
{
    [ToolboxBitmap(typeof(ControlButton), "Assets.Icons.image_button.png")]
    public partial class NonoImageButton : PictureBox
    {
        Bitmap? _bitmap_normal;
        Bitmap? _bitmap_hover;
        Bitmap? _bitmap_clicked;
        Bitmap? _bitmap_disabled;
        bool _isDisabled = false;
        ImageLayout _imageLayout;

        public NonoImageButton()
        {
            InitializeComponent();
            BorderStyle = BorderStyle.None;
            BackgroundImageLayout = ImageLayout.Stretch;
            _imageLayout = ImageLayout.Stretch;
            BackColor = Color.Transparent;

            if (_bitmap_hover == null) _bitmap_hover = _bitmap_normal;
            if (_bitmap_clicked == null) _bitmap_clicked = _bitmap_normal;
            if (_bitmap_disabled == null) _bitmap_disabled = _bitmap_normal;

            MouseEnter += on_MouseEnter;
            MouseLeave += on_MouseLeave;
            MouseDown += on_MouseDown;
            MouseUp += on_MouseUp;
        }

        private void on_MouseUp(object? sender, MouseEventArgs e)
        {
            if (_isDisabled) return;
            BackgroundImage = _bitmap_normal;
            Refresh();
        }

        private void on_MouseDown(object? sender, MouseEventArgs e)
        {
            if (_isDisabled) return;
            BackgroundImage = _bitmap_clicked;
            Refresh();
        }

        private void on_MouseLeave(object? sender, EventArgs e)
        {
            if (_isDisabled) return;
            BackgroundImage = _bitmap_normal;
            Refresh();
        }

        private void on_MouseEnter(object? sender, EventArgs e)
        {
            if (_isDisabled) return;
            BackgroundImage = _bitmap_hover;
            Refresh();
        }

        // Disable showing it in the properties window, we will use our own
        //[Browsable(false)]
        //public override ImageLayout BackgroundImageLayout { get; set; }

        // Disable showing it in the properties window, we will use our own
        [Browsable(false)]
        public override Image BackgroundImage { get; set; }

        [Category("Nono")]
        [Description("Whether the button is disabled or not")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public bool Disabled
        {
            get { return _isDisabled; }
            set {
                _isDisabled = value;
                if (_isDisabled)
                    BackgroundImage = _bitmap_disabled == null ? _bitmap_normal : _bitmap_disabled;
                else
                    BackgroundImage = _bitmap_normal;

                Refresh();
            }
        }

        [Category("Nono")]
        [Description("Normal state image")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Editor("System.Drawing.Design.ImageEditor, System.Drawing.Design", typeof(UITypeEditor))]
        public Bitmap ImageNormal
        {
            get { return _bitmap_normal; }
            set { _bitmap_normal = value; BackgroundImage = value; Refresh(); }
        }

        [Category("Nono")]
        [Description("Hover state image")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Editor("System.Drawing.Design.ImageEditor, System.Drawing.Design", typeof(UITypeEditor))]
        public Bitmap ImageHover
        {
            get { return _bitmap_hover == null ? _bitmap_normal : _bitmap_hover; }
            set { _bitmap_hover = value; }
        }

        [Category("Nono")]
        [Description("Disabled state image")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Editor("System.Drawing.Design.ImageEditor, System.Drawing.Design", typeof(UITypeEditor))]
        public Bitmap ImageDisabled
        {
            get { return _bitmap_disabled == null ? _bitmap_normal : _bitmap_disabled; }
            set { _bitmap_disabled = value; }
        }

        [Category("Nono")]
        [Description("Clicked state image")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Editor("System.Drawing.Design.ImageEditor, System.Drawing.Design", typeof(UITypeEditor))]
        public Bitmap ImageClicked
        {
            get { return _bitmap_clicked == null ? _bitmap_normal : _bitmap_clicked; }
            set { _bitmap_clicked = value; }
        }

        [Category("Nono")]
        [Description("Image layout")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Editor("System.Drawing.Design.ImageEditor, System.Drawing.Design", typeof(UITypeEditor))]
        public override ImageLayout BackgroundImageLayout
        {
            get { return _imageLayout; }
            set
            {
                _imageLayout = value;
                base.BackgroundImageLayout = value;
                Refresh();
            }
        }
    }
}
