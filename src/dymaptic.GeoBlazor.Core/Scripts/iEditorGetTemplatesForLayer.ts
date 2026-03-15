// override generated code in this file
import IEditorGetTemplatesForLayerGenerated from './iEditorGetTemplatesForLayer.gb';
import EditorGetTemplatesForLayer = __esri.EditorGetTemplatesForLayer;

export async function buildJsIEditorGetTemplatesForLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIEditorGetTemplatesForLayerGenerated } = await import('./iEditorGetTemplatesForLayer.gb');
    return await buildJsIEditorGetTemplatesForLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIEditorGetTemplatesForLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetIEditorGetTemplatesForLayerGenerated } = await import('./iEditorGetTemplatesForLayer.gb');
    return await buildDotNetIEditorGetTemplatesForLayerGenerated(jsObject, layerId, viewId);
}
