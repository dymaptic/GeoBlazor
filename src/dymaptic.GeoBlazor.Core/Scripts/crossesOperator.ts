// override generated code in this file
import CrossesOperatorGenerated from './crossesOperator.gb';
import crossesOperator = __esri.crossesOperator;

export default class CrossesOperatorWrapper extends CrossesOperatorGenerated {

    constructor(component: crossesOperator) {
        super(component);
    }
    
}

export async function buildJsCrossesOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCrossesOperatorGenerated } = await import('./crossesOperator.gb');
    return await buildJsCrossesOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCrossesOperator(jsObject: any): Promise<any> {
    let { buildDotNetCrossesOperatorGenerated } = await import('./crossesOperator.gb');
    return await buildDotNetCrossesOperatorGenerated(jsObject);
}
