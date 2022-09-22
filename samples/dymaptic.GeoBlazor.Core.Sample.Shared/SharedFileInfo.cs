using Microsoft.Extensions.FileProviders;


namespace dymaptic.GeoBlazor.Core.Sample.Shared;

internal class SharedFileInfo : IFileInfo
{
    public SharedFileInfo(string physicalPath)
    {
        PhysicalPath = physicalPath;
        Name = Path.GetFileName(physicalPath);
    }
    public Stream CreateReadStream()
    {
        throw new NotImplementedException();
    }

    public bool Exists => true;
    public long Length { get; }
    public string PhysicalPath { get; }
    public string Name { get; }
    public DateTimeOffset LastModified { get; }
    public bool IsDirectory { get; }
}