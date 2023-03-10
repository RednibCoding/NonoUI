using NonoUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonoUI.Other
{
    enum ResizeDirection
    {
        None,
        Left,
        Right,
        Top,
        Bottom,
        BottomRight,
        BottomLeft,
        TopRight,
        TopLeft,
    }

    [ToolboxBitmap(typeof(ResizeBehavior), "Assets.Icons.resize_behavior.png")]
    public partial class ResizeBehavior : Component
    {
        // Needed for the drop shadow
        const int CS_DropSHADOW = 0x20000;
        const int GCL_STYLE = (-26);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);


        Form? _targetForm;
        Point _mouseLocation;
        FormBorderStyle _originalFormBorderStyle;
        ResizeDirection _resizeDirection;

        public ResizeBehavior()
        {
            InitializeComponent();
            Disposed += on_Disposed;
        }

        [Category("Nono")]
        [Description("The Form that should get ResizeBahvior")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Form? TargetForm
        {
            get { return _targetForm; }
            set
            {
                _targetForm = value;
                if (_targetForm != null && _targetForm is Form form)
                {
                    _originalFormBorderStyle = form.FormBorderStyle;
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.MouseMove += on_MouseMove;
                    form.MouseDown += on_MouseDown;
                    form.MouseUp += on_MouseUp;
                    SetClassLong(form.Handle, GCL_STYLE, GetClassLong(form.Handle, GCL_STYLE) | CS_DropSHADOW);
                }
            }
        }

        private void on_MouseUp(object? sender, MouseEventArgs e)
        {
            _resizeDirection = ResizeDirection.None;
        }

        private void on_MouseDown(object? sender, MouseEventArgs e)
        {
            var form = sender as Form;
            if (form == null) return;
            _mouseLocation = new(-e.X, -e.Y);
        }

        private void on_MouseMove(object? sender, MouseEventArgs e)
        {
            var form = sender as Form;
            if (form == null) return;
            
            const int margin = 12;

            var left = false;
            var right = false;

   
            if (e.X <= margin) // Left border
            {
                left = true;
                Cursor.Current = Cursors.SizeWE;
            }
            else if (e.X >= form.ClientSize.Width - margin) // Right border
            {
                right = true;
                Cursor.Current = Cursors.SizeWE;
            }

            if (e.Y <= margin) // Top border
            {

                if (left)
                {
                    Cursor.Current = Cursors.SizeNWSE;
                }
                else if (right)
                {
                    Cursor.Current = Cursors.SizeNESW;
                }
                else
                {
                    Cursor.Current = Cursors.SizeNS;
                }
            }
            else if (e.Y >= form.ClientSize.Height - margin) // Bottom border
            {

                if (left)
                {
                    Cursor.Current = Cursors.SizeNESW;
                }
                else if (right)
                {
                    Cursor.Current = Cursors.SizeNWSE;
                }
                else
                {
                    Cursor.Current = Cursors.SizeNS;
                }
            }
            


            // ####################################################################################

            if (e.Button != MouseButtons.Left) return;

            if (_resizeDirection == ResizeDirection.None)
            {
                if (e.X <= margin) // Left border
                {
                    _resizeDirection = ResizeDirection.Left;
                    Cursor.Current = Cursors.SizeWE;
                }
                else if (e.X >= form.ClientSize.Width - margin) // Right border
                {
                    _resizeDirection = ResizeDirection.Right;
                    Cursor.Current = Cursors.SizeWE;
                }

                if (e.Y <= margin) // Top border
                {

                    if (_resizeDirection == ResizeDirection.Left)
                    {
                        _resizeDirection = ResizeDirection.TopLeft;
                        Cursor.Current = Cursors.SizeNWSE;
                    }
                    else if (_resizeDirection == ResizeDirection.Right)
                    {
                        _resizeDirection = ResizeDirection.TopRight;
                        Cursor.Current = Cursors.SizeNESW;
                    }
                    else
                    {
                        _resizeDirection = ResizeDirection.Top;
                        Cursor.Current = Cursors.SizeNS;
                    }
                }
                else if (e.Y >= form.ClientSize.Height - margin) // Bottom border
                {

                    if (_resizeDirection == ResizeDirection.Left)
                    {
                        _resizeDirection = ResizeDirection.BottomLeft;
                        Cursor.Current = Cursors.SizeNESW;
                    }
                    else if (_resizeDirection == ResizeDirection.Right)
                    {
                        _resizeDirection = ResizeDirection.BottomRight;
                        Cursor.Current = Cursors.SizeNWSE;
                    }
                    else
                    {
                        _resizeDirection = ResizeDirection.Bottom;
                        Cursor.Current = Cursors.SizeNS;
                    }
                }
            }

            switch (_resizeDirection)
            {
                case ResizeDirection.Left:
                    form.Width = form.Width + _mouseLocation.X - e.X;
                    form.Left = form.Left + e.X - _mouseLocation.X;
                    break;
                case ResizeDirection.Right:
                    form.Width = e.X;
                    break;
                case ResizeDirection.Top:
                    form.Height = form.Height + _mouseLocation.Y - e.Y;
                    form.Top = form.Top + e.Y - _mouseLocation.Y;
                    break;
                case ResizeDirection.Bottom:
                    form.Height = e.Y;
                    break;
                case ResizeDirection.BottomRight:
                    form.Width = e.X;
                    form.Height = e.Y;
                    break;
                case ResizeDirection.BottomLeft:
                    form.Width = form.Width + _mouseLocation.X - e.X;
                    form.Left = form.Left + e.X - _mouseLocation.X;
                    form.Height = e.Y;
                    break;
                case ResizeDirection.TopRight:
                    form.Height = form.Height + _mouseLocation.Y - e.Y;
                    form.Top = form.Top + e.Y - _mouseLocation.Y;
                    form.Width = e.X;
                    break;
                case ResizeDirection.TopLeft:
                    form.Height = form.Height + _mouseLocation.Y - e.Y;
                    form.Top = form.Top + e.Y - _mouseLocation.Y;
                    form.Width = form.Width + _mouseLocation.X - e.X;
                    form.Left = form.Left + e.X - _mouseLocation.X;
                    break;
                case ResizeDirection.None:
                default:
                    break;
            }

            _targetForm?.Refresh();

        }

        private void on_Disposed(object? sender, EventArgs e)
        {
            if (_targetForm == null) return;
            _targetForm.FormBorderStyle = _originalFormBorderStyle;
        }

    }
}
