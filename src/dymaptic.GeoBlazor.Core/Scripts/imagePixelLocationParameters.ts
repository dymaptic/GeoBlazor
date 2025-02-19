// override generated code in this file
import ImagePixelLocationParametersGenerated from './imagePixelLocationParameters.gb';
import ImagePixelLocationParameters from '@arcgis/core/rest/support/ImagePixelLocationParameters';

export default class ImagePixelLocationParametersWrapper extends ImagePixelLocationParametersGenerated {

    constructor(component: ImagePixelLocationParameters) {
        super(component);
    }
    
}              
export async function buildJsImagePixelLocationParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImagePixelLocationParametersGenerated } = await import('./imagePixelLocationParameters.gb');
    return await buildJsImagePixelLocationParametersGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetImagePixelLocationParameters(jsObject: any): Promise<any> {
    let { buildDotNetImagePixelLocationParametersGenerated } = await import('./imagePixelLocationParameters.gb');
    return await buildDotNetImagePixelLocationParametersGenerated(jsObject);
}
