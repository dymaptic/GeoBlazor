// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetAuthoringInfoField2ClassBreakInfos } from './authoringInfoField2ClassBreakInfos';

export async function buildJsAuthoringInfoField2ClassBreakInfosGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsAuthoringInfoField2ClassBreakInfos: any = {};

    if (hasValue(dotNetObject.maxValue)) {
        jsAuthoringInfoField2ClassBreakInfos.maxValue = dotNetObject.maxValue;
    }
    if (hasValue(dotNetObject.minValue)) {
        jsAuthoringInfoField2ClassBreakInfos.minValue = dotNetObject.minValue;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsAuthoringInfoField2ClassBreakInfos);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsAuthoringInfoField2ClassBreakInfos;
    
    return jsAuthoringInfoField2ClassBreakInfos;
}


export async function buildDotNetAuthoringInfoField2ClassBreakInfosGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetAuthoringInfoField2ClassBreakInfos: any = {};
    
    if (hasValue(jsObject.maxValue)) {
        dotNetAuthoringInfoField2ClassBreakInfos.maxValue = jsObject.maxValue;
    }
    
    if (hasValue(jsObject.minValue)) {
        dotNetAuthoringInfoField2ClassBreakInfos.minValue = jsObject.minValue;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetAuthoringInfoField2ClassBreakInfos.id = geoBlazorId;
    }

    return dotNetAuthoringInfoField2ClassBreakInfos;
}

