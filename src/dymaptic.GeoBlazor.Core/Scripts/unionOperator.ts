// override generated code in this file
import UnionOperatorGenerated from './unionOperator.gb';
import unionOperator = __esri.unionOperator;

export default class UnionOperatorWrapper extends UnionOperatorGenerated {

    constructor(component: unionOperator) {
        super(component);
    }
    
}

export async function buildJsUnionOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUnionOperatorGenerated } = await import('./unionOperator.gb');
    return await buildJsUnionOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUnionOperator(jsObject: any): Promise<any> {
    let { buildDotNetUnionOperatorGenerated } = await import('./unionOperator.gb');
    return await buildDotNetUnionOperatorGenerated(jsObject);
}
