import TrackViewModel from '@arcgis/core/widgets/Track/TrackViewModel';
import TrackViewModelGenerated from './trackViewModel.gb';

export default class TrackViewModelWrapper extends TrackViewModelGenerated {

    constructor(component: TrackViewModel) {
        super(component);
    }
    
}

export async function buildJsTrackViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTrackViewModelGenerated } = await import('./trackViewModel.gb');
    return await buildJsTrackViewModelGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetTrackViewModel(jsObject: any): Promise<any> {
    let { buildDotNetTrackViewModelGenerated } = await import('./trackViewModel.gb');
    return await buildDotNetTrackViewModelGenerated(jsObject);
}
