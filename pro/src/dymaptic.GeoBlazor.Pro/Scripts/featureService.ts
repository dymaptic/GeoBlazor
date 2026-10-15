// override generated code in this file
import FeatureServiceGenerated from './featureService.gb';
import FeatureService from '@arcgis/core/rest/featureService/FeatureService';

export default class FeatureServiceWrapper extends FeatureServiceGenerated {

    constructor(component: FeatureService) {
        super(component);
    }
    
}

export async function buildJsFeatureService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureServiceGenerated } = await import('./featureService.gb');
    return await buildJsFeatureServiceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureService(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureServiceGenerated } = await import('./featureService.gb');
    return await buildDotNetFeatureServiceGenerated(jsObject, layerId, viewId);
}
