// override generated code in this file
import ShadowCastViewModelGenerated from './shadowCastViewModel.gb';
import ShadowCastViewModel from '@arcgis/core/widgets/ShadowCast/ShadowCastViewModel';

export default class ShadowCastViewModelWrapper extends ShadowCastViewModelGenerated {

    constructor(component: ShadowCastViewModel) {
        super(component);
    }
    
}

export async function buildJsShadowCastViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsShadowCastViewModelGenerated } = await import('./shadowCastViewModel.gb');
    return await buildJsShadowCastViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetShadowCastViewModel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetShadowCastViewModelGenerated } = await import('./shadowCastViewModel.gb');
    return await buildDotNetShadowCastViewModelGenerated(jsObject, layerId, viewId);
}
