// override generated code in this file
import ClassedColorSliderWidgetGenerated from './classedColorSliderWidget.gb';
import ClassedColorSlider from '@arcgis/core/widgets/smartMapping/ClassedColorSlider';

export default class ClassedColorSliderWidgetWrapper extends ClassedColorSliderWidgetGenerated {

    constructor(widget: ClassedColorSlider) {
        super(widget);
    }
    
}

export async function buildJsClassedColorSliderWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClassedColorSliderWidgetGenerated } = await import('./classedColorSliderWidget.gb');
    return await buildJsClassedColorSliderWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetClassedColorSliderWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetClassedColorSliderWidgetGenerated } = await import('./classedColorSliderWidget.gb');
    return await buildDotNetClassedColorSliderWidgetGenerated(jsObject, layerId, viewId);
}
