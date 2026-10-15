// override generated code in this file
import FlowRendererGeneratorGenerated from './flowRendererGenerator.gb';
import flow = __esri.flow;

export default class FlowRendererGeneratorWrapper extends FlowRendererGeneratorGenerated {

    constructor(component: flow) {
        super(component);
    }
    
}

export async function buildJsFlowRendererGenerator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFlowRendererGeneratorGenerated } = await import('./flowRendererGenerator.gb');
    return await buildJsFlowRendererGeneratorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFlowRendererGenerator(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFlowRendererGeneratorGenerated } = await import('./flowRendererGenerator.gb');
    return await buildDotNetFlowRendererGeneratorGenerated(jsObject, layerId, viewId);
}
