// override generated code in this file
import SizeSliderWidgetGenerated from './sizeSliderWidget.gb';
import SizeSlider from '@arcgis/core/widgets/smartMapping/SizeSlider';

export default class SizeSliderWidgetWrapper extends SizeSliderWidgetGenerated {

    constructor(widget: SizeSlider) {
        super(widget);
    }
    
}

export async function buildJsSizeSliderWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSizeSliderWidgetGenerated } = await import('./sizeSliderWidget.gb');
    return await buildJsSizeSliderWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSizeSliderWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSizeSliderWidgetGenerated } = await import('./sizeSliderWidget.gb');
    return await buildDotNetSizeSliderWidgetGenerated(jsObject, layerId, viewId);
}
