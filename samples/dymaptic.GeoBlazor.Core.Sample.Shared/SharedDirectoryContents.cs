using Microsoft.Extensions.FileProviders;
using System.Collections;


namespace dymaptic.GeoBlazor.Core.Sample.Shared;

internal class SharedDirectoryContents : IDirectoryContents
{
    public SharedDirectoryContents(string subpath)
    {
        _subpath = subpath;
    }

    public bool Exists => true;

    public IEnumerator<IFileInfo> GetEnumerator()
    {
        return new SharedFileEnumerator(_subpath);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private readonly string _subpath;
}