// override generated code in this file

import LayerOptions from "@arcgis/core/popup/LayerOptions";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export function buildJsLayerOptions(dotNetObject: any): any {
    let jsLayerOptions = new LayerOptions();

    if (hasValue(dotNetObject.returnTopmostRaster)) {
        jsLayerOptions.returnTopmostRaster = dotNetObject.returnTopmostRaster;
    }
    if (hasValue(dotNetObject.showNoDataRecords)) {
        jsLayerOptions.showNoDataRecords = dotNetObject.showNoDataRecords;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(layerOptionsWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsLayerOptions;

    let dnInstantiatedObject = buildDotNetLayerOptions(jsLayerOptions);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for LayerOptions', e);
    }

    return jsLayerOptions;
}
export function buildDotNetLayerOptions(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetLayerOptions: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.returnTopmostRaster)) {
        dotNetLayerOptions.returnTopmostRaster = jsObject.returnTopmostRaster;
    }
    if (hasValue(jsObject.showNoDataRecords)) {
        dotNetLayerOptions.showNoDataRecords = jsObject.showNoDataRecords;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetLayerOptions.id = k;
                break;
            }
        }
    }

    return dotNetLayerOptions;
}
