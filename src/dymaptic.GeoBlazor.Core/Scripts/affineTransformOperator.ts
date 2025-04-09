// override generated code in this file
import AffineTransformOperatorGenerated from './affineTransformOperator.gb';
import affineTransformOperator = __esri.affineTransformOperator;

export default class AffineTransformOperatorWrapper extends AffineTransformOperatorGenerated {

    constructor(component: affineTransformOperator) {
        super(component);
    }
    
}

export async function buildJsAffineTransformOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAffineTransformOperatorGenerated } = await import('./affineTransformOperator.gb');
    return await buildJsAffineTransformOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAffineTransformOperator(jsObject: any): Promise<any> {
    let { buildDotNetAffineTransformOperatorGenerated } = await import('./affineTransformOperator.gb');
    return await buildDotNetAffineTransformOperatorGenerated(jsObject);
}
