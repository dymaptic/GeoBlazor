// override generated code in this file
import CapabilitiesDataGenerated from './capabilitiesData.gb';
import CapabilitiesData = __esri.CapabilitiesData;

export default class CapabilitiesDataWrapper extends CapabilitiesDataGenerated {

    constructor(component: CapabilitiesData) {
        super(component);
    }
    
}              
export async function buildJsCapabilitiesData(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCapabilitiesDataGenerated } = await import('./capabilitiesData.gb');
    return await buildJsCapabilitiesDataGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetCapabilitiesData(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesDataGenerated } = await import('./capabilitiesData.gb');
    return await buildDotNetCapabilitiesDataGenerated(jsObject);
}
