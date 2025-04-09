// override generated code in this file
import LengthOperatorGenerated from './lengthOperator.gb';
import lengthOperator = __esri.lengthOperator;

export default class LengthOperatorWrapper extends LengthOperatorGenerated {

    constructor(component: lengthOperator) {
        super(component);
    }
    
}

export async function buildJsLengthOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLengthOperatorGenerated } = await import('./lengthOperator.gb');
    return await buildJsLengthOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLengthOperator(jsObject: any): Promise<any> {
    let { buildDotNetLengthOperatorGenerated } = await import('./lengthOperator.gb');
    return await buildDotNetLengthOperatorGenerated(jsObject);
}
