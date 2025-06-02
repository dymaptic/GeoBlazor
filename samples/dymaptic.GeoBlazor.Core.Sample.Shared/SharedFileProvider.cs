using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;


namespace dymaptic.GeoBlazor.Core.Sample.Shared;

public class SharedFileProvider(HttpClient httpClient, NavigationManager navigationManager) : IFileProvider
{
    public IDirectoryContents GetDirectoryContents(string subpath)
    {
        return new SharedDirectoryContents(subpath);
    }

    public IFileInfo GetFileInfo(string subpath)
    {
        throw new NotImplementedException();
    }

    public IChangeToken Watch(string filter)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<Stream> GetFileStreamAsync(IFileInfo fileInfo)
    {
        HttpResponseMessage pageResponse = await httpClient.GetAsync(
            Path.Combine(navigationManager.BaseUri, fileInfo.PhysicalPath!));

        return await pageResponse.Content.ReadAsStreamAsync();
    }
}