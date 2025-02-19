// override generated code in this file
import ImageAngleParametersGenerated from './imageAngleParameters.gb';
import ImageAngleParameters from '@arcgis/core/rest/support/ImageAngleParameters';

export default class ImageAngleParametersWrapper extends ImageAngleParametersGenerated {

    constructor(component: ImageAngleParameters) {
        super(component);
    }
    
}              
export async function buildJsImageAngleParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageAngleParametersGenerated } = await import('./imageAngleParameters.gb');
    return await buildJsImageAngleParametersGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetImageAngleParameters(jsObject: any): Promise<any> {
    let { buildDotNetImageAngleParametersGenerated } = await import('./imageAngleParameters.gb');
    return await buildDotNetImageAngleParametersGenerated(jsObject);
}
