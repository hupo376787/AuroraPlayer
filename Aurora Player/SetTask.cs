using System;
using System.Windows.Forms;
using System.Drawing;
using DSkin.Forms;

namespace Aurora_Player
{
    public partial class SetTask : DSkinForm
    {
        public SetTask()
        {
            InitializeComponent();
        }

        MainForm mainfrm;

        private void SetTimeShutDown_Load(object sender, EventArgs e)
        {
            mainfrm = (MainForm)this.Owner;
            this.BackColor = Color.FromArgb(mainfrm.n_BackColorTransparency, this.BackColor);
            this.EnabledDWM = mainfrm.b_EnableDWM;
            //this.BackgroundImage = main.BackImageCurrent;
            dSkinComboBox_Task.AddItem("无操作"); dSkinComboBox_Task.AddItem("退出Aurora"); dSkinComboBox_Task.AddItem("锁定电脑");
            dSkinComboBox_Task.AddItem("注销电脑"); dSkinComboBox_Task.AddItem("关闭电脑"); dSkinComboBox_Task.AddItem("重启电脑");
            dSkinComboBox_Task.AddItem("关闭显示器");
        }

        private void SetTimeShutDown_Shown(object sender, EventArgs e)
        {
            if (mainfrm.str_SetTimeShutDown == "")
            {
                dSkinNumericUpDown_Month.InnerTextBox.Text = DateTime.Now.Month.ToString(); dSkinNumericUpDown_Month.Value = DateTime.Now.Month;
                dSkinNumericUpDown_Day.InnerTextBox.Text = DateTime.Now.Day.ToString(); dSkinNumericUpDown_Day.Value = DateTime.Now.Day;
                dSkinNumericUpDown_Hour.InnerTextBox.Text = DateTime.Now.Hour.ToString(); dSkinNumericUpDown_Hour.Value = DateTime.Now.Hour;
                dSkinNumericUpDown_Minute.InnerTextBox.Text = DateTime.Now.Minute.ToString(); dSkinNumericUpDown_Minute.Value = DateTime.Now.Minute;
            }
            else
            {
                string[] str_Arr = mainfrm.str_SetTimeShutDown.Split('.');
                dSkinNumericUpDown_Month.InnerTextBox.Text = str_Arr[0]; dSkinNumericUpDown_Month.Value = Convert.ToInt32(str_Arr[0]);
                dSkinNumericUpDown_Day.InnerTextBox.Text = str_Arr[1]; dSkinNumericUpDown_Day.Value = Convert.ToInt32(str_Arr[1]);
                dSkinNumericUpDown_Hour.InnerTextBox.Text = str_Arr[2]; dSkinNumericUpDown_Hour.Value = Convert.ToInt32(str_Arr[2]);
                dSkinNumericUpDown_Minute.InnerTextBox.Text = str_Arr[3]; dSkinNumericUpDown_Minute.Value = Convert.ToInt32(str_Arr[3]);
            }

            dSkinComboBox_Task.SelectedIndex = mainfrm.n_WhatistodoNext + 1;
            //if (mainfrm.n_WhatistodoNext == -1)
            //    dSkinComboBox_Task.SelectedIndex = 0;
            //else if (mainfrm.n_WhatistodoNext == 0)
            //    dSkinComboBox_Task.SelectedIndex = 1;
            //else if (mainfrm.n_WhatistodoNext == 1)
            //    dSkinComboBox_Task.SelectedIndex = 2;
            //else if (mainfrm.n_WhatistodoNext == 2)
            //    dSkinComboBox_Task.SelectedIndex = 3;

            dSkinLabel_LeftTime.Text = TimeHelper.GetTimeSpan(DateTime.Now.Month.ToString() + "." + DateTime.Now.Day.ToString() + "." +
                DateTime.Now.Hour.ToString() + "." + DateTime.Now.Minute.ToString(), mainfrm.str_SetTimeShutDown);
        }

