// override generated code in this file
import Collection from '@arcgis/core/core/Collection';
import FeatureTableWidgetGenerated from './featureTableWidget.gb';
import { ArcgisFeatureTable } from '@arcgis/map-components/dist/components/arcgis-feature-table';
import { hasValue } from './geoBlazorCore';

export default class FeatureTableWidgetWrapper extends FeatureTableWidgetGenerated {

    constructor(widget: ArcgisFeatureTable) {
        super(widget);
    }
}

export async function buildJsFeatureTableWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureTableWidgetGenerated } = await import('./featureTableWidget.gb');
    let jsFeatureTable = await buildJsFeatureTableWidgetGenerated(dotNetObject, layerId, viewId);

    if (!hasValue(jsFeatureTable.layer)
        && jsFeatureTable.layers instanceof Collection
        && jsFeatureTable.layers.length > 0) {
        jsFeatureTable.layer = jsFeatureTable.layers.getItemAt(0);
    }
    
    return jsFeatureTable;
}

export async function buildDotNetFeatureTableWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureTableWidgetGenerated } = await import('./featureTableWidget.gb');
    return await buildDotNetFeatureTableWidgetGenerated(jsObject, layerId, viewId);
}