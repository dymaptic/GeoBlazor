// override generated code in this file
import PolylineDrawActionGenerated from './polylineDrawAction.gb';
import PolylineDrawAction = __esri.PolylineDrawAction;

export default class PolylineDrawActionWrapper extends PolylineDrawActionGenerated {

    constructor(component: PolylineDrawAction) {
        super(component);
    }
    
}

export async function buildJsPolylineDrawAction(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolylineDrawActionGenerated } = await import('./polylineDrawAction.gb');
    return await buildJsPolylineDrawActionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolylineDrawAction(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPolylineDrawActionGenerated } = await import('./polylineDrawAction.gb');
    return await buildDotNetPolylineDrawActionGenerated(jsObject, layerId, viewId);
}
