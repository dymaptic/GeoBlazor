// override generated code in this file
import HandlesGenerated from './handles.gb';
import Handles from '@arcgis/core/core/Handles';

export default class HandlesWrapper extends HandlesGenerated {

    constructor(component: Handles) {
        super(component);
    }
    
}

export async function buildJsHandles(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHandlesGenerated } = await import('./handles.gb');
    return await buildJsHandlesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHandles(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetHandlesGenerated } = await import('./handles.gb');
    return await buildDotNetHandlesGenerated(jsObject, layerId, viewId);
}
