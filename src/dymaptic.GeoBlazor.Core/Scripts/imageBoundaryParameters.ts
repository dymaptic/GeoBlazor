// override generated code in this file
import ImageBoundaryParametersGenerated from './imageBoundaryParameters.gb';
import ImageBoundaryParameters from '@arcgis/core/rest/support/ImageBoundaryParameters';

export default class ImageBoundaryParametersWrapper extends ImageBoundaryParametersGenerated {

    constructor(component: ImageBoundaryParameters) {
        super(component);
    }
    
}              
export async function buildJsImageBoundaryParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageBoundaryParametersGenerated } = await import('./imageBoundaryParameters.gb');
    return await buildJsImageBoundaryParametersGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetImageBoundaryParameters(jsObject: any): Promise<any> {
    let { buildDotNetImageBoundaryParametersGenerated } = await import('./imageBoundaryParameters.gb');
    return await buildDotNetImageBoundaryParametersGenerated(jsObject);
}
