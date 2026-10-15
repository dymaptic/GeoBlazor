// override generated code in this file
import EditorViewModelGenerated from './editorViewModel.gb';
import EditorViewModel from '@arcgis/core/widgets/Editor/EditorViewModel';
import {buildJsGraphic} from "./graphic";
import {Graphic} from './geoBlazorCore';

export default class EditorViewModelWrapper extends EditorViewModelGenerated {

    constructor(component: EditorViewModel) {
        super(component);
    }

    async deleteFeatures(): Promise<void> {
        await this.component.deleteFeatures();
    }

    async startUpdateFeaturesWorkflow(features: any[]): Promise<void> {
        let jsFeatures: Graphic[] = features.map(f => buildJsGraphic(f) as Graphic);
        await this.component.startUpdateFeaturesWorkflow(jsFeatures);
    }
}

export async function buildJsEditorViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEditorViewModelGenerated } = await import('./editorViewModel.gb');
    return await buildJsEditorViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEditorViewModel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetEditorViewModelGenerated } = await import('./editorViewModel.gb');
    return await buildDotNetEditorViewModelGenerated(jsObject, layerId, viewId);
}
