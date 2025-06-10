using System.Collections.Generic;
using Avalonia.Controls;
using RomgrApp.Model;

namespace RomgrApp.UI.Components;

public partial class PlatformVListView : Grid
{

    public VoidDelegate OnOpenWorkspaceAction;
    
    public PlatformVListView()
    {
        InitializeComponent();
        var ps = new List<Platform>();

        ps.Add(new Platform()
        {
            Name = "FC",
            FullName = "Nintendo Famicom"
        });
        ps.Add(new Platform()
        {
            Name = "GBA",
            FullName = "Nintendo GameBoy Advanced"
        });
        PlatformList.ItemsSource = ps;


        ActionOpenWorkspace.Click += (_, _) =>
        {
            if(OnOpenWorkspaceAction!= null) OnOpenWorkspaceAction.Invoke();
        };
    }
}