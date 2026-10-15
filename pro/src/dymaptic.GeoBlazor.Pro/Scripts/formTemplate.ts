import FormTemplate from '@arcgis/core/form/FormTemplate';
import FormTemplateGenerated from './formTemplate.gb';

export async function buildJsFormTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFormTemplateGenerated } = await import('./formTemplate.gb');
    return await buildJsFormTemplateGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFormTemplate(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFormTemplateGenerated } = await import('./formTemplate.gb');
    return await buildDotNetFormTemplateGenerated(jsObject, layerId, viewId);
}

export default class FormTemplateWrapper extends FormTemplateGenerated {

    constructor(component: FormTemplate) {
        super(component);
    }
    
}

