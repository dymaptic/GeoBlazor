// override generated code in this file
import EqualsOperatorGenerated from './equalsOperator.gb';
import equalsOperator = __esri.equalsOperator;

export default class EqualsOperatorWrapper extends EqualsOperatorGenerated {

    constructor(component: equalsOperator) {
        super(component);
    }
    
}

export async function buildJsEqualsOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEqualsOperatorGenerated } = await import('./equalsOperator.gb');
    return await buildJsEqualsOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEqualsOperator(jsObject: any): Promise<any> {
    let { buildDotNetEqualsOperatorGenerated } = await import('./equalsOperator.gb');
    return await buildDotNetEqualsOperatorGenerated(jsObject);
}
