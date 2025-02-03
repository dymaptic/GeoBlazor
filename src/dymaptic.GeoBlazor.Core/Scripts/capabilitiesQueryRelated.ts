// override generated code in this file
import CapabilitiesQueryRelatedGenerated from './capabilitiesQueryRelated.gb';
import CapabilitiesQueryRelated = __esri.CapabilitiesQueryRelated;

export default class CapabilitiesQueryRelatedWrapper extends CapabilitiesQueryRelatedGenerated {

    constructor(component: CapabilitiesQueryRelated) {
        super(component);
    }
    
}              
export async function buildJsCapabilitiesQueryRelated(dotNetObject: any): Promise<any> {
    let { buildJsCapabilitiesQueryRelatedGenerated } = await import('./capabilitiesQueryRelated.gb');
    return await buildJsCapabilitiesQueryRelatedGenerated(dotNetObject);
}
export async function buildDotNetCapabilitiesQueryRelated(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesQueryRelatedGenerated } = await import('./capabilitiesQueryRelated.gb');
    return await buildDotNetCapabilitiesQueryRelatedGenerated(jsObject);
}
