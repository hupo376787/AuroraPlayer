using System;
using Shell32;
using System.IO;
using IWshRuntimeLibrary;
using System.Windows.Forms;

namespace Aurora_Player
{
    class CommandHelper
    {
        //执行关机、注销等命令
        public static void Excute(string str_Cmd)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true; p.Start();
            p.StandardInput.WriteLine(str_Cmd);
        }

        //锁定到任务栏
        public static void LockToTaskbar(bool isLock)
        {
            Shell shell = new Shell();
            Shell32.Folder folder = shell.NameSpace(Path.GetDirectoryName(Application.StartupPath + "\\Aurora Player.exe"));
            FolderItem app = folder.ParseName(Path.GetFileName(Application.StartupPath + "\\Aurora Player.exe"));
            string sVerb = isLock ? "锁定到任务栏(&K)" : "从任务栏脱离(&K)";

            foreach (FolderItemVerb Fib in app.Verbs())
            {
                if (Fib.Name == sVerb)
                {
                    Fib.DoIt();
                    return;
                }
            }

            return;
        }

        //创建快捷键方式桌面是否存在
        public static void CreateShortcutToDesktop(bool b_Create)
        {
            //判断创建快捷键方式桌面是否存在
            string deskTop = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            if (System.IO.File.Exists(deskTop + "\\Aurora Player.lnk"))  //
            {
                if (!b_Create)
                {
                    System.IO.File.Delete(deskTop + "\\Aurora Player.lnk");//删除原来的桌面快捷键方式
                    return;
                }
            }
            if (b_Create)
            {
                //注：如果桌面有现准备创建的快捷键方式，当程序执行创建语句时会修改桌面已有快捷键方式，程序不会出现异常
                WshShell shell = new WshShell();
                //快捷键方式创建的位置、名称
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + "Aurora Player.lnk");
                shortcut.TargetPath = @Application.StartupPath + "\\Aurora Player.exe"; //目标文件
                shortcut.WorkingDirectory = System.Environment.CurrentDirectory;//该属性指定应用程序的工作目录，当用户没有指定一个具体的目录时，快捷方式的目标应用程序将使用该属性所指定的目录来装载或保存文件。
                shortcut.WindowStyle = 1; //目标应用程序的窗口状态分为普通、最大化、最小化【1,3,7】
                shortcut.Description = "Aurora Player"; //描述
                shortcut.IconLocation = Application.StartupPath + "\\Aurora Player.ico";  //快捷方式图标
                shortcut.Arguments = "";
                //shortcut.Hotkey = "CTRL+ALT+F11"; // 快捷键
                shortcut.Save(); //必须调用保存快捷才成创建成功
            }
            else
                return;
        }

    }
}
