// override generated code in this file
import CentroidOperatorGenerated from './centroidOperator.gb';
import centroidOperator = __esri.centroidOperator;

export default class CentroidOperatorWrapper extends CentroidOperatorGenerated {

    constructor(component: centroidOperator) {
        super(component);
    }
    
}

export async function buildJsCentroidOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCentroidOperatorGenerated } = await import('./centroidOperator.gb');
    return await buildJsCentroidOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCentroidOperator(jsObject: any): Promise<any> {
    let { buildDotNetCentroidOperatorGenerated } = await import('./centroidOperator.gb');
    return await buildDotNetCentroidOperatorGenerated(jsObject);
}
