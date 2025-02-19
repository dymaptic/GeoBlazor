import PolylineDrawAction = __esri.PolylineDrawAction;
import PolylineDrawActionGenerated from './polylineDrawAction.gb';

export default class PolylineDrawActionWrapper extends PolylineDrawActionGenerated {

    constructor(component: PolylineDrawAction) {
        super(component);
    }
    
}

export async function buildJsPolylineDrawAction(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolylineDrawActionGenerated } = await import('./polylineDrawAction.gb');
    return await buildJsPolylineDrawActionGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetPolylineDrawAction(jsObject: any): Promise<any> {
    let { buildDotNetPolylineDrawActionGenerated } = await import('./polylineDrawAction.gb');
    return await buildDotNetPolylineDrawActionGenerated(jsObject);
}
