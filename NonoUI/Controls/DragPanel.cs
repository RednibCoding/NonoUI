using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NonoUI.Controls
{
    [ToolboxBitmap(typeof(DragPanel), "Assets.Icons.drag_panel.png")]
    public partial class DragPanel : Panel
    {
        Point _mouseLocation;
        Form _targetForm;

        public DragPanel() : base()
        {
            InitializeComponent();
            Height = 50;
            Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
            BackColor = Color.FromArgb(0, 0, 0, 0);
            MouseDown += on_MouseDown;
            MouseMove += on_MouseMove;
        }

        private void on_MouseDown(object? sender, MouseEventArgs e)
        {
            _mouseLocation = new(-e.X, -e.Y);
        }

        private void on_MouseMove(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (TargetForm == null) return;
                var mouseLoc = MousePosition;
                mouseLoc.Offset(_mouseLocation.X, _mouseLocation.Y);
                TargetForm.Location = mouseLoc;
            }
        }

        [Category("Nono")]
        [Description("The Form that gets moved when dragging the DragPanel")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Form TargetForm
        {
            get { return _targetForm; }
            set { _targetForm = value; }
        }
    }
}
