// override generated code in this file
import BasemapGalleryViewModelGenerated from './basemapGalleryViewModel.gb';
import BasemapGalleryViewModel from '@arcgis/core/widgets/BasemapGallery/BasemapGalleryViewModel';

export default class BasemapGalleryViewModelWrapper extends BasemapGalleryViewModelGenerated {

    constructor(component: BasemapGalleryViewModel) {
        super(component);
    }
    
}

export async function buildJsBasemapGalleryViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBasemapGalleryViewModelGenerated } = await import('./basemapGalleryViewModel.gb');
    return await buildJsBasemapGalleryViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBasemapGalleryViewModel(jsObject: any): Promise<any> {
    let { buildDotNetBasemapGalleryViewModelGenerated } = await import('./basemapGalleryViewModel.gb');
    return await buildDotNetBasemapGalleryViewModelGenerated(jsObject);
}
