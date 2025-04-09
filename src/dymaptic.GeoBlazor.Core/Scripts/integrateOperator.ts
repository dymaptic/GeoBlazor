// override generated code in this file
import IntegrateOperatorGenerated from './integrateOperator.gb';
import integrateOperator = __esri.integrateOperator;

export default class IntegrateOperatorWrapper extends IntegrateOperatorGenerated {

    constructor(component: integrateOperator) {
        super(component);
    }
    
}

export async function buildJsIntegrateOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIntegrateOperatorGenerated } = await import('./integrateOperator.gb');
    return await buildJsIntegrateOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIntegrateOperator(jsObject: any): Promise<any> {
    let { buildDotNetIntegrateOperatorGenerated } = await import('./integrateOperator.gb');
    return await buildDotNetIntegrateOperatorGenerated(jsObject);
}
