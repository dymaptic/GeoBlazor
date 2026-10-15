// override generated code in this file
import UtilityNetworkAssociationsWidgetGenerated from './utilityNetworkAssociationsWidget.gb';
import UtilityNetworkAssociations from '@arcgis/core/widgets/UtilityNetworkAssociations';

export default class UtilityNetworkAssociationsWidgetWrapper extends UtilityNetworkAssociationsWidgetGenerated {

    constructor(widget: UtilityNetworkAssociations) {
        super(widget);
    }
    
}

export async function buildJsUtilityNetworkAssociationsWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUtilityNetworkAssociationsWidgetGenerated } = await import('./utilityNetworkAssociationsWidget.gb');
    return await buildJsUtilityNetworkAssociationsWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUtilityNetworkAssociationsWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetUtilityNetworkAssociationsWidgetGenerated } = await import('./utilityNetworkAssociationsWidget.gb');
    return await buildDotNetUtilityNetworkAssociationsWidgetGenerated(jsObject, layerId, viewId);
}
