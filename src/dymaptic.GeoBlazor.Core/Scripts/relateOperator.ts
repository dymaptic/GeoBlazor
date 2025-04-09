// override generated code in this file
import RelateOperatorGenerated from './relateOperator.gb';
import relateOperator = __esri.relateOperator;

export default class RelateOperatorWrapper extends RelateOperatorGenerated {

    constructor(component: relateOperator) {
        super(component);
    }
    
}

export async function buildJsRelateOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelateOperatorGenerated } = await import('./relateOperator.gb');
    return await buildJsRelateOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRelateOperator(jsObject: any): Promise<any> {
    let { buildDotNetRelateOperatorGenerated } = await import('./relateOperator.gb');
    return await buildDotNetRelateOperatorGenerated(jsObject);
}
