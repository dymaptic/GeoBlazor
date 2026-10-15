import {hasValue, lookupGeoBlazorGraphicId} from './geoBlazorCore';

export async function buildJsSketchDeleteEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSketchDeleteEventGenerated } = await import('./sketchDeleteEvent.gb');
    return await buildJsSketchDeleteEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSketchDeleteEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSketchDeleteEventGenerated } = await import('./sketchDeleteEvent.gb');
    let dnEvent = await buildDotNetSketchDeleteEventGenerated(jsObject, layerId, viewId);

    for (let i = 0; i < dnEvent.graphics.length; i++) {
        let graphic = dnEvent.graphics[i];
        graphic.id = lookupGeoBlazorGraphicId(jsObject.graphics[i]);
        if (!hasValue(graphic.id)) {
            throw new Error("Graphic not found!");
            graphic.id = crypto.randomUUID();
        }
    }
    
    return dnEvent;
}
