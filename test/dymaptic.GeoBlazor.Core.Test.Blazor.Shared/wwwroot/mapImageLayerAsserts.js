import {getView, arcGisObjectRefs} from "./testRunner.js";

export async function toggleSublayers(methodName, sublayerIds) {
    let sublayers = sublayerIds.map(i => arcGisObjectRefs[i]);
    for (let sublayer of sublayers) {
        sublayer.visible = false;
    }
}