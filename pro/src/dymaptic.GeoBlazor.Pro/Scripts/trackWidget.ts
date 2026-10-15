import TrackWidgetGenerated from './trackWidget.gb';
import {buildJsStreamReference} from './geoBlazorCore';

export default class TrackWidgetWrapper extends TrackWidgetGenerated {

    constructor(widget) {
        super(widget);
    }

    isTracking(): boolean {
        return this.widget.tracking;
    }

    start() {
        this.widget.start();
    }

    stop() {
        this.widget.stop();
    }
}


export async function buildJsTrackWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTrackWidgetGenerated } = await import('./trackWidget.gb');
    let jsTrack = await buildJsTrackWidgetGenerated(dotNetObject, layerId, viewId);
    let eventRateLimit = dotNetObject.eventRateLimitInMilliseconds;
    let trackTimeoutId: number | undefined;
    jsTrack.on('track', async (evt: any) => {
        clearTimeout(trackTimeoutId);
        trackTimeoutId = setTimeout(async (ev, dnObject) => {
            requestAnimationFrame(async () => {
                let streamRef = buildJsStreamReference(ev ?? {});
                await dnObject.dotNetComponentReference.invokeMethodAsync('OnJsTrack', streamRef);
            })
        }, eventRateLimit, evt, dotNetObject);
        
    });
    
    return jsTrack;
}

export async function buildDotNetTrackWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTrackWidgetGenerated } = await import('./trackWidget.gb');
    return await buildDotNetTrackWidgetGenerated(jsObject, layerId, viewId);
}
