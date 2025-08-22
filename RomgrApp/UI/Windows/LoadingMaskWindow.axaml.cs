using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RomgrApp.UI.Windows;

public partial class LoadingMaskWindow : Window
{
    public event Action OnCanceled;

    public LoadingMaskWindow()
    {
        InitializeComponent();
        WindowStartupLocation = WindowStartupLocation.CenterOwner;

        CancelAction.Click += (sender, args) =>
        {
            Close(-1);
            OnCanceled?.Invoke();
        };
    }
}