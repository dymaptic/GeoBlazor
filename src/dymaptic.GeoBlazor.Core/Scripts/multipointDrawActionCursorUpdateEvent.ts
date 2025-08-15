// override generated code in this file
import MultipointDrawActionCursorUpdateEventGenerated from './multipointDrawActionCursorUpdateEvent.gb';
import MultipointDrawActionCursorUpdateEvent = __esri.MultipointDrawActionCursorUpdateEvent;

export default class MultipointDrawActionCursorUpdateEventWrapper extends MultipointDrawActionCursorUpdateEventGenerated {

    constructor(component: MultipointDrawActionCursorUpdateEvent) {
        super(component);
    }
    
}

export async function buildJsMultipointDrawActionCursorUpdateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMultipointDrawActionCursorUpdateEventGenerated } = await import('./multipointDrawActionCursorUpdateEvent.gb');
    return await buildJsMultipointDrawActionCursorUpdateEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMultipointDrawActionCursorUpdateEvent(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetMultipointDrawActionCursorUpdateEventGenerated } = await import('./multipointDrawActionCursorUpdateEvent.gb');
    return await buildDotNetMultipointDrawActionCursorUpdateEventGenerated(jsObject, viewId);
}
