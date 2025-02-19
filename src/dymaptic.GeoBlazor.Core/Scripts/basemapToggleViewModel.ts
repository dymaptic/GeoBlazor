import BasemapToggleViewModel from '@arcgis/core/widgets/BasemapToggle/BasemapToggleViewModel';
import BasemapToggleViewModelGenerated from './basemapToggleViewModel.gb';

export default class BasemapToggleViewModelWrapper extends BasemapToggleViewModelGenerated {

    constructor(component: BasemapToggleViewModel) {
        super(component);
    }
    
}

export async function buildJsBasemapToggleViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBasemapToggleViewModelGenerated } = await import('./basemapToggleViewModel.gb');
    return await buildJsBasemapToggleViewModelGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetBasemapToggleViewModel(jsObject: any): Promise<any> {
    let { buildDotNetBasemapToggleViewModelGenerated } = await import('./basemapToggleViewModel.gb');
    return await buildDotNetBasemapToggleViewModelGenerated(jsObject);
}
