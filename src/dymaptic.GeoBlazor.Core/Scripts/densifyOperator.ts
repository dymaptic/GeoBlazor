// override generated code in this file
import DensifyOperatorGenerated from './densifyOperator.gb';
import densifyOperator = __esri.densifyOperator;

export default class DensifyOperatorWrapper extends DensifyOperatorGenerated {

    constructor(component: densifyOperator) {
        super(component);
    }
    
}

export async function buildJsDensifyOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDensifyOperatorGenerated } = await import('./densifyOperator.gb');
    return await buildJsDensifyOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDensifyOperator(jsObject: any): Promise<any> {
    let { buildDotNetDensifyOperatorGenerated } = await import('./densifyOperator.gb');
    return await buildDotNetDensifyOperatorGenerated(jsObject);
}
