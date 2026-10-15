// override generated code in this file
import ColorSizeSliderWidgetGenerated from './colorSizeSliderWidget.gb';
import ColorSizeSlider from '@arcgis/core/widgets/smartMapping/ColorSizeSlider';

export default class ColorSizeSliderWidgetWrapper extends ColorSizeSliderWidgetGenerated {

    constructor(widget: ColorSizeSlider) {
        super(widget);
    }
    
}

export async function buildJsColorSizeSliderWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorSizeSliderWidgetGenerated } = await import('./colorSizeSliderWidget.gb');
    return await buildJsColorSizeSliderWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorSizeSliderWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetColorSizeSliderWidgetGenerated } = await import('./colorSizeSliderWidget.gb');
    return await buildDotNetColorSizeSliderWidgetGenerated(jsObject, layerId, viewId);
}
