// override generated code in this file
import ImageToMapMultirayParametersGenerated from './imageToMapMultirayParameters.gb';
import ImageToMapMultirayParameters from '@arcgis/core/rest/support/ImageToMapMultirayParameters';

export default class ImageToMapMultirayParametersWrapper extends ImageToMapMultirayParametersGenerated {

    constructor(component: ImageToMapMultirayParameters) {
        super(component);
    }
    
}              
export async function buildJsImageToMapMultirayParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageToMapMultirayParametersGenerated } = await import('./imageToMapMultirayParameters.gb');
    return await buildJsImageToMapMultirayParametersGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetImageToMapMultirayParameters(jsObject: any): Promise<any> {
    let { buildDotNetImageToMapMultirayParametersGenerated } = await import('./imageToMapMultirayParameters.gb');
    return await buildDotNetImageToMapMultirayParametersGenerated(jsObject);
}
