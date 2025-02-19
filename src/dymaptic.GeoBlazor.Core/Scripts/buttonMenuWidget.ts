import ButtonMenu from '@arcgis/core/widgets/FeatureTable/Grid/support/ButtonMenu';
import ButtonMenuWidgetGenerated from './buttonMenuWidget.gb';

export default class ButtonMenuWidgetWrapper extends ButtonMenuWidgetGenerated {

    constructor(widget: ButtonMenu) {
        super(widget);
    }
    
}

export async function buildJsButtonMenuWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsButtonMenuWidgetGenerated } = await import('./buttonMenuWidget.gb');
    return await buildJsButtonMenuWidgetGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetButtonMenuWidget(jsObject: any): Promise<any> {
    let { buildDotNetButtonMenuWidgetGenerated } = await import('./buttonMenuWidget.gb');
    return await buildDotNetButtonMenuWidgetGenerated(jsObject);
}
