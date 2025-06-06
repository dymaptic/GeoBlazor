// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetCapabilitiesQueryAttributeBinsSupportedStatistics } from './capabilitiesQueryAttributeBinsSupportedStatistics';

export async function buildJsCapabilitiesQueryAttributeBinsSupportedStatisticsGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsCapabilitiesQueryAttributeBinsSupportedStatistics: any = {};

    if (hasValue(dotNetObject.avg)) {
        jsCapabilitiesQueryAttributeBinsSupportedStatistics.avg = dotNetObject.avg;
    }
    if (hasValue(dotNetObject.count)) {
        jsCapabilitiesQueryAttributeBinsSupportedStatistics.count = dotNetObject.count;
    }
    if (hasValue(dotNetObject.max)) {
        jsCapabilitiesQueryAttributeBinsSupportedStatistics.max = dotNetObject.max;
    }
    if (hasValue(dotNetObject.min)) {
        jsCapabilitiesQueryAttributeBinsSupportedStatistics.min = dotNetObject.min;
    }
    if (hasValue(dotNetObject.percentileContinuous)) {
        jsCapabilitiesQueryAttributeBinsSupportedStatistics.percentileContinuous = dotNetObject.percentileContinuous;
    }
    if (hasValue(dotNetObject.percentileDiscrete)) {
        jsCapabilitiesQueryAttributeBinsSupportedStatistics.percentileDiscrete = dotNetObject.percentileDiscrete;
    }
    if (hasValue(dotNetObject.stddev)) {
        jsCapabilitiesQueryAttributeBinsSupportedStatistics.stddev = dotNetObject.stddev;
    }
    if (hasValue(dotNetObject.sum)) {
        jsCapabilitiesQueryAttributeBinsSupportedStatistics.sum = dotNetObject.sum;
    }
    if (hasValue(dotNetObject.var)) {
        jsCapabilitiesQueryAttributeBinsSupportedStatistics.var = dotNetObject.var;
    }
    
    jsObjectRefs[dotNetObject.id] = jsCapabilitiesQueryAttributeBinsSupportedStatistics;
    arcGisObjectRefs[dotNetObject.id] = jsCapabilitiesQueryAttributeBinsSupportedStatistics;
    
    return jsCapabilitiesQueryAttributeBinsSupportedStatistics;
}


export async function buildDotNetCapabilitiesQueryAttributeBinsSupportedStatisticsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetCapabilitiesQueryAttributeBinsSupportedStatistics: any = {};
    
    if (hasValue(jsObject.avg)) {
        dotNetCapabilitiesQueryAttributeBinsSupportedStatistics.avg = jsObject.avg;
    }
    
    if (hasValue(jsObject.count)) {
        dotNetCapabilitiesQueryAttributeBinsSupportedStatistics.count = jsObject.count;
    }
    
    if (hasValue(jsObject.max)) {
        dotNetCapabilitiesQueryAttributeBinsSupportedStatistics.max = jsObject.max;
    }
    
    if (hasValue(jsObject.min)) {
        dotNetCapabilitiesQueryAttributeBinsSupportedStatistics.min = jsObject.min;
    }
    
    if (hasValue(jsObject.percentileContinuous)) {
        dotNetCapabilitiesQueryAttributeBinsSupportedStatistics.percentileContinuous = jsObject.percentileContinuous;
    }
    
    if (hasValue(jsObject.percentileDiscrete)) {
        dotNetCapabilitiesQueryAttributeBinsSupportedStatistics.percentileDiscrete = jsObject.percentileDiscrete;
    }
    
    if (hasValue(jsObject.stddev)) {
        dotNetCapabilitiesQueryAttributeBinsSupportedStatistics.stddev = jsObject.stddev;
    }
    
    if (hasValue(jsObject.sum)) {
        dotNetCapabilitiesQueryAttributeBinsSupportedStatistics.sum = jsObject.sum;
    }
    
    if (hasValue(jsObject.var)) {
        dotNetCapabilitiesQueryAttributeBinsSupportedStatistics.var = jsObject.var;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetCapabilitiesQueryAttributeBinsSupportedStatistics.id = geoBlazorId;
    }

    return dotNetCapabilitiesQueryAttributeBinsSupportedStatistics;
}

