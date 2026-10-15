// override generated code in this file
import StreamLayerViewGenerated from './streamLayerView.gb';
import StreamLayerView from '@arcgis/core/views/layers/StreamLayerView';

export default class StreamLayerViewWrapper extends StreamLayerViewGenerated {

    constructor(component: StreamLayerView) {
        super(component);
    }
    
}

export async function buildJsStreamLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsStreamLayerViewGenerated } = await import('./streamLayerView.gb');
    return await buildJsStreamLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetStreamLayerView(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetStreamLayerViewGenerated } = await import('./streamLayerView.gb');
    return await buildDotNetStreamLayerViewGenerated(jsObject, layerId, viewId);
}
