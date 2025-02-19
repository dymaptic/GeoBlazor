// override generated code in this file
import ImageHistogramParametersGenerated from './imageHistogramParameters.gb';
import ImageHistogramParameters from '@arcgis/core/rest/support/ImageHistogramParameters';

export default class ImageHistogramParametersWrapper extends ImageHistogramParametersGenerated {

    constructor(component: ImageHistogramParameters) {
        super(component);
    }
    
}              
export async function buildJsImageHistogramParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageHistogramParametersGenerated } = await import('./imageHistogramParameters.gb');
    return await buildJsImageHistogramParametersGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetImageHistogramParameters(jsObject: any): Promise<any> {
    let { buildDotNetImageHistogramParametersGenerated } = await import('./imageHistogramParameters.gb');
    return await buildDotNetImageHistogramParametersGenerated(jsObject);
}
