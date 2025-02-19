import CollectionEvent = __esri.CollectionEvent;
import CollectionEventGenerated from './collectionEvent.gb';

export default class CollectionEventWrapper extends CollectionEventGenerated {

    constructor(component: CollectionEvent) {
        super(component);
    }
    
}

export async function buildJsCollectionEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCollectionEventGenerated } = await import('./collectionEvent.gb');
    return await buildJsCollectionEventGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetCollectionEvent(jsObject: any): Promise<any> {
    let { buildDotNetCollectionEventGenerated } = await import('./collectionEvent.gb');
    return await buildDotNetCollectionEventGenerated(jsObject);
}
