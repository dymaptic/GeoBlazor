using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Components;
public class PortalFolder : MapComponent
{

    /// <summary>
    ///    The unique id of the folder.
    /// </summary>
    public new string Id { get; set; } = default!;

    /// <summary>
    /// The date the folder was created.
    /// </summary>
    public DateTime CreatedDate { get; set; }


    /// <summary>
    ///  The portal associated with the folder.
    /// </summary>
    public Portal Portal { get; set; } = default!;

    /// <summary>
    ///   The title of the folder.
    /// </summary>
    public string Title { get; set; } = default!;

    /// <summary>
    ///  The URL to the folder.
    /// </summary>
    public string Url { get; set; } = default!;
}

