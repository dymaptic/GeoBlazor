// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file


import SizeStop from '@arcgis/core/renderers/visualVariables/support/SizeStop';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class SizeStopGenerated implements IPropertyWrapper {
    public component: SizeStop;
    public readonly geoBlazorId: string = '';

    constructor(component: SizeStop) {
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
    
    getProperty(prop: string): any {
        return this.component[prop];
    }
    
    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
    }
}
export async function buildJsSizeStopGenerated(dotNetObject: any): Promise<any> {
    let { default: SizeStop } = await import('@arcgis/core/renderers/visualVariables/support/SizeStop');
    let jsSizeStop = new SizeStop();
    if (hasValue(dotNetObject.label)) {
        jsSizeStop.label = dotNetObject.label;
    }
    if (hasValue(dotNetObject.size)) {
        jsSizeStop.size = dotNetObject.size;
    }
    if (hasValue(dotNetObject.value)) {
        jsSizeStop.value = dotNetObject.value;
    }
    let { default: SizeStopWrapper } = await import('./sizeStop');
    let sizeStopWrapper = new SizeStopWrapper(jsSizeStop);
    jsSizeStop.id = dotNetObject.id;
    
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(sizeStopWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = sizeStopWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsSizeStop;
    
    return jsSizeStop;
}

export async function buildDotNetSizeStopGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetSizeStop: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
        dotNetSizeStop.label = jsObject.label;
        dotNetSizeStop.size = jsObject.size;
        dotNetSizeStop.value = jsObject.value;
    return dotNetSizeStop;
}

