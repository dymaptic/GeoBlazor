// override generated code in this file
import ISmartMappingSliderBaseWidgetGenerated from './iSmartMappingSliderBaseWidget.gb';
import SmartMappingSliderBase = __esri.SmartMappingSliderBase;

export default class ISmartMappingSliderBaseWidgetWrapper extends ISmartMappingSliderBaseWidgetGenerated {

    constructor(widget: SmartMappingSliderBase) {
        super(widget);
    }

}

export async function buildJsISmartMappingSliderBaseWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsISmartMappingSliderBaseWidgetGenerated} = await import('./iSmartMappingSliderBaseWidget.gb');
    return await buildJsISmartMappingSliderBaseWidgetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetISmartMappingSliderBaseWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetISmartMappingSliderBaseWidgetGenerated} = await import('./iSmartMappingSliderBaseWidget.gb');
    return await buildDotNetISmartMappingSliderBaseWidgetGenerated(jsObject, layerId, viewId);
}
