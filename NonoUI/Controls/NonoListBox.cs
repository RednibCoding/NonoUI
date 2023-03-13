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
        Color _itemUnfocusedColor = Color.LightGray;

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
                    backBrush = new SolidBrush(_itemUnfocusedColor);

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
    }
}
