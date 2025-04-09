// override generated code in this file
import OffsetOperatorGenerated from './offsetOperator.gb';
import offsetOperator = __esri.offsetOperator;

export default class OffsetOperatorWrapper extends OffsetOperatorGenerated {

    constructor(component: offsetOperator) {
        super(component);
    }
    
}

export async function buildJsOffsetOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOffsetOperatorGenerated } = await import('./offsetOperator.gb');
    return await buildJsOffsetOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOffsetOperator(jsObject: any): Promise<any> {
    let { buildDotNetOffsetOperatorGenerated } = await import('./offsetOperator.gb');
    return await buildDotNetOffsetOperatorGenerated(jsObject);
}
