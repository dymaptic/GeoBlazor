import ImageryTileLayerGenerated from './imageryTileLayer.gb';
import ImageryTileLayer from '@arcgis/core/layers/ImageryTileLayer';
import {buildEncodedJson, hasValue} from './geoBlazorCore';
import {buildDotNetSpatialReference} from './spatialReference';
import {buildDotNetExtent} from './extent';

export default class ImageryTileLayerWrapper extends ImageryTileLayerGenerated {

    constructor(layer: ImageryTileLayer) {
        super(layer);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        let dotNetLayer = await buildDotNetImageryTileLayer(result, this.layerId, this.viewId);
        return buildEncodedJson(dotNetLayer);
    }

    async getServiceRasterInfo() {
        let jsInfo = this.layer.serviceRasterInfo;

        if (!hasValue(jsInfo) || !jsInfo) {
            return null;
        }
        let {buildDotNetFeatureSet} = await import('./featureSet');
        return {
            attributeTable: hasValue(jsInfo.attributeTable)
                ? await buildDotNetFeatureSet(jsInfo.attributeTable, null, this.viewId)
                : null,
            bandCount: jsInfo.bandCount,
            bandInfos: jsInfo.bandInfos,
            colormap: jsInfo.colormap,
            dataType: jsInfo.dataType,
            extent: buildDotNetExtent(jsInfo.extent),
            hasMultidimensionalTranspose: jsInfo.hasMultidimensionalTranspose,
            height: jsInfo.height,
            histograms: jsInfo.histograms,
            keyProperties: jsInfo.keyProperties,
            multidimensionalInfo: jsInfo.multidimensionalInfo,
            noDataValue: jsInfo.noDataValue,
            pixelSize: jsInfo.pixelSize,
            pixelType: jsInfo.pixelType,
            sensorInfo: jsInfo.sensorInfo,
            spatialReference: buildDotNetSpatialReference(jsInfo.spatialReference),
            statistics: jsInfo.statistics,
            width: jsInfo.width
        };
    }

    async setRenderer(renderer: any) {
        let {buildJsImageryRenderer} = await import('./imageryRenderer');
        this.layer.renderer = await buildJsImageryRenderer(renderer, this.layerId, this.viewId) as any;
    }

}

export async function buildJsImageryTileLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageryTileLayerGenerated} = await import('./imageryTileLayer.gb');
    let jsObject = await buildJsImageryTileLayerGenerated(dotNetObject, layerId, viewId);
    
    if (hasValue(dotNetObject.renderer)) {
        let {buildJsImageryRenderer} = await import('./imageryRenderer');
        jsObject.renderer = await buildJsImageryRenderer(dotNetObject.renderer, layerId, viewId);
    }
    
    return jsObject;
}

export async function buildDotNetImageryTileLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetImageryTileLayerGenerated} = await import('./imageryTileLayer.gb');
    let dnObject = await buildDotNetImageryTileLayerGenerated(jsObject, layerId, viewId);
    
    if (hasValue(jsObject.renderer)) {
        let {buildDotNetImageryRenderer} = await import('./imageryRenderer');
        dnObject.renderer = await buildDotNetImageryRenderer(jsObject.renderer, viewId);
    }
    
    return dnObject;
}
