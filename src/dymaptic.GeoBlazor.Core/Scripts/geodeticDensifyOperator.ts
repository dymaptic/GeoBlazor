// override generated code in this file
import GeodeticDensifyOperatorGenerated from './geodeticDensifyOperator.gb';
import geodeticDensifyOperator = __esri.geodeticDensifyOperator;

export default class GeodeticDensifyOperatorWrapper extends GeodeticDensifyOperatorGenerated {

    constructor(component: geodeticDensifyOperator) {
        super(component);
    }
    
}

export async function buildJsGeodeticDensifyOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeodeticDensifyOperatorGenerated } = await import('./geodeticDensifyOperator.gb');
    return await buildJsGeodeticDensifyOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeodeticDensifyOperator(jsObject: any): Promise<any> {
    let { buildDotNetGeodeticDensifyOperatorGenerated } = await import('./geodeticDensifyOperator.gb');
    return await buildDotNetGeodeticDensifyOperatorGenerated(jsObject);
}
