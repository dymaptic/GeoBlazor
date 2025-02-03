// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file


import Capabilities = __esri.Capabilities;
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class CapabilitiesGenerated implements IPropertyWrapper {
    public component: Capabilities;
    public readonly geoBlazorId: string = '';

    constructor(component: Capabilities) {
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
    
    async getAnalytics(): Promise<any> {
        let { buildDotNetCapabilitiesAnalytics } = await import('./capabilitiesAnalytics');
        return await buildDotNetCapabilitiesAnalytics(this.component.analytics);
    }
    async setAnalytics(value: any): Promise<void> {
        let { buildJsCapabilitiesAnalytics } = await import('./capabilitiesAnalytics');
        this.component.analytics = await buildJsCapabilitiesAnalytics(value);
    }
    async getAttachment(): Promise<any> {
        let { buildDotNetCapabilitiesAttachment } = await import('./capabilitiesAttachment');
        return await buildDotNetCapabilitiesAttachment(this.component.attachment);
    }
    async setAttachment(value: any): Promise<void> {
        let { buildJsCapabilitiesAttachment } = await import('./capabilitiesAttachment');
        this.component.attachment = await buildJsCapabilitiesAttachment(value);
    }
    async getData(): Promise<any> {
        let { buildDotNetCapabilitiesData } = await import('./capabilitiesData');
        return await buildDotNetCapabilitiesData(this.component.data);
    }
    async setData(value: any): Promise<void> {
        let { buildJsCapabilitiesData } = await import('./capabilitiesData');
        this.component.data = await buildJsCapabilitiesData(value);
    }
    async getEditing(): Promise<any> {
        let { buildDotNetCapabilitiesEditing } = await import('./capabilitiesEditing');
        return await buildDotNetCapabilitiesEditing(this.component.editing);
    }
    async setEditing(value: any): Promise<void> {
        let { buildJsCapabilitiesEditing } = await import('./capabilitiesEditing');
        this.component.editing = await buildJsCapabilitiesEditing(value);
    }
    async getMetadata(): Promise<any> {
        let { buildDotNetCapabilitiesMetadata } = await import('./capabilitiesMetadata');
        return await buildDotNetCapabilitiesMetadata(this.component.metadata);
    }
    async setMetadata(value: any): Promise<void> {
        let { buildJsCapabilitiesMetadata } = await import('./capabilitiesMetadata');
        this.component.metadata = await buildJsCapabilitiesMetadata(value);
    }
    async getOperations(): Promise<any> {
        let { buildDotNetCapabilitiesOperations } = await import('./capabilitiesOperations');
        return await buildDotNetCapabilitiesOperations(this.component.operations);
    }
    async setOperations(value: any): Promise<void> {
        let { buildJsCapabilitiesOperations } = await import('./capabilitiesOperations');
        this.component.operations = await buildJsCapabilitiesOperations(value);
    }
    async getQueryRelated(): Promise<any> {
        let { buildDotNetCapabilitiesQueryRelated } = await import('./capabilitiesQueryRelated');
        return await buildDotNetCapabilitiesQueryRelated(this.component.queryRelated);
    }
    async setQueryRelated(value: any): Promise<void> {
        let { buildJsCapabilitiesQueryRelated } = await import('./capabilitiesQueryRelated');
        this.component.queryRelated = await buildJsCapabilitiesQueryRelated(value);
    }
    async getQueryTopFeatures(): Promise<any> {
        let { buildDotNetCapabilitiesQueryTopFeatures } = await import('./capabilitiesQueryTopFeatures');
        return await buildDotNetCapabilitiesQueryTopFeatures(this.component.queryTopFeatures);
    }
    async setQueryTopFeatures(value: any): Promise<void> {
        let { buildJsCapabilitiesQueryTopFeatures } = await import('./capabilitiesQueryTopFeatures');
        this.component.queryTopFeatures = await buildJsCapabilitiesQueryTopFeatures(value);
    }
    getProperty(prop: string): any {
        return this.component[prop];
    }
    
    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
    }
}
export async function buildJsCapabilitiesGenerated(dotNetObject: any): Promise<any> {
    let jsCapabilities = {
    if (hasValue(dotNetObject.analytics)) {
        let { buildJsCapabilitiesAnalytics } = await import('capabilitiesAnalytics');
        jsCapabilities.analytics = await buildJsCapabilitiesAnalytics(dotNetObject.analytics) as any;

    }
    if (hasValue(dotNetObject.attachment)) {
        let { buildJsCapabilitiesAttachment } = await import('capabilitiesAttachment');
        jsCapabilities.attachment = await buildJsCapabilitiesAttachment(dotNetObject.attachment) as any;

    }
    if (hasValue(dotNetObject.data)) {
        let { buildJsCapabilitiesData } = await import('capabilitiesData');
        jsCapabilities.data = await buildJsCapabilitiesData(dotNetObject.data) as any;

    }
    if (hasValue(dotNetObject.editing)) {
        let { buildJsCapabilitiesEditing } = await import('capabilitiesEditing');
        jsCapabilities.editing = await buildJsCapabilitiesEditing(dotNetObject.editing) as any;

    }
    if (hasValue(dotNetObject.metadata)) {
        let { buildJsCapabilitiesMetadata } = await import('capabilitiesMetadata');
        jsCapabilities.metadata = await buildJsCapabilitiesMetadata(dotNetObject.metadata) as any;

    }
    if (hasValue(dotNetObject.operations)) {
        let { buildJsCapabilitiesOperations } = await import('capabilitiesOperations');
        jsCapabilities.operations = await buildJsCapabilitiesOperations(dotNetObject.operations) as any;

    }
    if (hasValue(dotNetObject.queryRelated)) {
        let { buildJsCapabilitiesQueryRelated } = await import('capabilitiesQueryRelated');
        jsCapabilities.queryRelated = await buildJsCapabilitiesQueryRelated(dotNetObject.queryRelated) as any;

    }
    if (hasValue(dotNetObject.queryTopFeatures)) {
        let { buildJsCapabilitiesQueryTopFeatures } = await import('capabilitiesQueryTopFeatures');
        jsCapabilities.queryTopFeatures = await buildJsCapabilitiesQueryTopFeatures(dotNetObject.queryTopFeatures) as any;

    }
        query: dotNetObject.query,
    }
    let { default: CapabilitiesWrapper } = await import('./capabilities');
    let capabilitiesWrapper = new CapabilitiesWrapper(jsCapabilities);
    jsCapabilities.id = dotNetObject.id;
    
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(capabilitiesWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = capabilitiesWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsCapabilities;
    
    return jsCapabilities;
}

export async function buildDotNetCapabilitiesGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetCapabilities: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
        if (hasValue(jsObject.analytics)) {
            let { buildDotNetCapabilitiesAnalytics } = await import('./capabilitiesAnalytics');
            dotNetCapabilities.analytics = await buildDotNetCapabilitiesAnalytics(jsObject.analytics);
        }
        if (hasValue(jsObject.attachment)) {
            let { buildDotNetCapabilitiesAttachment } = await import('./capabilitiesAttachment');
            dotNetCapabilities.attachment = await buildDotNetCapabilitiesAttachment(jsObject.attachment);
        }
        if (hasValue(jsObject.data)) {
            let { buildDotNetCapabilitiesData } = await import('./capabilitiesData');
            dotNetCapabilities.data = await buildDotNetCapabilitiesData(jsObject.data);
        }
        if (hasValue(jsObject.editing)) {
            let { buildDotNetCapabilitiesEditing } = await import('./capabilitiesEditing');
            dotNetCapabilities.editing = await buildDotNetCapabilitiesEditing(jsObject.editing);
        }
        if (hasValue(jsObject.metadata)) {
            let { buildDotNetCapabilitiesMetadata } = await import('./capabilitiesMetadata');
            dotNetCapabilities.metadata = await buildDotNetCapabilitiesMetadata(jsObject.metadata);
        }
        if (hasValue(jsObject.operations)) {
            let { buildDotNetCapabilitiesOperations } = await import('./capabilitiesOperations');
            dotNetCapabilities.operations = await buildDotNetCapabilitiesOperations(jsObject.operations);
        }
        if (hasValue(jsObject.queryRelated)) {
            let { buildDotNetCapabilitiesQueryRelated } = await import('./capabilitiesQueryRelated');
            dotNetCapabilities.queryRelated = await buildDotNetCapabilitiesQueryRelated(jsObject.queryRelated);
        }
        if (hasValue(jsObject.queryTopFeatures)) {
            let { buildDotNetCapabilitiesQueryTopFeatures } = await import('./capabilitiesQueryTopFeatures');
            dotNetCapabilities.queryTopFeatures = await buildDotNetCapabilitiesQueryTopFeatures(jsObject.queryTopFeatures);
        }
        dotNetCapabilities.query = jsObject.query;
    return dotNetCapabilities;
}

