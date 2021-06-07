using System;
using System.Runtime.InteropServices;
using static System.Console;
namespace cRPG
{
    class Engine
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static readonly IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;
        public static void Max()
        {
            Title = "cRPG®";
            SetWindowSize(LargestWindowWidth, LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
        }        
        public static void Print(string text, int speed = 15)
        {
            foreach (char c in text)
            {
                Write(c);
                System.Threading.Thread.Sleep(speed);
            }
            WriteLine("");
        }
    }
}
