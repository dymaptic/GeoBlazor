// override generated code in this file
import IntersectsOperatorGenerated from './intersectsOperator.gb';
import intersectsOperator = __esri.intersectsOperator;

export default class IntersectsOperatorWrapper extends IntersectsOperatorGenerated {

    constructor(component: intersectsOperator) {
        super(component);
    }
    
}

export async function buildJsIntersectsOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIntersectsOperatorGenerated } = await import('./intersectsOperator.gb');
    return await buildJsIntersectsOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIntersectsOperator(jsObject: any): Promise<any> {
    let { buildDotNetIntersectsOperatorGenerated } = await import('./intersectsOperator.gb');
    return await buildDotNetIntersectsOperatorGenerated(jsObject);
}
