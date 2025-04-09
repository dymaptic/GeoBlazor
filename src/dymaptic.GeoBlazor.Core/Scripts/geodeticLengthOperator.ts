// override generated code in this file
import GeodeticLengthOperatorGenerated from './geodeticLengthOperator.gb';
import geodeticLengthOperator = __esri.geodeticLengthOperator;

export default class GeodeticLengthOperatorWrapper extends GeodeticLengthOperatorGenerated {

    constructor(component: geodeticLengthOperator) {
        super(component);
    }
    
}

export async function buildJsGeodeticLengthOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeodeticLengthOperatorGenerated } = await import('./geodeticLengthOperator.gb');
    return await buildJsGeodeticLengthOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeodeticLengthOperator(jsObject: any): Promise<any> {
    let { buildDotNetGeodeticLengthOperatorGenerated } = await import('./geodeticLengthOperator.gb');
    return await buildDotNetGeodeticLengthOperatorGenerated(jsObject);
}
