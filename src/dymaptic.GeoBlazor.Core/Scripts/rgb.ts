// override generated code in this file
import RgbGenerated from './rgb.gb';
import rgb = __esri.rgb;

export default class RgbWrapper extends RgbGenerated {

    constructor(component: rgb) {
        super(component);
    }
    
}

export async function buildJsRgb(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRgbGenerated } = await import('./rgb.gb');
    return await buildJsRgbGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRgb(jsObject: any): Promise<any> {
    let { buildDotNetRgbGenerated } = await import('./rgb.gb');
    return await buildDotNetRgbGenerated(jsObject);
}
