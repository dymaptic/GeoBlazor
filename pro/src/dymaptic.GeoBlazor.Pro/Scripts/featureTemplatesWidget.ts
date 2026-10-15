import FeatureTemplates from '@arcgis/core/widgets/FeatureTemplates';
import FeatureTemplatesWidgetGenerated from './featureTemplatesWidget.gb';
import {arcGisObjectRefs, hasValue} from './geoBlazorCore';
import TemplateItem from "@arcgis/core/widgets/FeatureTemplates/TemplateItem";

export default class FeatureTemplatesWidgetWrapper extends FeatureTemplatesWidgetGenerated {

    constructor(widget: FeatureTemplates) {
        super(widget);
    }

    async select(item) {
        let { buildJsFeatureTemplate } = await import('./featureTemplate');
        let templateItem = {
            description: item.description,
            label: item.label,
            layer: arcGisObjectRefs[item.layer.id],
            template: await buildJsFeatureTemplate(item.template),
            thumbnail: item.thumbnail
        } as TemplateItem;
        this.widget.select(templateItem);
    }
}
export async function buildJsFeatureTemplatesWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureTemplatesWidgetGenerated } = await import('./featureTemplatesWidget.gb');
    let jsObject = await buildJsFeatureTemplatesWidgetGenerated(dotNetObject, layerId, viewId);
    
    if (hasValue(dotNetObject.layerIds) && dotNetObject.layerIds.length > 0) {
        let layers: any = [];
        for (let i = 0; i < dotNetObject.layerIds.length; i++) {
            let layerId = dotNetObject.layerIds[i];
            let layer = arcGisObjectRefs[layerId];
            if (hasValue(layer)) {
                layers.push(layer);
            }
        }
        
        jsObject.layers = layers;
    }
    
    return jsObject;
}

export async function buildDotNetFeatureTemplatesWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureTemplatesWidgetGenerated } = await import('./featureTemplatesWidget.gb');
    return await buildDotNetFeatureTemplatesWidgetGenerated(jsObject, layerId, viewId);
}
