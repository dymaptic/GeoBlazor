// override generated code in this file
import AutoCompleteOperatorGenerated from './autoCompleteOperator.gb';
import autoCompleteOperator = __esri.autoCompleteOperator;

export default class AutoCompleteOperatorWrapper extends AutoCompleteOperatorGenerated {

    constructor(component: autoCompleteOperator) {
        super(component);
    }
    
}

export async function buildJsAutoCompleteOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAutoCompleteOperatorGenerated } = await import('./autoCompleteOperator.gb');
    return await buildJsAutoCompleteOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAutoCompleteOperator(jsObject: any): Promise<any> {
    let { buildDotNetAutoCompleteOperatorGenerated } = await import('./autoCompleteOperator.gb');
    return await buildDotNetAutoCompleteOperatorGenerated(jsObject);
}
