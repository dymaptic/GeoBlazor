// override generated code in this file
import CapabilitiesEditingGenerated from './capabilitiesEditing.gb';
import CapabilitiesEditing = __esri.CapabilitiesEditing;

export default class CapabilitiesEditingWrapper extends CapabilitiesEditingGenerated {

    constructor(component: CapabilitiesEditing) {
        super(component);
    }
    
}              
export async function buildJsCapabilitiesEditing(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCapabilitiesEditingGenerated } = await import('./capabilitiesEditing.gb');
    return await buildJsCapabilitiesEditingGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetCapabilitiesEditing(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesEditingGenerated } = await import('./capabilitiesEditing.gb');
    return await buildDotNetCapabilitiesEditingGenerated(jsObject);
}
