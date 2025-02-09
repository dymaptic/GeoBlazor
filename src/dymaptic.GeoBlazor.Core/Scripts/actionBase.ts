// override generated code in this file
import ActionBaseGenerated from './actionBase.gb';
import ActionBase from '@arcgis/core/support/actions/ActionBase';

export default class ActionBaseWrapper extends ActionBaseGenerated {

    constructor(component: ActionBase) {
        super(component);
    }
    
}

export async function buildJsActionBase(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsActionBaseGenerated } = await import('./actionBase.gb');
    return await buildJsActionBaseGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetActionBase(jsObject: any): Promise<any> {
    let { buildDotNetActionBaseGenerated } = await import('./actionBase.gb');
    return await buildDotNetActionBaseGenerated(jsObject);
}
