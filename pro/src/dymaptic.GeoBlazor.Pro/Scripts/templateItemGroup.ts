import TemplateItemGroup from '@arcgis/core/widgets/FeatureTemplates/TemplateItemGroup';
import TemplateItemGroupGenerated from './templateItemGroup.gb';

export async function buildJsTemplateItemGroup(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTemplateItemGroupGenerated } = await import('./templateItemGroup.gb');
    return await buildJsTemplateItemGroupGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTemplateItemGroup(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTemplateItemGroupGenerated } = await import('./templateItemGroup.gb');
    return await buildDotNetTemplateItemGroupGenerated(jsObject, layerId, viewId);
}

export default class TemplateItemGroupWrapper extends TemplateItemGroupGenerated {

    constructor(component: TemplateItemGroup) {
        super(component);
    }
    
}

