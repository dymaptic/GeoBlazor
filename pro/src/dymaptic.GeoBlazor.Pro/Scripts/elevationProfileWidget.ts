// override generated code in this file
import ElevationProfileWidgetGenerated from './elevationProfileWidget.gb';
import ElevationProfile from '@arcgis/core/widgets/ElevationProfile';

export default class ElevationProfileWidgetWrapper extends ElevationProfileWidgetGenerated {

    constructor(widget: ElevationProfile) {
        super(widget);
    }
    
}

export async function buildJsElevationProfileWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsElevationProfileWidgetGenerated } = await import('./elevationProfileWidget.gb');
    return await buildJsElevationProfileWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetElevationProfileWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetElevationProfileWidgetGenerated } = await import('./elevationProfileWidget.gb');
    return await buildDotNetElevationProfileWidgetGenerated(jsObject, layerId, viewId);
}
