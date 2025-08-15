// override generated code in this file
import MultipointDrawActionUndoEventGenerated from './multipointDrawActionUndoEvent.gb';
import MultipointDrawActionUndoEvent = __esri.MultipointDrawActionUndoEvent;

export default class MultipointDrawActionUndoEventWrapper extends MultipointDrawActionUndoEventGenerated {

    constructor(component: MultipointDrawActionUndoEvent) {
        super(component);
    }
    
}

export async function buildJsMultipointDrawActionUndoEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMultipointDrawActionUndoEventGenerated } = await import('./multipointDrawActionUndoEvent.gb');
    return await buildJsMultipointDrawActionUndoEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMultipointDrawActionUndoEvent(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetMultipointDrawActionUndoEventGenerated } = await import('./multipointDrawActionUndoEvent.gb');
    return await buildDotNetMultipointDrawActionUndoEventGenerated(jsObject, viewId);
}
