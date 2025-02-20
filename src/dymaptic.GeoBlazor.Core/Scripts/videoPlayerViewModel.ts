// override generated code in this file
import VideoPlayerViewModelGenerated from './videoPlayerViewModel.gb';
import VideoPlayerViewModel from '@arcgis/core/widgets/VideoPlayer/VideoPlayerViewModel';

export default class VideoPlayerViewModelWrapper extends VideoPlayerViewModelGenerated {

    constructor(component: VideoPlayerViewModel) {
        super(component);
    }

}

export async function buildJsVideoPlayerViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsVideoPlayerViewModelGenerated} = await import('./videoPlayerViewModel.gb');
    return await buildJsVideoPlayerViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetVideoPlayerViewModel(jsObject: any): Promise<any> {
    let {buildDotNetVideoPlayerViewModelGenerated} = await import('./videoPlayerViewModel.gb');
    return await buildDotNetVideoPlayerViewModelGenerated(jsObject);
}
