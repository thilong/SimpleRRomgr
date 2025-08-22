using System;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using RomgrApp.Logic;

namespace RomgrApp.Model;

public class Platform
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string FullName { get; set; }

    public string Icon { get; set; }
    public string Publisher { get; set; }
    public string PublishDate { get; set; }

    public Platform()
    {
        
    }



    public Bitmap IconSource => ImageHelper.LoadFromResource(Icon);
}