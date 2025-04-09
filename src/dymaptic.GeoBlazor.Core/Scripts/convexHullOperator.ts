// override generated code in this file
import ConvexHullOperatorGenerated from './convexHullOperator.gb';
import convexHullOperator = __esri.convexHullOperator;

export default class ConvexHullOperatorWrapper extends ConvexHullOperatorGenerated {

    constructor(component: convexHullOperator) {
        super(component);
    }
    
}

export async function buildJsConvexHullOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsConvexHullOperatorGenerated } = await import('./convexHullOperator.gb');
    return await buildJsConvexHullOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetConvexHullOperator(jsObject: any): Promise<any> {
    let { buildDotNetConvexHullOperatorGenerated } = await import('./convexHullOperator.gb');
    return await buildDotNetConvexHullOperatorGenerated(jsObject);
}
