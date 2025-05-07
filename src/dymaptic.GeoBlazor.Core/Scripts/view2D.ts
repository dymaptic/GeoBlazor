// override generated code in this file
import View2DGenerated from './view2D.gb';
import View2D from '@arcgis/core/views/View2D';

export default class View2DWrapper extends View2DGenerated {

    constructor(component: View2D) {
        super(component);
    }
    
}

export async function buildJsView2D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsView2DGenerated } = await import('./view2D.gb');
    return await buildJsView2DGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetView2D(jsObject: any): Promise<any> {
    let { buildDotNetView2DGenerated } = await import('./view2D.gb');
    return await buildDotNetView2DGenerated(jsObject);
}
