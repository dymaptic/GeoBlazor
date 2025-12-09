using Microsoft.JSInterop;
using ProtoBuf.Meta;
using System.Runtime.CompilerServices;

namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Manages JavaScript interop with support for Protobuf serialization and streaming.
/// </summary>
/// <remarks>
///     This is the infrastructure class for the Protobuf serialization system.
///     The full implementation with serialization records will be added in a subsequent PR.
/// </remarks>
public static class JsSyncManager
{
    /// <summary>
    ///     Dictionary of serializable methods keyed by class name.
    /// </summary>
    public static Dictionary<string, SerializableMethodRecord[]> SerializableMethods { get; set; } = [];

    /// <summary>
    ///     Dictionary mapping source types to their Protobuf contract types.
    /// </summary>
    public static Dictionary<Type, Type> ProtoContractTypes { get; set; } = [];

    /// <summary>
    ///     Dictionary mapping collection item types to their Protobuf collection types.
    /// </summary>
    public static Dictionary<Type, Type> ProtoCollectionTypes { get; set; } = [];

    private static Dictionary<string, List<SerializableMethodRecord>>? _serializableMethods;

    /// <summary>
    ///     Initializes the JsSyncManager with Protobuf type registrations.
    /// </summary>
    public static void Initialize()
    {
        foreach (Type protoType in ProtoContractTypes.Values)
        {
            RuntimeTypeModel.Default.Add(protoType, true);
        }

        RuntimeTypeModel.Default.CompileInPlace();

        _serializableMethods = SerializableMethods
            .ToDictionary(g => g.Key, g => g.Value.ToList());
    }

    /// <summary>
    ///     Wrapper method to invoke a void JS function with serialization support.
    /// </summary>
    /// <param name="js">The IJSObjectReference to invoke the method on.</param>
    /// <param name="isServer">Boolean flag to identify if GeoBlazor is running in Blazor Server mode.</param>
    /// <param name="method">The name of the JS function to call.</param>
    /// <param name="className">The name of the calling class.</param>
    /// <param name="cancellationToken">A CancellationToken to cancel an asynchronous operation.</param>
    /// <param name="parameters">The collection of parameters to pass to the JS call.</param>
    public static async Task InvokeVoidJsMethod(this IJSObjectReference js, bool isServer,
        [CallerMemberName] string method = "", string className = "",
        CancellationToken cancellationToken = default, params object?[] parameters)
    {
        // Placeholder implementation - full serialization support will be added in subsequent PR
        await js.InvokeVoidAsync(method, cancellationToken, parameters);
    }

    /// <summary>
    ///     Wrapper method to invoke a JS function that returns a value with serialization support.
    /// </summary>
    /// <typeparam name="T">The expected return type.</typeparam>
    /// <param name="js">The IJSObjectReference to invoke the method on.</param>
    /// <param name="isServer">Boolean flag to identify if GeoBlazor is running in Blazor Server mode.</param>
    /// <param name="method">The name of the JS function to call.</param>
    /// <param name="className">The name of the calling class.</param>
    /// <param name="cancellationToken">A CancellationToken to cancel an asynchronous operation.</param>
    /// <param name="parameters">The collection of parameters to pass to the JS call.</param>
    /// <returns>The result of the JS call.</returns>
    public static async Task<T> InvokeJsMethod<T>(this IJSObjectReference js, bool isServer,
        [CallerMemberName] string method = "", string className = "",
        CancellationToken cancellationToken = default,
        params object?[] parameters)
    {
        // Placeholder implementation - full serialization support will be added in subsequent PR
        return await js.InvokeAsync<T>(method, cancellationToken, parameters);
    }
}
