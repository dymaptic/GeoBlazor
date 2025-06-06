// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue } from './arcGisJsInterop';
import { buildDotNetElevationQueryResult } from './elevationQueryResult';

export async function buildJsElevationQueryResultGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsElevationQueryResult: any = {};
    if (hasValue(dotNetObject.geometry)) {
        let { buildJsGeometry } = await import('./geometry');
        jsElevationQueryResult.geometry = buildJsGeometry(dotNetObject.geometry) as any;
    }
    if (hasValue(dotNetObject.sampleInfo) && dotNetObject.sampleInfo.length > 0) {
        let { buildJsElevationQueryResultSampleInfo } = await import('./elevationQueryResultSampleInfo');
        jsElevationQueryResult.sampleInfo = await Promise.all(dotNetObject.sampleInfo.map(async i => await buildJsElevationQueryResultSampleInfo(i, layerId, viewId))) as any;
    }

    if (hasValue(dotNetObject.noDataValue)) {
        jsElevationQueryResult.noDataValue = dotNetObject.noDataValue;
    }
    
    jsObjectRefs[dotNetObject.id] = jsElevationQueryResult;
    arcGisObjectRefs[dotNetObject.id] = jsElevationQueryResult;
    
    return jsElevationQueryResult;
}


export async function buildDotNetElevationQueryResultGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetElevationQueryResult: any = {};
    
    if (hasValue(jsObject.geometry)) {
        let { buildDotNetGeometry } = await import('./geometry');
        dotNetElevationQueryResult.geometry = buildDotNetGeometry(jsObject.geometry);
    }
    
    if (hasValue(jsObject.sampleInfo)) {
        let { buildDotNetElevationQueryResultSampleInfo } = await import('./elevationQueryResultSampleInfo');
        dotNetElevationQueryResult.sampleInfo = await Promise.all(jsObject.sampleInfo.map(async i => await buildDotNetElevationQueryResultSampleInfo(i)));
    }
    
    if (hasValue(jsObject.noDataValue)) {
        dotNetElevationQueryResult.noDataValue = jsObject.noDataValue;
    }
    

    return dotNetElevationQueryResult;
}

