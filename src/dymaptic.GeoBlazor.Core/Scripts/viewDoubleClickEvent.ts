import ViewDoubleClickEventGenerated from './viewDoubleClickEvent.gb';
export async function buildJsViewDoubleClickEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsViewDoubleClickEventGenerated} = await import('./viewDoubleClickEvent.gb');
    return await buildJsViewDoubleClickEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetViewDoubleClickEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetViewDoubleClickEventGenerated} = await import('./viewDoubleClickEvent.gb');
    return await buildDotNetViewDoubleClickEventGenerated(jsObject, layerId, viewId);
}

export default class ViewDoubleClickEventWrapper extends ViewDoubleClickEventGenerated {

    constructor(component: ViewDoubleClickEvent) {
        super(component);
    }
    
}

