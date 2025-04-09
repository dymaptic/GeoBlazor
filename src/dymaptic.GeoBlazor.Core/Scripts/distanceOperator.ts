// override generated code in this file
import DistanceOperatorGenerated from './distanceOperator.gb';
import distanceOperator = __esri.distanceOperator;

export default class DistanceOperatorWrapper extends DistanceOperatorGenerated {

    constructor(component: distanceOperator) {
        super(component);
    }
    
}

export async function buildJsDistanceOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDistanceOperatorGenerated } = await import('./distanceOperator.gb');
    return await buildJsDistanceOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDistanceOperator(jsObject: any): Promise<any> {
    let { buildDotNetDistanceOperatorGenerated } = await import('./distanceOperator.gb');
    return await buildDotNetDistanceOperatorGenerated(jsObject);
}
