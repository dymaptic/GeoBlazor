import DirectionalPadViewModel from '@arcgis/core/widgets/DirectionalPad/DirectionalPadViewModel';
import DirectionalPadViewModelGenerated from './directionalPadViewModel.gb';

export default class DirectionalPadViewModelWrapper extends DirectionalPadViewModelGenerated {

    constructor(component: DirectionalPadViewModel) {
        super(component);
    }

}

export async function buildJsDirectionalPadViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsDirectionalPadViewModelGenerated} = await import('./directionalPadViewModel.gb');
    return await buildJsDirectionalPadViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetDirectionalPadViewModel(jsObject: any): Promise<any> {
    let {buildDotNetDirectionalPadViewModelGenerated} = await import('./directionalPadViewModel.gb');
    return await buildDotNetDirectionalPadViewModelGenerated(jsObject);
}
