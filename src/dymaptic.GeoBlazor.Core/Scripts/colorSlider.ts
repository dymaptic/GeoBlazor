// override generated code in this file
import ColorSliderGenerated from './colorSlider.gb';
import ColorSlider from '@arcgis/core/widgets/smartMapping/ColorSlider';

export default class ColorSliderWrapper extends ColorSliderGenerated {

    constructor(component: ColorSlider) {
        super(component);
    }
    
}

export async function buildJsColorSlider(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorSliderGenerated } = await import('./colorSlider.gb');
    return await buildJsColorSliderGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorSlider(jsObject: any): Promise<any> {
    let { buildDotNetColorSliderGenerated } = await import('./colorSlider.gb');
    return await buildDotNetColorSliderGenerated(jsObject);
}
