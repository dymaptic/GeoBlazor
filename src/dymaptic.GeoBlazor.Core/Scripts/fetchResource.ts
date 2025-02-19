// override generated code in this file
import FetchResourceGenerated from './fetchResource.gb';
import FetchResource = __esri.FetchResource;

export default class FetchResourceWrapper extends FetchResourceGenerated {

    constructor(component: FetchResource) {
        super(component);
    }
    
}              
export async function buildJsFetchResource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFetchResourceGenerated } = await import('./fetchResource.gb');
    return await buildJsFetchResourceGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetFetchResource(jsObject: any): Promise<any> {
    let { buildDotNetFetchResourceGenerated } = await import('./fetchResource.gb');
    return await buildDotNetFetchResourceGenerated(jsObject);
}
