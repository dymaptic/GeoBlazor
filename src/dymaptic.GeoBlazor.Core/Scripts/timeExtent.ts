// override generated code in this file
import TimeExtent from '@arcgis/core/time/TimeExtent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {IPropertyWrapper} from "./definitions"

export default class TimeExtentWrapper implements IPropertyWrapper {
    public component: TimeExtent;
    public geoBlazorId: string | null = null;
    public viewId: string | null = null;
    public layerId: string | null = null;

    constructor(component: TimeExtent) {
        this.component = component;
    }

    // region methods

    unwrap() {
        return this.component;
    }


    async updateComponent(dotNetObject: any): Promise<void> {

        if (hasValue(dotNetObject.end)) {
            this.component.end = dotNetObject.end;
        }
        if (hasValue(dotNetObject.start)) {
            this.component.start = dotNetObject.start;
        }
    }

    async intersection(timeExtent: any): Promise<any> {
        let { buildJsTimeExtent } = await import('./timeExtent');
        let jsTimeExtent = await buildJsTimeExtent(timeExtent) as any;
        // @ts-ignore This method does exist
        let result = this.component.intersection(jsTimeExtent);
        let { buildDotNetTimeExtent } = await import('./timeExtent');
        return buildDotNetTimeExtent(result);
    }

    async union(timeExtent: any): Promise<any> {
        let { buildJsTimeExtent } = await import('./timeExtent');
        let jsTimeExtent = await buildJsTimeExtent(timeExtent) as any;
        // @ts-ignore This method does exist
        let result = this.component.union(jsTimeExtent);
        let { buildDotNetTimeExtent } = await import('./timeExtent');
        return buildDotNetTimeExtent(result);
    }

    // region properties

    getProperty(prop: string): any {
        return this.component[prop];
    }

    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
    }
}

export async function buildJsTimeExtent(dotNetObject: any, viewId: string | null): Promise<any> {
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

export function buildDotNetTimeExtent(jsObject: any, viewId: string | null): any {
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
