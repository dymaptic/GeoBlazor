// override generated code in this file
import PolygonOverlayOperatorGenerated from './polygonOverlayOperator.gb';
import polygonOverlayOperator = __esri.polygonOverlayOperator;

export default class PolygonOverlayOperatorWrapper extends PolygonOverlayOperatorGenerated {

    constructor(component: polygonOverlayOperator) {
        super(component);
    }
    
}

export async function buildJsPolygonOverlayOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolygonOverlayOperatorGenerated } = await import('./polygonOverlayOperator.gb');
    return await buildJsPolygonOverlayOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolygonOverlayOperator(jsObject: any): Promise<any> {
    let { buildDotNetPolygonOverlayOperatorGenerated } = await import('./polygonOverlayOperator.gb');
    return await buildDotNetPolygonOverlayOperatorGenerated(jsObject);
}
