// override generated code in this file
import ActionButtonGenerated from './actionButton.gb';
import ActionButton from '@arcgis/core/support/actions/ActionButton';

export default class ActionButtonWrapper extends ActionButtonGenerated {

    constructor(component: ActionButton) {
        super(component);
    }
    
}

export async function buildJsActionButton(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsActionButtonGenerated } = await import('./actionButton.gb');
    return await buildJsActionButtonGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetActionButton(jsObject: any): Promise<any> {
    let { buildDotNetActionButtonGenerated } = await import('./actionButton.gb');
    return await buildDotNetActionButtonGenerated(jsObject);
}
