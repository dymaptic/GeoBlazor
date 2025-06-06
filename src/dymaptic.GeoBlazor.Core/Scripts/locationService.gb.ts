// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import locator = __esri.locator;
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class LocationServiceGenerated implements IPropertyWrapper {
    public component: locator;
    public geoBlazorId: string | null = null;
    public viewId: string | null = null;
    public layerId: string | null = null;

    constructor(component: locator) {
        this.component = component;
    }
    
    // region methods
   
    unwrap() {
        return this.component;
    }
    

    async updateComponent(dotNetObject: any): Promise<void> {

    }
    
    // region properties
    
    getProperty(prop: string): any {
        return this.component[prop];
    }
    
    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
    }
}


export async function buildJsLocationServiceGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jslocator: any = {};


    let { default: LocationServiceWrapper } = await import('./locationService');
    let locationServiceWrapper = new LocationServiceWrapper(jslocator);
    locationServiceWrapper.geoBlazorId = dotNetObject.id;
    locationServiceWrapper.viewId = viewId;
    locationServiceWrapper.layerId = layerId;
    
    jsObjectRefs[dotNetObject.id] = locationServiceWrapper;
    arcGisObjectRefs[dotNetObject.id] = jslocator;
    
    return jslocator;
}


export async function buildDotNetLocationServiceGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetLocationService: any = {};
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetLocationService.id = geoBlazorId;
    }

    return dotNetLocationService;
}

