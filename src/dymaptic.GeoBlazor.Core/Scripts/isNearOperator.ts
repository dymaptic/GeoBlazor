// override generated code in this file
import IsNearOperatorGenerated from './isNearOperator.gb';
import isNearOperator = __esri.isNearOperator;

export default class IsNearOperatorWrapper extends IsNearOperatorGenerated {

    constructor(component: isNearOperator) {
        super(component);
    }
    
}

export async function buildJsIsNearOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIsNearOperatorGenerated } = await import('./isNearOperator.gb');
    return await buildJsIsNearOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIsNearOperator(jsObject: any): Promise<any> {
    let { buildDotNetIsNearOperatorGenerated } = await import('./isNearOperator.gb');
    return await buildDotNetIsNearOperatorGenerated(jsObject);
}
