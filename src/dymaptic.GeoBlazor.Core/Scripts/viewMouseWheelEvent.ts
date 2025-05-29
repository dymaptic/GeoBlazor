// override generated code in this file
import ViewMouseWheelEventGenerated from './viewMouseWheelEvent.gb';
import ViewMouseWheelEvent = __esri.ViewMouseWheelEvent;

export default class ViewMouseWheelEventWrapper extends ViewMouseWheelEventGenerated {

    constructor(component: ViewMouseWheelEvent) {
        super(component);
    }
    
}

export async function buildJsViewMouseWheelEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewMouseWheelEventGenerated } = await import('./viewMouseWheelEvent.gb');
    return await buildJsViewMouseWheelEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetViewMouseWheelEvent(jsObject: any): Promise<any> {
    let { buildDotNetViewMouseWheelEventGenerated } = await import('./viewMouseWheelEvent.gb');
    return await buildDotNetViewMouseWheelEventGenerated(jsObject);
}
