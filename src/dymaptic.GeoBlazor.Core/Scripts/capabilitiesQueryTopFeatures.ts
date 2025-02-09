// override generated code in this file
import CapabilitiesQueryTopFeaturesGenerated from './capabilitiesQueryTopFeatures.gb';
import CapabilitiesQueryTopFeatures = __esri.CapabilitiesQueryTopFeatures;

export default class CapabilitiesQueryTopFeaturesWrapper extends CapabilitiesQueryTopFeaturesGenerated {

    constructor(component: CapabilitiesQueryTopFeatures) {
        super(component);
    }
    
}              
export async function buildJsCapabilitiesQueryTopFeatures(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCapabilitiesQueryTopFeaturesGenerated } = await import('./capabilitiesQueryTopFeatures.gb');
    return await buildJsCapabilitiesQueryTopFeaturesGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetCapabilitiesQueryTopFeatures(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesQueryTopFeaturesGenerated } = await import('./capabilitiesQueryTopFeatures.gb');
    return await buildDotNetCapabilitiesQueryTopFeaturesGenerated(jsObject);
}
