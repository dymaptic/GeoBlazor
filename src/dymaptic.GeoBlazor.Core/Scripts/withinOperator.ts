// override generated code in this file
import WithinOperatorGenerated from './withinOperator.gb';
import withinOperator = __esri.withinOperator;

export default class WithinOperatorWrapper extends WithinOperatorGenerated {

    constructor(component: withinOperator) {
        super(component);
    }
    
}

export async function buildJsWithinOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWithinOperatorGenerated } = await import('./withinOperator.gb');
    return await buildJsWithinOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWithinOperator(jsObject: any): Promise<any> {
    let { buildDotNetWithinOperatorGenerated } = await import('./withinOperator.gb');
    return await buildDotNetWithinOperatorGenerated(jsObject);
}
