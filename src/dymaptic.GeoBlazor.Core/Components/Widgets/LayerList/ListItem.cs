using dymaptic.GeoBlazor.Core.Components.Layers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Components.Widgets.LayerList
{
    public class ListItem 
    {
        [Parameter]
        public string? Title { get; set; }
        [Parameter]
        public Layer? Layer { get; set; }
        [Parameter]
        public bool? Visible { get; set; }
        public List<ListItem>? Children { get; set; }
        
    }
}
