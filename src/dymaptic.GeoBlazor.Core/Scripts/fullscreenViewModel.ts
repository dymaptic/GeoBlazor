import FullscreenViewModel from '@arcgis/core/widgets/Fullscreen/FullscreenViewModel';
import FullscreenViewModelGenerated from './fullscreenViewModel.gb';

export default class FullscreenViewModelWrapper extends FullscreenViewModelGenerated {

    constructor(component: FullscreenViewModel) {
        super(component);
    }
    
}

export async function buildJsFullscreenViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFullscreenViewModelGenerated } = await import('./fullscreenViewModel.gb');
    return await buildJsFullscreenViewModelGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetFullscreenViewModel(jsObject: any): Promise<any> {
    let { buildDotNetFullscreenViewModelGenerated } = await import('./fullscreenViewModel.gb');
    return await buildDotNetFullscreenViewModelGenerated(jsObject);
}
