// override generated code in this file
import GraphicBufferOperatorGenerated from './graphicBufferOperator.gb';
import graphicBufferOperator = __esri.graphicBufferOperator;

export default class GraphicBufferOperatorWrapper extends GraphicBufferOperatorGenerated {

    constructor(component: graphicBufferOperator) {
        super(component);
    }
    
}

export async function buildJsGraphicBufferOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGraphicBufferOperatorGenerated } = await import('./graphicBufferOperator.gb');
    return await buildJsGraphicBufferOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGraphicBufferOperator(jsObject: any): Promise<any> {
    let { buildDotNetGraphicBufferOperatorGenerated } = await import('./graphicBufferOperator.gb');
    return await buildDotNetGraphicBufferOperatorGenerated(jsObject);
}
