using System.Collections.Generic;
using RomgrApp.Model;

namespace RomgrApp.Logic;

public class Workspace
{
    public string Path { get; set; }

    public List<Platform> Platforms { get; set; }
}