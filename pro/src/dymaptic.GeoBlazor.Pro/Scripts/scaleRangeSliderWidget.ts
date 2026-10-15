// override generated code in this file
import ScaleRangeSliderWidgetGenerated from './scaleRangeSliderWidget.gb';
import ScaleRangeSlider from '@arcgis/core/widgets/ScaleRangeSlider';

export default class ScaleRangeSliderWidgetWrapper extends ScaleRangeSliderWidgetGenerated {

    constructor(widget: ScaleRangeSlider) {
        super(widget);
    }
    
}

export async function buildJsScaleRangeSliderWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsScaleRangeSliderWidgetGenerated } = await import('./scaleRangeSliderWidget.gb');
    return await buildJsScaleRangeSliderWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetScaleRangeSliderWidget(jsObject: any): Promise<any> {
    let { buildDotNetScaleRangeSliderWidgetGenerated } = await import('./scaleRangeSliderWidget.gb');
    return await buildDotNetScaleRangeSliderWidgetGenerated(jsObject);
}
