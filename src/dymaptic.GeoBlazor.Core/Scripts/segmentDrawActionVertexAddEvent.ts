// override generated code in this file
import SegmentDrawActionVertexAddEventGenerated from './segmentDrawActionVertexAddEvent.gb';
import SegmentDrawActionVertexAddEvent = __esri.SegmentDrawActionVertexAddEvent;

export default class SegmentDrawActionVertexAddEventWrapper extends SegmentDrawActionVertexAddEventGenerated {

    constructor(component: SegmentDrawActionVertexAddEvent) {
        super(component);
    }
    
}

export async function buildJsSegmentDrawActionVertexAddEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSegmentDrawActionVertexAddEventGenerated } = await import('./segmentDrawActionVertexAddEvent.gb');
    return await buildJsSegmentDrawActionVertexAddEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSegmentDrawActionVertexAddEvent(jsObject: any): Promise<any> {
    let { buildDotNetSegmentDrawActionVertexAddEventGenerated } = await import('./segmentDrawActionVertexAddEvent.gb');
    return await buildDotNetSegmentDrawActionVertexAddEventGenerated(jsObject);
}
