// override generated code in this file
import IntersectionOperatorGenerated from './intersectionOperator.gb';
import intersectionOperator = __esri.intersectionOperator;

export default class IntersectionOperatorWrapper extends IntersectionOperatorGenerated {

    constructor(component: intersectionOperator) {
        super(component);
    }
    
}

export async function buildJsIntersectionOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIntersectionOperatorGenerated } = await import('./intersectionOperator.gb');
    return await buildJsIntersectionOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIntersectionOperator(jsObject: any): Promise<any> {
    let { buildDotNetIntersectionOperatorGenerated } = await import('./intersectionOperator.gb');
    return await buildDotNetIntersectionOperatorGenerated(jsObject);
}
