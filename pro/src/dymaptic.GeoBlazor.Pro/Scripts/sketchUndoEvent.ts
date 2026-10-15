import {hasValue, lookupGeoBlazorGraphicId} from './geoBlazorCore';

export async function buildJsSketchUndoEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSketchUndoEventGenerated } = await import('./sketchUndoEvent.gb');
    return await buildJsSketchUndoEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSketchUndoEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSketchUndoEventGenerated } = await import('./sketchUndoEvent.gb');
    let dnEvent = await buildDotNetSketchUndoEventGenerated(jsObject, layerId, viewId);

    for (let i = 0; i < dnEvent.graphics.length; i++) {
        let graphic = dnEvent.graphics[i];
        graphic.id = lookupGeoBlazorGraphicId(jsObject.graphics[i]);
        if (!hasValue(graphic.id)) {
            throw new Error("Graphic not found!");
        }
    }
    
    return dnEvent;
}
