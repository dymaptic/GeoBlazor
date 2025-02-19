// override generated code in this file
import PortalQueryParamsGenerated from './portalQueryParams.gb';
import PortalQueryParams from '@arcgis/core/portal/PortalQueryParams';

export default class PortalQueryParamsWrapper extends PortalQueryParamsGenerated {

    constructor(component: PortalQueryParams) {
        super(component);
    }
    
}              
export async function buildJsPortalQueryParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPortalQueryParamsGenerated } = await import('./portalQueryParams.gb');
    return await buildJsPortalQueryParamsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetPortalQueryParams(jsObject: any): Promise<any> {
    let { buildDotNetPortalQueryParamsGenerated } = await import('./portalQueryParams.gb');
    return await buildDotNetPortalQueryParamsGenerated(jsObject);
}
