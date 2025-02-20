import locator = __esri.locator;
import LocationServiceGenerated from './locationService.gb';

export default class LocationServiceWrapper extends LocationServiceGenerated {

    constructor(component: locator) {
        super(component);
    }

}

export async function buildJsLocationService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLocationServiceGenerated} = await import('./locationService.gb');
    return await buildJsLocationServiceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLocationService(jsObject: any): Promise<any> {
    let {buildDotNetLocationServiceGenerated} = await import('./locationService.gb');
    return await buildDotNetLocationServiceGenerated(jsObject);
}
