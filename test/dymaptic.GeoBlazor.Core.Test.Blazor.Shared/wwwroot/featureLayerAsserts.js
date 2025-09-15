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