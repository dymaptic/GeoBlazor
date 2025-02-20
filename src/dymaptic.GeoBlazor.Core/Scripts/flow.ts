// override generated code in this file
import FlowGenerated from './flow.gb';
import flow = __esri.flow;

export default class FlowWrapper extends FlowGenerated {

    constructor(component: flow) {
        super(component);
    }

}

export async function buildJsFlow(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFlowGenerated} = await import('./flow.gb');
    return await buildJsFlowGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFlow(jsObject: any): Promise<any> {
    let {buildDotNetFlowGenerated} = await import('./flow.gb');
    return await buildDotNetFlowGenerated(jsObject);
}
