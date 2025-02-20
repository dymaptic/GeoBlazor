// override generated code in this file
import ColorUtilsGenerated from './colorUtils.gb';
import colorUtils = __esri.colorUtils;

export default class ColorUtilsWrapper extends ColorUtilsGenerated {

    constructor(component: colorUtils) {
        super(component);
    }

}

export async function buildJsColorUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColorUtilsGenerated} = await import('./colorUtils.gb');
    return await buildJsColorUtilsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColorUtils(jsObject: any): Promise<any> {
    let {buildDotNetColorUtilsGenerated} = await import('./colorUtils.gb');
    return await buildDotNetColorUtilsGenerated(jsObject);
}
