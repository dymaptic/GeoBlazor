import {hasValue, lookupGeoBlazorGraphicId} from './geoBlazorCore';

export async function buildJsSketchRedoEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSketchRedoEventGenerated } = await import('./sketchRedoEvent.gb');
    return await buildJsSketchRedoEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSketchRedoEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSketchRedoEventGenerated } = await import('./sketchRedoEvent.gb');
    let dnEvent = await buildDotNetSketchRedoEventGenerated(jsObject, layerId, viewId);

    for (let i = 0; i < dnEvent.graphics.length; i++) {
        let graphic = dnEvent.graphics[i];
        graphic.id = lookupGeoBlazorGraphicId(jsObject.graphics[i]);
        if (!hasValue(graphic.id)) {
            throw new Error("Graphic not found!");
        }
    }
    
    return dnEvent;
}
