// override generated code in this file
import WMTSLayerGenerated from './wMTSLayer.gb';
import WMTSLayer from '@arcgis/core/layers/WMTSLayer';
import {hasValue} from "./arcGisJsInterop";

export default class WMTSLayerWrapper extends WMTSLayerGenerated {

    constructor(layer: WMTSLayer) {
        super(layer);
    }

    async updateComponent(dotNetObject: any): Promise<void> {
        if (hasValue(dotNetObject.activeLayer) && dotNetObject.activeLayer.wMTSSublayerId !== this.layer.activeLayer.id) {
            let { buildJsWMTSSublayer } = await import('./wMTSSublayer');
            this.layer.activeLayer = await buildJsWMTSSublayer(dotNetObject.activeLayer, this.layerId, this.viewId) as any;
        }
        if (hasValue(dotNetObject.effect)) {
            let { buildJsEffect } = await import('./effect');
            this.layer.effect = buildJsEffect(dotNetObject.effect) as any;
        }
        if (hasValue(dotNetObject.fullExtent)) {
            let { buildJsExtent } = await import('./extent');
            this.layer.fullExtent = buildJsExtent(dotNetObject.fullExtent) as any;
        }
        if (hasValue(dotNetObject.sublayers) && dotNetObject.sublayers.length > 0) {
            let { buildJsWMTSSublayer } = await import('./wMTSSublayer');
            this.layer.sublayers = await Promise.all(dotNetObject.sublayers.map(async i => await buildJsWMTSSublayer(i, this.layerId, this.viewId))) as any;
        }
        if (hasValue(dotNetObject.visibilityTimeExtent)) {
            let { buildJsTimeExtent } = await import('./timeExtent');
            this.layer.visibilityTimeExtent = await buildJsTimeExtent(dotNetObject.visibilityTimeExtent) as any;
        }
        if (hasValue(dotNetObject.blendMode)) {
            this.layer.blendMode = dotNetObject.blendMode;
        }
        if (hasValue(dotNetObject.customLayerParameters)) {
            this.layer.customLayerParameters = dotNetObject.customLayerParameters;
        }
        if (hasValue(dotNetObject.customParameters)) {
            this.layer.customParameters = dotNetObject.customParameters;
        }
        if (hasValue(dotNetObject.listMode)) {
            this.layer.listMode = dotNetObject.listMode;
        }
        if (hasValue(dotNetObject.opacity)) {
            this.layer.opacity = dotNetObject.opacity;
        }
        if (hasValue(dotNetObject.visible)) {
            this.layer.visible = dotNetObject.visible;
        }
    }

}

export async function buildJsWMTSLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWMTSLayerGenerated} = await import('./wMTSLayer.gb');
    return await buildJsWMTSLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWMTSLayer(jsObject: any): Promise<any> {
    let {buildDotNetWMTSLayerGenerated} = await import('./wMTSLayer.gb');
    return await buildDotNetWMTSLayerGenerated(jsObject);
}
