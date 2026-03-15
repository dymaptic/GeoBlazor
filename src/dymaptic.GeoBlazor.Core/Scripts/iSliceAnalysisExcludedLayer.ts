// override generated code in this file
import ISliceAnalysisExcludedLayerGenerated from './iSliceAnalysisExcludedLayer.gb';
import SliceAnalysisExcludedLayer = __esri.SliceAnalysisExcludedLayer;

export async function buildJsISliceAnalysisExcludedLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsISliceAnalysisExcludedLayerGenerated } = await import('./iSliceAnalysisExcludedLayer.gb');
    return await buildJsISliceAnalysisExcludedLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetISliceAnalysisExcludedLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetISliceAnalysisExcludedLayerGenerated } = await import('./iSliceAnalysisExcludedLayer.gb');
    return await buildDotNetISliceAnalysisExcludedLayerGenerated(jsObject, layerId, viewId);
}
