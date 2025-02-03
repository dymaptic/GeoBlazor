// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file


import CapabilitiesQueryTopFeatures = __esri.CapabilitiesQueryTopFeatures;
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class CapabilitiesQueryTopFeaturesGenerated implements IPropertyWrapper {
    public component: CapabilitiesQueryTopFeatures;
    public readonly geoBlazorId: string = '';

    constructor(component: CapabilitiesQueryTopFeatures) {
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
export async function buildJsCapabilitiesQueryTopFeaturesGenerated(dotNetObject: any): Promise<any> {
    let jsCapabilitiesQueryTopFeatures = {
        supportsCacheHint: dotNetObject.supportsCacheHint,
    }
    let { default: CapabilitiesQueryTopFeaturesWrapper } = await import('./capabilitiesQueryTopFeatures');
    let capabilitiesQueryTopFeaturesWrapper = new CapabilitiesQueryTopFeaturesWrapper(jsCapabilitiesQueryTopFeatures);
    jsCapabilitiesQueryTopFeatures.id = dotNetObject.id;
    
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(capabilitiesQueryTopFeaturesWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = capabilitiesQueryTopFeaturesWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsCapabilitiesQueryTopFeatures;
    
    return jsCapabilitiesQueryTopFeatures;
}

export async function buildDotNetCapabilitiesQueryTopFeaturesGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetCapabilitiesQueryTopFeatures: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
        dotNetCapabilitiesQueryTopFeatures.supportsCacheHint = jsObject.supportsCacheHint;
    return dotNetCapabilitiesQueryTopFeatures;
}

