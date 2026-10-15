import {hasValue, lookupGeoBlazorGraphicId} from './geoBlazorCore';

export async function buildJsSketchUpdateEvent(dotNetObject: any): Promise<any> {
    let { buildJsSketchUpdateEventGenerated } = await import('./sketchUpdateEvent.gb');
    return await buildJsSketchUpdateEventGenerated(dotNetObject);
}     

export async function buildDotNetSketchUpdateEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSketchUpdateEventGenerated } = await import('./sketchUpdateEvent.gb');
    let dnEvent = await buildDotNetSketchUpdateEventGenerated(jsObject, layerId, viewId);
    for (let i = 0; i < dnEvent.graphics.length; i++) {
        let graphic = dnEvent.graphics[i];
        graphic.id = lookupGeoBlazorGraphicId(jsObject.graphics[i]);
        if (!hasValue(graphic.id)) {
            throw new Error("Graphic not found!");
        }
    }
    return dnEvent;
}
