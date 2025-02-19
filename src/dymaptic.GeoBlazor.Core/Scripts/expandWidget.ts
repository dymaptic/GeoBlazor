// override generated code in this file
import ExpandWidgetGenerated from './expandWidget.gb';
import Expand from '@arcgis/core/widgets/Expand';

export default class ExpandWidgetWrapper extends ExpandWidgetGenerated {

    constructor(widget: Expand) {
        super(widget);
    }
    
}

export async function buildJsExpandWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsExpandWidgetGenerated } = await import('./expandWidget.gb');
    return await buildJsExpandWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetExpandWidget(jsObject: any): Promise<any> {
    let { buildDotNetExpandWidgetGenerated } = await import('./expandWidget.gb');
    return await buildDotNetExpandWidgetGenerated(jsObject);
}
