// override generated code in this file
import TraceServiceGenerated from './traceService.gb';
import trace = __esri.trace;

export default class TraceServiceWrapper extends TraceServiceGenerated {

    constructor(component: trace) {
        super(component);
    }
    
}

export async function buildJsTraceService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTraceServiceGenerated } = await import('./traceService.gb');
    return await buildJsTraceServiceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTraceService(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTraceServiceGenerated } = await import('./traceService.gb');
    return await buildDotNetTraceServiceGenerated(jsObject, layerId, viewId);
}
