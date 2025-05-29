import ViewDragEventGenerated from './viewDragEvent.gb';

export async function buildJsViewDragEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewDragEventGenerated } = await import('./viewDragEvent.gb');
    return await buildJsViewDragEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetViewDragEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetViewDragEventGenerated } = await import('./viewDragEvent.gb');
    return await buildDotNetViewDragEventGenerated(jsObject, layerId, viewId);
}

    constructor(component: ViewDragEvent) {
        super(component);
    }
    
}


export default class ViewDragEventWrapper extends ViewDragEventGenerated {

    constructor(component: ViewDragEvent) {
        super(component);
    }
    
}

