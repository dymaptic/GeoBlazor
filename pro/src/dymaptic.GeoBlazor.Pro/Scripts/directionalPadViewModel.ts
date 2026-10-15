// override generated code in this file
import DirectionalPadViewModelGenerated from './directionalPadViewModel.gb';
import DirectionalPadViewModel from '@arcgis/core/widgets/DirectionalPad/DirectionalPadViewModel';

export default class DirectionalPadViewModelWrapper extends DirectionalPadViewModelGenerated {

    constructor(component: DirectionalPadViewModel) {
        super(component);
    }
    
}

export async function buildJsDirectionalPadViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDirectionalPadViewModelGenerated } = await import('./directionalPadViewModel.gb');
    return await buildJsDirectionalPadViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDirectionalPadViewModel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetDirectionalPadViewModelGenerated } = await import('./directionalPadViewModel.gb');
    return await buildDotNetDirectionalPadViewModelGenerated(jsObject, layerId, viewId);
}
