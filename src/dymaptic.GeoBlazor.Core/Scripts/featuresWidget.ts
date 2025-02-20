import Features from '@arcgis/core/widgets/Features';
import FeaturesWidgetGenerated from './featuresWidget.gb';

export default class FeaturesWidgetWrapper extends FeaturesWidgetGenerated {

    constructor(widget: Features) {
        super(widget);
    }

}

export async function buildJsFeaturesWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFeaturesWidgetGenerated} = await import('./featuresWidget.gb');
    return await buildJsFeaturesWidgetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFeaturesWidget(jsObject: any): Promise<any> {
    let {buildDotNetFeaturesWidgetGenerated} = await import('./featuresWidget.gb');
    return await buildDotNetFeaturesWidgetGenerated(jsObject);
}
