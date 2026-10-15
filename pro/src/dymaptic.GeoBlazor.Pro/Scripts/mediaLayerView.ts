import MediaLayerView from '@arcgis/core/views/layers/MediaLayerView';
import MediaLayerViewGenerated from './mediaLayerView.gb';

export async function buildJsMediaLayerView(dotNetObject: any): Promise<any> {
    let { buildJsMediaLayerViewGenerated } = await import('./mediaLayerView.gb');
    return await buildJsMediaLayerViewGenerated(dotNetObject);
}     

export async function buildDotNetMediaLayerView(jsObject: any): Promise<any> {
    let { buildDotNetMediaLayerViewGenerated } = await import('./mediaLayerView.gb');
    return await buildDotNetMediaLayerViewGenerated(jsObject);
}


export default class MediaLayerViewWrapper extends MediaLayerViewGenerated {

    constructor(component: MediaLayerView) {
        super(component);
    }
    
}

