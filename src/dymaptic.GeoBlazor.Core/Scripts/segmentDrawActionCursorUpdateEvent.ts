// override generated code in this file
import SegmentDrawActionCursorUpdateEventGenerated from './segmentDrawActionCursorUpdateEvent.gb';
import SegmentDrawActionCursorUpdateEvent = __esri.SegmentDrawActionCursorUpdateEvent;

export default class SegmentDrawActionCursorUpdateEventWrapper extends SegmentDrawActionCursorUpdateEventGenerated {

    constructor(component: SegmentDrawActionCursorUpdateEvent) {
        super(component);
    }
    
}

export async function buildJsSegmentDrawActionCursorUpdateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSegmentDrawActionCursorUpdateEventGenerated } = await import('./segmentDrawActionCursorUpdateEvent.gb');
    return await buildJsSegmentDrawActionCursorUpdateEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSegmentDrawActionCursorUpdateEvent(jsObject: any): Promise<any> {
    let { buildDotNetSegmentDrawActionCursorUpdateEventGenerated } = await import('./segmentDrawActionCursorUpdateEvent.gb');
    return await buildDotNetSegmentDrawActionCursorUpdateEventGenerated(jsObject);
}
