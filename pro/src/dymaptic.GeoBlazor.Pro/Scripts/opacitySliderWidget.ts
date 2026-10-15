// override generated code in this file
import OpacitySliderWidgetGenerated from './opacitySliderWidget.gb';
import OpacitySlider from '@arcgis/core/widgets/smartMapping/OpacitySlider';

export default class OpacitySliderWidgetWrapper extends OpacitySliderWidgetGenerated {

    constructor(widget: OpacitySlider) {
        super(widget);
    }
    
}

export async function buildJsOpacitySliderWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOpacitySliderWidgetGenerated } = await import('./opacitySliderWidget.gb');
    return await buildJsOpacitySliderWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOpacitySliderWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetOpacitySliderWidgetGenerated } = await import('./opacitySliderWidget.gb');
    return await buildDotNetOpacitySliderWidgetGenerated(jsObject, layerId, viewId);
}
