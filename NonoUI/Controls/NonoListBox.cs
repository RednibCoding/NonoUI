using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonoUI.Controls
{
    [ToolboxBitmap(typeof(NonoButton), "Assets.Icons.list_box.png")]
    public partial class NonoListBox : ListBox
    {
        Color _itemBackgroundColor = Color.Transparent;
        Color _selectedItemBackgroundColor = Color.FromArgb(255, 192, 192, 255);
        Color _itemTextColor = Color.Black;
        Color _selectedItemTextColor = Color.White;
        Color _borderColor = Color.LightGray;
        Color _focusColor = Color.FromArgb(255, 128, 128, 255);
        bool _hasBorder = true;
        int _itemHeight = 40;
        private Font _font = new Font("Sans Serif", 11, FontStyle.Regular);

        public NonoListBox()
        {
            DoubleBuffered = true;
            InitializeComponent();

            DrawMode = DrawMode.OwnerDrawFixed;
            BorderStyle = BorderStyle.None;
            DrawItem += on_DrawItem;
            ItemHeight = _itemHeight;
            Font = _font;
            SelectedIndexChanged += on_SelectedIndexChanged;
            //SetStyle(ControlStyles.UserPaint, true);
        }

        private void on_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // This is a work around, it shouldn't be needed,
            // but selecting items overdraws the border at that location
            // So we call refresh for now on every selction change so the border and stuff
            // gets redrawn
            Refresh();
        }

        // We have to use WndProc because doing it in OnPaint does not work correctly, dont ask me why
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            var switchExpr = m.Msg;
            switch (switchExpr)
            {
                case 0xF:
                {
                    var g = CreateGraphics();
                    g.SmoothingMode = SmoothingMode.Default;
                    int borderWidth = 1;
                    Rectangle rect = new Rectangle(0, 0, ClientRectangle.Width-1 , ClientRectangle.Height-1);

                    using (var p = new Pen(Focused ? _focusColor : _borderColor, borderWidth) { Alignment = PenAlignment.Center })
                    {
                        g.DrawRectangle(p, rect);

                    }

                    break;
                    }

                default:
                {
                    break;
                }
            }
        }

        private void on_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e == null) return;
            if (Items.Count <= 0) return;
            e.DrawBackground();
            Graphics g = e.Graphics;
            SolidBrush backBrush;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                if (Focused)
                    backBrush = new SolidBrush(_selectedItemBackgroundColor);
                else
                    backBrush = new SolidBrush(_borderColor);

            }
            else
                backBrush = new SolidBrush(_itemBackgroundColor);

            g.FillRectangle(backBrush, e.Bounds);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Center;

            var foreBrush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ? new SolidBrush(_selectedItemTextColor) : new SolidBrush(_itemTextColor);

            e.Graphics.DrawString(Items[e.Index].ToString(), e.Font ?? Font, foreBrush, e.Bounds, stringFormat);
            //e.DrawFocusRectangle();
        }

        [Category("Nono")]
        [Description("The height of a single item.")]
        [Browsable(true)]
        public override int ItemHeight
        {
            get { return _itemHeight; }
            set { _itemHeight = value; base.ItemHeight = value; }
        }

        [Category("Nono")]
        [Description("The background color of the selected item.")]
        [Browsable(true)]
        public Color SelectedItemBackColor
        {
            get { return _selectedItemBackgroundColor; }
            set { _selectedItemBackgroundColor = value; }
        }

        [Category("Nono")]
        [Description("The background color of the items.")]
        [Browsable(true)]
        public Color ItemBackColor
        {
            get { return _itemBackgroundColor; }
            set { _itemBackgroundColor = value; }
        }

        [Category("Nono")]
        [Description("The text color of the selected item.")]
        [Browsable(true)]
        public Color SelectedItemTextColor
        {
            get { return _selectedItemTextColor; }
            set { _selectedItemTextColor = value; }
        }

        [Category("Nono")]
        [Description("The background color of the items.")]
        [Browsable(true)]
        public Color ItemTextColor
        {
            get { return _itemTextColor; }
            set { _itemTextColor = value; }
        }

        [Category("Nono")]
        [Description("Wehter the list box has a border or not.")]
        [Browsable(true)]
        public bool HasBorder
        {
            get { return _hasBorder; }
            set { _hasBorder = value; }
        }

        [Category("Nono")]
        [Description("The border color of the list box.")]
        [Browsable(true)]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }

        [Category("Nono")]
        [Description("The border color when the list box has focus.")]
        [Browsable(true)]
        public Color FocusBorderColor
        {
            get { return _focusColor; }
            set { _focusColor = value; }
        }
    }
}
