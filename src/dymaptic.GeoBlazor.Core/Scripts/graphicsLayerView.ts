// override generated code in this file
import GraphicsLayerViewGenerated from './graphicsLayerView.gb';
import GraphicsLayerView from '@arcgis/core/views/layers/GraphicsLayerView';

export default class GraphicsLayerViewWrapper extends GraphicsLayerViewGenerated {

    constructor(component: GraphicsLayerView) {
        super(component);
    }
    
}

export async function buildJsGraphicsLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGraphicsLayerViewGenerated } = await import('./graphicsLayerView.gb');
    return await buildJsGraphicsLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGraphicsLayerView(jsObject: any): Promise<any> {
    let { buildDotNetGraphicsLayerViewGenerated } = await import('./graphicsLayerView.gb');
    return await buildDotNetGraphicsLayerViewGenerated(jsObject);
}
