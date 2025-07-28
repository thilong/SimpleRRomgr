using Avalonia.Controls;
using Avalonia.Platform;

namespace RomgrApp.UI.Windows;

public partial class MainWindow : BaseWindow
{
    
    
    public MainWindow()
    {
        InitializeComponent();

        WindowMinimizeActionButton.Click += (sender, args) => MinimizeCommand();
        WindowMaximizeActionButton.Click += (sender, args) => MaximizeCommand();
        WindowCloseActionButton.Click += (sender, args) => CloseCommand();
        
        
        
    }
    
}