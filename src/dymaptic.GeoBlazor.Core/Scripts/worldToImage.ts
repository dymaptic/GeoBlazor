// override generated code in this file
import WorldToImageGenerated from './worldToImage.gb';
import worldToImage = __esri.worldToImage;

export default class WorldToImageWrapper extends WorldToImageGenerated {

    constructor(component: worldToImage) {
        super(component);
    }
    
}

export async function buildJsWorldToImage(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWorldToImageGenerated } = await import('./worldToImage.gb');
    return await buildJsWorldToImageGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWorldToImage(jsObject: any): Promise<any> {
    let { buildDotNetWorldToImageGenerated } = await import('./worldToImage.gb');
    return await buildDotNetWorldToImageGenerated(jsObject);
}
