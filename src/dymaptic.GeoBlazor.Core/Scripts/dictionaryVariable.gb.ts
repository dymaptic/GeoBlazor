// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetDictionaryVariable } from './dictionaryVariable';

export async function buildJsDictionaryVariableGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsDictionaryVariable: any = {};
    if (hasValue(dotNetObject.properties) && dotNetObject.properties.length > 0) {
        let { buildJsIProfileVariable } = await import('./iProfileVariable');
        jsDictionaryVariable.properties = dotNetObject.properties.map(i => buildJsIProfileVariable(i)) as any;
    }

    if (hasValue(dotNetObject.name)) {
        jsDictionaryVariable.name = dotNetObject.name;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsDictionaryVariable);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsDictionaryVariable;
    
    return jsDictionaryVariable;
}


export async function buildDotNetDictionaryVariableGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetDictionaryVariable: any = {};
    
    if (hasValue(jsObject.properties)) {
        let { buildDotNetIProfileVariable } = await import('./iProfileVariable');
        dotNetDictionaryVariable.properties = jsObject.properties.map(i => buildDotNetIProfileVariable(i));
    }
    
    if (hasValue(jsObject.name)) {
        dotNetDictionaryVariable.name = jsObject.name;
    }
    
    if (hasValue(jsObject.type)) {
        dotNetDictionaryVariable.type = jsObject.type;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetDictionaryVariable.id = geoBlazorId;
    }

    return dotNetDictionaryVariable;
}

