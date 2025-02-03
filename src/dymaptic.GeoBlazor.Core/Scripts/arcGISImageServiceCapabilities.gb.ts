// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file


import ArcGISImageServiceCapabilities = __esri.ArcGISImageServiceCapabilities;
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class ArcGISImageServiceCapabilitiesGenerated implements IPropertyWrapper {
    public component: ArcGISImageServiceCapabilities;
    public readonly geoBlazorId: string = '';

    constructor(component: ArcGISImageServiceCapabilities) {
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
    
    async getMensuration(): Promise<any> {
        let { buildDotNetArcGISImageServiceCapabilitiesMensuration } = await import('./arcGISImageServiceCapabilitiesMensuration');
        return await buildDotNetArcGISImageServiceCapabilitiesMensuration(this.component.mensuration);
    }
    async setMensuration(value: any): Promise<void> {
        let { buildJsArcGISImageServiceCapabilitiesMensuration } = await import('./arcGISImageServiceCapabilitiesMensuration');
        this.component.mensuration = await buildJsArcGISImageServiceCapabilitiesMensuration(value);
    }
    async getOperations(): Promise<any> {
        let { buildDotNetArcGISImageServiceCapabilitiesOperations } = await import('./arcGISImageServiceCapabilitiesOperations');
        return await buildDotNetArcGISImageServiceCapabilitiesOperations(this.component.operations);
    }
    async setOperations(value: any): Promise<void> {
        let { buildJsArcGISImageServiceCapabilitiesOperations } = await import('./arcGISImageServiceCapabilitiesOperations');
        this.component.operations = await buildJsArcGISImageServiceCapabilitiesOperations(value);
    }
    getProperty(prop: string): any {
        return this.component[prop];
    }
    
    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
    }
}
export async function buildJsArcGISImageServiceCapabilitiesGenerated(dotNetObject: any): Promise<any> {
    let jsArcGISImageServiceCapabilities = {
    if (hasValue(dotNetObject.mensuration)) {
        let { buildJsArcGISImageServiceCapabilitiesMensuration } = await import('arcGISImageServiceCapabilitiesMensuration');
        jsArcGISImageServiceCapabilities.mensuration = await buildJsArcGISImageServiceCapabilitiesMensuration(dotNetObject.mensuration) as any;

    }
    if (hasValue(dotNetObject.operations)) {
        let { buildJsArcGISImageServiceCapabilitiesOperations } = await import('arcGISImageServiceCapabilitiesOperations');
        jsArcGISImageServiceCapabilities.operations = await buildJsArcGISImageServiceCapabilitiesOperations(dotNetObject.operations) as any;

    }
        query: dotNetObject.query,
    }
    let { default: ArcGISImageServiceCapabilitiesWrapper } = await import('./arcGISImageServiceCapabilities');
    let arcGISImageServiceCapabilitiesWrapper = new ArcGISImageServiceCapabilitiesWrapper(jsArcGISImageServiceCapabilities);
    jsArcGISImageServiceCapabilities.id = dotNetObject.id;
    
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(arcGISImageServiceCapabilitiesWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = arcGISImageServiceCapabilitiesWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsArcGISImageServiceCapabilities;
    
    return jsArcGISImageServiceCapabilities;
}

export async function buildDotNetArcGISImageServiceCapabilitiesGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetArcGISImageServiceCapabilities: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
        if (hasValue(jsObject.mensuration)) {
            let { buildDotNetArcGISImageServiceCapabilitiesMensuration } = await import('./arcGISImageServiceCapabilitiesMensuration');
            dotNetArcGISImageServiceCapabilities.mensuration = await buildDotNetArcGISImageServiceCapabilitiesMensuration(jsObject.mensuration);
        }
        if (hasValue(jsObject.operations)) {
            let { buildDotNetArcGISImageServiceCapabilitiesOperations } = await import('./arcGISImageServiceCapabilitiesOperations');
            dotNetArcGISImageServiceCapabilities.operations = await buildDotNetArcGISImageServiceCapabilitiesOperations(jsObject.operations);
        }
        dotNetArcGISImageServiceCapabilities.query = jsObject.query;
    return dotNetArcGISImageServiceCapabilities;
}

