// override generated code in this file
import TopFeaturesQueryGenerated from './topFeaturesQuery.gb';
import TopFeaturesQuery from '@arcgis/core/rest/support/TopFeaturesQuery';

export default class TopFeaturesQueryWrapper extends TopFeaturesQueryGenerated {

    constructor(component: TopFeaturesQuery) {
        super(component);
    }
    
}              
export async function buildJsTopFeaturesQuery(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTopFeaturesQueryGenerated } = await import('./topFeaturesQuery.gb');
    return await buildJsTopFeaturesQueryGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetTopFeaturesQuery(jsObject: any): Promise<any> {
    let { buildDotNetTopFeaturesQueryGenerated } = await import('./topFeaturesQuery.gb');
    return await buildDotNetTopFeaturesQueryGenerated(jsObject);
}
