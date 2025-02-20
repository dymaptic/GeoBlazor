// override generated code in this file
import RouteServiceGenerated from './routeService.gb';
import route = __esri.route;

export default class RouteServiceWrapper extends RouteServiceGenerated {

    constructor(component: route) {
        super(component);
    }

}

export async function buildJsRouteService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRouteServiceGenerated} = await import('./routeService.gb');
    return await buildJsRouteServiceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRouteService(jsObject: any): Promise<any> {
    let {buildDotNetRouteServiceGenerated} = await import('./routeService.gb');
    return await buildDotNetRouteServiceGenerated(jsObject);
}
