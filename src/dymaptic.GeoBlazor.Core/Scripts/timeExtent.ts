// override generated code in this file
import TimeExtentGenerated from './timeExtent.gb';
import TimeExtent from '@arcgis/core/TimeExtent';
import {hasValue} from "./arcGisJsInterop";

export default class TimeExtentWrapper extends TimeExtentGenerated {

    constructor(component: TimeExtent) {
        super(component);
    }

}

export async function buildJsTimeExtent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTimeExtentGenerated} = await import('./timeExtent.gb');
    return await buildJsTimeExtentGenerated(dotNetObject, layerId, viewId);
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
