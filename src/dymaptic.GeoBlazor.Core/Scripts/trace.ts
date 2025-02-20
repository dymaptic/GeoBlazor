// override generated code in this file
import TraceGenerated from './trace.gb';
import trace = __esri.trace;

export default class TraceWrapper extends TraceGenerated {

    constructor(component: trace) {
        super(component);
    }

}

export async function buildJsTrace(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTraceGenerated} = await import('./trace.gb');
    return await buildJsTraceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTrace(jsObject: any): Promise<any> {
    let {buildDotNetTraceGenerated} = await import('./trace.gb');
    return await buildDotNetTraceGenerated(jsObject);
}
