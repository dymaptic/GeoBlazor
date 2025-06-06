// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue } from './arcGisJsInterop';
import { buildDotNetRasterSliceValue } from './rasterSliceValue';

export async function buildJsRasterSliceValueGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsRasterSliceValue: any = {};
    if (hasValue(dotNetObject.multidimensionalDefinition) && dotNetObject.multidimensionalDefinition.length > 0) {
        let { buildJsDimensionalDefinition } = await import('./dimensionalDefinition');
        jsRasterSliceValue.multidimensionalDefinition = await Promise.all(dotNetObject.multidimensionalDefinition.map(async i => await buildJsDimensionalDefinition(i))) as any;
    }

    if (hasValue(dotNetObject.magdirValue) && dotNetObject.magdirValue.length > 0) {
        jsRasterSliceValue.magdirValue = dotNetObject.magdirValue;
    }
    if (hasValue(dotNetObject.value) && dotNetObject.value.length > 0) {
        jsRasterSliceValue.value = dotNetObject.value;
    }
    
    jsObjectRefs[dotNetObject.id] = jsRasterSliceValue;
    arcGisObjectRefs[dotNetObject.id] = jsRasterSliceValue;
    
    return jsRasterSliceValue;
}


export async function buildDotNetRasterSliceValueGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetRasterSliceValue: any = {};
    
    if (hasValue(jsObject.multidimensionalDefinition)) {
        let { buildDotNetDimensionalDefinition } = await import('./dimensionalDefinition');
        dotNetRasterSliceValue.multidimensionalDefinition = await Promise.all(jsObject.multidimensionalDefinition.map(async i => await buildDotNetDimensionalDefinition(i)));
    }
    
    if (hasValue(jsObject.magdirValue)) {
        dotNetRasterSliceValue.magdirValue = jsObject.magdirValue;
    }
    
    if (hasValue(jsObject.value)) {
        dotNetRasterSliceValue.value = jsObject.value;
    }
    

    return dotNetRasterSliceValue;
}

