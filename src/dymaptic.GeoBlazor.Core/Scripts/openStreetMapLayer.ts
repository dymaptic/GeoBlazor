// override generated code in this file

// Workaround for ESRI OpenStreetMapLayer issue with custom urlTemplate
// See: https://github.com/Esri/jsapi-resources/issues/562
// This bypasses the typical path used in other layers due to a known limitation
// If ESRI fixes this in a future release, we can remove this logic

import OpenStreetMapLayerGenerated from './openStreetMapLayer.gb';
import OpenStreetMapLayer from '@arcgis/core/layers/OpenStreetMapLayer';
import {buildEncodedJson, copyValuesIfExists, hasValue} from "./geoBlazorCore";


export default class OpenStreetMapLayerWrapper extends OpenStreetMapLayerGenerated {

    constructor(layer: OpenStreetMapLayer) {
        super(layer);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        let dotNetLayer = await buildDotNetOpenStreetMapLayer(result, this.viewId);
        return buildEncodedJson(dotNetLayer);
    }
}


export async function buildJsOpenStreetMapLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    const { buildJsOpenStreetMapLayerGenerated } = await import('./openStreetMapLayer.gb');

    const hasUrlTemplate = await prepareUrlTemplate(dotNetObject);

    const osmLayer = await buildJsOpenStreetMapLayerGenerated(dotNetObject, layerId, viewId)

    if (hasUrlTemplate) {
        return createWebTileLayerFromOsmLayer(dotNetObject, layerId, viewId, osmLayer);
    }

    return osmLayer;
}

export async function buildDotNetOpenStreetMapLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetOpenStreetMapLayerGenerated } = await import('./openStreetMapLayer.gb');
    return await buildDotNetOpenStreetMapLayerGenerated(jsObject, layerId, viewId);
}

async function prepareUrlTemplate(dotNetObject: any): Promise<boolean> {
    if (!hasValue(dotNetObject.urlTemplate)) {
        return false;
    }

    dotNetObject.extraData = {
        urlTemplate: dotNetObject.urlTemplate,
        subDomains: dotNetObject.subDomains,
    };

    dotNetObject.urlTemplate = null;
    dotNetObject.subDomains = null;
    return true;
}

async function createWebTileLayerFromOsmLayer(
    dotNetObject: any,
    layerId: string | null,
    viewId: string | null,
    osmLayer: any
) {
    const { buildJsWebTileLayerGenerated } = await import('./webTileLayer.gb');

    dotNetObject.type = 'web-tile';
    dotNetObject.urlTemplate = dotNetObject.extraData!.urlTemplate;
    dotNetObject.subDomains = dotNetObject.extraData!.subDomains;
    delete dotNetObject.extraData;

    const webTileLayer = await buildJsWebTileLayerGenerated(dotNetObject, layerId, viewId);

    copyValuesIfExists(osmLayer, webTileLayer,
        'blendMode',
        'copyright',
        'maxScale',
        'minScale',
        'fullExtent'
    );

    return webTileLayer;
}
