// override generated code in this file
import PolygonSlicerOperatorGenerated from './polygonSlicerOperator.gb';
import polygonSlicerOperator = __esri.polygonSlicerOperator;

export default class PolygonSlicerOperatorWrapper extends PolygonSlicerOperatorGenerated {

    constructor(component: polygonSlicerOperator) {
        super(component);
    }
    
}

export async function buildJsPolygonSlicerOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolygonSlicerOperatorGenerated } = await import('./polygonSlicerOperator.gb');
    return await buildJsPolygonSlicerOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolygonSlicerOperator(jsObject: any): Promise<any> {
    let { buildDotNetPolygonSlicerOperatorGenerated } = await import('./polygonSlicerOperator.gb');
    return await buildDotNetPolygonSlicerOperatorGenerated(jsObject);
}
