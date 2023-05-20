import {
    arcGisObjectRefs
} from "./_content/dymaptic.GeoBlazor.Core/js/arcGisJsInterop.js";

export function assertBasemapHasTwoLayers(viewId) {
    let view = arcGisObjectRefs[viewId];
    if (view.map.basemap.baseLayers.length !== 2) {
        throw new Error("Basemap does not have two layers");
    }
}

export function testThrow() {
    throw new Error("Test throw");
}