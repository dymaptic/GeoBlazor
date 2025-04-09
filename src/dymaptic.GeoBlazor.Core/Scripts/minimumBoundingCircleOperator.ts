// override generated code in this file
import MinimumBoundingCircleOperatorGenerated from './minimumBoundingCircleOperator.gb';
import minimumBoundingCircleOperator = __esri.minimumBoundingCircleOperator;

export default class MinimumBoundingCircleOperatorWrapper extends MinimumBoundingCircleOperatorGenerated {

    constructor(component: minimumBoundingCircleOperator) {
        super(component);
    }
    
}

export async function buildJsMinimumBoundingCircleOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMinimumBoundingCircleOperatorGenerated } = await import('./minimumBoundingCircleOperator.gb');
    return await buildJsMinimumBoundingCircleOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMinimumBoundingCircleOperator(jsObject: any): Promise<any> {
    let { buildDotNetMinimumBoundingCircleOperatorGenerated } = await import('./minimumBoundingCircleOperator.gb');
    return await buildDotNetMinimumBoundingCircleOperatorGenerated(jsObject);
}
