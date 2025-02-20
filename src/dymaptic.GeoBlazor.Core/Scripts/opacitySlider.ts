import OpacitySlider from '@arcgis/core/widgets/smartMapping/OpacitySlider';
import OpacitySliderGenerated from './opacitySlider.gb';

export default class OpacitySliderWrapper extends OpacitySliderGenerated {

    constructor(component: OpacitySlider) {
        super(component);
    }

}

export async function buildJsOpacitySlider(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsOpacitySliderGenerated} = await import('./opacitySlider.gb');
    return await buildJsOpacitySliderGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetOpacitySlider(jsObject: any): Promise<any> {
    let {buildDotNetOpacitySliderGenerated} = await import('./opacitySlider.gb');
    return await buildDotNetOpacitySliderGenerated(jsObject);
}
