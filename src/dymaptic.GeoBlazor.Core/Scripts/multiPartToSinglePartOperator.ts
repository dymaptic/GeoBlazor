// override generated code in this file
import MultiPartToSinglePartOperatorGenerated from './multiPartToSinglePartOperator.gb';
import multiPartToSinglePartOperator = __esri.multiPartToSinglePartOperator;

export default class MultiPartToSinglePartOperatorWrapper extends MultiPartToSinglePartOperatorGenerated {

    constructor(component: multiPartToSinglePartOperator) {
        super(component);
    }
    
}

export async function buildJsMultiPartToSinglePartOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMultiPartToSinglePartOperatorGenerated } = await import('./multiPartToSinglePartOperator.gb');
    return await buildJsMultiPartToSinglePartOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMultiPartToSinglePartOperator(jsObject: any): Promise<any> {
    let { buildDotNetMultiPartToSinglePartOperatorGenerated } = await import('./multiPartToSinglePartOperator.gb');
    return await buildDotNetMultiPartToSinglePartOperatorGenerated(jsObject);
}
