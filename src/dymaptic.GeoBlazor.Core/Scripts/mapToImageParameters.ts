// override generated code in this file
import MapToImageParametersGenerated from './mapToImageParameters.gb';
import MapToImageParameters from '@arcgis/core/rest/support/MapToImageParameters';

export default class MapToImageParametersWrapper extends MapToImageParametersGenerated {

    constructor(component: MapToImageParameters) {
        super(component);
    }
    
}              
export async function buildJsMapToImageParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMapToImageParametersGenerated } = await import('./mapToImageParameters.gb');
    return await buildJsMapToImageParametersGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetMapToImageParameters(jsObject: any): Promise<any> {
    let { buildDotNetMapToImageParametersGenerated } = await import('./mapToImageParameters.gb');
    return await buildDotNetMapToImageParametersGenerated(jsObject);
}
