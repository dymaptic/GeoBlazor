import LocateViewModel from '@arcgis/core/widgets/Locate/LocateViewModel';
import LocateViewModelGenerated from './locateViewModel.gb';

export default class LocateViewModelWrapper extends LocateViewModelGenerated {

    constructor(component: LocateViewModel) {
        super(component);
    }

}

export async function buildJsLocateViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLocateViewModelGenerated} = await import('./locateViewModel.gb');
    return await buildJsLocateViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLocateViewModel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetLocateViewModelGenerated} = await import('./locateViewModel.gb');
    return await buildDotNetLocateViewModelGenerated(jsObject, layerId, viewId);
}
