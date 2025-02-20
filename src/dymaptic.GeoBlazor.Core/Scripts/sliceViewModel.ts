import SliceViewModel from '@arcgis/core/widgets/Slice/SliceViewModel';
import SliceViewModelGenerated from './sliceViewModel.gb';

export default class SliceViewModelWrapper extends SliceViewModelGenerated {

    constructor(component: SliceViewModel) {
        super(component);
    }

}

export async function buildJsSliceViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSliceViewModelGenerated} = await import('./sliceViewModel.gb');
    return await buildJsSliceViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSliceViewModel(jsObject: any): Promise<any> {
    let {buildDotNetSliceViewModelGenerated} = await import('./sliceViewModel.gb');
    return await buildDotNetSliceViewModelGenerated(jsObject);
}
