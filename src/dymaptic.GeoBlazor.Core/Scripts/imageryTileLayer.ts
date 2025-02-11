import ImageryTileLayerGenerated from './imageryTileLayer.gb';
import ImageryTileLayer from '@arcgis/core/layers/ImageryTileLayer';
import {buildDotNetExtent, buildDotNetFeatureSet, buildDotNetSpatialReference} from './dotNetBuilder';
import {hasValue} from './arcGisJsInterop';
import {buildJsImageryRenderer} from './jsBuilder';
import {IPropertyWrapper} from './definitions';

export default class ImageryTileLayerWrapper extends ImageryTileLayerGenerated {

    constructor(layer: ImageryTileLayer) {
        super(layer);
    }


    getServiceRasterInfo() {
        let jsInfo = this.layer.serviceRasterInfo;
        if (!hasValue(jsInfo)) {
            return null;
        }
        return {
            attributeTable: hasValue(jsInfo.attributeTable) ? buildDotNetFeatureSet(jsInfo.attributeTable, null, this.viewId) : null,
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
    
    setRenderer(renderer: any) {
        this.layer.renderer = buildJsImageryRenderer(renderer) as any;
    }




}
export async function buildJsImageryTileLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageryTileLayerGenerated } = await import('./imageryTileLayer.gb');
    return await buildJsImageryTileLayerGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetImageryTileLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetImageryTileLayerGenerated } = await import('./imageryTileLayer.gb');
    return await buildDotNetImageryTileLayerGenerated(jsObject, layerId, viewId);
}
