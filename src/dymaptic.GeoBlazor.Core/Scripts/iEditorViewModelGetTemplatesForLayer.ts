// override generated code in this file
import IEditorViewModelGetTemplatesForLayerGenerated from './iEditorViewModelGetTemplatesForLayer.gb';
import EditorViewModelGetTemplatesForLayer = __esri.EditorViewModelGetTemplatesForLayer;

export async function buildJsIEditorViewModelGetTemplatesForLayer(dotNetObject: any): Promise<any> {
    let { buildJsIEditorViewModelGetTemplatesForLayerGenerated } = await import('./iEditorViewModelGetTemplatesForLayer.gb');
    return await buildJsIEditorViewModelGetTemplatesForLayerGenerated(dotNetObject);
}     

export async function buildDotNetIEditorViewModelGetTemplatesForLayer(jsObject: any): Promise<any> {
    let { buildDotNetIEditorViewModelGetTemplatesForLayerGenerated } = await import('./iEditorViewModelGetTemplatesForLayer.gb');
    return await buildDotNetIEditorViewModelGetTemplatesForLayerGenerated(jsObject);
}
