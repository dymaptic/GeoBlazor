using dymaptic.GeoBlazor.Core.Sample.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.FileProviders;


namespace dymaptic.GeoBlazor.Core.Sample.Maui;

public class MauiFileProvider : SharedFileProvider
{
    public MauiFileProvider(HttpClient httpClient, NavigationManager navigationManager) : base(httpClient,
        navigationManager)
    {
    }

    public override async Task<Stream> GetFileStreamAsync(IFileInfo fileInfo)
    {
        return await FileSystem.OpenAppPackageFileAsync(fileInfo.Name);
    }
}