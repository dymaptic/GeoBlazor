// override generated code in this file
import PointDrawActionGenerated from './pointDrawAction.gb';
import PointDrawAction = __esri.PointDrawAction;

export default class PointDrawActionWrapper extends PointDrawActionGenerated {

    constructor(component: PointDrawAction) {
        super(component);
    }

}

export async function buildJsPointDrawAction(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPointDrawActionGenerated} = await import('./pointDrawAction.gb');
    return await buildJsPointDrawActionGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPointDrawAction(jsObject: any): Promise<any> {
    let {buildDotNetPointDrawActionGenerated} = await import('./pointDrawAction.gb');
    return await buildDotNetPointDrawActionGenerated(jsObject);
}
