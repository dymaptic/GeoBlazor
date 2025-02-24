// override generated code in this file
import LocateWidgetGenerated from './locateWidget.gb';
import Locate from '@arcgis/core/widgets/Locate';

export default class LocateWidgetWrapper extends LocateWidgetGenerated {

    constructor(widget: Locate) {
        super(widget);
    }

}

export async function buildJsLocateWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLocateWidgetGenerated} = await import('./locateWidget.gb');
    return await buildJsLocateWidgetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLocateWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetLocateWidgetGenerated} = await import('./locateWidget.gb');
    return await buildDotNetLocateWidgetGenerated(jsObject, layerId, viewId);
}
