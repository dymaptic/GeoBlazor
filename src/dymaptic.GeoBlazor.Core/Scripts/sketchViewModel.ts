import SketchViewModel from '@arcgis/core/widgets/Sketch/SketchViewModel';
import SketchViewModelGenerated from './sketchViewModel.gb';

export default class SketchViewModelWrapper extends SketchViewModelGenerated {

    constructor(component: SketchViewModel) {
        super(component);
    }

}

export async function buildJsSketchViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSketchViewModelGenerated} = await import('./sketchViewModel.gb');
    return await buildJsSketchViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSketchViewModel(jsObject: any): Promise<any> {
    let {buildDotNetSketchViewModelGenerated} = await import('./sketchViewModel.gb');
    return await buildDotNetSketchViewModelGenerated(jsObject);
}
