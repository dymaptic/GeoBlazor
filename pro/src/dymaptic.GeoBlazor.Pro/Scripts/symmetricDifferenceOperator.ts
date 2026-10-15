// override generated code in this file
import SymmetricDifferenceOperatorGenerated from './symmetricDifferenceOperator.gb';
import symmetricDifferenceOperator = __esri.symmetricDifferenceOperator;

export default class SymmetricDifferenceOperatorWrapper extends SymmetricDifferenceOperatorGenerated {

    constructor(component: symmetricDifferenceOperator) {
        super(component);
    }
    
}

export async function buildJsSymmetricDifferenceOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSymmetricDifferenceOperatorGenerated } = await import('./symmetricDifferenceOperator.gb');
    return await buildJsSymmetricDifferenceOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSymmetricDifferenceOperator(jsObject: any): Promise<any> {
    let { buildDotNetSymmetricDifferenceOperatorGenerated } = await import('./symmetricDifferenceOperator.gb');
    return await buildDotNetSymmetricDifferenceOperatorGenerated(jsObject);
}
