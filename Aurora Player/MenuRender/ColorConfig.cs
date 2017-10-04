using System.Drawing;

namespace Aurora_Player
{
    public class ColorConfig
    {
        private Color _fontcolor = Color.White;
        /// <summary>  
        /// 菜单字体颜色  
        /// </summary>  
        public Color FontColor
        {
            get { return this._fontcolor; }
            set { this._fontcolor = value; }
        }

        private Color _marginstartcolor = Color.FromArgb(113, 113, 113);
        /// <summary>  
        /// 下拉菜单坐标图标区域开始颜色  
        /// </summary>  
        public Color MarginStartColor
        {
            get { return this._marginstartcolor; }
            set { this._marginstartcolor = value; }
        }

        private Color _marginendcolor = Color.FromArgb(70, 70, 70);
        /// <summary>  
        /// 下拉菜单坐标图标区域结束颜色  
        /// </summary>  
        public Color MarginEndColor
        {
            get { return this._marginendcolor; }
            set { this._marginendcolor = value; }
        }

        private Color _dropdownitembackcolor = Color.FromArgb(40, 40, 40);
        /// <summary>  
        /// 下拉项背景颜色  
        /// </summary>  
        public Color DropDownItemBackColor
        {
            get { return this._dropdownitembackcolor; }
            set { this._dropdownitembackcolor = value; }
        }

        public Color _dropdownitemstartcolor = Color.Orange;
        /// <summary>  
        /// 下拉项选中时开始颜色  
        /// </summary>  
        public Color DropDownItemStartColor
        {
            get { return this._dropdownitemstartcolor; }
            set { this._dropdownitemstartcolor = value; }
        }

        public Color _dorpdownitemendcolor = Color.Orange;//FromArgb(160, 100, 20);
        /// <summary>  
        /// 下拉项选中时结束颜色  
        /// </summary>  
        public Color DropDownItemEndColor
        {
            get { return this._dorpdownitemendcolor; }
            set { this._dorpdownitemendcolor = value; }
        }

        private Color _menuitemstartcolor = Color.FromArgb(52, 106, 159);
        /// <summary>  
        /// 主菜单项选中时的开始颜色  
        /// </summary>  
        public Color MenuItemStartColor
        {
            get { return this._menuitemstartcolor; }
            set { this._menuitemstartcolor = value; }
        }

        private Color _menuitemendcolor = Color.FromArgb(73, 124, 174);
        /// <summary>  
        /// 主菜单项选中时的结束颜色  
        /// </summary>  
        public Color MenuItemEndColor
        {
            get { return this._menuitemendcolor; }
            set { this._menuitemendcolor = value; }
        }

        private Color _separatorcolor = Color.Gray;
        /// <summary>  
        /// 分割线颜色  
        /// </summary>  
        public Color SeparatorColor
        {
            get { return this._separatorcolor; }
            set { this._separatorcolor = value; }
        }

        private Color _mainmenubackcolor = Color.Black;
        /// <summary>  
        /// 主菜单背景色  
        /// </summary>  
        public Color MainMenuBackColor
        {
            get { return this._mainmenubackcolor; }
            set { this._mainmenubackcolor = value; }
        }

        private Color _mainmenustartcolor = Color.FromArgb(93, 93, 93);
        /// <summary>  
        /// 主菜单背景开始颜色  
        /// </summary>  
        public Color MainMenuStartColor
        {
            get { return this._mainmenustartcolor; }
            set { this._mainmenustartcolor = value; }
        }

        private Color _mainmenuendcolor = Color.FromArgb(34, 34, 34);
        /// <summary>  
        /// 主菜单背景结束颜色  
        /// </summary>  
        public Color MainMenuEndColor
        {
            get { return this._mainmenuendcolor; }
            set { this._mainmenuendcolor = value; }
        }

        private Color _dropdownborder = Color.FromArgb(40, 96, 151);
        /// <summary>  
        /// 下拉区域边框颜色  
        /// </summary>  
        public Color DropDownBorder
        {
            get { return this._dropdownborder; }
            set { this._dropdownborder = value; }
        }
    }
}
