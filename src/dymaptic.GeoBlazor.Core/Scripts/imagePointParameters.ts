// override generated code in this file
import ImagePointParametersGenerated from './imagePointParameters.gb';
import ImagePointParameters from '@arcgis/core/rest/support/ImagePointParameters';

export default class ImagePointParametersWrapper extends ImagePointParametersGenerated {

    constructor(component: ImagePointParameters) {
        super(component);
    }
    
}              
export async function buildJsImagePointParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImagePointParametersGenerated } = await import('./imagePointParameters.gb');
    return await buildJsImagePointParametersGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetImagePointParameters(jsObject: any): Promise<any> {
    let { buildDotNetImagePointParametersGenerated } = await import('./imagePointParameters.gb');
    return await buildDotNetImagePointParametersGenerated(jsObject);
}
