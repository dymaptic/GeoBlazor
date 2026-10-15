// override generated code in this file
import VideoPlayerWidgetGenerated from './videoPlayerWidget.gb';
import VideoPlayer from '@arcgis/core/widgets/VideoPlayer';

export default class VideoPlayerWidgetWrapper extends VideoPlayerWidgetGenerated {

    constructor(widget: VideoPlayer) {
        super(widget);
    }
    
}

export async function buildJsVideoPlayerWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVideoPlayerWidgetGenerated } = await import('./videoPlayerWidget.gb');
    return await buildJsVideoPlayerWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVideoPlayerWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVideoPlayerWidgetGenerated } = await import('./videoPlayerWidget.gb');
    return await buildDotNetVideoPlayerWidgetGenerated(jsObject, layerId, viewId);
}
