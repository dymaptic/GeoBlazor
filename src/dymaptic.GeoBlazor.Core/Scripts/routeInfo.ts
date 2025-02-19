// override generated code in this file
import RouteInfoGenerated from './routeInfo.gb';
import RouteInfo from '@arcgis/core/rest/support/RouteInfo';

export default class RouteInfoWrapper extends RouteInfoGenerated {

    constructor(component: RouteInfo) {
        super(component);
    }
    
}

export async function buildJsRouteInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRouteInfoGenerated } = await import('./routeInfo.gb');
    return await buildJsRouteInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRouteInfo(jsObject: any): Promise<any> {
    let { buildDotNetRouteInfoGenerated } = await import('./routeInfo.gb');
    return await buildDotNetRouteInfoGenerated(jsObject);
}
