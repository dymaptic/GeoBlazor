// override generated code in this file
import ImageryTileLayerViewGenerated from './imageryTileLayerView.gb';
import ImageryTileLayerView from '@arcgis/core/views/layers/ImageryTileLayerView';

export default class ImageryTileLayerViewWrapper extends ImageryTileLayerViewGenerated {

    constructor(component: ImageryTileLayerView) {
        super(component);
    }
    
}

export async function buildJsImageryTileLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageryTileLayerViewGenerated } = await import('./imageryTileLayerView.gb');
    return await buildJsImageryTileLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetImageryTileLayerView(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetImageryTileLayerViewGenerated } = await import('./imageryTileLayerView.gb');
    return await buildDotNetImageryTileLayerViewGenerated(jsObject, viewId);
}
