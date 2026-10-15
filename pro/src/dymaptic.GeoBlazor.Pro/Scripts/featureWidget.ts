// override generated code in this file
import FeatureWidgetGenerated from './featureWidget.gb';
import Feature from '@arcgis/core/widgets/Feature';

export default class FeatureWidgetWrapper extends FeatureWidgetGenerated {

    constructor(widget: Feature) {
        super(widget);
    }

    async setSpatialReference(spatialReference: any): Promise<void> {
        let {buildJsSpatialReference} = await import('./spatialReference');
        this.widget.spatialReference = buildJsSpatialReference(spatialReference) as any;
    }
}

export async function buildJsFeatureWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureWidgetGenerated } = await import('./featureWidget.gb');
    return await buildJsFeatureWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureWidgetGenerated } = await import('./featureWidget.gb');
    return await buildDotNetFeatureWidgetGenerated(jsObject, layerId, viewId);
}
