// override generated code in this file
import ImageryLayerViewGenerated from './imageryLayerView.gb';
import ImageryLayerView from '@arcgis/core/views/layers/ImageryLayerView';

export default class ImageryLayerViewWrapper extends ImageryLayerViewGenerated {

    constructor(component: ImageryLayerView) {
        super(component);
    }
    
}

export async function buildJsImageryLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageryLayerViewGenerated } = await import('./imageryLayerView.gb');
    return await buildJsImageryLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetImageryLayerView(jsObject: any): Promise<any> {
    let { buildDotNetImageryLayerViewGenerated } = await import('./imageryLayerView.gb');
    return await buildDotNetImageryLayerViewGenerated(jsObject);
}
