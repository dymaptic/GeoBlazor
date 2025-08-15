// override generated code in this file
import WebDocument2DGenerated from './webDocument2D.gb';
import WebDocument2D from '@arcgis/core/WebDocument2D';

export default class WebDocument2DWrapper extends WebDocument2DGenerated {

    constructor(component: WebDocument2D) {
        super(component);
    }
    
}

export async function buildJsWebDocument2D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebDocument2DGenerated } = await import('./webDocument2D.gb');
    return await buildJsWebDocument2DGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWebDocument2D(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetWebDocument2DGenerated } = await import('./webDocument2D.gb');
    return await buildDotNetWebDocument2DGenerated(jsObject, viewId);
}
