// override generated code in this file
import ISliceExcludedLayerGenerated from './iSliceExcludedLayer.gb';
import SliceExcludedLayer = __esri.SliceExcludedLayer;

export async function buildJsISliceExcludedLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsISliceExcludedLayerGenerated } = await import('./iSliceExcludedLayer.gb');
    return await buildJsISliceExcludedLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetISliceExcludedLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetISliceExcludedLayerGenerated } = await import('./iSliceExcludedLayer.gb');
    return await buildDotNetISliceExcludedLayerGenerated(jsObject, layerId, viewId);
}
