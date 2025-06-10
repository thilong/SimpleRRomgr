using System.Collections.Generic;

namespace RomgrApp.Model;

public class Game
{
    public int PlatformId { get; set; }
    public int[] CategoryId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Publisher { get; set; }
    public string PublishDate { get; set; }


    public int Rate { get; set; }


    public List<Media> Medias { get; set; }
}