        private void dSkinButton_OK_Click(object sender, EventArgs e)
        {
            if (dSkinComboBox_Task.Text == "无操作")
            {
                dSkinLabel_LeftTime.Text = "还没有选择计划任务";
                return;
            }
            if(dSkinLabel_LeftTime.Text.Contains("-") || dSkinLabel_LeftTime.Text == "Wha~~~t？你想时光倒流回到过去？")
            {
                mainfrm.ShowTips("Aurora 暂时无法实现时光倒流,等实现了一定让你第一时间尝鲜");
                dSkinLabel_LeftTime.Text = "Wha~~~t？你想时光倒流回到过去？";
                return;
            }
            mainfrm.str_SetTimeShutDown = dSkinNumericUpDown_Month.InnerTextBox.Text + "." + dSkinNumericUpDown_Day.InnerTextBox.Text + "."
                + dSkinNumericUpDown_Hour.InnerTextBox.Text + "." + dSkinNumericUpDown_Minute.InnerTextBox.Text;

            string str_temp = TimeHelper.GetTimeSpan(DateTime.Now.Month.ToString() + "." + DateTime.Now.Day.ToString() + "." 
                + DateTime.Now.Hour.ToString() + "." + DateTime.Now.Minute.ToString(), mainfrm.str_SetTimeShutDown);
            string str_temp0 = System.Text.RegularExpressions.Regex.Match(str_temp, "(?<= ).*?(?=天)").Value.Trim();
            string str_temp1 = System.Text.RegularExpressions.Regex.Match(str_temp, "(?<=天).*?(?=小时)").Value.Trim();
            string str_temp2 = System.Text.RegularExpressions.Regex.Match(str_temp, "(?<=小时).*?(?=分钟)").Value.Trim();
            string str_temp3 = System.Text.RegularExpressions.Regex.Match(str_temp, "(?<=分钟).*?(?=秒)").Value.Trim();
            Int64 n_temp = Convert.ToInt32(str_temp0) * 24 * 3600 +  Convert.ToInt32(str_temp1) * 3600
                        + Convert.ToInt32(str_temp2) * 60 + Convert.ToInt32(str_temp3);
            mainfrm.n_SetTaskTimeLeft = n_temp;
            if (dSkinComboBox_Task.Text == "无操作")
            {
                mainfrm.n_WhatistodoNext = -1;
            }
            else if (dSkinComboBox_Task.Text == "退出Aurora")
            {
                mainfrm.n_WhatistodoNext = 0;
            }
            else if (dSkinComboBox_Task.Text == "锁定电脑")
            {
                mainfrm.n_WhatistodoNext = 1;
            }
            else if (dSkinComboBox_Task.Text == "注销电脑")
            {
                mainfrm.n_WhatistodoNext = 2;
            }
            else if (dSkinComboBox_Task.Text == "关闭电脑")
            {
                mainfrm.n_WhatistodoNext = 3;
            }
            else if (dSkinComboBox_Task.Text == "重启电脑")
            {
                mainfrm.n_WhatistodoNext = 4;
            }
            else if (dSkinComboBox_Task.Text == "关闭显示器")
            {
                mainfrm.n_WhatistodoNext = 5;
            }
            mainfrm.timer_SetTask.Dispose();
            mainfrm.timer_SetTask.Enabled = true;
            mainfrm.timer_SetTask.Start();
            //CommandHelper.Excute("shutdown /s /t " + n_temp.ToString());
            this.Close();
            mainfrm.ShowTips("Aurora 将在 " + dSkinLabel_LeftTime.Text + "后执行“" + dSkinComboBox_Task.Text + "”任务");
        }

        private void dSkinButton_Delete_Click(object sender, EventArgs e)
        {
            CommandHelper.Excute("shutdown /a");
            DllHelper.SendMessage(0xFFFF, 0x112, 0xF170, -1);//2为PowerOff, 1为省电状态，-1为开机
            mainfrm.ShowTips("用户已取消计划任务");
            mainfrm.timer_SetTask.Enabled = false;
            mainfrm.timer_SetTask.Stop();
            mainfrm.n_WhatistodoNext = -1;
        }

