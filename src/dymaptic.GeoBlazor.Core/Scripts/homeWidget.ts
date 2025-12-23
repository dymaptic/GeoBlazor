// override generated code in this file
import HomeWidgetGenerated from './homeWidget.gb';
import Home from '@arcgis/core/widgets/Home';

export default class HomeWidgetWrapper extends HomeWidgetGenerated {

    constructor(widget: Home) {
        super(widget);
    }

}

export async function buildJsHomeWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsHomeWidgetGenerated} = await import('./homeWidget.gb');
    return await buildJsHomeWidgetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetHomeWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetHomeWidgetGenerated} = await import('./homeWidget.gb');
    return await buildDotNetHomeWidgetGenerated(jsObject, layerId, viewId);
}
