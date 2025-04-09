// override generated code in this file
import SegmentDrawActionDrawCompleteEventGenerated from './segmentDrawActionDrawCompleteEvent.gb';
import SegmentDrawActionDrawCompleteEvent = __esri.SegmentDrawActionDrawCompleteEvent;

export default class SegmentDrawActionDrawCompleteEventWrapper extends SegmentDrawActionDrawCompleteEventGenerated {

    constructor(component: SegmentDrawActionDrawCompleteEvent) {
        super(component);
    }
    
}

export async function buildJsSegmentDrawActionDrawCompleteEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSegmentDrawActionDrawCompleteEventGenerated } = await import('./segmentDrawActionDrawCompleteEvent.gb');
    return await buildJsSegmentDrawActionDrawCompleteEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSegmentDrawActionDrawCompleteEvent(jsObject: any): Promise<any> {
    let { buildDotNetSegmentDrawActionDrawCompleteEventGenerated } = await import('./segmentDrawActionDrawCompleteEvent.gb');
    return await buildDotNetSegmentDrawActionDrawCompleteEventGenerated(jsObject);
}
