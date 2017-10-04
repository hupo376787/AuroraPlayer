using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Aurora_Player
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if(!File.Exists(Application.StartupPath + "\\Aurora Player.Settings.cfg"))
            {
                WriteCfg();
            }
            try
            {
                MainForm main = new MainForm();
                if (args != null && args.Length > 0)
                {
                    main.b_OpenWithArgs = true;
                    //main.InitThumbnailToolbarButton();
                    //当有参数时，初始化控制面板还没有读取FocusColor
                    //IniHelper ini = new IniHelper(Application.StartupPath + "\\Aurora Player.Settings.cfg");
                    //main.FocusColor = Color.FromArgb(Convert.ToInt32(ini.ReadValue("Settings", "FocusColor")));
                    main.str_File_OpenWithArgs = args[0];
                    Application.Run(main);
                }
                else
                {
                    main.b_OpenWithArgs = false;
                    Application.Run(main);
                }
            }
            catch { }
        }

        private static void WriteCfg()
        {
            String filePath = Application.StartupPath + "\\Aurora Player.Settings.cfg";
            System.Reflection.Assembly app = System.Reflection.Assembly.GetExecutingAssembly();
            Stream fsOpen = app.GetManifestResourceStream("Aurora_Player.Settings.cfg");
            FileStream fsSave = new FileStream(filePath, FileMode.Create);
            StreamReader sr = new StreamReader(fsOpen);
            StreamWriter sw = new StreamWriter(fsSave);
            long lenth = sr.BaseStream.Length;
            int i = 0;
            char[] bytes = new char[256];
            while (!sr.EndOfStream)
            {
                i = sr.Read(bytes, 0, 256);
                sw.Write(bytes, 0, i);
            }
            sw.Flush();
            sw.Close();
            sr.Close();
            fsSave.Close();
            fsOpen.Close();

        }
    }
}
