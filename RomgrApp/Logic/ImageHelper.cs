using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace RomgrApp.Logic;

public static class ImageHelper
{
    public static Bitmap LoadFromResource(String path)
    {
        return LoadFromResource(new Uri(path));
    }
    
    public static Bitmap LoadFromResource(Uri resourceUri)
    {
        try
        {
            Bitmap ret = new Bitmap(AssetLoader.Open(resourceUri));
            return ret;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while optn image '{resourceUri}' : {ex.Message}");
            return null;
        }
        
    }

    public static async Task<Bitmap> LoadFromWeb(Uri url)
    {
        using var httpClient = new HttpClient();
        try
        {
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsByteArrayAsync();
            return new Bitmap(new MemoryStream(data));
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"An error occurred while downloading image '{url}' : {ex.Message}");
            return null;
        }
    }
}