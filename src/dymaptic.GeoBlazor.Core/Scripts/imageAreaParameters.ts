// override generated code in this file
import ImageAreaParametersGenerated from './imageAreaParameters.gb';
import ImageAreaParameters from '@arcgis/core/rest/support/ImageAreaParameters';

export default class ImageAreaParametersWrapper extends ImageAreaParametersGenerated {

    constructor(component: ImageAreaParameters) {
        super(component);
    }
    
}              
export async function buildJsImageAreaParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageAreaParametersGenerated } = await import('./imageAreaParameters.gb');
    return await buildJsImageAreaParametersGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetImageAreaParameters(jsObject: any): Promise<any> {
    let { buildDotNetImageAreaParametersGenerated } = await import('./imageAreaParameters.gb');
    return await buildDotNetImageAreaParametersGenerated(jsObject);
}
