// override generated code in this file
import CapabilitiesOperationsGenerated from './capabilitiesOperations.gb';
import CapabilitiesOperations = __esri.CapabilitiesOperations;

export default class CapabilitiesOperationsWrapper extends CapabilitiesOperationsGenerated {

    constructor(component: CapabilitiesOperations) {
        super(component);
    }
    
}              
export async function buildJsCapabilitiesOperations(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCapabilitiesOperationsGenerated } = await import('./capabilitiesOperations.gb');
    return await buildJsCapabilitiesOperationsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetCapabilitiesOperations(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesOperationsGenerated } = await import('./capabilitiesOperations.gb');
    return await buildDotNetCapabilitiesOperationsGenerated(jsObject);
}
