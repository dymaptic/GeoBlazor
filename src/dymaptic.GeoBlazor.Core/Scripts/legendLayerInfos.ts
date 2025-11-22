import {arcGisObjectRefs, hasValue, jsObjectRefs} from './geoBlazorCore';

export async function buildJsLegendLayerInfos(dotNetObject: any): Promise<any> {
    let jsLegendLayerInfos: any = {};
    if (hasValue(dotNetObject.layerId) && arcGisObjectRefs.hasOwnProperty(dotNetObject.layerId)) {
        jsLegendLayerInfos.layer = arcGisObjectRefs[dotNetObject.layerId];
    }

    if (hasValue(dotNetObject.sublayerIds) && dotNetObject.sublayerIds.length > 0) {
        jsLegendLayerInfos.sublayerIds = dotNetObject.sublayerIds;
    }
    if (hasValue(dotNetObject.title)) {
        jsLegendLayerInfos.title = dotNetObject.title;
    }

    let jsObjectRef = DotNet.createJSObjectReference(jsLegendLayerInfos);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsLegendLayerInfos;

    return jsLegendLayerInfos;
}

export async function buildDotNetLegendLayerInfos(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetLegendLayerInfosGenerated} = await import('./legendLayerInfos.gb');
    return await buildDotNetLegendLayerInfosGenerated(jsObject, viewId);
}
