using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;


namespace dymaptic.Blazor.GIS.API.Core.Sample.Shared;

public class SharedFileProvider : IFileProvider
{
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;

    public SharedFileProvider(HttpClient httpClient, NavigationManager navigationManager)
    {
        _httpClient = httpClient;
        _navigationManager = navigationManager;
    }

    public virtual async Task<Stream> GetFileStreamAsync(IFileInfo fileInfo)
    {
        HttpResponseMessage pageResponse = await _httpClient.GetAsync(
                    Path.Combine(_navigationManager.BaseUri, fileInfo.PhysicalPath));
        return await pageResponse.Content.ReadAsStreamAsync();
    }

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
}