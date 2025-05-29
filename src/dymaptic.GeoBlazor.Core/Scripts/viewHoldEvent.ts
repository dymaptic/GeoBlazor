import ViewHoldEventGenerated from './viewHoldEvent.gb';
export async function buildJsViewHoldEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsViewHoldEventGenerated} = await import('./viewHoldEvent.gb');
    return await buildJsViewHoldEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetViewHoldEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetViewHoldEventGenerated} = await import('./viewHoldEvent.gb');
    return await buildDotNetViewHoldEventGenerated(jsObject, layerId, viewId);
}

    constructor(component: ViewHoldEvent) {
        super(component);
    }
    
}


export default class ViewHoldEventWrapper extends ViewHoldEventGenerated {

    constructor(component: ViewHoldEvent) {
        super(component);
    }
    
}

