using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonoUI.Controls
{
    [ToolboxBitmap(typeof(NonoButton), "Assets.Icons.tab_control.png")]
    public partial class NonoTabControl : TabControl
    {
        private int _tabWidth = 180;
        private int _tabHeight = 50;
        private Font _font = new Font("Sans Serif", 11, FontStyle.Regular);

        public NonoTabControl()
        {
            InitializeComponent();
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(_tabWidth, _tabHeight);
            Font = _font;
        }


        [Category("Nono")]
        [Description("Specifies the width of a single tab button.")]
        [Browsable(true)]
        [DefaultValue(200)]
        public int TabWidth
        {
            get { return _tabWidth; }
            set { _tabWidth = value; ItemSize = new Size(value, _tabHeight); }
        }

        [Category("Nono")]
        [Description("Specifies the height of a single tab button.")]
        [Browsable(true)]
        [DefaultValue(60)]
        public int TabHeight
        {
            get { return _tabHeight; }
            set { _tabHeight = value; ItemSize = new Size(_tabWidth, value); }
        }
    }
}
