// override generated code in this file
import ImageIdentifyParametersGenerated from './imageIdentifyParameters.gb';
import ImageIdentifyParameters from '@arcgis/core/rest/support/ImageIdentifyParameters';

export default class ImageIdentifyParametersWrapper extends ImageIdentifyParametersGenerated {

    constructor(component: ImageIdentifyParameters) {
        super(component);
    }
    
}              
export async function buildJsImageIdentifyParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageIdentifyParametersGenerated } = await import('./imageIdentifyParameters.gb');
    return await buildJsImageIdentifyParametersGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetImageIdentifyParameters(jsObject: any): Promise<any> {
    let { buildDotNetImageIdentifyParametersGenerated } = await import('./imageIdentifyParameters.gb');
    return await buildDotNetImageIdentifyParametersGenerated(jsObject);
}
