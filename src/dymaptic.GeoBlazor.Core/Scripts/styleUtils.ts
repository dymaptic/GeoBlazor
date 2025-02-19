// override generated code in this file
import StyleUtilsGenerated from './styleUtils.gb';
import styleUtils = __esri.styleUtils;

export default class StyleUtilsWrapper extends StyleUtilsGenerated {

    constructor(component: styleUtils) {
        super(component);
    }
    
}

export async function buildJsStyleUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsStyleUtilsGenerated } = await import('./styleUtils.gb');
    return await buildJsStyleUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetStyleUtils(jsObject: any): Promise<any> {
    let { buildDotNetStyleUtilsGenerated } = await import('./styleUtils.gb');
    return await buildDotNetStyleUtilsGenerated(jsObject);
}
