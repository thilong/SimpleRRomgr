using System.Collections.Generic;
using Avalonia.Controls;
using RomgrApp.Model;

namespace RomgrApp.UI.Components;

public partial class PlatformVListView : Border
{
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
    }
}