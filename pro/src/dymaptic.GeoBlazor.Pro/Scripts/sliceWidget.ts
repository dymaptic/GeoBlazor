// override generated code in this file
import SliceWidgetGenerated from './sliceWidget.gb';
import Slice from '@arcgis/core/widgets/Slice';

export default class SliceWidgetWrapper extends SliceWidgetGenerated {

    constructor(widget: Slice) {
        super(widget);
    }
    
}

export async function buildJsSliceWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSliceWidgetGenerated } = await import('./sliceWidget.gb');
    return await buildJsSliceWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSliceWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSliceWidgetGenerated } = await import('./sliceWidget.gb');
    return await buildDotNetSliceWidgetGenerated(jsObject, layerId, viewId);
}
