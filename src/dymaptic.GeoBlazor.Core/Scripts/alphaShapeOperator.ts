// override generated code in this file
import AlphaShapeOperatorGenerated from './alphaShapeOperator.gb';
import alphaShapeOperator = __esri.alphaShapeOperator;

export default class AlphaShapeOperatorWrapper extends AlphaShapeOperatorGenerated {

    constructor(component: alphaShapeOperator) {
        super(component);
    }
    
}

export async function buildJsAlphaShapeOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAlphaShapeOperatorGenerated } = await import('./alphaShapeOperator.gb');
    return await buildJsAlphaShapeOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAlphaShapeOperator(jsObject: any): Promise<any> {
    let { buildDotNetAlphaShapeOperatorGenerated } = await import('./alphaShapeOperator.gb');
    return await buildDotNetAlphaShapeOperatorGenerated(jsObject);
}
