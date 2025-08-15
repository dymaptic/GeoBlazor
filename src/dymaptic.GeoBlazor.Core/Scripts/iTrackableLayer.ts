// override generated code in this file
import ITrackableLayerGenerated from './iTrackableLayer.gb';
import TrackableLayer = __esri.TrackableLayer;

export async function buildJsITrackableLayer(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsITrackableLayerGenerated } = await import('./iTrackableLayer.gb');
    return await buildJsITrackableLayerGenerated(dotNetObject, viewId);
}     

export async function buildDotNetITrackableLayer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetITrackableLayerGenerated } = await import('./iTrackableLayer.gb');
    return await buildDotNetITrackableLayerGenerated(jsObject, viewId);
}
