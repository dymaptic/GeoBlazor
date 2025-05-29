// override generated code in this file
import CompassWidgetGenerated from './compassWidget.gb';
import Compass from '@arcgis/core/widgets/Compass';

export default class CompassWidgetWrapper extends CompassWidgetGenerated {

    constructor(widget: Compass) {
        super(widget);
    }

}

export async function buildJsCompassWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCompassWidgetGenerated} = await import('./compassWidget.gb');
    return await buildJsCompassWidgetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCompassWidget(jsObject: any): Promise<any> {
    let {buildDotNetCompassWidgetGenerated} = await import('./compassWidget.gb');
    return await buildDotNetCompassWidgetGenerated(jsObject);
}
