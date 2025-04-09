// override generated code in this file
import DifferenceOperatorGenerated from './differenceOperator.gb';
import differenceOperator = __esri.differenceOperator;

export default class DifferenceOperatorWrapper extends DifferenceOperatorGenerated {

    constructor(component: differenceOperator) {
        super(component);
    }
    
}

export async function buildJsDifferenceOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDifferenceOperatorGenerated } = await import('./differenceOperator.gb');
    return await buildJsDifferenceOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDifferenceOperator(jsObject: any): Promise<any> {
    let { buildDotNetDifferenceOperatorGenerated } = await import('./differenceOperator.gb');
    return await buildDotNetDifferenceOperatorGenerated(jsObject);
}
