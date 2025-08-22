using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using RomgrApp.Model;

namespace RomgrApp.Logic;

public class Workspace
{
    public enum WorkspaceOperationResult
    {
        Ok = 0,
        Canceled = -1,
        Running = -2,
        Error = -3
    }

    private static Workspace _instance = null;

    public static Workspace Shared => _instance ??= new Workspace();


    public string Path { get; set; }

    public List<Platform> Platforms { get; set; }

    private CancellationTokenSource _cancellationTokenSource;

    public async Task<WorkspaceOperationResult> LoadWorkspaceAsync(string path)
    {
        if (_cancellationTokenSource != null) return WorkspaceOperationResult.Running;
        try
        {
            _cancellationTokenSource = new CancellationTokenSource();
            List<Platform> newPlatforms = await DoAsyncScanWorkspace(path, _cancellationTokenSource.Token);
            Platforms = newPlatforms;
            return WorkspaceOperationResult.Ok;
        }
        catch (OperationCanceledException canceled)
        {
            return WorkspaceOperationResult.Canceled;
        }
        catch (Exception exception)
        {
            return WorkspaceOperationResult.Error;
        }
    }

    public void CancelLoadWorkspace()
    {
        if (_cancellationTokenSource != null)
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource = null;
        }
    }

    private static async Task<List<Platform>> DoAsyncScanWorkspace(string path, CancellationToken cancellationToken)
    {
        var folders = Directory.GetDirectories(path);

        
        
        
        for (int i = 0; i < 100; i++)
        {
            // 检查取消请求
            var canceled = cancellationToken.IsCancellationRequested;
            cancellationToken.ThrowIfCancellationRequested();
            // 模拟工作
            await Task.Delay(100, cancellationToken);
            Console.WriteLine($"Processing item {i}");
        }

        return null;
    }
}