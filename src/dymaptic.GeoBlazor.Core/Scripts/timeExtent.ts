// override generated code in this file
import TimeExtentGenerated from './timeExtent.gb';
import TimeExtent from '@arcgis/core/TimeExtent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export default class TimeExtentWrapper extends TimeExtentGenerated {

    constructor(component: TimeExtent) {
        super(component);
    }

}

export async function buildJsTimeExtent(dotNetObject: any): Promise<any> {
    let properties: any = {};

    if (hasValue(dotNetObject.end)) {
        properties.end = dotNetObject.end;
    }
    if (hasValue(dotNetObject.start)) {
        properties.start = dotNetObject.start;
    }
    
    let jsTimeExtent = new TimeExtent(properties);

    let timeExtentWrapper = new TimeExtentWrapper(jsTimeExtent);
    timeExtentWrapper.geoBlazorId = dotNetObject.geoBlazorId;
    
    jsObjectRefs[dotNetObject.id] = timeExtentWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsTimeExtent;
    
    return jsTimeExtent;
}

export function buildDotNetTimeExtent(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetTimeExtent: any = {
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.end)) {
        dotNetTimeExtent.end = jsObject.end.toISOString();
    }
    if (hasValue(jsObject.start)) {
        dotNetTimeExtent.start = jsObject.start.toISOString();
    }

    return dotNetTimeExtent;
}
