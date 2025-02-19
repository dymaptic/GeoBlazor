// override generated code in this file
import ImageSampleGenerated from './imageSample.gb';
import ImageSample from '@arcgis/core/rest/support/ImageSample';

export default class ImageSampleWrapper extends ImageSampleGenerated {

    constructor(component: ImageSample) {
        super(component);
    }
    
}              
export async function buildJsImageSample(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageSampleGenerated } = await import('./imageSample.gb');
    return await buildJsImageSampleGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetImageSample(jsObject: any): Promise<any> {
    let { buildDotNetImageSampleGenerated } = await import('./imageSample.gb');
    return await buildDotNetImageSampleGenerated(jsObject);
}
