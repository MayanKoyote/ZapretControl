using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

#pragma warning disable IDE0079
#pragma warning disable SYSLIB1054
namespace ZapretControl.Extensions
{
    internal static class ProcessExtensions
    {
        public static void BringToForeground(this Process process)

        {
            var handle = process.MainWindowHandle;
            if (handle == IntPtr.Zero) return;

            if (IsIconic(handle))
            {
                ShowWindow(handle, SW_RESTORE);
            }

            SetForegroundWindow(handle);
        }

        #region WINAPI

        private const int SW_RESTORE = 9;

        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        #endregion WINAPI
    }
}