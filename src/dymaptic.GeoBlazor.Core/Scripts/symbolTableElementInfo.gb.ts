// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, generateSerializableJson } from './arcGisJsInterop';
import { buildDotNetSymbolTableElementInfo } from './symbolTableElementInfo';

export async function buildJsSymbolTableElementInfoGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsSymbolTableElementInfo: any = {};
    if (hasValue(dotNetObject.symbol)) {
        let { buildJsSymbol } = await import('./symbol');
        jsSymbolTableElementInfo.symbol = buildJsSymbol(dotNetObject.symbol) as any;
    }

    if (hasValue(dotNetObject.label)) {
        jsSymbolTableElementInfo.label = dotNetObject.label;
    }
    if (hasValue(dotNetObject.preview)) {
        jsSymbolTableElementInfo.preview = dotNetObject.preview;
    }
    if (hasValue(dotNetObject.size)) {
        jsSymbolTableElementInfo.size = dotNetObject.size;
    }
    if (hasValue(dotNetObject.value)) {
        jsSymbolTableElementInfo.value = JSON.parse(dotNetObject.value);
    }
    
    jsObjectRefs[dotNetObject.id] = jsSymbolTableElementInfo;
    arcGisObjectRefs[dotNetObject.id] = jsSymbolTableElementInfo;
    
    return jsSymbolTableElementInfo;
}


export async function buildDotNetSymbolTableElementInfoGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetSymbolTableElementInfo: any = {};
    
    if (hasValue(jsObject.symbol)) {
        let { buildDotNetSymbol } = await import('./symbol');
        dotNetSymbolTableElementInfo.symbol = buildDotNetSymbol(jsObject.symbol);
    }
    
    if (hasValue(jsObject.label)) {
        dotNetSymbolTableElementInfo.label = jsObject.label;
    }
    
    if (hasValue(jsObject.preview)) {
        dotNetSymbolTableElementInfo.preview = jsObject.preview;
    }
    
    if (hasValue(jsObject.size)) {
        dotNetSymbolTableElementInfo.size = jsObject.size;
    }
    
    if (hasValue(jsObject.value)) {
        dotNetSymbolTableElementInfo.value = generateSerializableJson(jsObject.value);
    }
    

    return dotNetSymbolTableElementInfo;
}

