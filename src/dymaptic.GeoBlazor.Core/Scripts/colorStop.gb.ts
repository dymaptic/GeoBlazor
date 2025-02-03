// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file


import ColorStop from '@arcgis/core/renderers/visualVariables/support/ColorStop';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class ColorStopGenerated implements IPropertyWrapper {
    public component: ColorStop;
    public readonly geoBlazorId: string = '';

    constructor(component: ColorStop) {
        this.component = component;
        // set all properties from component
        for (let prop in component) {
            if (component.hasOwnProperty(prop)) {
                this[prop] = component[prop];
            }
        }
    }
    
    // region methods
   
    unwrap() {
        return this.component;
    }
    
    // region properties
    
    async getColor(): Promise<any> {
        let { buildDotNetMapColor } = await import('./mapColor');
        return await buildDotNetMapColor(this.component.color);
    }
    async setColor(value: any): Promise<void> {
        let { buildJsMapColor } = await import('./mapColor');
        this.component.color = await buildJsMapColor(value);
    }
    getProperty(prop: string): any {
        return this.component[prop];
    }
    
    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
    }
}
export async function buildJsColorStopGenerated(dotNetObject: any): Promise<any> {
    let { default: ColorStop } = await import('@arcgis/core/renderers/visualVariables/support/ColorStop');
    let jsColorStop = new ColorStop();
    if (hasValue(dotNetObject.color)) {
        let { buildJsColor } = await import('./mapColor');
        jsColorStop.color = await buildJsColor(dotNetObject.color) as any;
    }
    if (hasValue(dotNetObject.label)) {
        jsColorStop.label = dotNetObject.label;
    }
    if (hasValue(dotNetObject.value)) {
        jsColorStop.value = dotNetObject.value;
    }
    let { default: ColorStopWrapper } = await import('./colorStop');
    let colorStopWrapper = new ColorStopWrapper(jsColorStop);
    jsColorStop.id = dotNetObject.id;
    
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(colorStopWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = colorStopWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsColorStop;
    
    return jsColorStop;
}

export async function buildDotNetColorStopGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetColorStop: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
        if (hasValue(jsObject.color)) {
            let { buildDotNetMapColor } = await import('./mapColor');
            dotNetColorStop.color = await buildDotNetMapColor(jsObject.color);
        }
        dotNetColorStop.label = jsObject.label;
        dotNetColorStop.value = jsObject.value;
    return dotNetColorStop;
}

