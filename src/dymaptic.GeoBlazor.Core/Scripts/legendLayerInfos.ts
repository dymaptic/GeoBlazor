import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

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

    try {
        let dnInstantiatedObject = await buildDotNetLegendLayerInfos(jsLegendLayerInfos);

        let seenObjects = new WeakMap();
        await dotNetObject.dotNetComponentReference?.invokeMethodAsync('OnJsComponentCreated',
            jsObjectRef, JSON.stringify(dnInstantiatedObject, function (key, value) {
                if (key.startsWith('_') || key === 'jsComponentReference') {
                    return undefined;
                }
                if (typeof value === 'object' && value !== null
                    && !(Array.isArray(value) && value.length === 0)) {
                    if (seenObjects.has(value)) {
                        console.debug(`Circular reference in serializing type LegendLayerInfos detected at path: ${key}, value: ${value.declaredClass}`);
                        return undefined;
                    }
                    seenObjects.set(value, true);
                }
                return value;
            }));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for LegendLayerInfos', e);
    }

    return jsLegendLayerInfos;
}

export async function buildDotNetLegendLayerInfos(jsObject: any): Promise<any> {
    let {buildDotNetLegendLayerInfosGenerated} = await import('./legendLayerInfos.gb');
    return await buildDotNetLegendLayerInfosGenerated(jsObject);
}
