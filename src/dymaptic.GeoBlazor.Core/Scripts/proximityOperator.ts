// override generated code in this file
import ProximityOperatorGenerated from './proximityOperator.gb';
import proximityOperator = __esri.proximityOperator;

export default class ProximityOperatorWrapper extends ProximityOperatorGenerated {

    constructor(component: proximityOperator) {
        super(component);
    }
    
}

export async function buildJsProximityOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsProximityOperatorGenerated } = await import('./proximityOperator.gb');
    return await buildJsProximityOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetProximityOperator(jsObject: any): Promise<any> {
    let { buildDotNetProximityOperatorGenerated } = await import('./proximityOperator.gb');
    return await buildDotNetProximityOperatorGenerated(jsObject);
}
