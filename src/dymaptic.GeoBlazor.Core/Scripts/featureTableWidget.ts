// override generated code in this file
import FeatureTableWidgetGenerated from './featureTableWidget.gb';
import FeatureTable from '@arcgis/core/widgets/FeatureTable';

export default class FeatureTableWidgetWrapper extends FeatureTableWidgetGenerated {

    constructor(widget: FeatureTable) {
        super(widget);
    }

}

export async function buildJsFeatureTableWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFeatureTableWidgetGenerated} = await import('./featureTableWidget.gb');
    return await buildJsFeatureTableWidgetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFeatureTableWidget(jsObject: any): Promise<any> {
    let {buildDotNetFeatureTableWidgetGenerated} = await import('./featureTableWidget.gb');
    return await buildDotNetFeatureTableWidgetGenerated(jsObject);
}
