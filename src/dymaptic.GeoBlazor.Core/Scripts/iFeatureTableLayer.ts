// override generated code in this file
import IFeatureTableLayerGenerated from './iFeatureTableLayer.gb';
import FeatureTableLayer from '@arcgis/core/layers/Layer';

export async function buildJsIFeatureTableLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIFeatureTableLayerGenerated } = await import('./iFeatureTableLayer.gb');
    return await buildJsIFeatureTableLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIFeatureTableLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetIFeatureTableLayerGenerated } = await import('./iFeatureTableLayer.gb');
    return await buildDotNetIFeatureTableLayerGenerated(jsObject, layerId, viewId);
}
