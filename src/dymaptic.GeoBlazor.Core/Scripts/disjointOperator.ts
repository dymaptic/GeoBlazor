// override generated code in this file
import DisjointOperatorGenerated from './disjointOperator.gb';
import disjointOperator = __esri.disjointOperator;

export default class DisjointOperatorWrapper extends DisjointOperatorGenerated {

    constructor(component: disjointOperator) {
        super(component);
    }
    
}

export async function buildJsDisjointOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDisjointOperatorGenerated } = await import('./disjointOperator.gb');
    return await buildJsDisjointOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDisjointOperator(jsObject: any): Promise<any> {
    let { buildDotNetDisjointOperatorGenerated } = await import('./disjointOperator.gb');
    return await buildDotNetDisjointOperatorGenerated(jsObject);
}
