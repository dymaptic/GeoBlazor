// override generated code in this file
import CatalogUtilsGenerated from './catalogUtils.gb';
import catalogUtils = __esri.catalogUtils;

export default class CatalogUtilsWrapper extends CatalogUtilsGenerated {

    constructor(component: catalogUtils) {
        super(component);
    }
    
}

export async function buildJsCatalogUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCatalogUtilsGenerated } = await import('./catalogUtils.gb');
    return await buildJsCatalogUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCatalogUtils(jsObject: any): Promise<any> {
    let { buildDotNetCatalogUtilsGenerated } = await import('./catalogUtils.gb');
    return await buildDotNetCatalogUtilsGenerated(jsObject);
}
