// override generated code in this file
import LegendWidgetGenerated from './legendWidget.gb';
import Legend from '@arcgis/core/widgets/Legend';

export default class LegendWidgetWrapper extends LegendWidgetGenerated {

    constructor(widget: Legend) {
        super(widget);
    }
    
}

export async function buildJsLegendWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLegendWidgetGenerated } = await import('./legendWidget.gb');
    return await buildJsLegendWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLegendWidget(jsObject: any): Promise<any> {
    let { buildDotNetLegendWidgetGenerated } = await import('./legendWidget.gb');
    return await buildDotNetLegendWidgetGenerated(jsObject);
}
