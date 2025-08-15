// override generated code in this file
import ImageElementGenerated from './imageElement.gb';
import ImageElement from '@arcgis/core/layers/support/ImageElement';

export default class ImageElementWrapper extends ImageElementGenerated {

    constructor(component: ImageElement) {
        super(component);
    }
    
}

export async function buildJsImageElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageElementGenerated } = await import('./imageElement.gb');
    return await buildJsImageElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetImageElement(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetImageElementGenerated } = await import('./imageElement.gb');
    return await buildDotNetImageElementGenerated(jsObject, viewId);
}
