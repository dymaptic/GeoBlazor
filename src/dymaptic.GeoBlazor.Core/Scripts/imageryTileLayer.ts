import ImageryTileLayer from '@arcgis/core/layers/ImageryTileLayer';
import {buildDotNetExtent, buildDotNetFeatureSet, buildDotNetSpatialReference} from './dotNetBuilder';
import {hasValue} from './arcGisJsInterop';
import {buildJsImageryRenderer} from './jsBuilder';
import {IPropertyWrapper} from './definitions';

export default class ImageryTileLayerWrapper implements IPropertyWrapper {
    public layer: ImageryTileLayer;

    constructor(layer: ImageryTileLayer) {
        this.layer = layer;
        // set all properties from layer
        for (let prop in layer) {
            if (layer.hasOwnProperty(prop)) {
                this[prop] = layer[prop];
            }
        }
    }

    unwrap() {
        return this.layer;
    }
    async load(options: AbortSignal): Promise<void> {
        await this.layer.load(options);
    }

    getServiceRasterInfo(viewId: string) {
        let jsInfo = this.layer.serviceRasterInfo;
        return {
            attributeTable: hasValue(jsInfo.attributeTable) ? buildDotNetFeatureSet(jsInfo.attributeTable, viewId) : null,
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

    setProperty(prop, value) {
        this.layer[prop] = value;
    }

    getProperty(prop: string) {
        return this.layer[prop];
    }

    addToProperty(prop: string, value: any) {
        if (Array.isArray(value)) {
            this.layer[prop].addMany(value);
        } else {
            this.layer[prop].add(value);
        }
    }

    removeFromProperty(prop: string, value: any) {
        if (Array.isArray(value)) {
            this.layer[prop].removeMany(value);
        } else {
            this.layer[prop].remove(value);
        }
    }
}
