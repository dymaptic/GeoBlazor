// override generated code in this file
import AttributionWidgetGenerated from './attributionWidget.gb';
import Attribution from '@arcgis/core/widgets/Attribution';

export default class AttributionWidgetWrapper extends AttributionWidgetGenerated {

    constructor(widget: Attribution) {
        super(widget);
    }
    
}

export async function buildJsAttributionWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttributionWidgetGenerated } = await import('./attributionWidget.gb');
    return await buildJsAttributionWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttributionWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetAttributionWidgetGenerated } = await import('./attributionWidget.gb');
    return await buildDotNetAttributionWidgetGenerated(jsObject, layerId, viewId);
}
