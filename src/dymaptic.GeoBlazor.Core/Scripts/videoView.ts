// override generated code in this file
import VideoViewGenerated from './videoView.gb';
import VideoView = __esri.VideoView;

export default class VideoViewWrapper extends VideoViewGenerated {

    constructor(component: VideoView) {
        super(component);
    }
    
}

export async function buildJsVideoView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVideoViewGenerated } = await import('./videoView.gb');
    return await buildJsVideoViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVideoView(jsObject: any): Promise<any> {
    let { buildDotNetVideoViewGenerated } = await import('./videoView.gb');
    return await buildDotNetVideoViewGenerated(jsObject);
}
