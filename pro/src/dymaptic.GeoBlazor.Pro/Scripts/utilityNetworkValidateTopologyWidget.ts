// override generated code in this file
import UtilityNetworkValidateTopologyWidgetGenerated from './utilityNetworkValidateTopologyWidget.gb';
import UtilityNetworkValidateTopology from '@arcgis/core/widgets/UtilityNetworkValidateTopology';

export default class UtilityNetworkValidateTopologyWidgetWrapper extends UtilityNetworkValidateTopologyWidgetGenerated {

    constructor(widget: UtilityNetworkValidateTopology) {
        super(widget);
    }
    
}

export async function buildJsUtilityNetworkValidateTopologyWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUtilityNetworkValidateTopologyWidgetGenerated } = await import('./utilityNetworkValidateTopologyWidget.gb');
    return await buildJsUtilityNetworkValidateTopologyWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUtilityNetworkValidateTopologyWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetUtilityNetworkValidateTopologyWidgetGenerated } = await import('./utilityNetworkValidateTopologyWidget.gb');
    return await buildDotNetUtilityNetworkValidateTopologyWidgetGenerated(jsObject, layerId, viewId);
}
