namespace dymaptic.GeoBlazor.Core.Options;

public partial record RequestOptions
{


    /// <summary>
    ///     If uploading a file, specify the form data or element used to submit the file here. If specified, the parameters of the query will be added to the URL.
    /// </summary>
    public string? Body { get; set; }

}