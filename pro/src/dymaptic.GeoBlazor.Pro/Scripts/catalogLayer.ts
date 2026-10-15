import CatalogLayer from '@arcgis/core/layers/CatalogLayer';
// override generated code in this file
import CatalogLayerGenerated from './catalogLayer.gb';
import {buildEncodedJson, hasValue} from "./geoBlazorCore";

export default class CatalogLayerWrapper extends CatalogLayerGenerated {

    constructor(layer: CatalogLayer) {
        super(layer);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        let dotNetLayer = await buildDotNetCatalogLayer(result, this.layerId, this.viewId);
        return buildEncodedJson(dotNetLayer);
    }
    async setOrderBy(value: any): Promise<void> {
        if (!hasValue(value)) {
            this.layer.orderBy = [];
        }
        let { buildJsOrderByInfo } = await import('./orderByInfo');
        this.layer.orderBy = await Promise.all(value.map(async i => await buildJsOrderByInfo(i, this.layerId, this.viewId))) as any;
    }
    async setSpatialReference(spatialReference: any): Promise<void> {
        let {buildJsSpatialReference} = await import('./spatialReference');
        this.layer.spatialReference = buildJsSpatialReference(spatialReference) as any;
    }
    
}

export async function buildJsCatalogLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCatalogLayerGenerated } = await import('./catalogLayer.gb');
    return await buildJsCatalogLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCatalogLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCatalogLayerGenerated } = await import('./catalogLayer.gb');
    return await buildDotNetCatalogLayerGenerated(jsObject, layerId, viewId);
}
