// override generated code in this file
import TraceJobInfoGenerated from './traceJobInfo.gb';
import TraceJobInfo from '@arcgis/core/networks/support/TraceJobInfo';

export default class TraceJobInfoWrapper extends TraceJobInfoGenerated {

    constructor(component: TraceJobInfo) {
        super(component);
    }
    
}

export async function buildJsTraceJobInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTraceJobInfoGenerated } = await import('./traceJobInfo.gb');
    return await buildJsTraceJobInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTraceJobInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTraceJobInfoGenerated } = await import('./traceJobInfo.gb');
    return await buildDotNetTraceJobInfoGenerated(jsObject, layerId, viewId);
}
