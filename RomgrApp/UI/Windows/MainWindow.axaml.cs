using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform;
using Avalonia.Platform.Storage;
using RomgrApp.Logic;

namespace RomgrApp.UI.Windows;

public partial class MainWindow : BaseWindow
{
    public MainWindow()
    {
        InitializeComponent();

        WindowMinimizeAction.Click += (sender, args) => MinimizeCommand();
        WindowMaximizeAction.Click += (sender, args) => MaximizeCommand();
        WindowCloseAction.Click += (sender, args) => CloseCommand();

        OpenWorkspaceAction.Click += (sender, args) => { _ = OpenWorkspace(); };
    }

    private async Task OpenWorkspace()
    {
        var newWorkspacePathResult = await this.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions()
        {
            AllowMultiple = false, Title = "Open Workspace"
        });

        if (newWorkspacePathResult.Count < 1) return;
        var newPath = newWorkspacePathResult[0].Path.AbsolutePath;

        LoadingMaskWindow loadingMask = new LoadingMaskWindow();
        loadingMask.OnCanceled += () => { Workspace.Shared.CancelLoadWorkspace(); };
        _ = loadingMask.ShowDialog(this);
        Console.Write("0");

        var openResult = await Workspace.Shared.LoadWorkspaceAsync(newPath);
        Console.Write("{0}", openResult);
    }
}