        private void dSkinNumericUpDown_Hour_ValueChanged(object sender, EventArgs e)
        {
            GetLeftTime();
        }

        private void dSkinNumericUpDown_Minute_ValueChanged(object sender, EventArgs e)
        {
            GetLeftTime();
        }

        #region 改变窗体背景
        protected override void OnLayeredPaintBackground(PaintEventArgs e)
        {
            base.OnLayeredPaintBackground(e);

            //SetForeColor(this, mainFrm.BackImageCurrent);

            if (mainfrm.BackImageCurrent != null)
            {
                if (mainfrm.n_BackImageTransparency <= 1)
                {
                    return;
                }
                if (mainfrm.n_BackImageTransparency == 100)
                {
                    e.Graphics.DrawImage(mainfrm.BackImageCurrent, 0, 0, this.Width, this.Height);
                    return;
                }
                e.Graphics.DrawImage(mainfrm.BackImageCurrent, new Rectangle(0, 0, this.Width, this.Height),
                    0, 0, mainfrm.BackImageCurrent.Width, mainfrm.BackImageCurrent.Height, GraphicsUnit.Pixel,
                    DSkin.ImageEffects.ChangeOpacity((float)(1.0 * mainfrm.n_BackImageTransparency / 100)));
            }
        }

        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            base.OnBackgroundImageChanged(e);
        }

        #endregion

        private void dSkinNumericUpDown_Day_ValueChanged(object sender, EventArgs e)
        {
            if (dSkinNumericUpDown_Month.InnerTextBox.Text == "1" || dSkinNumericUpDown_Month.InnerTextBox.Text == "3"
                || dSkinNumericUpDown_Month.InnerTextBox.Text == "5" || dSkinNumericUpDown_Month.InnerTextBox.Text == "7"
                 || dSkinNumericUpDown_Month.InnerTextBox.Text == "8" || dSkinNumericUpDown_Month.InnerTextBox.Text == "10"
                  || dSkinNumericUpDown_Month.InnerTextBox.Text == "12")
            {
                dSkinNumericUpDown_Day.Maximum = 31;
            }
            else if (dSkinNumericUpDown_Month.InnerTextBox.Text == "4" || dSkinNumericUpDown_Month.InnerTextBox.Text == "6"
                 || dSkinNumericUpDown_Month.InnerTextBox.Text == "9" || dSkinNumericUpDown_Month.InnerTextBox.Text == "11")
            {
                dSkinNumericUpDown_Day.Maximum = 30;
            }
            else if(dSkinNumericUpDown_Month.InnerTextBox.Text == "2")
            {
                int n_Year = DateTime.Now.Year;
                if((n_Year % 4 == 0 && n_Year % 100 != 0) || n_Year % 400 == 0)
                    dSkinNumericUpDown_Day.Maximum = 29;
                else
                    dSkinNumericUpDown_Day.Maximum = 28;
            }

            GetLeftTime();
        }

        private void dSkinNumericUpDown_Month_ValueChanged(object sender, EventArgs e)
        {
            GetLeftTime();
        }

        private void GetLeftTime()
        {
            string str_TT = dSkinNumericUpDown_Month.InnerTextBox.Text + "." + dSkinNumericUpDown_Day.InnerTextBox.Text + "."
                + dSkinNumericUpDown_Hour.InnerTextBox.Text + "." + dSkinNumericUpDown_Minute.InnerTextBox.Text;
            dSkinLabel_LeftTime.Text = TimeHelper.GetTimeSpan(DateTime.Now.Month.ToString() + "." + DateTime.Now.Day.ToString() + "." + 
                DateTime.Now.Hour.ToString() + "." + DateTime.Now.Minute.ToString(), str_TT);
        }

        private void dSkinComboBox_Task_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetLeftTime();
        }

    }
}
