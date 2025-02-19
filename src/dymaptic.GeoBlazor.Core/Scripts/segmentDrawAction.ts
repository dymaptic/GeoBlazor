// override generated code in this file
import SegmentDrawActionGenerated from './segmentDrawAction.gb';
import SegmentDrawAction = __esri.SegmentDrawAction;

export default class SegmentDrawActionWrapper extends SegmentDrawActionGenerated {

    constructor(component: SegmentDrawAction) {
        super(component);
    }
    
}

export async function buildJsSegmentDrawAction(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSegmentDrawActionGenerated } = await import('./segmentDrawAction.gb');
    return await buildJsSegmentDrawActionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSegmentDrawAction(jsObject: any): Promise<any> {
    let { buildDotNetSegmentDrawActionGenerated } = await import('./segmentDrawAction.gb');
    return await buildDotNetSegmentDrawActionGenerated(jsObject);
}
