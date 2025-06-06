// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import externalRenderers = __esri.externalRenderers;
import { arcGisObjectRefs, jsObjectRefs, hasValue } from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class ExternalRenderersGenerated implements IPropertyWrapper {
    public component: externalRenderers;
    public geoBlazorId: string | null = null;
    public viewId: string | null = null;
    public layerId: string | null = null;

    constructor(component: externalRenderers) {
        this.component = component;
    }
    
    // region methods
   
    unwrap() {
        return this.component;
    }
    

    async updateComponent(dotNetObject: any): Promise<void> {

    }
    
    async add(view: any,
        renderer: any): Promise<void> {
        this.component.add(view,
            renderer);
    }

    async fromRenderCoordinates(): Promise<void> {
        this.component.fromRenderCoordinates();
    }

    async getRenderCamera(): Promise<any> {
        return this.component.getRenderCamera();
    }

    async remove(view: any,
        renderer: any): Promise<void> {
        this.component.remove(view,
            renderer);
    }

    async renderCoordinateTransformAt(): Promise<void> {
        this.component.renderCoordinateTransformAt();
    }

    async requestRender(): Promise<void> {
        this.component.requestRender();
    }

    async toRenderCoordinates(): Promise<void> {
        this.component.toRenderCoordinates();
    }

    // region properties
    
    getProperty(prop: string): any {
        return this.component[prop];
    }
    
    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
    }
}


export async function buildJsExternalRenderersGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsexternalRenderers: any = {};


    let { default: ExternalRenderersWrapper } = await import('./externalRenderers');
    let externalRenderersWrapper = new ExternalRenderersWrapper(jsexternalRenderers);
    externalRenderersWrapper.geoBlazorId = dotNetObject.id;
    externalRenderersWrapper.viewId = viewId;
    externalRenderersWrapper.layerId = layerId;
    
    let jsObjectRef = DotNet.createJSObjectReference(externalRenderersWrapper);
    jsObjectRefs[dotNetObject.id] = externalRenderersWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsexternalRenderers;
    
    return jsexternalRenderers;
}


export async function buildDotNetExternalRenderersGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetExternalRenderers: any = {};
    

    return dotNetExternalRenderers;
}

