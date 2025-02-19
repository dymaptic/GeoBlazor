import BasemapToggle from '@arcgis/core/widgets/BasemapToggle';
import BasemapToggleWidgetGenerated from './basemapToggleWidget.gb';

export default class BasemapToggleWidgetWrapper extends BasemapToggleWidgetGenerated {

    constructor(widget: BasemapToggle) {
        super(widget);
    }
    
}

export async function buildJsBasemapToggleWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBasemapToggleWidgetGenerated } = await import('./basemapToggleWidget.gb');
    return await buildJsBasemapToggleWidgetGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetBasemapToggleWidget(jsObject: any): Promise<any> {
    let { buildDotNetBasemapToggleWidgetGenerated } = await import('./basemapToggleWidget.gb');
    return await buildDotNetBasemapToggleWidgetGenerated(jsObject);
}
