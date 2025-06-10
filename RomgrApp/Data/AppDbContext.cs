using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using RomgrApp.Model;

namespace RomgrApp.Data;

public class AppDbContext(String workingPath) : DbContext
{
    public static void OpenNew(String workingPath)
    {
        Shared = new AppDbContext(workingPath);
    }
    
    public static AppDbContext Shared { get; private set; }

    private readonly string _dbPath = Path.Combine(workingPath, "rrmgr.db");

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={_dbPath}");


    public DbSet<Platform> Platforms;
}