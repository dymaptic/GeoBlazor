// override generated code in this file
import SimplifyOperatorGenerated from './simplifyOperator.gb';
import simplifyOperator = __esri.simplifyOperator;

export default class SimplifyOperatorWrapper extends SimplifyOperatorGenerated {

    constructor(component: simplifyOperator) {
        super(component);
    }
    
}

export async function buildJsSimplifyOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSimplifyOperatorGenerated } = await import('./simplifyOperator.gb');
    return await buildJsSimplifyOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSimplifyOperator(jsObject: any): Promise<any> {
    let { buildDotNetSimplifyOperatorGenerated } = await import('./simplifyOperator.gb');
    return await buildDotNetSimplifyOperatorGenerated(jsObject);
}
