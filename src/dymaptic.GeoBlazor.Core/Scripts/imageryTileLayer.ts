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


    getServiceRasterInfo(viewId: string) {
        let jsInfo = this.layer.serviceRasterInfo;
        return {
            attributeTable: hasValue(jsInfo.attributeTable) ? buildDotNetFeatureSet(jsInfo.attributeTable, null, viewId) : null,
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
