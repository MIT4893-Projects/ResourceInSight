using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace ResourceInSight.Helpers;

internal static class OverlayClickThroughHelper
{
    private const int WS_EX_TRANSPARENT = 0x00000020;
    private const int GWL_EXSTYLE = (-20);

    [DllImport("user32.dll")]
    private static extern int GetWindowLong(IntPtr hwnd, int index);

    [DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

    public static void SetWindowExTransparent(Window window)
    {
        nint hwnd = new WindowInteropHelper(window).Handle;
        SetWindowExTransparent(hwnd);
    }

    public static void SetWindowExNotTransparent(Window window)
    {
        nint hwnd = new WindowInteropHelper(window).Handle;
        SetWindowExNotTransparent(hwnd);
    }

    public static void SetWindowExTransparent(IntPtr hwnd)
    {
        var extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
        _ = SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT);
    }

    public static void SetWindowExNotTransparent(IntPtr hwnd)
    {
        var extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
        _ = SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle & ~WS_EX_TRANSPARENT);
    }

}
