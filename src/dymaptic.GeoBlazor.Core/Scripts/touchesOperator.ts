// override generated code in this file
import TouchesOperatorGenerated from './touchesOperator.gb';
import touchesOperator = __esri.touchesOperator;

export default class TouchesOperatorWrapper extends TouchesOperatorGenerated {

    constructor(component: touchesOperator) {
        super(component);
    }
    
}

export async function buildJsTouchesOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTouchesOperatorGenerated } = await import('./touchesOperator.gb');
    return await buildJsTouchesOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTouchesOperator(jsObject: any): Promise<any> {
    let { buildDotNetTouchesOperatorGenerated } = await import('./touchesOperator.gb');
    return await buildDotNetTouchesOperatorGenerated(jsObject);
}
