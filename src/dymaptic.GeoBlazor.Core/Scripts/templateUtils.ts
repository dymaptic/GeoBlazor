// override generated code in this file
import TemplateUtilsGenerated from './templateUtils.gb';
import templateUtils = __esri.templateUtils;

export default class TemplateUtilsWrapper extends TemplateUtilsGenerated {

    constructor(component: templateUtils) {
        super(component);
    }
    
}

export async function buildJsTemplateUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTemplateUtilsGenerated } = await import('./templateUtils.gb');
    return await buildJsTemplateUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTemplateUtils(jsObject: any): Promise<any> {
    let { buildDotNetTemplateUtilsGenerated } = await import('./templateUtils.gb');
    return await buildDotNetTemplateUtilsGenerated(jsObject);
}
