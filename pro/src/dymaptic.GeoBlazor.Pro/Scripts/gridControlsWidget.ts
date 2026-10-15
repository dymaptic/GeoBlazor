// override generated code in this file
import GridControlsWidgetGenerated from './gridControlsWidget.gb';
import GridControls from '@arcgis/core/widgets/support/GridControls';

export default class GridControlsWidgetWrapper extends GridControlsWidgetGenerated {

    constructor(widget: GridControls) {
        super(widget);
    }
    
}

export async function buildJsGridControlsWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGridControlsWidgetGenerated } = await import('./gridControlsWidget.gb');
    return await buildJsGridControlsWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGridControlsWidget(jsObject: any): Promise<any> {
    let { buildDotNetGridControlsWidgetGenerated } = await import('./gridControlsWidget.gb');
    return await buildDotNetGridControlsWidgetGenerated(jsObject);
}
