// override generated code in this file
import WebglGenerated from './webgl.gb';
import webgl = __esri.webgl;

export default class WebglWrapper extends WebglGenerated {

    constructor(component: webgl) {
        super(component);
    }
    
}

export async function buildJsWebgl(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebglGenerated } = await import('./webgl.gb');
    return await buildJsWebglGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWebgl(jsObject: any): Promise<any> {
    let { buildDotNetWebglGenerated } = await import('./webgl.gb');
    return await buildDotNetWebglGenerated(jsObject);
}
