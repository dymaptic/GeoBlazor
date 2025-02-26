// override generated code in this file
import WFSLayerViewGenerated from './wFSLayerView.gb';
import WFSLayerView from '@arcgis/core/views/layers/WFSLayerView';

export default class WFSLayerViewWrapper extends WFSLayerViewGenerated {

    constructor(component: WFSLayerView) {
        super(component);
    }
    
}

export async function buildJsWFSLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWFSLayerViewGenerated } = await import('./wFSLayerView.gb');
    return await buildJsWFSLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWFSLayerView(jsObject: any): Promise<any> {
    let { buildDotNetWFSLayerViewGenerated } = await import('./wFSLayerView.gb');
    return await buildDotNetWFSLayerViewGenerated(jsObject);
}
