// override generated code in this file
import ImageSampleParametersGenerated from './imageSampleParameters.gb';
import ImageSampleParameters from '@arcgis/core/rest/support/ImageSampleParameters';

export default class ImageSampleParametersWrapper extends ImageSampleParametersGenerated {

    constructor(component: ImageSampleParameters) {
        super(component);
    }
    
}              
export async function buildJsImageSampleParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageSampleParametersGenerated } = await import('./imageSampleParameters.gb');
    return await buildJsImageSampleParametersGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetImageSampleParameters(jsObject: any): Promise<any> {
    let { buildDotNetImageSampleParametersGenerated } = await import('./imageSampleParameters.gb');
    return await buildDotNetImageSampleParametersGenerated(jsObject);
}
