import {getView, arcGisObjectRefs} from "../dymaptic.GeoBlazor.Core.Test.Blazor.Shared/testRunner.js";


export function assertHasReduction(methodName, layerId) {
    let view = getView(methodName);
    let layer = arcGisObjectRefs[layerId];
    if (layer?.featureReduction === undefined || layer?.featureReduction === null) {
        throw new Error(`No feature reduction`);
    }
}