// override generated code in this file
import ViewshedLayerViewGenerated from './viewshedLayerView.gb';
import ViewshedLayerView from '@arcgis/core/views/layers/ViewshedLayerView';

export default class ViewshedLayerViewWrapper extends ViewshedLayerViewGenerated {

    constructor(component: ViewshedLayerView) {
        super(component);
    }
    
}

export async function buildJsViewshedLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewshedLayerViewGenerated } = await import('./viewshedLayerView.gb');
    return await buildJsViewshedLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetViewshedLayerView(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetViewshedLayerViewGenerated } = await import('./viewshedLayerView.gb');
    return await buildDotNetViewshedLayerViewGenerated(jsObject, viewId);
}
