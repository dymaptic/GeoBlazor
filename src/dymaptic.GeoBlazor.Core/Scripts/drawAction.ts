// override generated code in this file
import DrawActionGenerated from './drawAction.gb';
import DrawAction from '@arcgis/core/views/draw/DrawAction';

export default class DrawActionWrapper extends DrawActionGenerated {

    constructor(component: DrawAction) {
        super(component);
    }
    
}

export async function buildJsDrawAction(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDrawActionGenerated } = await import('./drawAction.gb');
    return await buildJsDrawActionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDrawAction(jsObject: any): Promise<any> {
    let { buildDotNetDrawActionGenerated } = await import('./drawAction.gb');
    return await buildDotNetDrawActionGenerated(jsObject);
}
