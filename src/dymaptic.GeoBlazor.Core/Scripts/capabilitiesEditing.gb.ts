// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file


import CapabilitiesEditing = __esri.CapabilitiesEditing;
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class CapabilitiesEditingGenerated implements IPropertyWrapper {
    public component: CapabilitiesEditing;
    public readonly geoBlazorId: string = '';

    constructor(component: CapabilitiesEditing) {
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
export async function buildJsCapabilitiesEditingGenerated(dotNetObject: any): Promise<any> {
    let jsCapabilitiesEditing = {
        supportsDeleteByAnonymous: dotNetObject.supportsDeleteByAnonymous,
        supportsDeleteByOthers: dotNetObject.supportsDeleteByOthers,
        supportsGeometryUpdate: dotNetObject.supportsGeometryUpdate,
        supportsGlobalId: dotNetObject.supportsGlobalId,
        supportsRollbackOnFailure: dotNetObject.supportsRollbackOnFailure,
        supportsUpdateByAnonymous: dotNetObject.supportsUpdateByAnonymous,
        supportsUpdateByOthers: dotNetObject.supportsUpdateByOthers,
        supportsUpdateWithoutM: dotNetObject.supportsUpdateWithoutM,
        supportsUploadWithItemId: dotNetObject.supportsUploadWithItemId,
    }
    let { default: CapabilitiesEditingWrapper } = await import('./capabilitiesEditing');
    let capabilitiesEditingWrapper = new CapabilitiesEditingWrapper(jsCapabilitiesEditing);
    jsCapabilitiesEditing.id = dotNetObject.id;
    
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(capabilitiesEditingWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = capabilitiesEditingWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsCapabilitiesEditing;
    
    return jsCapabilitiesEditing;
}

export async function buildDotNetCapabilitiesEditingGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetCapabilitiesEditing: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
        dotNetCapabilitiesEditing.supportsDeleteByAnonymous = jsObject.supportsDeleteByAnonymous;
        dotNetCapabilitiesEditing.supportsDeleteByOthers = jsObject.supportsDeleteByOthers;
        dotNetCapabilitiesEditing.supportsGeometryUpdate = jsObject.supportsGeometryUpdate;
        dotNetCapabilitiesEditing.supportsGlobalId = jsObject.supportsGlobalId;
        dotNetCapabilitiesEditing.supportsRollbackOnFailure = jsObject.supportsRollbackOnFailure;
        dotNetCapabilitiesEditing.supportsUpdateByAnonymous = jsObject.supportsUpdateByAnonymous;
        dotNetCapabilitiesEditing.supportsUpdateByOthers = jsObject.supportsUpdateByOthers;
        dotNetCapabilitiesEditing.supportsUpdateWithoutM = jsObject.supportsUpdateWithoutM;
        dotNetCapabilitiesEditing.supportsUploadWithItemId = jsObject.supportsUploadWithItemId;
    return dotNetCapabilitiesEditing;
}

