// override generated code in this file
import ImageGPSInfoParametersGenerated from './imageGPSInfoParameters.gb';
import ImageGPSInfoParameters from '@arcgis/core/rest/support/ImageGPSInfoParameters';

export default class ImageGPSInfoParametersWrapper extends ImageGPSInfoParametersGenerated {

    constructor(component: ImageGPSInfoParameters) {
        super(component);
    }
    
}              
export async function buildJsImageGPSInfoParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageGPSInfoParametersGenerated } = await import('./imageGPSInfoParameters.gb');
    return await buildJsImageGPSInfoParametersGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetImageGPSInfoParameters(jsObject: any): Promise<any> {
    let { buildDotNetImageGPSInfoParametersGenerated } = await import('./imageGPSInfoParameters.gb');
    return await buildDotNetImageGPSInfoParametersGenerated(jsObject);
}
