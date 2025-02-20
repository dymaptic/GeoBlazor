import EditorViewModel from '@arcgis/core/widgets/Editor/EditorViewModel';
import EditorViewModelGenerated from './editorViewModel.gb';

export default class EditorViewModelWrapper extends EditorViewModelGenerated {

    constructor(component: EditorViewModel) {
        super(component);
    }

}

export async function buildJsEditorViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsEditorViewModelGenerated} = await import('./editorViewModel.gb');
    return await buildJsEditorViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetEditorViewModel(jsObject: any): Promise<any> {
    let {buildDotNetEditorViewModelGenerated} = await import('./editorViewModel.gb');
    return await buildDotNetEditorViewModelGenerated(jsObject);
}
