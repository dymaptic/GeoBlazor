// override generated code in this file

import {hasValue} from "./arcGisJsInterop";

export async function buildJsRasterInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRasterInfoGenerated} = await import('./rasterInfo.gb');
    return await buildJsRasterInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRasterInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetRasterInfoGenerated} = await import('./rasterInfo.gb');
    let dotNetRasterInfo = await buildDotNetRasterInfoGenerated(jsObject, layerId, viewId);
    if (hasValue(jsObject.attributeTable)) {
        let { buildDotNetFeatureSet } = await import('./featureSet');
        dotNetRasterInfo.attributeTable = await buildDotNetFeatureSet(jsObject.attributeTable, null, null);
    }
    
    return dotNetRasterInfo;
}
