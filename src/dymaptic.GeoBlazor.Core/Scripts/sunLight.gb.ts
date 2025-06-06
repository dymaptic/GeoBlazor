// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetSunLight } from './sunLight';

export async function buildJsSunLightGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsSunLight: any = {};
    if (hasValue(dotNetObject.ambient)) {
        let { buildJsColorAndIntensity } = await import('./colorAndIntensity');
        jsSunLight.ambient = await buildJsColorAndIntensity(dotNetObject.ambient, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.diffuse)) {
        let { buildJsColorAndIntensity } = await import('./colorAndIntensity');
        jsSunLight.diffuse = await buildJsColorAndIntensity(dotNetObject.diffuse, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.direction) && dotNetObject.direction.length > 0) {
        jsSunLight.direction = dotNetObject.direction;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsSunLight);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSunLight;
    
    return jsSunLight;
}


export async function buildDotNetSunLightGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetSunLight: any = {};
    
    if (hasValue(jsObject.ambient)) {
        let { buildDotNetColorAndIntensity } = await import('./colorAndIntensity');
        dotNetSunLight.ambient = await buildDotNetColorAndIntensity(jsObject.ambient, layerId, viewId);
    }
    
    if (hasValue(jsObject.diffuse)) {
        let { buildDotNetColorAndIntensity } = await import('./colorAndIntensity');
        dotNetSunLight.diffuse = await buildDotNetColorAndIntensity(jsObject.diffuse, layerId, viewId);
    }
    
    if (hasValue(jsObject.direction)) {
        dotNetSunLight.direction = jsObject.direction;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetSunLight.id = geoBlazorId;
    }

    return dotNetSunLight;
}

