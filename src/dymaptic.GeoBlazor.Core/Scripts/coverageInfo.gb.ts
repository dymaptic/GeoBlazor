// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, removeCircularReferences } from './arcGisJsInterop';
import { buildDotNetCoverageInfo } from './coverageInfo';

export async function buildJsCoverageInfoGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsCoverageInfo: any = {};
    if (hasValue(dotNetObject.coverageDescription)) {
        jsCoverageInfo.coverageDescription = dotNetObject.coverageDescription;
    }
    if (hasValue(dotNetObject.lonLatEnvelope)) {
        let { buildJsExtent } = await import('./extent');
        jsCoverageInfo.lonLatEnvelope = buildJsExtent(dotNetObject.lonLatEnvelope) as any;
    }
    if (hasValue(dotNetObject.rasterInfo)) {
        let { buildJsRasterInfo } = await import('./rasterInfo');
        jsCoverageInfo.rasterInfo = await buildJsRasterInfo(dotNetObject.rasterInfo, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.bandNames) && dotNetObject.bandNames.length > 0) {
        jsCoverageInfo.bandNames = dotNetObject.bandNames;
    }
    if (hasValue(dotNetObject.coverageId)) {
        jsCoverageInfo.id = dotNetObject.coverageId;
    }
    if (hasValue(dotNetObject.description)) {
        jsCoverageInfo.description = dotNetObject.description;
    }
    if (hasValue(dotNetObject.supportedFormats) && dotNetObject.supportedFormats.length > 0) {
        jsCoverageInfo.supportedFormats = dotNetObject.supportedFormats;
    }
    if (hasValue(dotNetObject.supportedInterpolations) && dotNetObject.supportedInterpolations.length > 0) {
        jsCoverageInfo.supportedInterpolations = dotNetObject.supportedInterpolations;
    }
    if (hasValue(dotNetObject.title)) {
        jsCoverageInfo.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.useEPSGAxis)) {
        jsCoverageInfo.useEPSGAxis = dotNetObject.useEPSGAxis;
    }
    if (hasValue(dotNetObject.version)) {
        jsCoverageInfo.version = dotNetObject.version;
    }
    
    jsObjectRefs[dotNetObject.id] = jsCoverageInfo;
    arcGisObjectRefs[dotNetObject.id] = jsCoverageInfo;
    
    return jsCoverageInfo;
}


export async function buildDotNetCoverageInfoGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetCoverageInfo: any = {};
    
    if (hasValue(jsObject.lonLatEnvelope)) {
        let { buildDotNetExtent } = await import('./extent');
        dotNetCoverageInfo.lonLatEnvelope = buildDotNetExtent(jsObject.lonLatEnvelope);
    }
    
    if (hasValue(jsObject.rasterInfo)) {
        let { buildDotNetRasterInfo } = await import('./rasterInfo');
        dotNetCoverageInfo.rasterInfo = await buildDotNetRasterInfo(jsObject.rasterInfo);
    }
    
    if (hasValue(jsObject.bandNames)) {
        dotNetCoverageInfo.bandNames = jsObject.bandNames;
    }
    
    if (hasValue(jsObject.coverageDescription)) {
        dotNetCoverageInfo.coverageDescription = removeCircularReferences(jsObject.coverageDescription);
    }
    
    if (hasValue(jsObject.id)) {
        dotNetCoverageInfo.coverageId = jsObject.id;
    }
    
    if (hasValue(jsObject.description)) {
        dotNetCoverageInfo.description = jsObject.description;
    }
    
    if (hasValue(jsObject.supportedFormats)) {
        dotNetCoverageInfo.supportedFormats = jsObject.supportedFormats;
    }
    
    if (hasValue(jsObject.supportedInterpolations)) {
        dotNetCoverageInfo.supportedInterpolations = removeCircularReferences(jsObject.supportedInterpolations);
    }
    
    if (hasValue(jsObject.title)) {
        dotNetCoverageInfo.title = jsObject.title;
    }
    
    if (hasValue(jsObject.useEPSGAxis)) {
        dotNetCoverageInfo.useEPSGAxis = jsObject.useEPSGAxis;
    }
    
    if (hasValue(jsObject.version)) {
        dotNetCoverageInfo.version = removeCircularReferences(jsObject.version);
    }
    

    return dotNetCoverageInfo;
}

