// override generated code in this file
import GeodeticDistanceOperatorGenerated from './geodeticDistanceOperator.gb';
import geodeticDistanceOperator = __esri.geodeticDistanceOperator;

export default class GeodeticDistanceOperatorWrapper extends GeodeticDistanceOperatorGenerated {

    constructor(component: geodeticDistanceOperator) {
        super(component);
    }
    
}

export async function buildJsGeodeticDistanceOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeodeticDistanceOperatorGenerated } = await import('./geodeticDistanceOperator.gb');
    return await buildJsGeodeticDistanceOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeodeticDistanceOperator(jsObject: any): Promise<any> {
    let { buildDotNetGeodeticDistanceOperatorGenerated } = await import('./geodeticDistanceOperator.gb');
    return await buildDotNetGeodeticDistanceOperatorGenerated(jsObject);
}
