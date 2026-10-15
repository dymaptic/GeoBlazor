// override generated code in this file
import PlacesServiceGenerated from './placesService.gb';
import places = __esri.places;

export default class PlacesServiceWrapper extends PlacesServiceGenerated {

    constructor(component: places) {
        super(component);
    }
    
}

export async function buildJsPlacesService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPlacesServiceGenerated } = await import('./placesService.gb');
    return await buildJsPlacesServiceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPlacesService(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPlacesServiceGenerated } = await import('./placesService.gb');
    return await buildDotNetPlacesServiceGenerated(jsObject, layerId, viewId);
}
