// override generated code in this file
import BasemapLayerListViewModelGenerated from './basemapLayerListViewModel.gb';
import BasemapLayerListViewModel from '@arcgis/core/widgets/BasemapLayerList/BasemapLayerListViewModel';

export default class BasemapLayerListViewModelWrapper extends BasemapLayerListViewModelGenerated {

    constructor(component: BasemapLayerListViewModel) {
        super(component);
    }
    
}

export async function buildJsBasemapLayerListViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBasemapLayerListViewModelGenerated } = await import('./basemapLayerListViewModel.gb');
    return await buildJsBasemapLayerListViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBasemapLayerListViewModel(jsObject: any): Promise<any> {
    let { buildDotNetBasemapLayerListViewModelGenerated } = await import('./basemapLayerListViewModel.gb');
    return await buildDotNetBasemapLayerListViewModelGenerated(jsObject);
}
