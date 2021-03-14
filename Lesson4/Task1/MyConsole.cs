using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace Task1
{
    class MyConsole
	{
        const int STD_OUTPUT_HANDLE = -11;

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetStdHandle(int handle);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleDisplayMode(IntPtr ConsoleHandle, uint Flags, IntPtr NewScreenBufferDimensions);

        public static void FullScreen()
        {
            var hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
            SetConsoleDisplayMode(hConsole, 1, IntPtr.Zero);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
        }
	}
}
