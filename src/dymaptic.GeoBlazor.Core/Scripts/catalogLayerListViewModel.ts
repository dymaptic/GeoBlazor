import CatalogLayerListViewModel from '@arcgis/core/widgets/CatalogLayerList/CatalogLayerListViewModel';
import CatalogLayerListViewModelGenerated from './catalogLayerListViewModel.gb';

export default class CatalogLayerListViewModelWrapper extends CatalogLayerListViewModelGenerated {

    constructor(component: CatalogLayerListViewModel) {
        super(component);
    }
    
}

export async function buildJsCatalogLayerListViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCatalogLayerListViewModelGenerated } = await import('./catalogLayerListViewModel.gb');
    return await buildJsCatalogLayerListViewModelGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetCatalogLayerListViewModel(jsObject: any): Promise<any> {
    let { buildDotNetCatalogLayerListViewModelGenerated } = await import('./catalogLayerListViewModel.gb');
    return await buildDotNetCatalogLayerListViewModelGenerated(jsObject);
}
