import {arcGisObjectRefs} from "./testRunner.js";

function resolveLayerById(id) {
    return arcGisObjectRefs[id];
}
    

function assertEq(actual, expected, msg) {
    if (Array.isArray(expected)) {
        const pass = Array.isArray(actual) && expected.length === actual.length
            ? expected.every((v, i) => v === actual[i])
            : false;
        if (!pass) throw new Error(msg + ` (expected: ${JSON.stringify(expected)}, actual: ${JSON.stringify(actual)})`);
        return;
    }
    if (actual !== expected) {
        throw new Error(msg + ` (expected: ${JSON.stringify(expected)}, actual: ${JSON.stringify(actual)})`);
    }
}

export function assertFeatureLayerBooleanPropEquals(methodName, id, prop, expected) {
    const layer = resolveLayerById(id);
    assertEq(!!layer[prop], !!expected, `Boolean property mismatch: ${prop}`);
}

export function assertFeatureLayerNumberPropEquals(methodName, id, prop, expected) {
    const layer = resolveLayerById(id);
    assertEq(Number(layer[prop]), Number(expected), `Number property mismatch: ${prop}`);
}

export function assertFeatureLayerStringPropEquals(methodName, id, prop, expected) {
    const layer = resolveLayerById(id);
    assertEq(String(layer[prop] ?? ""), String(expected ?? ""), `String property mismatch: ${prop}`);
}

export function assertFeatureLayerArrayPropEquals(methodName, id, prop, expected) {
    const layer = resolveLayerById(id);
    const arr = Array.isArray(layer[prop]) ? layer[prop] : [];
    assertEq(arr, expected, `Array property mismatch: ${prop}`);
}

export function assertFeatureLayerRendererType(methodName, id, expectedType) {
    const layer = resolveLayerById(id);
    const t = layer.renderer?.type;
    if (t !== expectedType) {
        throw new Error(`Renderer type mismatch. expected=${expectedType}, actual=${t}`);
    }
}

export function assertFeatureLayerPopupTitle(methodName, id, expectedTitle) {
    const layer = resolveLayerById(id);
    const t = layer.popupTemplate?.title;
    if (String(t ?? "") !== String(expectedTitle ?? "")) {
        throw new Error(`PopupTemplate.title mismatch. expected=${expectedTitle}, actual=${t}`);
    }
}

export function assertFeatureLayerOrderByContains(methodName, id, field, order) {
    const layer = resolveLayerById(id);
    const items = layer.orderBy || [];
    const hit = items.some(i => i?.field === field && String(i?.order || "").toUpperCase() === String(order).toUpperCase());
    if (!hit) {
        throw new Error(`orderBy missing expected entry: ${field} ${order}`);
    }
}

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