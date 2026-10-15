// override generated code in this file
import BinaryColorSizeSliderWidgetGenerated from './binaryColorSizeSliderWidget.gb';
import BinaryColorSizeSlider from '@arcgis/core/widgets/smartMapping/BinaryColorSizeSlider';

export default class BinaryColorSizeSliderWidgetWrapper extends BinaryColorSizeSliderWidgetGenerated {

    constructor(widget: BinaryColorSizeSlider) {
        super(widget);
    }
    
}

export async function buildJsBinaryColorSizeSliderWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBinaryColorSizeSliderWidgetGenerated } = await import('./binaryColorSizeSliderWidget.gb');
    return await buildJsBinaryColorSizeSliderWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBinaryColorSizeSliderWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetBinaryColorSizeSliderWidgetGenerated } = await import('./binaryColorSizeSliderWidget.gb');
    return await buildDotNetBinaryColorSizeSliderWidgetGenerated(jsObject, layerId, viewId);
}
