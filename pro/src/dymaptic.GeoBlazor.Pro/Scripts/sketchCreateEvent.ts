import {graphicsRefs, hasValue, lookupGeoBlazorGraphicId} from './geoBlazorCore';

export async function buildJsSketchCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSketchCreateEventGenerated } = await import('./sketchCreateEvent.gb');
    return await buildJsSketchCreateEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSketchCreateEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSketchCreateEventGenerated } = await import('./sketchCreateEvent.gb');
    let dnEvent = await buildDotNetSketchCreateEventGenerated(jsObject, layerId, viewId);
    if (dnEvent.state === 'complete') {
        dnEvent.graphic.id = lookupGeoBlazorGraphicId(jsObject.graphic);
        if (!hasValue(dnEvent.graphic.id)) {
            dnEvent.graphic.id = crypto.randomUUID();
            if (!graphicsRefs.hasOwnProperty(layerId!)) {
                graphicsRefs[layerId!] = {};
            }
            graphicsRefs[layerId!][dnEvent.graphic.id] = dnEvent.graphic;
        }
    }
    return dnEvent;
}
