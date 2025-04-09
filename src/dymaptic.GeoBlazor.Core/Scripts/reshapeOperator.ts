// override generated code in this file
import ReshapeOperatorGenerated from './reshapeOperator.gb';
import reshapeOperator = __esri.reshapeOperator;

export default class ReshapeOperatorWrapper extends ReshapeOperatorGenerated {

    constructor(component: reshapeOperator) {
        super(component);
    }
    
}

export async function buildJsReshapeOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsReshapeOperatorGenerated } = await import('./reshapeOperator.gb');
    return await buildJsReshapeOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetReshapeOperator(jsObject: any): Promise<any> {
    let { buildDotNetReshapeOperatorGenerated } = await import('./reshapeOperator.gb');
    return await buildDotNetReshapeOperatorGenerated(jsObject);
}
