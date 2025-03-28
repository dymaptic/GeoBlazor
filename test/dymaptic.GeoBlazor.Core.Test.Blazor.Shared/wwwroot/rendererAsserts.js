import {arcGisObjectRefs} from "./testRunner.js";

export function assertUniqueValueInfos(methodName, layerId) {
    let layer = arcGisObjectRefs[layerId];
    if (layer.renderer.uniqueValueInfos === undefined) {
        throw new Error(`Expected uniqueValueInfos`);
    }
    var colors = [];
    var shapes = [];
    for (let i = 0; i < layer.renderer.uniqueValueInfos.length; i++) {
        let uvi = layer.renderer.uniqueValueInfos[i];
        if (uvi.value === undefined) {
            throw new Error(`Expected value`);
        }
        if (uvi.symbol === undefined) {
            throw new Error(`Expected symbol`);
        }
        if (!colors.find(c => c === uvi.symbol.color.toHex())) {
            colors.push(uvi.symbol.color.toHex());
        }
        if (!shapes.find(s => s === uvi.symbol.style)) {
            shapes.push(uvi.symbol.style);
        }
    }
    if (colors.length < 2) {
        throw new Error(`Expected multiple colors`);
    }
    if (shapes.length < 2) {
        throw new Error(`Expected multiple shapes`);
    }
}