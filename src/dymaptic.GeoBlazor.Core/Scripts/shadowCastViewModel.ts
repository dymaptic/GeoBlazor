import ShadowCastViewModel from '@arcgis/core/widgets/ShadowCast/ShadowCastViewModel';
import ShadowCastViewModelGenerated from './shadowCastViewModel.gb';

export default class ShadowCastViewModelWrapper extends ShadowCastViewModelGenerated {

    constructor(component: ShadowCastViewModel) {
        super(component);
    }

}

export async function buildJsShadowCastViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsShadowCastViewModelGenerated} = await import('./shadowCastViewModel.gb');
    return await buildJsShadowCastViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetShadowCastViewModel(jsObject: any): Promise<any> {
    let {buildDotNetShadowCastViewModelGenerated} = await import('./shadowCastViewModel.gb');
    return await buildDotNetShadowCastViewModelGenerated(jsObject);
}
