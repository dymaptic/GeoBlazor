// override generated code in this file
import LocationGenerated from './location.gb';
import location = __esri.location;

export default class LocationWrapper extends LocationGenerated {

    constructor(component: location) {
        super(component);
    }

}

export async function buildJsLocation(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLocationGenerated} = await import('./location.gb');
    return await buildJsLocationGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLocation(jsObject: any): Promise<any> {
    let {buildDotNetLocationGenerated} = await import('./location.gb');
    return await buildDotNetLocationGenerated(jsObject);
}
