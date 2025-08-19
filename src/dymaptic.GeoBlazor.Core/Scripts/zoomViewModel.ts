import ZoomViewModel from '@arcgis/core/widgets/Zoom/ZoomViewModel';
import ZoomViewModelGenerated from './zoomViewModel.gb';

export default class ZoomViewModelWrapper extends ZoomViewModelGenerated {

    constructor(component: ZoomViewModel) {
        super(component);
    }

}

export async function buildJsZoomViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsZoomViewModelGenerated} = await import('./zoomViewModel.gb');
    return await buildJsZoomViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetZoomViewModel(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetZoomViewModelGenerated} = await import('./zoomViewModel.gb');
    return await buildDotNetZoomViewModelGenerated(jsObject, viewId);
}
