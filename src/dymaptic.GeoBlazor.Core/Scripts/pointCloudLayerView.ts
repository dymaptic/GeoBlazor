import PointCloudLayerView from '@arcgis/core/views/layers/PointCloudLayerView';
import PointCloudLayerViewGenerated from './pointCloudLayerView.gb';

export default class PointCloudLayerViewWrapper extends PointCloudLayerViewGenerated {

    constructor(component: PointCloudLayerView) {
        super(component);
    }
    
}

export async function buildJsPointCloudLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPointCloudLayerViewGenerated } = await import('./pointCloudLayerView.gb');
    return await buildJsPointCloudLayerViewGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetPointCloudLayerView(jsObject: any): Promise<any> {
    let { buildDotNetPointCloudLayerViewGenerated } = await import('./pointCloudLayerView.gb');
    return await buildDotNetPointCloudLayerViewGenerated(jsObject);
}
