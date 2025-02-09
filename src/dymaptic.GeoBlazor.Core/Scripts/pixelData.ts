// override generated code in this file
import PixelDataGenerated from './pixelData.gb';
import PixelData = __esri.PixelData;

export default class PixelDataWrapper extends PixelDataGenerated {

    constructor(component: PixelData) {
        super(component);
    }
    
}              
export async function buildJsPixelData(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPixelDataGenerated } = await import('./pixelData.gb');
    return await buildJsPixelDataGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetPixelData(jsObject: any): Promise<any> {
    let { buildDotNetPixelDataGenerated } = await import('./pixelData.gb');
    return await buildDotNetPixelDataGenerated(jsObject);
}
