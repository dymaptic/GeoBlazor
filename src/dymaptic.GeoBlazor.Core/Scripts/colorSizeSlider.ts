// override generated code in this file
import ColorSizeSliderGenerated from './colorSizeSlider.gb';
import ColorSizeSlider from '@arcgis/core/widgets/smartMapping/ColorSizeSlider';

export default class ColorSizeSliderWrapper extends ColorSizeSliderGenerated {

    constructor(component: ColorSizeSlider) {
        super(component);
    }
    
}

export async function buildJsColorSizeSlider(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorSizeSliderGenerated } = await import('./colorSizeSlider.gb');
    return await buildJsColorSizeSliderGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorSizeSlider(jsObject: any): Promise<any> {
    let { buildDotNetColorSizeSliderGenerated } = await import('./colorSizeSlider.gb');
    return await buildDotNetColorSizeSliderGenerated(jsObject);
}
