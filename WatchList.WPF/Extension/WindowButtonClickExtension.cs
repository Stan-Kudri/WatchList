using System.Windows;

namespace WatchList.WPF.Extension
{
    public static class WindowButtonClickExtension
    {
        public static void ClickButtonWindow(this Window window)
        {
            window.DialogResult = true;
            window?.Close();
        }
    }
}
