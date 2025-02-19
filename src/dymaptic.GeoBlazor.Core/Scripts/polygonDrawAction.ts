// override generated code in this file
import PolygonDrawActionGenerated from './polygonDrawAction.gb';
import PolygonDrawAction = __esri.PolygonDrawAction;

export default class PolygonDrawActionWrapper extends PolygonDrawActionGenerated {

    constructor(component: PolygonDrawAction) {
        super(component);
    }
    
}

export async function buildJsPolygonDrawAction(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolygonDrawActionGenerated } = await import('./polygonDrawAction.gb');
    return await buildJsPolygonDrawActionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolygonDrawAction(jsObject: any): Promise<any> {
    let { buildDotNetPolygonDrawActionGenerated } = await import('./polygonDrawAction.gb');
    return await buildDotNetPolygonDrawActionGenerated(jsObject);
}
