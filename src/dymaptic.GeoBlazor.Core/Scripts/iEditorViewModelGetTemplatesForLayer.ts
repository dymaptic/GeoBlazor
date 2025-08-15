// override generated code in this file
import IEditorViewModelGetTemplatesForLayerGenerated from './iEditorViewModelGetTemplatesForLayer.gb';
import EditorViewModelGetTemplatesForLayer = __esri.EditorViewModelGetTemplatesForLayer;

export async function buildJsIEditorViewModelGetTemplatesForLayer(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIEditorViewModelGetTemplatesForLayerGenerated } = await import('./iEditorViewModelGetTemplatesForLayer.gb');
    return await buildJsIEditorViewModelGetTemplatesForLayerGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIEditorViewModelGetTemplatesForLayer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIEditorViewModelGetTemplatesForLayerGenerated } = await import('./iEditorViewModelGetTemplatesForLayer.gb');
    return await buildDotNetIEditorViewModelGetTemplatesForLayerGenerated(jsObject, viewId);
}
