// override generated code in this file
import TransformationGenerated from './transformation.gb';
import Transformation from '@arcgis/core/geometry/operators/support/Transformation';

export default class TransformationWrapper extends TransformationGenerated {

    constructor(component: Transformation) {
        super(component);
    }
    
}

export async function buildJsTransformation(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTransformationGenerated } = await import('./transformation.gb');
    return await buildJsTransformationGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTransformation(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetTransformationGenerated } = await import('./transformation.gb');
    return await buildDotNetTransformationGenerated(jsObject, viewId);
}
