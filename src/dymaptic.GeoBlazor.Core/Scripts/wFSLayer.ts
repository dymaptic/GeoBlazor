// override generated code in this file
import WFSLayerGenerated from './wFSLayer.gb';
import WFSLayer from '@arcgis/core/layers/WFSLayer';

export default class WFSLayerWrapper extends WFSLayerGenerated {

    constructor(layer: WFSLayer) {
        super(layer);
    }

    async getFeatureReduction(): Promise<any> {
        try {
            let jsFeatureReduction = this.layer.featureReduction;
            let { buildDotNetIFeatureReduction } = await import('./iFeatureReduction');
            return await buildDotNetIFeatureReduction(jsFeatureReduction);
        } catch (error) {
            throw new Error("Available only in GeoBlazor Pro. " + error);
        }
    }
    
    async setFeatureReduction(featureReduction: any) {
        let { buildJsIFeatureReduction } = await import('./iFeatureReduction');
        let jsFeatureReduction = await buildJsIFeatureReduction(featureReduction, this.layerId, this.viewId);
        this.layer.featureReduction = jsFeatureReduction;
    }

    async setSpatialReference(spatialReference: any): Promise<void> {
        let {buildJsSpatialReference} = await import('./spatialReference');
        this.layer.spatialReference = buildJsSpatialReference(spatialReference) as any;
    }
}

export async function buildJsWFSLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWFSLayerGenerated} = await import('./wFSLayer.gb');
    // simplify the object, it might have been loaded from the server and contain stuff that will break
    delete dotNetObject.wfsCapabilities;
    return await buildJsWFSLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWFSLayer(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetWFSLayerGenerated} = await import('./wFSLayer.gb');
    return await buildDotNetWFSLayerGenerated(jsObject, viewId);
}
