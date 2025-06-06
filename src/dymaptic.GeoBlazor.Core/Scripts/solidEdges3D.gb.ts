// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import SolidEdges3D from '@arcgis/core/symbols/edges/SolidEdges3D';
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetSolidEdges3D } from './solidEdges3D';

export async function buildJsSolidEdges3DGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(dotNetObject.color)) {
        let { buildJsMapColor } = await import('./mapColor');
        properties.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.extensionLength)) {
        properties.extensionLength = dotNetObject.extensionLength;
    }
    if (hasValue(dotNetObject.size)) {
        properties.size = dotNetObject.size;
    }
    let jsSolidEdges3D = new SolidEdges3D(properties);
    
    let jsObjectRef = DotNet.createJSObjectReference(jsSolidEdges3D);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSolidEdges3D;
    
    return jsSolidEdges3D;
}


export async function buildDotNetSolidEdges3DGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetSolidEdges3D: any = {};
    
    if (hasValue(jsObject.color)) {
        let { buildDotNetMapColor } = await import('./mapColor');
        dotNetSolidEdges3D.color = buildDotNetMapColor(jsObject.color);
    }
    
    if (hasValue(jsObject.extensionLength)) {
        dotNetSolidEdges3D.extensionLength = jsObject.extensionLength;
    }
    
    if (hasValue(jsObject.size)) {
        dotNetSolidEdges3D.size = jsObject.size;
    }
    
    if (hasValue(jsObject.type)) {
        dotNetSolidEdges3D.type = jsObject.type;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetSolidEdges3D.id = geoBlazorId;
    }

    return dotNetSolidEdges3D;
}

