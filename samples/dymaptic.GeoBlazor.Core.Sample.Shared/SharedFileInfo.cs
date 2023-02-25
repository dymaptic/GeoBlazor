using Microsoft.Extensions.FileProviders;


namespace dymaptic.GeoBlazor.Core.Sample.Shared;

internal class SharedFileInfo : IFileInfo
{
    public SharedFileInfo(string physicalPath)
    {
        PhysicalPath = physicalPath;
        Name = Path.GetFileName(physicalPath);
    }

    public bool Exists => true;
    public long Length { get; } = default!;
    public string PhysicalPath { get; }
    public string Name { get; }
    public DateTimeOffset LastModified { get; } = default!;
    public bool IsDirectory { get; } = default!;

    public Stream CreateReadStream()
    {
        throw new NotImplementedException();
    }
}