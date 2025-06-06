// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue } from './arcGisJsInterop';
import { buildDotNetIMeshComponentMaterial } from './iMeshComponentMaterial';

export async function buildJsIMeshComponentMaterialGenerated(dotNetObject: any): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsMeshComponentMaterial: any = {};

    
    jsObjectRefs[dotNetObject.id] = jsMeshComponentMaterial;
    arcGisObjectRefs[dotNetObject.id] = jsMeshComponentMaterial;
    
    return jsMeshComponentMaterial;
}


export async function buildDotNetIMeshComponentMaterialGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetIMeshComponentMaterial: any = {};
    

    return dotNetIMeshComponentMaterial;
}

