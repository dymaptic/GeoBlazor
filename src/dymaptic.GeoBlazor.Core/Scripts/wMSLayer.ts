// override generated code in this file
import WMSLayerGenerated from './wMSLayer.gb';
import WMSLayer from '@arcgis/core/layers/WMSLayer';
import {hasValue} from './arcGisJsInterop';

export default class WMSLayerWrapper extends WMSLayerGenerated {

    constructor(layer: WMSLayer) {
        super(layer);
    }

    async setSpatialReference(spatialReference: any): Promise<void> {
        let {buildJsSpatialReference} = await import('./spatialReference');
        this.layer.spatialReference = buildJsSpatialReference(spatialReference) as any;
    }
}

export async function buildJsWMSLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWMSLayerGenerated} = await import('./wMSLayer.gb');
    let jsWmsLayer = await buildJsWMSLayerGenerated(dotNetObject, layerId, viewId);
    if (hasValue(dotNetObject.sublayers) && dotNetObject.sublayers.length > 0) {
        // reload the selected sublayers to get all details from the server
        let currentJsSublayers = jsWmsLayer.sublayers;
        jsWmsLayer.sublayers = [];
        for (let sublayer of dotNetObject.sublayers) {
            // find by name
            let jsSublayer = jsWmsLayer.findSublayerByName(sublayer.name);
            if (!hasValue(jsSublayer)) {
                // find by id
                jsSublayer = jsWmsLayer.findSublayerById(sublayer.wMSSublayerId);
            }
            if (!hasValue(jsSublayer)) {
                // find in current sublayers by name
                jsSublayer = currentJsSublayers.find(s => s.name === sublayer.name);
            }
            
            jsWmsLayer.sublayers.push(jsSublayer);
        }
    }
    
    return jsWmsLayer;
}

export async function buildDotNetWMSLayer(jsObject: any): Promise<any> {
    let {buildDotNetWMSLayerGenerated} = await import('./wMSLayer.gb');
    return await buildDotNetWMSLayerGenerated(jsObject);
}
