// override generated code in this file
import ShapePreservingProjectOperatorGenerated from './shapePreservingProjectOperator.gb';
import shapePreservingProjectOperator = __esri.shapePreservingProjectOperator;

export default class ShapePreservingProjectOperatorWrapper extends ShapePreservingProjectOperatorGenerated {

    constructor(component: shapePreservingProjectOperator) {
        super(component);
    }
    
}

export async function buildJsShapePreservingProjectOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsShapePreservingProjectOperatorGenerated } = await import('./shapePreservingProjectOperator.gb');
    return await buildJsShapePreservingProjectOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetShapePreservingProjectOperator(jsObject: any): Promise<any> {
    let { buildDotNetShapePreservingProjectOperatorGenerated } = await import('./shapePreservingProjectOperator.gb');
    return await buildDotNetShapePreservingProjectOperatorGenerated(jsObject);
}
