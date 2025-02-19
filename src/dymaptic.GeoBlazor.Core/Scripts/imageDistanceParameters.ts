// override generated code in this file
import ImageDistanceParametersGenerated from './imageDistanceParameters.gb';
import ImageDistanceParameters from '@arcgis/core/rest/support/ImageDistanceParameters';

export default class ImageDistanceParametersWrapper extends ImageDistanceParametersGenerated {

    constructor(component: ImageDistanceParameters) {
        super(component);
    }
    
}              
export async function buildJsImageDistanceParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageDistanceParametersGenerated } = await import('./imageDistanceParameters.gb');
    return await buildJsImageDistanceParametersGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetImageDistanceParameters(jsObject: any): Promise<any> {
    let { buildDotNetImageDistanceParametersGenerated } = await import('./imageDistanceParameters.gb');
    return await buildDotNetImageDistanceParametersGenerated(jsObject);
}
