using Avalonia.Controls;
using Avalonia.Platform;

namespace RomgrApp.UI.Windows;

public partial class MainWindow : BaseWindow
{
    
    
    public MainWindow()
    {
        InitializeComponent();

        WindowMinimizeAction.Click += (sender, args) => MinimizeCommand();
        WindowMaximizeAction.Click += (sender, args) => MaximizeCommand();
        WindowCloseAction.Click += (sender, args) => CloseCommand();
        
        
        
    }
    
}