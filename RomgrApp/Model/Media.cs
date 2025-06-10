namespace RomgrApp.Model;

public enum MediaType
{
    UnKnown,
    ArtBox,
    Banner,
    Video,
    Screenshot
}

public class Media
{
    public MediaType Type { get; set; }
    public string Path { get; set; }
}