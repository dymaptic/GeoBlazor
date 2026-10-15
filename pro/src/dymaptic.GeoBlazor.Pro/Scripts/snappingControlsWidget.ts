// override generated code in this file
import SnappingControlsWidgetGenerated from './snappingControlsWidget.gb';
import SnappingControls from '@arcgis/core/widgets/support/SnappingControls';

export default class SnappingControlsWidgetWrapper extends SnappingControlsWidgetGenerated {

    constructor(widget: SnappingControls) {
        super(widget);
    }
    
}

export async function buildJsSnappingControlsWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSnappingControlsWidgetGenerated } = await import('./snappingControlsWidget.gb');
    return await buildJsSnappingControlsWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSnappingControlsWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSnappingControlsWidgetGenerated } = await import('./snappingControlsWidget.gb');
    return await buildDotNetSnappingControlsWidgetGenerated(jsObject, layerId, viewId);
}
