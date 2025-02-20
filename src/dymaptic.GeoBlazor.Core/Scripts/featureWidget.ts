// override generated code in this file
import FeatureWidgetGenerated from './featureWidget.gb';
import Feature from '@arcgis/core/widgets/Feature';

export default class FeatureWidgetWrapper extends FeatureWidgetGenerated {

    constructor(widget: Feature) {
        super(widget);
    }

}

export async function buildJsFeatureWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFeatureWidgetGenerated} = await import('./featureWidget.gb');
    return await buildJsFeatureWidgetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFeatureWidget(jsObject: any): Promise<any> {
    let {buildDotNetFeatureWidgetGenerated} = await import('./featureWidget.gb');
    return await buildDotNetFeatureWidgetGenerated(jsObject);
}
