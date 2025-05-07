// override generated code in this file
import MultipointDrawActionVertexRemoveEventGenerated from './multipointDrawActionVertexRemoveEvent.gb';
import MultipointDrawActionVertexRemoveEvent = __esri.MultipointDrawActionVertexRemoveEvent;

export default class MultipointDrawActionVertexRemoveEventWrapper extends MultipointDrawActionVertexRemoveEventGenerated {

    constructor(component: MultipointDrawActionVertexRemoveEvent) {
        super(component);
    }
    
}

export async function buildJsMultipointDrawActionVertexRemoveEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMultipointDrawActionVertexRemoveEventGenerated } = await import('./multipointDrawActionVertexRemoveEvent.gb');
    return await buildJsMultipointDrawActionVertexRemoveEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMultipointDrawActionVertexRemoveEvent(jsObject: any): Promise<any> {
    let { buildDotNetMultipointDrawActionVertexRemoveEventGenerated } = await import('./multipointDrawActionVertexRemoveEvent.gb');
    return await buildDotNetMultipointDrawActionVertexRemoveEventGenerated(jsObject);
}
