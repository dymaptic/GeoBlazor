// override generated code in this file
import FullscreenViewModelGenerated from './fullscreenViewModel.gb';
import FullscreenViewModel from '@arcgis/core/widgets/Fullscreen/FullscreenViewModel';

export default class FullscreenViewModelWrapper extends FullscreenViewModelGenerated {

    constructor(component: FullscreenViewModel) {
        super(component);
    }
    
}

export async function buildJsFullscreenViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFullscreenViewModelGenerated } = await import('./fullscreenViewModel.gb');
    return await buildJsFullscreenViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFullscreenViewModel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFullscreenViewModelGenerated } = await import('./fullscreenViewModel.gb');
    return await buildDotNetFullscreenViewModelGenerated(jsObject, layerId, viewId);
}
