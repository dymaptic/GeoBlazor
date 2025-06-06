// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue } from './arcGisJsInterop';
import { buildDotNetWebMapSaveAsOptions } from './webMapSaveAsOptions';

export async function buildJsWebMapSaveAsOptionsGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsWebMapSaveAsOptions: any = {};
    if (hasValue(dotNetObject.folder)) {
        let { buildJsPortalFolder } = await import('./portalFolder');
        jsWebMapSaveAsOptions.folder = await buildJsPortalFolder(dotNetObject.folder) as any;
    }

    if (hasValue(dotNetObject.ignoreUnsupported)) {
        jsWebMapSaveAsOptions.ignoreUnsupported = dotNetObject.ignoreUnsupported;
    }
    
    jsObjectRefs[dotNetObject.id] = jsWebMapSaveAsOptions;
    arcGisObjectRefs[dotNetObject.id] = jsWebMapSaveAsOptions;
    
    return jsWebMapSaveAsOptions;
}


export async function buildDotNetWebMapSaveAsOptionsGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetWebMapSaveAsOptions: any = {};
    
    if (hasValue(jsObject.folder)) {
        let { buildDotNetPortalFolder } = await import('./portalFolder');
        dotNetWebMapSaveAsOptions.folder = await buildDotNetPortalFolder(jsObject.folder);
    }
    
    if (hasValue(jsObject.ignoreUnsupported)) {
        dotNetWebMapSaveAsOptions.ignoreUnsupported = jsObject.ignoreUnsupported;
    }
    

    return dotNetWebMapSaveAsOptions;
}

