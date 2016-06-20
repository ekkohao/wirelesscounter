using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace wirelesssacler
{
    public static class Delaytime
    {

        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();
            }
        }
    }
}
