using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using DSkin.Forms;
using DSkin.Common;


namespace Aurora_Player
{
    class FormHelper
    {
        //获取图片主色调，设置前景色
        public static void SetForeColor(DSkinForm form, Image image)
        {
            Color cl = SkinTools.GetImageAverageColor(image);
            if ((cl.B + cl.G + cl.R) / 2 > 200)
            {
                form.ForeColor = Color.Black;
            }
            else
            {
                form.ForeColor = Color.WhiteSmoke;
            }
        }
    }
}
