using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RomgrApp.Model;

namespace RomgrApp.UI.Components;

public partial class CategoryVListView : Grid
{
    public CategoryVListView()
    {
        InitializeComponent();
        var td = new List<Category>
        {
            new()
            {
                Name = "All"
            },
            new()
            {
                Name = "角色扮演"
            },
            new()
            {
                Name = "格斗游戏"
            }
        };
        CategoryList.ItemsSource = td;
    }
}