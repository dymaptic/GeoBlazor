// override generated code in this file
import FloorFilterWidgetGenerated from './floorFilterWidget.gb';
import FloorFilter from '@arcgis/core/widgets/FloorFilter';

export default class FloorFilterWidgetWrapper extends FloorFilterWidgetGenerated {

    constructor(widget: FloorFilter) {
        super(widget);
    }
    
}

export async function buildJsFloorFilterWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFloorFilterWidgetGenerated } = await import('./floorFilterWidget.gb');
    return await buildJsFloorFilterWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFloorFilterWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFloorFilterWidgetGenerated } = await import('./floorFilterWidget.gb');
    return await buildDotNetFloorFilterWidgetGenerated(jsObject, layerId, viewId);
}
