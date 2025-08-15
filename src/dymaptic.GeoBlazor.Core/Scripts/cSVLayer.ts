// override generated code in this file
import CSVLayerGenerated from './cSVLayer.gb';
import CSVLayer from '@arcgis/core/layers/CSVLayer';

export default class CSVLayerWrapper extends CSVLayerGenerated {

    constructor(layer: CSVLayer) {
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

export async function buildJsCSVLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCSVLayerGenerated} = await import('./cSVLayer.gb');
    return await buildJsCSVLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCSVLayer(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetCSVLayerGenerated} = await import('./cSVLayer.gb');
    return await buildDotNetCSVLayerGenerated(jsObject, viewId);
}
