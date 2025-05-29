// override generated code in this file
import UIGenerated from './uI.gb';
import UI from '@arcgis/core/views/ui/UI';

export default class UIWrapper extends UIGenerated {

    constructor(component: UI) {
        super(component);
    }
    
}

export async function buildJsUI(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUIGenerated } = await import('./uI.gb');
    return await buildJsUIGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUI(jsObject: any): Promise<any> {
    let { buildDotNetUIGenerated } = await import('./uI.gb');
    return await buildDotNetUIGenerated(jsObject);
}
