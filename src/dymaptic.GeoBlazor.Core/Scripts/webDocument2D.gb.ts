import WebDocument2D from "@arcgis/core/WebDocument2D";
import {IPropertyWrapper} from "./definitions";

export default class WebDocument2DGenerated implements IPropertyWrapper {
    public component: WebDocument2D;
    public geoBlazorId: string | null = null;
    public viewId: string | null = null;
    public layerId: string | null = null;

    constructor(component: WebDocument2D) {
        this.component = component;
    }
    
    // region methods
    
    unwrap() {
        return this.component;
    }
    
    async getProperty(name: any): Promise<any> {
        return this.component[name];
    }
    
    async setProperty(name: any, value: any): Promise<void> {
        this.component[name] = value;
    }
}

export async function buildJsWebDocument2DGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    return null;
}

export async function buildDotNetWebDocument2DGenerated(jsObject: any): Promise<any> {
    return null;
}