using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RomgrApp.Data;
using RomgrApp.Model;

namespace RomgrApp.Logic;

public class PlatformOp
{
    public static PlatformOp Shared = new PlatformOp();


    private List<Platform> _platforms;

    public async Task<List<Platform>> GetPlatformsAsync()
    {
        return _platforms ??= await AppDbContext.Shared.Platforms.ToListAsync();
    }

    public async Task<List<Platform>> AddPlatformAsync(Platform newPlatform)
    {
        await AppDbContext.Shared.Platforms.AddAsync(newPlatform);
        _platforms = await AppDbContext.Shared.Platforms.ToListAsync();
        return _platforms;
    }
    
    
}