// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file


import OrderedLayerOrderBy = __esri.OrderedLayerOrderBy;
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class OrderedLayerOrderByGenerated implements IPropertyWrapper {
    public component: OrderedLayerOrderBy;
    public readonly geoBlazorId: string = '';

    constructor(component: OrderedLayerOrderBy) {
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
export async function buildJsOrderedLayerOrderByGenerated(dotNetObject: any): Promise<any> {
    let jsOrderedLayerOrderBy = {
        field: dotNetObject.field,
        order: dotNetObject.order,
        valueExpression: dotNetObject.valueExpression,
    }
    let { default: OrderedLayerOrderByWrapper } = await import('./orderedLayerOrderBy');
    let orderedLayerOrderByWrapper = new OrderedLayerOrderByWrapper(jsOrderedLayerOrderBy);
    jsOrderedLayerOrderBy.id = dotNetObject.id;
    
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(orderedLayerOrderByWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = orderedLayerOrderByWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsOrderedLayerOrderBy;
    
    return jsOrderedLayerOrderBy;
}

export async function buildDotNetOrderedLayerOrderByGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetOrderedLayerOrderBy: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
        dotNetOrderedLayerOrderBy.field = jsObject.field;
        dotNetOrderedLayerOrderBy.order = jsObject.order;
        dotNetOrderedLayerOrderBy.valueExpression = jsObject.valueExpression;
    return dotNetOrderedLayerOrderBy;
}

