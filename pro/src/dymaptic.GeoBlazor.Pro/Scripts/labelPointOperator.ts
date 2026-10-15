// override generated code in this file
import LabelPointOperatorGenerated from './labelPointOperator.gb';
import labelPointOperator = __esri.labelPointOperator;

export default class LabelPointOperatorWrapper extends LabelPointOperatorGenerated {

    constructor(component: labelPointOperator) {
        super(component);
    }
    
}

export async function buildJsLabelPointOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLabelPointOperatorGenerated } = await import('./labelPointOperator.gb');
    return await buildJsLabelPointOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLabelPointOperator(jsObject: any): Promise<any> {
    let { buildDotNetLabelPointOperatorGenerated } = await import('./labelPointOperator.gb');
    return await buildDotNetLabelPointOperatorGenerated(jsObject);
}
