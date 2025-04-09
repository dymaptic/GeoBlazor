// override generated code in this file
import AreaOperatorGenerated from './areaOperator.gb';
import areaOperator = __esri.areaOperator;

export default class AreaOperatorWrapper extends AreaOperatorGenerated {

    constructor(component: areaOperator) {
        super(component);
    }
    
}

export async function buildJsAreaOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAreaOperatorGenerated } = await import('./areaOperator.gb');
    return await buildJsAreaOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAreaOperator(jsObject: any): Promise<any> {
    let { buildDotNetAreaOperatorGenerated } = await import('./areaOperator.gb');
    return await buildDotNetAreaOperatorGenerated(jsObject);
}
