// override generated code in this file
import LayerListViewModelGenerated from './layerListViewModel.gb';
import LayerListViewModel from '@arcgis/core/widgets/LayerList/LayerListViewModel';

export default class LayerListViewModelWrapper extends LayerListViewModelGenerated {

    constructor(component: LayerListViewModel) {
        super(component);
    }
    
}

export async function buildJsLayerListViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerListViewModelGenerated } = await import('./layerListViewModel.gb');
    return await buildJsLayerListViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayerListViewModel(jsObject: any): Promise<any> {
    let { buildDotNetLayerListViewModelGenerated } = await import('./layerListViewModel.gb');
    return await buildDotNetLayerListViewModelGenerated(jsObject);
}
