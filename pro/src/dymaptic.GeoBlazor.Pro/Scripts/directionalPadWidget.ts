// override generated code in this file
import DirectionalPadWidgetGenerated from './directionalPadWidget.gb';
import DirectionalPad from '@arcgis/core/widgets/DirectionalPad';

export default class DirectionalPadWidgetWrapper extends DirectionalPadWidgetGenerated {

    constructor(widget: DirectionalPad) {
        super(widget);
    }
    
}

export async function buildJsDirectionalPadWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDirectionalPadWidgetGenerated } = await import('./directionalPadWidget.gb');
    return await buildJsDirectionalPadWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDirectionalPadWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetDirectionalPadWidgetGenerated } = await import('./directionalPadWidget.gb');
    return await buildDotNetDirectionalPadWidgetGenerated(jsObject, layerId, viewId);
}
