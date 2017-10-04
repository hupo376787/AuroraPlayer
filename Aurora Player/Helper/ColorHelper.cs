using System.Drawing;

namespace Aurora_Player
{
    class ColorHelper
    {
        //RGB与int类型之间的转换
        public static int RGBtoInt(Color color)
        {
            return (int)(((int)color.B << 16) | (ushort)(((ushort)color.G << 8) | color.R));
        }

        public static Color InttoRGB(int color)
        {
            int r = 0xFF & color;
            int g = 0xFF00 & color;
            g >>= 8;
            int b = 0xFF0000 & color;
            b >>= 16;
            return Color.FromArgb(r, g, b);
        }
    }
}
