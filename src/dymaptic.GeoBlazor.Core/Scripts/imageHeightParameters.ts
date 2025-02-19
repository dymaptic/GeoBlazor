// override generated code in this file
import ImageHeightParametersGenerated from './imageHeightParameters.gb';
import ImageHeightParameters from '@arcgis/core/rest/support/ImageHeightParameters';

export default class ImageHeightParametersWrapper extends ImageHeightParametersGenerated {

    constructor(component: ImageHeightParameters) {
        super(component);
    }
    
}              
export async function buildJsImageHeightParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageHeightParametersGenerated } = await import('./imageHeightParameters.gb');
    return await buildJsImageHeightParametersGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetImageHeightParameters(jsObject: any): Promise<any> {
    let { buildDotNetImageHeightParametersGenerated } = await import('./imageHeightParameters.gb');
    return await buildDotNetImageHeightParametersGenerated(jsObject);
}
