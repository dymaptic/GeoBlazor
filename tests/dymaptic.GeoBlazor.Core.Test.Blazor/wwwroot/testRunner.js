import {
    arcGisObjectRefs
} from "./_content/dymaptic.GeoBlazor.Core/js/arcGisJsInterop.js";

export function assertBasemapHasTwoLayers(viewId) {
    let view = arcGisObjectRefs[viewId];
    if (view.map.basemap.baseLayers.length !== 2) {
        throw new Error("Basemap does not have two layers");
    }
}

export function assertWidgetExists(viewId, widgetClass) {
    let view = arcGisObjectRefs[viewId];
    let widget = view.ui._components.find(c => c.widget.declaredClass === widgetClass)
    if (!widget) {
        throw new Error("Widget does not exist");
    }
}

export function testThrow() {
    throw new Error("Test throw");
}