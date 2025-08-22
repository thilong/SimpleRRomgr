using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RomgrApp.Model;

namespace RomgrApp.UI.Components;

public partial class GameGridListView : UserControl
{
    public List<Game> Games { get; set; }

    public GameGridListView()
    {
        InitializeComponent();


        Games =
        [
            new Game()
            {
                Name = "超级玛丽奥"
            },

            new Game()
            {
                Name = "坦克大战"
            },
            new Game()
            {
                Name = "坦克大战"
            },
            new Game()
            {
                Name = "坦克大战"
            },
            new Game()
            {
                Name = "坦克大战"
            },
            new Game()
            {
                Name = "坦克大战"
            }
        ];

        DataContext = this;
    }
}