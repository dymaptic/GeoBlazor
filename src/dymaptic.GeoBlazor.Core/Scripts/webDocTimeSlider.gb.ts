// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import TimeSlider from '@arcgis/core/webdoc/widgets/TimeSlider';
import { arcGisObjectRefs, jsObjectRefs, hasValue } from './arcGisJsInterop';
import { buildDotNetWebDocTimeSlider } from './webDocTimeSlider';

export async function buildJsWebDocTimeSliderGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(dotNetObject.currentTimeExtent)) {
        let { buildJsTimeExtent } = await import('./timeExtent');
        properties.currentTimeExtent = await buildJsTimeExtent(dotNetObject.currentTimeExtent) as any;
    }
    if (hasValue(dotNetObject.fullTimeExtent)) {
        let { buildJsTimeExtent } = await import('./timeExtent');
        properties.fullTimeExtent = await buildJsTimeExtent(dotNetObject.fullTimeExtent) as any;
    }
    if (hasValue(dotNetObject.stopInterval)) {
        let { buildJsTimeInterval } = await import('./timeInterval');
        properties.stopInterval = await buildJsTimeInterval(dotNetObject.stopInterval) as any;
    }

    if (hasValue(dotNetObject.loop)) {
        properties.loop = dotNetObject.loop;
    }
    if (hasValue(dotNetObject.numStops)) {
        properties.numStops = dotNetObject.numStops;
    }
    if (hasValue(dotNetObject.numThumbs)) {
        properties.numThumbs = dotNetObject.numThumbs;
    }
    if (hasValue(dotNetObject.stopDelay)) {
        properties.stopDelay = dotNetObject.stopDelay;
    }
    if (hasValue(dotNetObject.stops) && dotNetObject.stops.length > 0) {
        properties.stops = dotNetObject.stops;
    }
    let jsTimeSlider = new TimeSlider(properties);
    
    jsObjectRefs[dotNetObject.id] = jsTimeSlider;
    arcGisObjectRefs[dotNetObject.id] = jsTimeSlider;
    
    return jsTimeSlider;
}


export async function buildDotNetWebDocTimeSliderGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetWebDocTimeSlider: any = {};
    
    if (hasValue(jsObject.currentTimeExtent)) {
        let { buildDotNetTimeExtent } = await import('./timeExtent');
        dotNetWebDocTimeSlider.currentTimeExtent = buildDotNetTimeExtent(jsObject.currentTimeExtent);
    }
    
    if (hasValue(jsObject.fullTimeExtent)) {
        let { buildDotNetTimeExtent } = await import('./timeExtent');
        dotNetWebDocTimeSlider.fullTimeExtent = buildDotNetTimeExtent(jsObject.fullTimeExtent);
    }
    
    if (hasValue(jsObject.stopInterval)) {
        let { buildDotNetTimeInterval } = await import('./timeInterval');
        dotNetWebDocTimeSlider.stopInterval = await buildDotNetTimeInterval(jsObject.stopInterval);
    }
    
    if (hasValue(jsObject.loop)) {
        dotNetWebDocTimeSlider.loop = jsObject.loop;
    }
    
    if (hasValue(jsObject.numStops)) {
        dotNetWebDocTimeSlider.numStops = jsObject.numStops;
    }
    
    if (hasValue(jsObject.numThumbs)) {
        dotNetWebDocTimeSlider.numThumbs = jsObject.numThumbs;
    }
    
    if (hasValue(jsObject.stopDelay)) {
        dotNetWebDocTimeSlider.stopDelay = jsObject.stopDelay;
    }
    
    if (hasValue(jsObject.stops)) {
        dotNetWebDocTimeSlider.stops = jsObject.stops;
    }
    

    return dotNetWebDocTimeSlider;
}

