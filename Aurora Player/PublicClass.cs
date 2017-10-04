namespace Aurora_Player
{
    class PublicClass
    {

        //鼠标定义详见 https://msdn.microsoft.com/en-us/library/windows/desktop/ms645605(v=vs.85).aspx
        public const int WM_LBUTTONDOWN = 0x0201;        //左键点击
        public const int WM_LBUTTONUP = 0x0202;          //左键弹起
        public const int WM_LBUTTONDBLCLK = 0x0203;      //左键双击

        public const int WM_RBUTTONDOWN = 0x0204;       //右键按下
        public const int WM_RBUTTONUP = 0x205;          //右键弹起
        public const int WM_RBUTTONDBLCLK = 0x206;      //右键双击

        public const int WM_MBUTTONDOWN = 0x0207;       //中键按下
        public const int WM_MBUTTONUP = 0x0208;         //中键弹起
        public const int WM_MBUTTONDBLCLK = 0x0209;     //中键双击
        
        public const int WM_MOUSEMOVE = 0x0200;         //鼠标移动
        public const int WM_MOUSELEAVE = 0x02A3;        //鼠标离开
        public const int WM_MOUSEHOVER = 0x02A1;        //鼠标悬停
        public const int WM_MOUSEWHEEL = 0x020A;        //鼠标滑轮

        public const int WM_KEYDOWN = 0x100;  //Key down
        public const int WM_KEYUP = 0x101;   //Key up

        public const int WM_XBUTTONDOWN = 0x020B;
        public const int MK_XBUTTON1 = 0x0020;
        public const int MK_XBUTTON2 = 0x0040;

        public enum PLAY_STATE : int
        {
            PS_READY = 0,           // 准备就绪
            PS_OPENING = 1,         // 正在打开
            PS_PAUSING = 2,         // 正在暂停
            PS_PAUSED = 3,          // 暂停中
            PS_PLAYING = 4,         // 正在开始播放
            PS_PLAY = 5,            // 播放中
            PS_CLOSING = 6,         // 正在开始关闭
        };

        public enum PLAY_MODE : int
        {
            PS_LISTORDER = 0,           // 顺序播放
            PS_LISTLOOP = 1,            // 列表循环
            PS_ONELOOP = 2,             // 单个循环
            PS_LISTRANDOM = 3,          // 随机播放
        };

        public enum WhtaistodoNext : int
        {
            PS_DoNoThing = -1,            //啥也不干
            PS_ExitApp = 0,               //退出Aurora
            PS_LockPC = 1,                //锁定
            PS_LogOff = 2,                //注销
            PS_Shutdown = 3,              //关机
            PS_Reboot = 4,                //重启
            PS_TurnOffMonitor = 5,        //关闭显示器
        };

        public enum AdType : int
        {
            None = -1,                  //无广告
            AdAd = 0,                   //广告
            WhatIsNew = 1,              //更新日志
        };
    }

    public class EmailStatus
    {
        public bool result { get; set; }
        public string statusCode { get; set; }
        public string message { get; set; }
        //public string info { get; set; }
    }

    //using Newtonsoft.Json;
    //EmailStatus email0 = new EmailStatus
    //{
    //    result = true,
    //    statusCode = "200",
    //    message = "请求成功",
    //    info = ""
    //};
    //string json = JsonConvert.SerializeObject(email0, Formatting.Indented);
    //Console.WriteLine(json);

    //        EmailStatus email1 = JsonConvert.DeserializeObject<EmailStatus>(json);
    //Console.WriteLine(email1.result);

    




}
