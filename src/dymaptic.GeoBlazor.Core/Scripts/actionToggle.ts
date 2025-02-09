// override generated code in this file
import ActionToggleGenerated from './actionToggle.gb';
import ActionToggle from '@arcgis/core/support/actions/ActionToggle';

export default class ActionToggleWrapper extends ActionToggleGenerated {

    constructor(component: ActionToggle) {
        super(component);
    }
    
}

export async function buildJsActionToggle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsActionToggleGenerated } = await import('./actionToggle.gb');
    return await buildJsActionToggleGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetActionToggle(jsObject: any): Promise<any> {
    let { buildDotNetActionToggleGenerated } = await import('./actionToggle.gb');
    return await buildDotNetActionToggleGenerated(jsObject);
}
