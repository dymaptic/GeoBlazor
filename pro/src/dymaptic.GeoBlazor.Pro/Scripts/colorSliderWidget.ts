// override generated code in this file
import ColorSliderWidgetGenerated from './colorSliderWidget.gb';
import ColorSlider from '@arcgis/core/widgets/smartMapping/ColorSlider';

export default class ColorSliderWidgetWrapper extends ColorSliderWidgetGenerated {

    constructor(widget: ColorSlider) {
        super(widget);
    }
    
}

export async function buildJsColorSliderWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorSliderWidgetGenerated } = await import('./colorSliderWidget.gb');
    return await buildJsColorSliderWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorSliderWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetColorSliderWidgetGenerated } = await import('./colorSliderWidget.gb');
    return await buildDotNetColorSliderWidgetGenerated(jsObject, layerId, viewId);
}
