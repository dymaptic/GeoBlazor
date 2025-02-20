// override generated code in this file
import ImageServiceGenerated from './imageService.gb';
import imageService = __esri.imageService;

export default class ImageServiceWrapper extends ImageServiceGenerated {

    constructor(component: imageService) {
        super(component);
    }

}

export async function buildJsImageService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageServiceGenerated} = await import('./imageService.gb');
    return await buildJsImageServiceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImageService(jsObject: any): Promise<any> {
    let {buildDotNetImageServiceGenerated} = await import('./imageService.gb');
    return await buildDotNetImageServiceGenerated(jsObject);
}
