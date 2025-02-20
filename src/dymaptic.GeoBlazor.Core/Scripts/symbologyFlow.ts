import symbologyFlow = __esri.symbologyFlow;
import SymbologyFlowGenerated from './symbologyFlow.gb';

export default class SymbologyFlowWrapper extends SymbologyFlowGenerated {

    constructor(component: symbologyFlow) {
        super(component);
    }

}

export async function buildJsSymbologyFlow(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSymbologyFlowGenerated} = await import('./symbologyFlow.gb');
    return await buildJsSymbologyFlowGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSymbologyFlow(jsObject: any): Promise<any> {
    let {buildDotNetSymbologyFlowGenerated} = await import('./symbologyFlow.gb');
    return await buildDotNetSymbologyFlowGenerated(jsObject);
}
