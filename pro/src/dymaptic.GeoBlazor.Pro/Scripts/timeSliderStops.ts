import {hasValue} from './geoBlazorCore';

export async function buildJsTimeSliderStops(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }
    
    switch (dotNetObject.type) {
        case 'stops-by-dates':
            let {buildJsStopsByDates} = await import('./stopsByDates');
            return await buildJsStopsByDates(dotNetObject, layerId, viewId);
        case 'stops-by-count':
            let {buildJsStopsByCount} = await import('./stopsByCount');
            return await buildJsStopsByCount(dotNetObject, layerId, viewId);
        case 'stops-by-interval':
            let {buildJsStopsByInterval} = await import('./stopsByInterval');
            return await buildJsStopsByInterval(dotNetObject, layerId, viewId);
        default:
            return null;
    }
}

export async function buildDotNetTimeSliderStops(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetTimeSliderStops: any = {
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.dates)) {
        dotNetTimeSliderStops.type = 'stops-by-dates';
        dotNetTimeSliderStops.dates = jsObject.dates;
    } else if (hasValue(jsObject.count)) {
        dotNetTimeSliderStops.type = 'stops-by-count';
        dotNetTimeSliderStops.count = jsObject.count;
        let {buildDotNetTimeExtent} = await import('./timeExtent');
        dotNetTimeSliderStops.timeExtent = buildDotNetTimeExtent(jsObject.timeExtent);
    } else {
        dotNetTimeSliderStops.type = 'stops-by-interval';
        let {buildDotNetTimeInterval} = await import('./timeInterval');
        dotNetTimeSliderStops.interval = await buildDotNetTimeInterval(jsObject.interval);
        let {buildDotNetTimeExtent} = await import('./timeExtent');
        dotNetTimeSliderStops.timeExtent = buildDotNetTimeExtent(jsObject.timeExtent);
    }

    return dotNetTimeSliderStops;
}