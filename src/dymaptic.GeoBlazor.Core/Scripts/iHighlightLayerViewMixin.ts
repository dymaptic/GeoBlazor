import HighlightLayerViewMixin from '@arcgis/core/views/layers/HighlightLayerViewMixin';
import IHighlightLayerViewMixinGenerated from './iHighlightLayerViewMixin.gb';

export default class IHighlightLayerViewMixinWrapper extends IHighlightLayerViewMixinGenerated {

    constructor(component: HighlightLayerViewMixin) {
        super(component);
    }

}

export async function buildJsIHighlightLayerViewMixin(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsIHighlightLayerViewMixinGenerated} = await import('./iHighlightLayerViewMixin.gb');
    return await buildJsIHighlightLayerViewMixinGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetIHighlightLayerViewMixin(jsObject: any): Promise<any> {
    let {buildDotNetIHighlightLayerViewMixinGenerated} = await import('./iHighlightLayerViewMixin.gb');
    return await buildDotNetIHighlightLayerViewMixinGenerated(jsObject);
}
