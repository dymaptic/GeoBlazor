// override generated code in this file
import ViewPointerEnterEventGenerated from './viewPointerEnterEvent.gb';
import ViewPointerEnterEvent = __esri.ViewPointerEnterEvent;

export default class ViewPointerEnterEventWrapper extends ViewPointerEnterEventGenerated {

    constructor(component: ViewPointerEnterEvent) {
        super(component);
    }
    
}

export async function buildJsViewPointerEnterEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewPointerEnterEventGenerated } = await import('./viewPointerEnterEvent.gb');
    return await buildJsViewPointerEnterEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetViewPointerEnterEvent(jsObject: any): Promise<any> {
    let { buildDotNetViewPointerEnterEventGenerated } = await import('./viewPointerEnterEvent.gb');
    return await buildDotNetViewPointerEnterEventGenerated(jsObject);
}
