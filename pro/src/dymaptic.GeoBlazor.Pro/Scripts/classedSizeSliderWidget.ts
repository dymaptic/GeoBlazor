// override generated code in this file
import ClassedSizeSliderWidgetGenerated from './classedSizeSliderWidget.gb';
import ClassedSizeSlider from '@arcgis/core/widgets/smartMapping/ClassedSizeSlider';

export default class ClassedSizeSliderWidgetWrapper extends ClassedSizeSliderWidgetGenerated {

    constructor(widget: ClassedSizeSlider) {
        super(widget);
    }
    
}

export async function buildJsClassedSizeSliderWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClassedSizeSliderWidgetGenerated } = await import('./classedSizeSliderWidget.gb');
    return await buildJsClassedSizeSliderWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetClassedSizeSliderWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetClassedSizeSliderWidgetGenerated } = await import('./classedSizeSliderWidget.gb');
    return await buildDotNetClassedSizeSliderWidgetGenerated(jsObject, layerId, viewId);
}
