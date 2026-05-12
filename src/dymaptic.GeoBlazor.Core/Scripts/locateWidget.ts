// override generated code in this file
import LocateWidgetGenerated from './locateWidget.gb';
import Locate from '@arcgis/core/widgets/Locate';
import {hasValue, lookupGeoBlazorId} from './geoBlazorCore';
import { ArcgisLocate } from '@arcgis/map-components/dist/components/arcgis-locate';

export default class LocateWidgetWrapper extends LocateWidgetGenerated {

    constructor(widget: ArcgisLocate) {
        super(widget);
    }

}

export async function buildJsLocateWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLocateWidgetGenerated} = await import('./locateWidget.gb');
    return await buildJsLocateWidgetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLocateWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetLocateWidgetGenerated } = await import('./locateWidget.gb');
    return await buildDotNetLocateWidgetGenerated(jsObject, layerId, viewId);
}
