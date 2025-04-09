// override generated code in this file
import GeodeticAreaOperatorGenerated from './geodeticAreaOperator.gb';
import geodeticAreaOperator = __esri.geodeticAreaOperator;

export default class GeodeticAreaOperatorWrapper extends GeodeticAreaOperatorGenerated {

    constructor(component: geodeticAreaOperator) {
        super(component);
    }
    
}

export async function buildJsGeodeticAreaOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeodeticAreaOperatorGenerated } = await import('./geodeticAreaOperator.gb');
    return await buildJsGeodeticAreaOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeodeticAreaOperator(jsObject: any): Promise<any> {
    let { buildDotNetGeodeticAreaOperatorGenerated } = await import('./geodeticAreaOperator.gb');
    return await buildDotNetGeodeticAreaOperatorGenerated(jsObject);
}
