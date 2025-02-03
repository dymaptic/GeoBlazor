// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file


import LayerOptions from '@arcgis/core/popup/LayerOptions';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class LayerOptionsGenerated implements IPropertyWrapper {
    public component: LayerOptions;
    public readonly geoBlazorId: string = '';

    constructor(component: LayerOptions) {
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
export async function buildJsLayerOptionsGenerated(dotNetObject: any): Promise<any> {
    let { default: LayerOptions } = await import('@arcgis/core/popup/LayerOptions');
    let jsLayerOptions = new LayerOptions();
    if (hasValue(dotNetObject.returnTopmostRaster)) {
        jsLayerOptions.returnTopmostRaster = dotNetObject.returnTopmostRaster;
    }
    if (hasValue(dotNetObject.showNoDataRecords)) {
        jsLayerOptions.showNoDataRecords = dotNetObject.showNoDataRecords;
    }
    let { default: LayerOptionsWrapper } = await import('./layerOptions');
    let layerOptionsWrapper = new LayerOptionsWrapper(jsLayerOptions);
    jsLayerOptions.id = dotNetObject.id;
    
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(layerOptionsWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = layerOptionsWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsLayerOptions;
    
    return jsLayerOptions;
}

export async function buildDotNetLayerOptionsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetLayerOptions: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
        dotNetLayerOptions.returnTopmostRaster = jsObject.returnTopmostRaster;
        dotNetLayerOptions.showNoDataRecords = jsObject.showNoDataRecords;
    return dotNetLayerOptions;
}

