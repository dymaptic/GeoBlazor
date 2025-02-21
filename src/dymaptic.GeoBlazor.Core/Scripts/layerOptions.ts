// override generated code in this file

import LayerOptions from "@arcgis/core/popup/LayerOptions";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export function buildJsLayerOptions(dotNetObject: any): any {
    let properties:any = {};

    if (hasValue(dotNetObject.returnTopmostRaster)) {
        properties.returnTopmostRaster = dotNetObject.returnTopmostRaster;
    }
    if (hasValue(dotNetObject.showNoDataRecords)) {
        properties.showNoDataRecords = dotNetObject.showNoDataRecords;
    }

    let jsLayerOptions = new LayerOptions(properties);

    let jsObjectRef = DotNet.createJSObjectReference(jsLayerOptions);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsLayerOptions;

    return jsLayerOptions;
}

export function buildDotNetLayerOptions(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetLayerOptions: any = {
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
