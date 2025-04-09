// override generated code in this file
import IEditorViewModelGetTemplatesForLayerGenerated from './iEditorViewModelGetTemplatesForLayer.gb';
import EditorViewModelGetTemplatesForLayer = __esri.EditorViewModelGetTemplatesForLayer;

export default class IEditorViewModelGetTemplatesForLayerWrapper extends IEditorViewModelGetTemplatesForLayerGenerated {

    constructor(layer: EditorViewModelGetTemplatesForLayer) {
        super(layer);
    }
    
}

export async function buildJsIEditorViewModelGetTemplatesForLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIEditorViewModelGetTemplatesForLayerGenerated } = await import('./iEditorViewModelGetTemplatesForLayer.gb');
    return await buildJsIEditorViewModelGetTemplatesForLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIEditorViewModelGetTemplatesForLayer(jsObject: any): Promise<any> {
    let { buildDotNetIEditorViewModelGetTemplatesForLayerGenerated } = await import('./iEditorViewModelGetTemplatesForLayer.gb');
    return await buildDotNetIEditorViewModelGetTemplatesForLayerGenerated(jsObject);
}
