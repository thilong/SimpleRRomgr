using Avalonia.Controls;
using Avalonia.Input;

namespace RomgrApp.UI.Windows;

public class BaseWindow : Window
{
    public void MinimizeCommand() => this.WindowState = WindowState.Minimized;
    public void MaximizeCommand() => ToggleMaximize();
    public void CloseCommand() => this.Close();
    private void ToggleMaximize()
    {
        var window = this;
        window.WindowState = window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
    }
}