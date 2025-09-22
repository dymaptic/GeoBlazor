import { arcGisObjectRefs } from "./testRunner.js";
function resolveLayerViewByLayerId(layerId) {
    const layer = arcGisObjectRefs[layerId];
    if (layer?.views?.length) return layer.views[0];

    if (typeof window.getLayerViewByLayerId === "function") {
        const lv = window.getLayerViewByLayerId(layerId);
        if (lv) return lv;
    }

    const views =
        window.__geoblazor_views ??
        (window.__map?.views ? [window.__map.views[0]] : []) ??
        [];
    for (const v of views) {
        if (!v?.map?.layers) continue;
        const lyr = v.map.layers.find?.(l => l?.id === layerId);
        if (!lyr) continue;

        const fromViewCollection = v?.layerViews?.find?.(x => x?.layer?.id === layerId);
        if (fromViewCollection) return fromViewCollection;

        const fromLayer = lyr?.views?.[0];
        if (fromLayer) return fromLayer;
    }

    throw new Error("LayerView not found for layerId: " + layerId);
}

export function assertFeatureLayerViewFilterWhere(methodName, layerId, expectedWhere) {
    const lv = resolveLayerViewByLayerId(layerId);
    const where = String(lv?.filter?.where ?? "");
    assertEq(where, String(expectedWhere), "LayerView.filter.where mismatch");
}

export function assertFeatureLayerViewMaxFeatures(methodName, layerId, expected) {
    const lv = resolveLayerViewByLayerId(layerId);
    const value = Number(lv?.maximumNumberOfFeatures ?? 0);
    assertEq(value, Number(expected), "maximumNumberOfFeatures mismatch");
}