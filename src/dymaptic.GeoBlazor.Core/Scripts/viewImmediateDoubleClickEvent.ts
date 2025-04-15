import ViewImmediateDoubleClickEventGenerated from './viewImmediateDoubleClickEvent.gb';
export async function buildJsViewImmediateDoubleClickEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsViewImmediateDoubleClickEventGenerated} = await import('./viewImmediateDoubleClickEvent.gb');
    return await buildJsViewImmediateDoubleClickEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetViewImmediateDoubleClickEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetViewImmediateDoubleClickEventGenerated} = await import('./viewImmediateDoubleClickEvent.gb');
    return await buildDotNetViewImmediateDoubleClickEventGenerated(jsObject, layerId, viewId);
}

    constructor(component: ViewImmediateDoubleClickEvent) {
        super(component);
    }
    
}


export default class ViewImmediateDoubleClickEventWrapper extends ViewImmediateDoubleClickEventGenerated {

    constructor(component: ViewImmediateDoubleClickEvent) {
        super(component);
    }
    
}

