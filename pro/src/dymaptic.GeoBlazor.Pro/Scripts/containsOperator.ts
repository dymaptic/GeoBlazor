// override generated code in this file
import ContainsOperatorGenerated from './containsOperator.gb';
import containsOperator = __esri.containsOperator;

export default class ContainsOperatorWrapper extends ContainsOperatorGenerated {

    constructor(component: containsOperator) {
        super(component);
    }
    
}

export async function buildJsContainsOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsContainsOperatorGenerated } = await import('./containsOperator.gb');
    return await buildJsContainsOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetContainsOperator(jsObject: any): Promise<any> {
    let { buildDotNetContainsOperatorGenerated } = await import('./containsOperator.gb');
    return await buildDotNetContainsOperatorGenerated(jsObject);
}
