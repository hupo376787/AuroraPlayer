using System;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace Aurora_Player
{
    class LinkFile
    {
        #region 程序关联到文件 
        [DllImport("shell32.dll")]//立即刷新显示而不重启电脑
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
        /// <summary> 
        /// 关联文件 双击启动程序的文件 
        /// </summary> 
        public static string[] FileNameWhoInvokeEXE = null;

        /// <summary> 
        /// 设置关联文件 
        /// </summary> 
        /// <param name="ExName">文件扩展名——.rmvb</param> 
        /// <param name="TypeName">文件类型名——Aurora Player.rmvb</param> 
        /// <param name="IconPath">文件图标</param> 
        /// <param name="AppPath">启动程序</param> 
        public static void SetLink(string ExName, string TypeName, string IconPath, string AppPath)
        {
            try
            {
                RegistryKey root = Registry.ClassesRoot;//root key 

                //change extendname link 
                root.CreateSubKey(ExName);
                root.DeleteSubKeyTree(ExName);
                root.CreateSubKey(ExName);

                RegistryKey ExKey = root.OpenSubKey(ExName, true);
                ExKey.SetValue("", TypeName);
                ExKey.SetValue("Content Type", TypeName);//add value 

                //create new filetype 
                root.CreateSubKey(TypeName);
                root.DeleteSubKeyTree(TypeName);
                root.CreateSubKey(TypeName);

                RegistryKey TypeKey = root.OpenSubKey(TypeName, true);
                TypeKey.SetValue("", TypeName);
                TypeKey.CreateSubKey("DefaultIcon").SetValue("", "\"" + IconPath + "\",0");//new subkey icon 
                TypeKey.CreateSubKey("shell\\Open\\Command").SetValue("", "\"" + AppPath + "\"" + " " + "\"" + "%1" + "\"");//new subkey command 
                TypeKey.Close();
                root.Close();
                SHChangeNotify(0x8000000, 0, IntPtr.Zero, IntPtr.Zero);//not need reboot 
            }
            catch { }
        }
        /// <summary> 
        /// 解除关联文件 
        /// </summary> 
        /// <param name="TypeName"></param> 
        public static void DelLink(string TypeName)
        {
            try
            {
                RegistryKey root = Registry.ClassesRoot;
                root.DeleteSubKeyTree(TypeName);//delete type key 
                root.Close();
                SHChangeNotify(0x8000000, 0, IntPtr.Zero, IntPtr.Zero);//not need reboot 
            }
            catch { }
        }
        #endregion

        #region 程序加入系统右键 
        /// <summary> 
        /// 程序关联扩展名文件右键菜单 
        /// </summary> 
        /// <param name="ExName">扩展名文件</param> 
        /// <param name="MenuName">右键显示名称</param> 
        /// <param name="AppPath">程序</param> 
        public static void SetRightMenuLink(string MenuName, string AppPath)
        {
            try
            {
                RegistryKey shellKey = Registry.ClassesRoot.OpenSubKey("*\\shell", true);
                shellKey.CreateSubKey(MenuName).CreateSubKey("command").SetValue("", "\"" + AppPath + "\"" + "\"" + " %1" + "\"");
                shellKey.Close();
            }
            catch { }

        }
        /// <summary> 
        /// 解除程序关联扩展名文件右键菜单 
        /// </summary> 
        /// <param name="ExName">扩展名文件</param> 
        public static void DeleteRightMenuLink(string MenuName)
        {
            try
            {
                RegistryKey fileshellKey = Registry.ClassesRoot.OpenSubKey("*\\shell", true);
                fileshellKey.DeleteSubKeyTree(MenuName);
                fileshellKey.Close();
            }
            catch { }
        }
        #endregion

        #region 跨进程通信 

        public const int WM_COPYDATA = 0x004A;
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);

        /// <summary> 
        /// 所需传递的结构体 
        /// </summary> 
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;//用户定义数据 
            public int cbData;//数据大小 
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;//指向数据的指针 
        }

        /// <summary> 
        /// 发送字符串 
        /// </summary> 
        /// <param name="hWnd"></param> 
        /// <param name="str"></param> 
        public static void SendStr(IntPtr hWnd, string str)
        {
            try
            {
                byte[] sarr = System.Text.Encoding.Default.GetBytes(str);
                int len = sarr.Length;
                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)100;
                cds.lpData = str;
                cds.cbData = len + 1;
                SendMessage(hWnd, WM_COPYDATA, 0, ref cds);
            }
            catch { }
        }

        //#region 跨进程通信 接收消息 
        ///// <summary> 
        ///// 重写接收函数 放到主窗体类中 
        ///// </summary> 
        ///// <param name="m"></param> 
        //protected override void DefWndProc(ref Message m) 
        //{ 
        //    if (m.Msg == LinkFile.WM_COPYDATA) 
        //    { 
        //        LinkFile.COPYDATASTRUCT mystr = new LinkFile.COPYDATASTRUCT(); 
        //        Type mytype = mystr.GetType(); 
        //        mystr = (LinkFile.COPYDATASTRUCT)m.GetLParam(mytype);//获取类型 
        //        string str = mystr.lpData; 
        //        wmplayer1.URL = str; 
        //        listBox1.Items.Add(str); 
        //        listBox1.SelectedItems.Clear(); 
        //        listBox1.SetSelected(listBox1.Items.Count - 1, true); 
        //        labelFormTitle.Text = str; 
        //    } 
        //    base.DefWndProc(ref m); 
        //} 
        //#endregion 
        #endregion

    }
}
