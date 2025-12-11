// override generated code in this file

import {hasValue} from './geoBlazorCore';

export async function buildJsRasterInfo(dotNetObject: any): Promise<any> {
    let {buildJsRasterInfoGenerated} = await import('./rasterInfo.gb');
    return await buildJsRasterInfoGenerated(dotNetObject);
}

export async function buildDotNetRasterInfo(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetRasterInfoGenerated} = await import('./rasterInfo.gb');
    let dotNetRasterInfo = await buildDotNetRasterInfoGenerated(jsObject, viewId);
    if (hasValue(jsObject.attributeTable)) {
        let { buildDotNetFeatureSet } = await import('./featureSet');
        dotNetRasterInfo.attributeTable = await buildDotNetFeatureSet(jsObject.attributeTable, null, null);
    }
    
    return dotNetRasterInfo;
}
