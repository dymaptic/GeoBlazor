import {arcGisObjectRefs} from "../dymaptic.GeoBlazor.Core/js/arcGisJsInterop.js";

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

export function assertGraphicExistsInView(viewId, geometryType, count) {
    let view = arcGisObjectRefs[viewId];
    let graphics = view.graphics.items.filter(g => g.geometry.type === geometryType);
    if (graphics.length !== count) {
        throw new Error(`Expected ${count} graphics of type ${geometryType} but found ${graphics.length}`);
    }
}

export function assertKmlLayerExists(viewId) {
    let view = arcGisObjectRefs[viewId];
    let layers = view.map.layers.items[0].type;
    if (layers !== 'kml') {
        throw new Error(`There are no Layers in this view`);
    }
}

export function testThrow() {
    throw new Error("Test throw");
}