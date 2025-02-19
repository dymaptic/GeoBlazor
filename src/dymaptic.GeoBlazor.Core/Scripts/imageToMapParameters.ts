// override generated code in this file
import ImageToMapParametersGenerated from './imageToMapParameters.gb';
import ImageToMapParameters from '@arcgis/core/rest/support/ImageToMapParameters';

export default class ImageToMapParametersWrapper extends ImageToMapParametersGenerated {

    constructor(component: ImageToMapParameters) {
        super(component);
    }
    
}              
export async function buildJsImageToMapParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageToMapParametersGenerated } = await import('./imageToMapParameters.gb');
    return await buildJsImageToMapParametersGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetImageToMapParameters(jsObject: any): Promise<any> {
    let { buildDotNetImageToMapParametersGenerated } = await import('./imageToMapParameters.gb');
    return await buildDotNetImageToMapParametersGenerated(jsObject);
}
