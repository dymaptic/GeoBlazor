// override generated code in this file
import ImageToWorldGenerated from './imageToWorld.gb';
import imageToWorld = __esri.imageToWorld;

export default class ImageToWorldWrapper extends ImageToWorldGenerated {

    constructor(component: imageToWorld) {
        super(component);
    }
    
}

export async function buildJsImageToWorld(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageToWorldGenerated } = await import('./imageToWorld.gb');
    return await buildJsImageToWorldGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetImageToWorld(jsObject: any): Promise<any> {
    let { buildDotNetImageToWorldGenerated } = await import('./imageToWorld.gb');
    return await buildDotNetImageToWorldGenerated(jsObject);
}
