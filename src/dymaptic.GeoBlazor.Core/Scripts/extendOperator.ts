// override generated code in this file
import ExtendOperatorGenerated from './extendOperator.gb';
import extendOperator = __esri.extendOperator;

export default class ExtendOperatorWrapper extends ExtendOperatorGenerated {

    constructor(component: extendOperator) {
        super(component);
    }
    
}

export async function buildJsExtendOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsExtendOperatorGenerated } = await import('./extendOperator.gb');
    return await buildJsExtendOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetExtendOperator(jsObject: any): Promise<any> {
    let { buildDotNetExtendOperatorGenerated } = await import('./extendOperator.gb');
    return await buildDotNetExtendOperatorGenerated(jsObject);
}
