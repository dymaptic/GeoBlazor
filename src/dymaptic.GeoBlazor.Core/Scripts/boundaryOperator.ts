// override generated code in this file
import BoundaryOperatorGenerated from './boundaryOperator.gb';
import boundaryOperator = __esri.boundaryOperator;

export default class BoundaryOperatorWrapper extends BoundaryOperatorGenerated {

    constructor(component: boundaryOperator) {
        super(component);
    }
    
}

export async function buildJsBoundaryOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBoundaryOperatorGenerated } = await import('./boundaryOperator.gb');
    return await buildJsBoundaryOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBoundaryOperator(jsObject: any): Promise<any> {
    let { buildDotNetBoundaryOperatorGenerated } = await import('./boundaryOperator.gb');
    return await buildDotNetBoundaryOperatorGenerated(jsObject);
}
