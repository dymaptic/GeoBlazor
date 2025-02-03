// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file


import UniqueValueRendererLegendOptions = __esri.UniqueValueRendererLegendOptions;
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class UniqueValueRendererLegendOptionsGenerated implements IPropertyWrapper {
    public component: UniqueValueRendererLegendOptions;
    public readonly geoBlazorId: string = '';

    constructor(component: UniqueValueRendererLegendOptions) {
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
export async function buildJsUniqueValueRendererLegendOptionsGenerated(dotNetObject: any): Promise<any> {
    let jsUniqueValueRendererLegendOptions = {
        title: dotNetObject.title,
    }
    let { default: UniqueValueRendererLegendOptionsWrapper } = await import('./uniqueValueRendererLegendOptions');
    let uniqueValueRendererLegendOptionsWrapper = new UniqueValueRendererLegendOptionsWrapper(jsUniqueValueRendererLegendOptions);
    jsUniqueValueRendererLegendOptions.id = dotNetObject.id;
    
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(uniqueValueRendererLegendOptionsWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = uniqueValueRendererLegendOptionsWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsUniqueValueRendererLegendOptions;
    
    return jsUniqueValueRendererLegendOptions;
}

export async function buildDotNetUniqueValueRendererLegendOptionsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetUniqueValueRendererLegendOptions: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
        dotNetUniqueValueRendererLegendOptions.title = jsObject.title;
    return dotNetUniqueValueRendererLegendOptions;
}

