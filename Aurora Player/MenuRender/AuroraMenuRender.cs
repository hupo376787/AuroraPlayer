using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Aurora_Player
{
    public class AuroraMenuRender : ToolStripProfessionalRenderer
    {
        ColorConfig colorconfig = new ColorConfig();//创建颜色配置类  
        /// <summary>  
        /// 渲染整个背景  
        /// </summary>  
        /// <param name="e"></param>  
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            e.ToolStrip.ForeColor = colorconfig.FontColor;
            //如果是下拉  
            if (e.ToolStrip is ToolStripDropDown)
            {
                e.Graphics.FillRectangle(new SolidBrush(colorconfig.DropDownItemBackColor), e.AffectedBounds);
            }
            //如果是菜单项  
            else if (e.ToolStrip is MenuStrip)
            {
                Blend blend = new Blend();
                float[] fs = new float[5] { 0f, 0.3f, 0.5f, 0.8f, 1f };
                float[] f = new float[5] { 0f, 0.5f, 0.9f, 0.5f, 0f };
                blend.Positions = fs;
                blend.Factors = f;
                FillLineGradient(e.Graphics, e.AffectedBounds, colorconfig.MainMenuStartColor, colorconfig.MainMenuEndColor, 90f, blend);
            }
            else
            {
                base.OnRenderToolStripBackground(e);
            }
        }
        /// <summary>  
        /// 渲染下拉左侧图标区域  
        /// </summary>  
        /// <param name="e"></param>  
        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            FillLineGradient(e.Graphics, e.AffectedBounds, colorconfig.MarginStartColor, colorconfig.MarginEndColor, 0f, null);
        }
        /// <summary>  
        /// 渲染菜单项的背景  
        /// </summary>  
        /// <param name="e"></param>  
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.ToolStrip is MenuStrip)
            {
                //如果被选中或被按下  
                if (e.Item.Selected || e.Item.Pressed)
                {
                    Blend blend = new Blend();
                    float[] fs = new float[5] { 0f, 0.3f, 0.5f, 0.8f, 1f };
                    float[] f = new float[5] { 0f, 0.5f, 1f, 0.5f, 0f };
                    blend.Positions = fs;
                    blend.Factors = f;
                    FillLineGradient(e.Graphics, new Rectangle(0, 0, e.Item.Size.Width, e.Item.Size.Height), colorconfig.MenuItemStartColor, colorconfig.MenuItemEndColor, 90f, blend);
                }
                else
                    base.OnRenderMenuItemBackground(e);
            }
            else if (e.ToolStrip is ToolStripDropDown)
            {
                if (e.Item.Selected)
                {
                    FillLineGradient(e.Graphics, new Rectangle(0, 0, e.Item.Size.Width, e.Item.Size.Height), colorconfig.DropDownItemStartColor, colorconfig.DropDownItemEndColor, 90f, null);
                }
            }
            else
            {
                base.OnRenderMenuItemBackground(e);
            }
        }
        /// <summary>  
        /// 渲染菜单项的分隔线  
        /// </summary>  
        /// <param name="e"></param>  
        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(colorconfig.SeparatorColor), 0, 2, e.Item.Width, 2);
        }
        /// <summary>  
        /// 渲染边框  
        /// </summary>  
        /// <param name="e"></param>  
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip is ToolStripDropDown)
            {
                e.Graphics.DrawRectangle(new Pen(colorconfig.DropDownBorder), new Rectangle(0, 0, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1));
            }
            else
            {
                base.OnRenderToolStripBorder(e);
            }
        }
        /// <summary>  
        /// 渲染箭头  
        /// </summary>  
        /// <param name="e"></param>  
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = Color.Red;//设置为红色，当然还可以 画出各种形状  
            base.OnRenderArrow(e);
        }
        /// <summary>  
        /// 填充线性渐变  
        /// </summary>  
        /// <param name="g">画布</param>  
        /// <param name="rect">填充区域</param>  
        /// <param name="startcolor">开始颜色</param>  
        /// <param name="endcolor">结束颜色</param>  
        /// <param name="angle">角度</param>  
        /// <param name="blend">对象的混合图案</param>  
        private void FillLineGradient(Graphics g, Rectangle rect, Color startcolor, Color endcolor, float angle, Blend blend)
        {
            LinearGradientBrush linebrush = new LinearGradientBrush(rect, startcolor, endcolor, angle);
            if (blend != null)
            {
                linebrush.Blend = blend;
            }
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillPath(linebrush, path);
        }
    }
}
