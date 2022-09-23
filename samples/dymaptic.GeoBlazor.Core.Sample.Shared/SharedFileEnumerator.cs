using dymaptic.GeoBlazor.Core.Sample.Shared.Pages;
using Microsoft.Extensions.FileProviders;
using System.Collections;
using System.Reflection;


namespace dymaptic.GeoBlazor.Core.Sample.Shared;

internal class SharedFileEnumerator : IEnumerator<IFileInfo>
{
    public SharedFileEnumerator(string subpath)
    {
        _pages ??= Assembly.GetAssembly(typeof(Navigation))!.DefinedTypes
            .Select(t => t.FullName)
            .Where(n => n is not null && n.StartsWith(Namespace))
            .Select(n => new SharedFileInfo(
                $"{subpath}/{n!.Split('.').Last().Split('+').First()}.html") as IFileInfo)
            .ToList();
    }

    public IFileInfo Current => _pages![_currentIndex];

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        return;
    }

    public bool MoveNext()
    {
        _currentIndex++;
        return _currentIndex < _pages!.Count;
    }

    public void Reset()
    {
        _currentIndex = 0;
    }

    private const string Namespace = "dymaptic.GeoBlazor.Core.Sample.Shared.Pages";
    private static IList<IFileInfo>? _pages;
    private int _currentIndex;
}