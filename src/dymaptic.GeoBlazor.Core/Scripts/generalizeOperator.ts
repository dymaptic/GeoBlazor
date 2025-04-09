// override generated code in this file
import GeneralizeOperatorGenerated from './generalizeOperator.gb';
import generalizeOperator = __esri.generalizeOperator;

export default class GeneralizeOperatorWrapper extends GeneralizeOperatorGenerated {

    constructor(component: generalizeOperator) {
        super(component);
    }
    
}

export async function buildJsGeneralizeOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeneralizeOperatorGenerated } = await import('./generalizeOperator.gb');
    return await buildJsGeneralizeOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeneralizeOperator(jsObject: any): Promise<any> {
    let { buildDotNetGeneralizeOperatorGenerated } = await import('./generalizeOperator.gb');
    return await buildDotNetGeneralizeOperatorGenerated(jsObject);
}
