using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace wirelesssacler
{
    static class Program
    {
        public static System.Threading.Mutex Run;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool noRun = false;

            Run = new System.Threading.Mutex(true, "SmsProgram", out noRun);
            if (noRun)
            {
                Run.ReleaseMutex();
                Application.EnableVisualStyles();
                
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Mainfrm());
            }
            else
            {
                MessageBox.Show("程序已运行！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }
    }
}
