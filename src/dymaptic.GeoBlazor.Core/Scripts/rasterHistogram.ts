import {hasValue} from "./arcGisJsInterop";

export function buildJsRasterHistogram(dotNetObject: any): any {
    if (!hasValue(dotNetObject)) {
        return null;
    }
    
    let jsRasterHistogram: any = {};
    if (hasValue(dotNetObject.counts) && dotNetObject.counts.length > 0) {
        jsRasterHistogram.counts = dotNetObject.counts;
    } else if (hasValue(dotNetObject.byteCounts) && dotNetObject.byteCounts.length > 0) {
        jsRasterHistogram.counts = dotNetObject.byteCounts;
    }
    
    if (hasValue(dotNetObject.max)) {
        jsRasterHistogram.max = dotNetObject.max;
    }
    
    if (hasValue(dotNetObject.min)) {
        jsRasterHistogram.min = dotNetObject.min;
    }
    
    if (hasValue(dotNetObject.size)) {
        jsRasterHistogram.size = dotNetObject.size;
    }
    
    return jsRasterHistogram;
}

export function buildDotNetRasterHistogram(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetRasterHistogram: any = {};
    
    if (hasValue(jsObject.counts)) {
        if (jsObject.counts instanceof Uint8Array) {
            dotNetRasterHistogram.byteCounts = jsObject.counts;
        } else {
            dotNetRasterHistogram.counts = jsObject.counts;
        }
    }
    
    if (hasValue(jsObject.max)) {
        dotNetRasterHistogram.max = jsObject.max;
    }
    
    if (hasValue(jsObject.min)) {
        dotNetRasterHistogram.min = jsObject.min;
    }
    
    if (hasValue(jsObject.size)) {
        dotNetRasterHistogram.size = jsObject.size;
    }
    
    return dotNetRasterHistogram;
}
