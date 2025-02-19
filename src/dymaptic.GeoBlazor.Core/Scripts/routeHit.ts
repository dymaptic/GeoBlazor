// override generated code in this file
import RouteHitGenerated from './routeHit.gb';
import RouteHit = __esri.RouteHit;

export default class RouteHitWrapper extends RouteHitGenerated {

    constructor(component: RouteHit) {
        super(component);
    }
    
}

export async function buildJsRouteHit(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRouteHitGenerated } = await import('./routeHit.gb');
    return await buildJsRouteHitGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRouteHit(jsObject: any): Promise<any> {
    let { buildDotNetRouteHitGenerated } = await import('./routeHit.gb');
    return await buildDotNetRouteHitGenerated(jsObject);
}
