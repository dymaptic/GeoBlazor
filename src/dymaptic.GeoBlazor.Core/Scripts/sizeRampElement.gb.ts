// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetSizeRampElement } from './sizeRampElement';

export async function buildJsSizeRampElementGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsSizeRampElement: any = {};
    if (hasValue(dotNetObject.infos) && dotNetObject.infos.length > 0) {
        let { buildJsSizeRampStop } = await import('./sizeRampStop');
        jsSizeRampElement.infos = await Promise.all(dotNetObject.infos.map(async i => await buildJsSizeRampStop(i, layerId, viewId))) as any;
    }

    if (hasValue(dotNetObject.title)) {
        jsSizeRampElement.title = dotNetObject.title;
    }
    
    jsObjectRefs[dotNetObject.id] = jsSizeRampElement;
    arcGisObjectRefs[dotNetObject.id] = jsSizeRampElement;
    
    return jsSizeRampElement;
}


export async function buildDotNetSizeRampElementGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetSizeRampElement: any = {};
    
    if (hasValue(jsObject.infos)) {
        let { buildDotNetSizeRampStop } = await import('./sizeRampStop');
        dotNetSizeRampElement.infos = await Promise.all(jsObject.infos.map(async i => await buildDotNetSizeRampStop(i, layerId, viewId)));
    }
    
    if (hasValue(jsObject.title)) {
        dotNetSizeRampElement.title = jsObject.title;
    }
    
    if (hasValue(jsObject.type)) {
        dotNetSizeRampElement.type = jsObject.type;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetSizeRampElement.id = geoBlazorId;
    }

    return dotNetSizeRampElement;
}

