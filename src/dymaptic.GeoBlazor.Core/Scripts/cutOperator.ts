// override generated code in this file
import CutOperatorGenerated from './cutOperator.gb';
import cutOperator = __esri.cutOperator;

export default class CutOperatorWrapper extends CutOperatorGenerated {

    constructor(component: cutOperator) {
        super(component);
    }
    
}

export async function buildJsCutOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCutOperatorGenerated } = await import('./cutOperator.gb');
    return await buildJsCutOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCutOperator(jsObject: any): Promise<any> {
    let { buildDotNetCutOperatorGenerated } = await import('./cutOperator.gb');
    return await buildDotNetCutOperatorGenerated(jsObject);
}
