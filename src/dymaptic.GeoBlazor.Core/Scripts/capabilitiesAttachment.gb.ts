// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file


import CapabilitiesAttachment = __esri.CapabilitiesAttachment;
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class CapabilitiesAttachmentGenerated implements IPropertyWrapper {
    public component: CapabilitiesAttachment;
    public readonly geoBlazorId: string = '';

    constructor(component: CapabilitiesAttachment) {
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
export async function buildJsCapabilitiesAttachmentGenerated(dotNetObject: any): Promise<any> {
    let jsCapabilitiesAttachment = {
        supportsCacheHint: dotNetObject.supportsCacheHint,
        supportsContentType: dotNetObject.supportsContentType,
        supportsExifInfo: dotNetObject.supportsExifInfo,
        supportsKeywords: dotNetObject.supportsKeywords,
        supportsName: dotNetObject.supportsName,
        supportsResize: dotNetObject.supportsResize,
        supportsSize: dotNetObject.supportsSize,
    }
    let { default: CapabilitiesAttachmentWrapper } = await import('./capabilitiesAttachment');
    let capabilitiesAttachmentWrapper = new CapabilitiesAttachmentWrapper(jsCapabilitiesAttachment);
    jsCapabilitiesAttachment.id = dotNetObject.id;
    
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(capabilitiesAttachmentWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = capabilitiesAttachmentWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsCapabilitiesAttachment;
    
    return jsCapabilitiesAttachment;
}

export async function buildDotNetCapabilitiesAttachmentGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetCapabilitiesAttachment: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
        dotNetCapabilitiesAttachment.supportsCacheHint = jsObject.supportsCacheHint;
        dotNetCapabilitiesAttachment.supportsContentType = jsObject.supportsContentType;
        dotNetCapabilitiesAttachment.supportsExifInfo = jsObject.supportsExifInfo;
        dotNetCapabilitiesAttachment.supportsKeywords = jsObject.supportsKeywords;
        dotNetCapabilitiesAttachment.supportsName = jsObject.supportsName;
        dotNetCapabilitiesAttachment.supportsResize = jsObject.supportsResize;
        dotNetCapabilitiesAttachment.supportsSize = jsObject.supportsSize;
    return dotNetCapabilitiesAttachment;
}

