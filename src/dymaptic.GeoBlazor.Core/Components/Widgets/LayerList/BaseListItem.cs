using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Components.Widgets.LayerList
{
    /// <summary>
    ///     The ListItem class represents one of the operationalItems in the LayerListViewModel. In the LayerList widget UI, the list item represents a layer displayed in the view. It provides access to the associated layer's properties, allows the developer to configure actions related to the layer, and allows the developer to add content to the item related to the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html">ArcGIS JS API</a>
    /// </summary>
    public class BaseListItem
    {
        /// <summary>
        ///     The displayed title of the basemap layer in the Basemap LayerList Widget.
        /// </summary>
        [Parameter]
        public string? Title { get; set; }

        /// <summary>
        ///     The displayed id of the basemap layer in the basemap LayerList Widget.
        /// </summary>
        [Parameter]
        public string? Id { get; set; }

        /// <summary>
        ///     The children basemap items in a layer.
        /// </summary>
        [Parameter]
        public List<ListItem>? BasemapItems { get; set; }

        /// <summary>
        ///     The children base items in a layer.
        /// </summary>

        public List<ListItem>? BaseItems { get; set; }
        /// <summary>
        ///     The children reference items in a layer.
        /// </summary>
        [Parameter]
        public List<ListItem>? ReferenceItems { get; set; }

        /// <summary>
        ///     Determines whether the basemap layer is visible on load.
        /// </summary>
        [Parameter]
        public bool? Visible { get; set; }

        /// <summary>
        ///     Sets the actions on click for the list item.
        /// </summary>
        /// <remarks>
        ///     The Action Sections property and corresponding functionality will be fully implemented
        ///     in a future iteration.  Currently, a user can view available layers in the layer list widget
        ///     and toggle the selected layer's visibility. More capabilities will be available after full
        ///     implementation of ActionSection.
        /// </remarks>
        public ActionBase[][]? ActionSections { get; set; }
    }
}
