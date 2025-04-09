// override generated code in this file
import CollectionBeforeRemoveEventGenerated from './collectionBeforeRemoveEvent.gb';
import CollectionBeforeRemoveEvent = __esri.CollectionBeforeRemoveEvent;

export default class CollectionBeforeRemoveEventWrapper extends CollectionBeforeRemoveEventGenerated {

    constructor(component: CollectionBeforeRemoveEvent) {
        super(component);
    }
    
}

export async function buildJsCollectionBeforeRemoveEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCollectionBeforeRemoveEventGenerated } = await import('./collectionBeforeRemoveEvent.gb');
    return await buildJsCollectionBeforeRemoveEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCollectionBeforeRemoveEvent(jsObject: any): Promise<any> {
    let { buildDotNetCollectionBeforeRemoveEventGenerated } = await import('./collectionBeforeRemoveEvent.gb');
    return await buildDotNetCollectionBeforeRemoveEventGenerated(jsObject);
}
